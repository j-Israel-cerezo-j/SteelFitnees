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
            var promotionsRequest = new List<Promotion>();
            promotionsDTO.ForEach(promotionDTO => {
                validateFormantCheck(promotionDTO.check);

                Promotion promotion = new Promotion()
                {
                    id = promotionDTO.id != null ? Convert.ToInt32(promotionDTO.id) : 0,
                    fkBranche = promotionDTO.branches,
                    promotionName =promotionDTO.promotionName,
                    checkk = Convert.ToBoolean(promotionDTO.check),
                    img = request.Files[$"img{i}"]

                };
                i++;
                promotionsRequest.Add(promotion);
            });

            var promotionsBranchDB = branchPromoList.listPromotionsBranch();
            List<int> idPromotionsInPrmotionBranchDB = promotionsBranchDB.Select(promotionB => promotionB.fkPromotion).ToList();
            var fileNamesTem = new List<string>();
            var idsPromotionsTem = new List<int>();
            
            try
            {
                promotionsRequest.ForEach(promotionRequest => {
                    if (promotionRequest.id==0)
                    {
                        Images.validWrongSizeInImageName(new List<HttpPostedFile>() { promotionRequest.img });
                        promotionRequest.fileName = rd.Next(1, 100000000).ToString() + promotionRequest.img.FileName;
                        string path = Images.Save(promotionRequest.img, "promotions", promotionRequest.fileName);
                        promotionRequest.path = path;
                        fileNamesTem.Add(promotionRequest.fileName);
                        var idPromotionInser = promotionAdd.addPromotion(promotionRequest);
                        idsPromotionsTem.Add(idPromotionInser);
                        if (promotionRequest.fkBranche != null)
                        {
                            foreach (var idBrancheItem in promotionRequest.fkBranche)
                            {
                                promotionAdd.addPromotionBranch(Convert.ToInt32(idBrancheItem), idPromotionInser);
                            }
                        }
                    }
                    else
                    {
                        promotionUpdate.update(promotionRequest.id, Convert.ToBoolean(promotionRequest.checkk));
                        promotionDelete.promotionBrachByidPromotionDelete(promotionRequest.id);

                        foreach (var idBrancheitem in promotionRequest.fkBranche)
                        {
                            promotionAdd.addPromotionBranch(Convert.ToInt32(idBrancheitem), promotionRequest.id);
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

        public string promotionsSearching(string strValue)
        {
            return Converter.ToJson(promotionTable.listAllPromotionsByCharacteres(strValue)).ToString();
        }

        public string promotionsByVisibilityOrBranchOrNone(string strId,string visibilityStr)
        {
            if (strId == null && visibilityStr == null)
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }
            else if (strId == null&& visibilityStr!= null)
            {
                return Converter.ToJson(promotionTable.tableAllVisibility(Convert.ToInt32(visibilityStr))).ToString();
            }
            if (visibilityStr!= null && strId != null)
            {
                return Converter.ToJson(promotionTable.tableVisivilityByBranche(Convert.ToInt32(strId), Convert.ToInt32(visibilityStr))).ToString();
            }
            else
            {
                return Converter.ToJson(promotionTable.tableByBranche(Convert.ToInt32(strId))).ToString();
            }
        }
        public string promotionsNoBranch()
        {
            return Converter.ToJson(promotionTable.tableNoBranche()).ToString();
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
        public List<int> idBrancheByPromotion(string idStr)
        {
            
            if (idStr == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }else if (idStr== "undefined")
            {
                return null;
            }
            try
            {
                return promotionRD.idBrancheByPromotion(Convert.ToInt32(idStr));
            }
            catch (ExceptionDao ed)
            {
                return null;
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
