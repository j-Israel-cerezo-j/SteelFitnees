﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using Validaciones.utils;
using CapaLogicaNegocio.utils;
using CapaLogicaNegocio.Exceptions;
using CapaLogicaNegocio.Adds;
using CapaLogicaNegocio.MessageErrors;
using CapaLogicaNegocio.Lists;
using CapaLogicaNegocio.Deletes;
using CapaLogicaNegocio.RecoverData;
using CapaLogicaNegocio.Updates;
using CapaLogicaNegocio.Tables;
using CapaLogicaNegocio.Selects;
using System.Web;
using System.IO;
using CapaLogicaNegocio.Inserts;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace CapaLogicaNegocio.Services
{
    public class BrancheSerevice
    {
        private BrancheAdd brancheAdd = new BrancheAdd();
        private BrancheList brancheList = new BrancheList();
        private BrancheDelete brancheDelete = new BrancheDelete();
        private BrancheRData brancherData = new BrancheRData();
        private BrancheUpdate brancheUpdate = new BrancheUpdate();
        private ImageList imageList = new ImageList();
        private Delete delete = new Delete();
        private Random rd = new Random();
        private DayList dayList = new DayList();    
        private BranchesTable branchesTable=new BranchesTable();
        private SchedulesTable schedulesTable = new SchedulesTable();   
        private ProductTable productTable=new ProductTable();
        public bool add(Dictionary<string, string> request, List<HttpPostedFile> filesList)
        {
            if (filesList.Count == 0)
                throw new ServiceException(MessageErrors.MessageErrors.uploadPicturesPlease);

            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(request);            
            if (camposEmptysOrNull.Count == 0)
            {
                var fileNamesTem=new List<string>();
                Images.validWrongSizeInImageName(filesList);
                Images.validateThatTheNameOfTheImageDoesNotHaveCommas(filesList);
                Branche branche = new Branche();
                branche.nombre = RetrieveAtributes.values(request, "nombre");
                branche.descripcion = RetrieveAtributes.values(request, "description");
                branche.ubicacion = RetrieveAtributes.values(request, "ubicacion");
                int idBranceAdd=brancheAdd.add(branche);
                if (idBranceAdd == 0)
                    throw new ServiceException(MessageErrors.MessageErrors.errorAddingToBranch);

                try
                {
                    foreach (var file in filesList)
                    {
                        string fileName = rd.Next(1, 100000000).ToString() + file.FileName;
                        fileNamesTem.Add(fileName);
                        string path = Images.Save(file, "branchTem", fileName);
                        string strUnionsFiel = "('" + fileName + "','" + path + "'," + idBranceAdd + ")";
                        Insert.Many(strUnionsFiel, "images");
                    }
                    ban = true;
                }
                catch(ServiceException se)
                {
                    rollbackSavedImages(fileNamesTem);
                    fileNamesTem = null;
                    rollBackBranche(idBranceAdd.ToString());
                    throw new ServiceException(se.getMessage());
                }
                catch (Exception ex)
                {
                    rollbackSavedImages(fileNamesTem);
                    fileNamesTem = null;
                    rollBackBranche(idBranceAdd.ToString());
                    throw new ServiceException(MessageErrors.MessageErrors.errorAddingImage);
                }
            }
            else
            {
                foreach (var item in camposEmptysOrNull)
                {
                    if (item.Value)
                    {                        
                        throw new ServiceException(item.Key + " esta vacío");
                    }
                }
            }
            return ban;
        }      
        public bool update(Dictionary<string, string> request,string strId, List<HttpPostedFile> filesList)
        {
            var arrayPathImg = Converter.ToList(RetrieveAtributes.values(request, "arrayParhImgs"));
            if (filesList.Count == 0 && arrayPathImg[0].ToString() == "")
                throw new ServiceException(MessageErrors.MessageErrors.uploadPicturesPlease);

            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(request);
            if (camposEmptysOrNull.Count == 0)
            {
                var fileNamesTem = new List<string>();
                Images.validWrongSizeInImageName(filesList);
                Images.validateThatTheNameOfTheImageDoesNotHaveCommas(filesList);
                bool status =Convert.ToBoolean( RetrieveAtributes.values(request, "statusImajes"));
                Branche branche = new Branche();
                branche.idSucursal = Convert.ToInt32(strId);
                branche.nombre = RetrieveAtributes.values(request, "nombre");
                branche.descripcion = RetrieveAtributes.values(request, "description");
                branche.ubicacion = RetrieveAtributes.values(request, "ubicacion");

                var imagesDBByBranche = imageList.listImagesByIdBranche(branche.idSucursal);
                if (status)
                {
                    try
                    {
                        string queryPathImg = queryPathImag(arrayPathImg);
                        delete.deletWhereNot("images", "fkSucursal", "path", branche.idSucursal.ToString(), queryPathImg);
                        foreach (var file in filesList)
                        {                           
                            string fileName = rd.Next(1, 100000000).ToString() + file.FileName;
                            fileNamesTem.Add(fileName);
                            string path = Images.Save(file, "branchTem", fileName);
                            string strUnionsFiel = "('" + fileName + "','" + path + "'," + branche.idSucursal + ")";
                            Insert.Many(strUnionsFiel, "images");
                        }
                        deleteInFilderImage(imagesDBByBranche,arrayPathImg);

                        return true;
                    }
                    catch (ServiceException se)
                    {
                        rollbackSavedImages(fileNamesTem);
                        fileNamesTem = null;
                        rollbackUpdate(branche.idSucursal,imagesDBByBranche);
                        throw new ServiceException(se.getMessage());
                    }
                    catch (Exception e)
                    {
                        rollbackSavedImages(fileNamesTem);
                        fileNamesTem = null;
                        rollbackUpdate(branche.idSucursal, imagesDBByBranche);
                        throw new ServiceException(MessageErrors.MessageErrors.failedToUpdate);
                    }                    
                }               
                return brancheUpdate.update(branche);
            }
            else
            {
                foreach (var item in camposEmptysOrNull)
                {
                    if (item.Value)
                    {
                        throw new ServiceException(item.Key + " esta vacío");
                    }
                }
            }
            return ban;
        }
        public bool deleteBranche(string strIds)
        {
            try
            {
                var idsList = Converter.ToList(strIds);
                foreach (var idItem in idsList)
                {
                    var lisImages = imageList.listImagesByIdBranche(Convert.ToInt32(idItem));
                    foreach (var img in lisImages)
                    {
                        Images.Delete("branchTem", img.nombre);
                    }
                }
                delete.whereIn("images", "fkSucursal", strIds);
                return brancheDelete.delete(strIds);
            }
            catch (ServiceException se)
            {
                throw new ServiceException(se.getMessage());
            }
            catch (Exception e)
            {
                throw new ServiceException(MessageErrors.MessageErrors.errorDeletingBranch);
            }
        }
        public void deleteInFilderImage(List<Image> imagesDB,List<object> pathsImagesNews)
        {
            foreach (var image in imagesDB)
            {
                if (!pathsImagesNews.Contains(image.path))
                {
                    Images.Delete("branchTem", image.nombre);
                }
            }
        }


        private void rollbackUpdate(int idBranch, List<Image> images)
        {
            brancheDelete.deletImagesByIdBranch(idBranch);
            foreach (var image in images)
            {
                string strUnionsFiel = "('" + image.nombre + "','" + image.path + "'," + idBranch.ToString() + ")";
                Insert.Many(strUnionsFiel, "images");
            }
        }
        private void rollbackSavedImages(List<string> fileNames)
        {
            foreach (var name in fileNames)
            {
                Images.Delete("branchTem", name);
            }
        }
        private void rollBackBranche(string strId)
        {
            brancheDelete.delete(strId);
        }
        
        public Branche getBrancheById(string strId)
        {
            if (strId == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }
            return brancherData.dataBrancheByIdBranche(Convert.ToInt32(strId));
        }
        public List<Image> getImageListById(string strId)
        {
            if (strId == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }

            return imageList.listImagesByIdBranche(Convert.ToInt32(strId));
        }
        public List<Day> getDays()
        {
            return dayList.listDays();
        }
        public string getProductsByIdBranche(string strId)
        {
            if (strId == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }
            return Converter.ToJson(productTable.ByIdBranche(Convert.ToInt32(strId))).ToString();
        }

        public bool addCommmentsByBranche(Dictionary<string, string> request, string strId)
        {
            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(request);
            if (camposEmptysOrNull.Count == 0)
            {
                if (strId == "")
                    throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
                CommentBranch commentBranch = new CommentBranch();
                commentBranch.comment = RetrieveAtributes.values(request, "comments");
                commentBranch.commentDate = DateTime.Today;
                commentBranch.fkBranche = Convert.ToInt32(strId);

                return brancheAdd.addComments(commentBranch);
            }
            else
            {
                foreach (var item in camposEmptysOrNull)
                {
                    if (item.Value)
                    {
                        throw new ServiceException(item.Key + " esta vacío");
                    }
                }
            }
            return ban;

        }

        public string jsonImagesByIdBranche(string strId)
        {
            if (strId == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }

            return Converter.ToJson(imageList.listImagesByIdBranche(Convert.ToInt32(strId)));
        }
        public string jsonBranches()
        {
            return Converter.ToJson(brancheList.listBraches());
        }
        public string jsonTableBranches()
        {
            return Converter.ToJson(branchesTable.table(), "idSucursal").ToString();
        }
        public string jsonRecoverData(string strId)
        {
            if (strId == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }
            var branches = new List<Branche>
            {
                brancherData.dataBrancheByIdBranche(Convert.ToInt32(strId))
            };
            return Converter.ToJson(branches);
        }
        public string jsontableSchedulesByIdBrancheTable(string strId)
        {
            if (strId == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }
            var namesTypeDateTime=new List<string>() { "horaInicio", "horaCierre" };
            return Converter.ToJson(schedulesTable.ByIdBranche(Convert.ToInt32(strId)),true, namesTypeDateTime).ToString();
        }
        public string jsonCommentsBranches(string strId)
        {
            if (strId == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }
            return Converter.ToJson(brancheList.listCommentsByIdBrache(Convert.ToInt32(strId)));
        }
        public string jsonCommentsBranchesByWeeksAndId(string strId,string strWeek)
        {
            if (strId == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }            
            if (!Validation.FormantDateFullFormant(strWeek))
            {
                throw new ServiceException(MessageErrors.MessageErrors.formantIncorrectTime);
            }            
            DateTime weekIni=Convert.ToDateTime(strWeek);
            DateTime weekEnd = weekIni.AddDays(7);

            return Converter.ToJson(brancheList.listCommentsByIdBracheAndWeek(Convert.ToInt32(strId),weekIni,weekEnd));
        }

        private string queryPathImag(List<object> arrayPathImg)
        {
            StringBuilder sbPathIm = new StringBuilder();
            sbPathIm.Append("(");
            foreach (var path in arrayPathImg)
            {
                sbPathIm.Append("'" + path + "',");
            }
            sbPathIm.Remove(sbPathIm.Length - 1, 1);
            sbPathIm.Append(")");
            return sbPathIm.ToString();
        }

        public string onkeyupCommentsByIdBranchesAndCharacteres(string strId, string characteres)
        {
            if (characteres!="")
            {
                if (strId == "" || strId == "0")
                {
                    throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
                }
                characteres = "%" + characteres + "%";
                return Converter.ToJson(brancheList.listCommentsByIdBranchesAndCharacteres(Convert.ToInt32(strId), characteres));
            }
            else
            {
               return jsonCommentsBranches(strId);
            }
            
        }
        public List<string> onkeyupSearchList(string caracteres)
        {
            caracteres = "%" + caracteres + "%";
            return Converter.ToList(branchesTable.branchesBranchesByCharactersConicidences(caracteres));

        }
        public string onkeyupSearchTable(string caracteres)
        {            
            return Converter.ToJson(brancheList.listBranchesBranchesByCharactersConicidences(caracteres));

        }
    }
}
