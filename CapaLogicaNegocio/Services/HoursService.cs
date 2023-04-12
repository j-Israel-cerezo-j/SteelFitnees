using System;
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
using System.Data;
using System.Web.UI.WebControls;

namespace CapaLogicaNegocio.Services
{
    public class HoursService
    {
        private DataHour dataHour = new DataHour();
        private AddHour addHour = new AddHour();
        private HoursList hoursList = new HoursList();
        private HourDelete deleteHour = new HourDelete();
        private HourUpdate hourUpdate = new HourUpdate();
        private SchedulesTable schedulesTable = new SchedulesTable();

        public bool add(Dictionary<string, string> request)
        {
            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(request);
            if (camposEmptysOrNull.Count == 0)
            {
                Hour hour = buildObjHour(request);
                return addHour.add(hour);
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
        public string jsonHoursTable()
        {
            var namesTypeDateTime = new List<string>() { "horaInicio", "horaCierre" };
            return Converter.ToJson(schedulesTable.Schedules(),true, namesTypeDateTime).ToString();
        }
        public bool deleteHours(string strIds)
        {
            return deleteHour.delete(strIds);
        }
        public bool updateHours(Dictionary<string, string> request, string strId)
        {
            if (strId=="")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }
            var camposEmptysOrNull = Validation.isNullOrEmptys(request);
            bool ban = false;
            if (camposEmptysOrNull.Count == 0)
            {                                
                Hour hour = buildObjHour(request);
                hour.idHorario = Convert.ToInt32(strId);
                return hourUpdate.hourUpdate(hour);
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
        public string jsonRecoverData(string strId)
        {            
            if (strId == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }
            var hours = new List<Hour>
            {
                dataHour.dataHour(Convert.ToInt32(strId))
            };
            string jsonRecoerDtes = Converter.ToJson(hours);
            return jsonRecoerDtes;
        }
        private void vaalidedFormantTimes(string strStartTime, string strEndTime)
        {
            if (!Validation.FormantTime(strStartTime))
            {
                throw new ServiceException(MessageErrors.MessageErrors.formantIncorrectTime);
            }
            else if (!Validation.FormantTime(strEndTime))
            {
                throw new ServiceException(MessageErrors.MessageErrors.formantIncorrectTime);
            }
        }
        private void validateSelec(string select)
        {
            if (!Validation.Select(select))
            {
                throw new ServiceException(MessageErrors.MessageErrors.invalidSelectorIn());
            }
        }
        private Hour buildObjHour(Dictionary<string, string> request)
        {
            Hour hour = new Hour();
            string strStartHour = RetrieveAtributes.values(request, "horaInicio");
            string strEndHour = RetrieveAtributes.values(request, "horaCierre");
            vaalidedFormantTimes(strStartHour, strEndHour);
            hour.horaInicio = Convert.ToDateTime(strStartHour);
            hour.horaCierre = Convert.ToDateTime(strEndHour);

            string strSelectFkBranche = RetrieveAtributes.values(request, "branches");
            string strSelectFkDay = RetrieveAtributes.values(request, "days");
            validateSelec(strSelectFkBranche);
            validateSelec(strSelectFkDay);
            hour.fkDia = Convert.ToInt32(strSelectFkDay);
            hour.fkSucursal = Convert.ToInt32(strSelectFkBranche);
            return hour;
        }

        public string jsonTableSchedulesByIdDay(string strId)
        {
            if (strId == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }
            var namesTypeDateTime = new List<string>() { "horaInicio", "horaCierre" };
            return Converter.ToJson(schedulesTable.ByIdDay(Convert.ToInt32(strId)), true, namesTypeDateTime).ToString();
        }
        public List<string> onkeyupSearchList(string caracteres)
        {
            caracteres = "%" + caracteres + "%";
            return Converter.ToList(schedulesTable.ByCharacters(caracteres));

        }
        public string onkeyupSearchTable(string caracteres)
        {
            var namesTypeDateTime = new List<string>() { "horaInicio", "horaCierre" };
            return Converter.ToJson(schedulesTable.ByCharacters(caracteres),true,namesTypeDateTime).ToString();

        }
    }
}
