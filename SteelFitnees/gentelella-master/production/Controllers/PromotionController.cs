using CapaLogicaNegocio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SteelFitnees.gentelella_master.production.Controllers
{    
    public class PromotionController : ApiController
    {
        private PromotionService promotionService=new PromotionService();
        [HttpGet]
        [Route("api/promotions/get")]
        public IHttpActionResult getPromotions()
        {
            return Ok("Hola");
        }
    }
}
