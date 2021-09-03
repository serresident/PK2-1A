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
        public const string ConnStr = "server=localhost;user=sysdba;password=masterkey;database=asutp;default command timeout=20;";

        private Logger logger = LogManager.GetCurrentClassLogger();

        private readonly ProcessDataTcp _processDataTcp;
        Dictionary<string, string> _archive;
        bool firstInit;

        public ArchivService(ProcessDataTcp processDataTcp)
        {
            _processDataTcp = processDataTcp;
            _archive = new Dictionary<string, string>();
            foreach (PropertyInfo prop in processDataTcp.GetType().GetProperties().Where(p => p.PropertyType.IsPrimitive ))
            {

                _archive.Add(prop.Name, String.Empty);
            }
        }
    

        public void Worker()
        {
            if (!firstInit)
            {
                foreach (PropertyInfo prop in _processDataTcp.GetType().GetProperties().Where(p => p.PropertyType.IsPrimitive ))
                {
                    _archive[prop.Name] = prop.GetValue(_processDataTcp).ToString();
                }

                firstInit = true;
            }
            Dictionary<string, string> values = new Dictionary<string, string>();

            if (firstInit)
            {


                foreach (PropertyInfo prop in _processDataTcp.GetType().GetProperties().Where(p => p.PropertyType.IsPrimitive /*&& p.PropertyType != typeof(bool) && !p.CanWrite && Attribute.IsDefined(p, typeof(ArchivAttribute))*/))
                {
                    if (_archive[prop.Name] != prop.GetValue(_processDataTcp).ToString())
                    {
                        var t =prop.GetValue(_processDataTcp).ToString();
                       if ( prop.GetValue(_processDataTcp).ToString()=="False")
                        values.Add(prop.Name, "0");
                       else if(prop.GetValue(_processDataTcp).ToString() == "True")
                            values.Add(prop.Name, "1");
                        else values.Add(prop.Name, float.Parse(prop.GetValue(_processDataTcp).ToString()).ToString(CultureInfo.InvariantCulture));
                        _archive[prop.Name] = prop.GetValue(_processDataTcp).ToString();
                    }
                }

                if (values.Count > 0)
                {


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


    }
}

