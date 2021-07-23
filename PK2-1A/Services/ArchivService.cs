using MySqlConnector;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using belofor.Attributes;
using belofor.Models;

namespace belofor.Services
{
    public class ArchivService
    {
        public const string ConnStr = "server=A2ESS;user=sysdba;password=masterkey;database=asutp;default command timeout=20;";

        private Logger logger = LogManager.GetCurrentClassLogger();

        private readonly ProcessDataTcp _processDataTcp;

        public ArchivService(ProcessDataTcp processDataTcp)
        {
            _processDataTcp = processDataTcp;
        }

        public void Worker()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();

            foreach (PropertyInfo prop in _processDataTcp.GetType().GetProperties().Where(p => p.PropertyType.IsPrimitive && p.PropertyType != typeof(bool) && !p.CanWrite && Attribute.IsDefined(p, typeof(ArchivAttribute))))
            {
                values.Add(prop.Name, float.Parse(prop.GetValue(_processDataTcp).ToString()).ToString(CultureInfo.InvariantCulture));
            }

            using (var conn = new MySqlConnection(ConnStr))
            {
                try
                {
                    conn.Open();

                    using (var command = conn.CreateCommand())
                    {

                        command.CommandText = @"INSERT INTO measurements (DTS, `values`) VALUES (@DTS, @values); DELETE FROM measurements WHERE DTS < @minDTS";
                        command.Parameters.AddWithValue("@DTS", DateTime.Now);
                        command.Parameters.AddWithValue("@values", JsonConvert.SerializeObject(values));
                        command.Parameters.AddWithValue("@minDTS", DateTime.Now.AddMonths(-2));

                        command.ExecuteNonQuery();

                    }
                }

                catch (Exception ex)
                {
                    logger.Error(ex, this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name);
                }
                finally
                {
                    conn.Close();
                }


            }

        }


    }
}

