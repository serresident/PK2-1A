﻿using MySqlConnector;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using belofor.Attributes;
using belofor.Models;

namespace belofor.Services
{
    public class JournalService
    {
        private const string connStr = "server=localhost ;user=sysdba;password=masterkey;database=asutp;default command timeout=20;";

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly ProcessDataTcp _processDataTcp;

        Dictionary<string, string> _journal;
        bool firstInit;


        public JournalService(ProcessDataTcp processDataTcp)
        {
            _processDataTcp = processDataTcp;
            _journal = new Dictionary<string, string>();

         foreach (PropertyInfo prop in processDataTcp.GetType().GetProperties().Where(p => p.PropertyType.IsPrimitive && Attribute.IsDefined(p, typeof(JournalAttribute))))
               // foreach (PropertyInfo prop in processDataTcp.GetType().GetProperties().Where(p => p.PropertyType.IsPrimitive ))
                {
                    
                _journal.Add(prop.Name, String.Empty);
            }
        }
        //Rr6qESotEniwmvQg7--eNjdQ6oHTzErVZbY1N67ndKX_orFsvTaRIyFVkKjnzuVsEoY4ckzvX1362MYe_au-dg==
        public void Worker()
        {
            if (_processDataTcp.JOURNAL == 13 && !firstInit)
            {
                foreach (PropertyInfo prop in _processDataTcp.GetType().GetProperties().Where(p => p.PropertyType.IsPrimitive && Attribute.IsDefined(p, typeof(JournalAttribute))))
                {
                    _journal[prop.Name] = prop.GetValue(_processDataTcp).ToString();
                }

                firstInit = true;
            }

            if (_processDataTcp.JOURNAL == 13 && firstInit)
            {
                foreach (PropertyInfo prop in _processDataTcp.GetType().GetProperties().Where(p => p.PropertyType.IsPrimitive && Attribute.IsDefined(p, typeof(JournalAttribute))))
                {
                    if (_journal[prop.Name] != prop.GetValue(_processDataTcp).ToString())
                    {
                      var attr = prop.GetCustomAttribute<JournalAttribute>();

                       Debug.WriteLine(string.Format(attr.Message, _journal[prop.Name], prop.GetValue(_processDataTcp)));

                        using (var conn = new MySqlConnection(connStr))
                        {
                            try
                            {
                                conn.Open();

                                using (var command = conn.CreateCommand())
                                {

                                    command.CommandText = @"INSERT INTO journal (DTS, `message`) VALUES (@DTS, @message); DELETE FROM journal WHERE DTS < @minDTS";
                                    command.Parameters.AddWithValue("@DTS", DateTime.Now);
                                    command.Parameters.AddWithValue("@message", string.Format(attr.Message+ " "+prop.Name+ " >> [{0}] --> [{1}]", _journal[prop.Name], prop.GetValue(_processDataTcp)));
                                    command.Parameters.AddWithValue("@minDTS", DateTime.Now.AddDays(-7));

                                    command.ExecuteNonQuery();

                                }
                            }

                            catch (Exception ex)
                            {
                                _logger.Error(ex, "Insert new journal MySql");
                            }
                            finally
                            {
                                // always call Close when done reading.
                                conn.Close();
                            }


                        }

                        _journal[prop.Name] = prop.GetValue(_processDataTcp).ToString();
                    }
                }
            }


        }
    }

}
