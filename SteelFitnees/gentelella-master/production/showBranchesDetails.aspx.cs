using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

using CapaLogicaNegocio;
using CapaEntidades;
using CapaLogicaNegocio.Services;
using CapaLogicaNegocio.Exceptions;

namespace SteelFitnees.gentelella_master.production
{
    public partial class showBranchesDetails : System.Web.UI.Page
    {
        private BrancheSerevice brancheSerevice=new BrancheSerevice();
        public Branche getBranche { get; private  set; }
        public List<Image> getListImagesById{ get; private set; }
        public List<Day> getListDays { get; private set; }
        public int getIdBranche { get; set; }
        public bool getErrorBool { get; private set; } = false;
        public string getSchedulesByIdBranche{ get; private set; }
        public string getProductsByIdBranche { get; private set; }
        public string getMessageError{ get; private set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            string stridBranche = Request.QueryString["id"];
            if (stridBranche != "" && stridBranche != null)
            {
                getIdBranche = Convert.ToInt32(stridBranche);
                getBrancheByid();
                getImageById();
                geyDays();
                getProductsById();
                getTableSchedulesByIdBrancheTable();
            }
        }
        private void getBrancheByid()
        {
            try
            {
                string stridBranche = Request.QueryString["id"];
                getBranche = brancheSerevice.getBrancheById(stridBranche);
            }catch(ServiceException se)
            {
                getErrorBool = true;
                getMessageError=se.getMessage();
            }

        }
        private void getImageById()
        {
            try
            {
                string stridBranche = Request.QueryString["id"];
                getListImagesById = brancheSerevice.getImageListById(stridBranche);
            }
            catch (ServiceException se)
            {
                getErrorBool = true;
                getMessageError = se.getMessage();
            }
        }
        private void geyDays()
        {
            getListDays=brancheSerevice.getDays();
        }
        private void getTableSchedulesByIdBrancheTable()
        {
            try
            {
                string stridBranche = Request.QueryString["id"];
                getSchedulesByIdBranche = brancheSerevice.jsontableSchedulesByIdBrancheTable(stridBranche);
            }
            catch (ServiceException se)
            {
                getErrorBool = true;
                getMessageError = se.getMessage();
            }
        }
        private void getProductsById()
        {
            try
            {
                string stridBranche = Request.QueryString["id"];
                getProductsByIdBranche = brancheSerevice.getProductsByIdBranche(stridBranche);
            }
            catch (ServiceException se)
            {
                getErrorBool = true;
                getMessageError = se.getMessage();
            }
        }
    }
}