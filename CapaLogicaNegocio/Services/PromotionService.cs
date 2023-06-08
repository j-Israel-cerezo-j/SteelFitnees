using CapaEntidades;
using CapaEntidades.DTO;
using CapaLogicaNegocio.Adds;
using CapaLogicaNegocio.Deletes;
using CapaLogicaNegocio.Exceptions;
using CapaLogicaNegocio.MessageErrors;
using CapaLogicaNegocio.Tables;
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
                    fkBranche = Convert.ToInt32(promotionDTO.branche),
                    check = Convert.ToBoolean(promotionDTO.check),
                    img = request.Files[$"img{i}"]

                };
                i++;
                promotions.Add(promotion);
            });

            var fileNamesTem = new List<string>();
            var idsPromotionsTem = new List<int>();
            try
            {
                promotions.ForEach(promotion => {
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
