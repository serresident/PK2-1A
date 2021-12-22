﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace belofor
{
    internal static class To_Config
    {

       public static string ReadRetane(string name)
        {
            string result = null;
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                result = appSettings[name] ?? "Not Found";
                // result = "1";
                //MessageBox.Show(result);
            }
            catch (ConfigurationErrorsException e)
            {
                // MessageBox.Show(e.ToString()); 
                //  logger.Error("ReadSetting" + e.ToString());
            }

            return result;
        }

        /// <summary>
        /// суммирует передаваемое значение к значению параметра в app.config (сумматор)
        /// </summary>
        /// <param name="value">значение</param>
        /// <param name="nameTag">имя</param>
        /// <returns></returns>
        public static  void WriteRetane(double value, string nameTag)
        {


            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;


                if (settings[nameTag] == null)
                {
                    settings.Add(nameTag, value.ToString( "0:0.0##"));
                }
                else
                {
                    settings[nameTag].Value = value.ToString();
                }

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

            }
            catch (ConfigurationErrorsException e)
            {
                //  MessageBox.Show("Error writing app settings" + e.Message);
            }

            //logger.Info(total+" total "+nameTag);


        }
    }
}
