using EjercicioPOOLab.Transporte.Entities.Interfaces.Abstract;
using System.Collections.Generic;
using System.Configuration;

namespace EjercicioPOOLab.Transporte.Application.Logic
{
    public class GenericLogic
    {
        public static int MissingNumTrans(string tipeTransport, List<TransportePublico> transList)
        {
            if (tipeTransport == ConfigurationManager.AppSettings["omnibus"])
            {
                return int.Parse(ConfigurationManager.AppSettings["maxCantTipeTrans"]) - transList.Count;
            }
            return int.Parse(ConfigurationManager.AppSettings["maxTransList"]) - transList.Count;
        }
        public static string TipeTransport(int cantTrans)
        {
            if (cantTrans >= int.Parse(ConfigurationManager.AppSettings["maxCantTipeTrans"]))
            {
                return ConfigurationManager.AppSettings["taxi"];
            }
            return ConfigurationManager.AppSettings["omnibus"];
        }
        public static int SetMaxPlace(string tipeTransport)
        {
            if (tipeTransport == ConfigurationManager.AppSettings["taxi"])
            {
                int maxPlace = int.Parse(ConfigurationManager.AppSettings["maxTaxiPassanger"]);
                return maxPlace;
            }
            return int.Parse(ConfigurationManager.AppSettings["maxOmnibusPassanger"]);
        }
        public static void Settings(string value, string key)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            if (settings[key] == null)
            {
                settings.Add(key, value);
            }
            else
            {
                settings[key].Value = value;
            }
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }
        public static string StopTrans(TransportePublico transPublic)
        {
            return transPublic.Detenerse();
        }
        public static string GoTrans(TransportePublico transPublic)
        {

            return transPublic.Avanzar();
        }
    }
}
