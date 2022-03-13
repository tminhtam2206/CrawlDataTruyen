using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlDataTruyen
{
    public  class DataProvider
    {
        private static DataProvider instance;
        private MySqlConnection connection;
        private MySqlCommand command;
        public string strConnection = @"Server = localhost; Database = db_tangkinhcac_mvc; UId = root; Pwd = ; Pooling=false;Character Set=utf8";
        //public string strConnection = @"Server=sql6.freemysqlhosting.net;Database=sql6443074;UId=sql6443074;Pwd=mclIDSRK5K;Pooling=false;Character Set=utf8";
        //public string strConnection = @"server=fdb34.awardspace.net;userid=3953467_10xu;password=T@m123456;database=3953467_10xu;port=3306";
        //public string strConnection = "Server=185.176.43.113; User=3953467_10xu; Database=3953467_10xu; Password=T@m123456; port=3306; Allow Zero Datetime=true; Convert Zero Datetime=true;";

        //public string strConnection = "Server=192.168.0.105; User=laptop; Database=db_tangkinhcac_mvc; Password=PASSWORD; port=3306; Allow Zero Datetime=true; Convert Zero Datetime=true;";

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set { instance = value; }
        }

        private DataProvider()
        {
            connection = new MySqlConnection(strConnection);
        }

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            try
            {
                connection.Open();
                command = new MySqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                DataTable data = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
                return data;
            }
            catch
            {
                connection.Close();
            }

            return null;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            try
            {
                connection.Open();
                command = new MySqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();
                connection.Close();
                return data;
            }
            catch
            {
                connection.Close();
            }

            return data;
        }
    }
}
