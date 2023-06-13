using CapaDatos.ExceptionDao;
using CapaEntidades;
using CapaEntidades.DTO;
using CapaLogicaNegocio.Adds;
using CapaLogicaNegocio.Deletes;
using CapaLogicaNegocio.Exceptions;
using CapaLogicaNegocio.Lists;
using CapaLogicaNegocio.MessageErrors;
using CapaLogicaNegocio.RecoverData;
using CapaLogicaNegocio.Selects;
using CapaLogicaNegocio.Tables;
using CapaLogicaNegocio.Updates;
using CapaLogicaNegocio.utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Validaciones.utils;

namespace CapaLogicaNegocio.Services
{
    public class PromotionService
    {
        private PromotionAdd promotionAdd = new PromotionAdd();
        private PromotionDelete promotionDelete = new PromotionDelete();
        private PromotionTable promotionTable = new PromotionTable();
        private PromotionUpdate promotionUpdate = new PromotionUpdate();
        private PromotionBranchList branchPromoList = new PromotionBranchList();
        private PromotionRD promotionRD = new PromotionRD();
        private Random rd = new Random();
        public string add(HttpRequest request)
        {
            var formData = request.Form["data"];
            var promotionsDTO = JsonConvert.DeserializeObject<List<PromotionDTO>>(formData);
            int i = 0;
            var promotions = new List<Promotion>();
            promotionsDTO.ForEach(promotionDTO => {

                validateFormantBranch(promotionDTO.branche);
                validateFormantCheck(promotionDTO.check);

                Promotion promotion = new Promotion()
                {             
                    id= promotionDTO.id!=null?Convert.ToInt32(promotionDTO.id): 0,
                    fkBranche = Convert.ToInt32(promotionDTO.branche),
                    checkk = Convert.ToBoolean(promotionDTO.check),
                    img = request.Files[$"img{i}"]

                };
                i++;
                promotions.Add(promotion);
            });

            var promotionsBranch = branchPromoList.listPromotionsBranch();
            List<int> idPromotionsInPrmotionBranch = promotionsBranch.Select(promotionB => promotionB.fkPromotion).ToList();
            var fileNamesTem = new List<string>();
            var idsPromotionsTem = new List<int>();
            
            try
            {
                promotions.ForEach(promotion => {
                    if (promotion.id==0)
                    {
                        Images.validWrongSizeInImageName(new List<HttpPostedFile>() { promotion.img });
                        promotion.fileName = rd.Next(1, 100000000).ToString() + promotion.img.FileName;
                        string path = Images.Save(promotion.img, "promotions", promotion.fileName);
                        promotion.path = path;
                        fileNamesTem.Add(promotion.fileName);
                        var idPromotionInser = promotionAdd.addPromotion(promotion);
                        idsPromotionsTem.Add(idPromotionInser);
                        if (promotion.fkBranche != -1)
                        {
                            promotionAdd.addPromotionBranch(promotion.fkBranche, idPromotionInser);
                        }
                    }
                    else
                    {
                        promotionUpdate.update(promotion.id, Convert.ToBoolean(promotion.checkk));
                        if (promotion.fkBranche==-1)
                        {
                            if (idPromotionsInPrmotionBranch.Contains(promotion.id))
                            {
                                promotionDelete.promotionBrachByidPromotionDelete(promotion.id);
                            }                            
                        }
                        else
                        {
                            if (idPromotionsInPrmotionBranch.Contains(promotion.id))
                            {
                                promotionUpdate.updateBrancheInPromotionBranchByPromotion(promotion.id, promotion.fkBranche);
                            }
                            else
                            {
                                promotionAdd.addPromotionBranch(promotion.fkBranche, promotion.id);
                            }
                        }
                    }
                });
            }
            catch (ServiceException se)
            {
                rollbackImg(fileNamesTem);
                rollbackPromotions(idsPromotionsTem);
                throw new ServiceException(se.getMessage());
            }
            catch (Exception e)
            {
                rollbackImg(fileNamesTem);
                rollbackPromotions(idsPromotionsTem);
                throw new ServiceException("Error al guardar la promoción");
            }

            return Converter.ToJson(promotionTable.table()).ToString();
        }
        public string jsonPromotions()
        {
            return Converter.ToJson(promotionTable.table()).ToString();
        }
        public string delete(HttpRequest request)
        {
            var strIdsPromotionsRequest = request.Form["idsToDelete"];
            if (strIdsPromotionsRequest == "")
            {
                throw new ServiceException("Seleccione una casilla a eliminar por favor");
            }
            var promotions = branchPromoList.listPromotions();
            var idsPromotions=promotions.Select(x => x.id).ToList();
            var promotionsBranchExisting = branchPromoList.listPromotionsBranch();
            var idsExistingPromotionBranch = promotionsBranchExisting.Select(item => item.fkPromotion).ToList();
            var idsListPromotionsRequest = Converter.ToList(strIdsPromotionsRequest);
            idsListPromotionsRequest.ForEach(idPromotionRequestStr => {
                var idPromotionR=Convert.ToInt32(idPromotionRequestStr);
                if (idsExistingPromotionBranch.Contains(Convert.ToInt32(idPromotionR)))
                {
                    promotionDelete.promotionBrachByidPromotionDelete(Convert.ToInt32(idPromotionR));
                }

                if (idsPromotions.Contains(idPromotionR))
                {
                    var promotion = promotions.Find(pro => { return pro.id == idPromotionR; });
                    Images.Delete("promotions", promotion.fileName);
                }
            });

            promotionDelete.delete(strIdsPromotionsRequest);
            return Converter.ToJson(promotionTable.table()).ToString();
        }
        public int idBrancheByPromotion(string idStr)
        {
            
            if (idStr == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }else if (idStr== "undefined")
            {
                return 0;
            }
            try
            {
                return promotionRD.idBrancheByPromotion(Convert.ToInt32(idStr));
            }
            catch (ExceptionDao ed)
            {
                return 0;
            }
        }

        private void rollbackImg(List<string> fileNames)
        {
            fileNames.ForEach(fileName => {
                Images.Delete("promotions",fileName);
            });            
        }

        private void rollbackPromotions(List<int> idsPromotions)
        {
            if (idsPromotions.Count() > 0) {
                var idsStr = Converter.ToString(idsPromotions);
                promotionDelete.delete(idsStr.ToString());
            }            
        }
        private void validateFormantBranch(string fkBranche)
        {
            if (!Validation.SelectFormant(fkBranche))
            {
                throw new ServiceException(MessageErrors.MessageErrors.invalidSelectorIn("sucursales"));
            }
        }
        private void validateFormantCheck(string check)
        {
            if (!Validation.FormantCheck(check))
            {
                throw new ServiceException(MessageErrors.MessageErrors.formantIncorrectCheck);
            }
        }
    }
}
