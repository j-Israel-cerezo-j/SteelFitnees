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
namespace CapaLogicaNegocio.Services
{
    public class DayService
    {
        private DayAdd dayAdd = new DayAdd();
        private DayList dayList = new DayList();
        private DayDelete dayDelete = new DayDelete();
        private DayData dayData = new DayData();
        private DayUpdate dayUpdate = new DayUpdate();
        private HoursList hoursList = new HoursList();
        private DaysTable daysTable= new DaysTable();
        public bool add(Dictionary<string, string> request)
        {
            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(request);
            if (camposEmptysOrNull.Count == 0)
            {
                Day day = new Day();
                day.dia = RetrieveAtributes.values(request, "dia");
                return dayAdd.add(day);
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
        public bool updateDays(Dictionary<string, string> request, string strId)
        {
            if (strId == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }
            var camposEmptysOrNull = Validation.isNullOrEmptys(request);
            bool ban = false;
            if (camposEmptysOrNull.Count == 0)
            {
                Day day = new Day();
                day.idDia = Convert.ToInt32(strId);
                day.dia = RetrieveAtributes.values(request, "dia");
                return dayUpdate.update(day);
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
        public bool deleteDays(string strIds)
        {
            var idsList = Converter.ToList(strIds);
            var schedules = hoursList.listHours();
            for (int i = 0; i < schedules.Count; i++)
            {
                if (idsList.Contains(schedules[i].fkDia.ToString()))
                {
                    throw new ServiceException(MessageErrors.MessageErrors.errorDeleteDayReference);
                }
            }
            return dayDelete.delete(strIds);
        }
        public string jsonRecoverData(string strId)
        {
            if (strId == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }
            var hours = new List<Day>
            {
                dayData.data(Convert.ToInt32(strId))
            };
            return Converter.ToJson(hours);
        }
        public string jsonDays()
        {
            return Converter.ToJson(dayList.listDays());
        }
        public List<string> onkeyupSearchList(string caracteres)
        {
            caracteres = "%" + caracteres + "%";
            return Converter.ToList(daysTable.listDaysByCharactersConicidences(caracteres));

        }
        public string onkeyupSearchTable(string caracteres)
        {
            return Converter.ToJson(dayList.tableDaysByCharactersConicidences(caracteres));

        }
    }
}
