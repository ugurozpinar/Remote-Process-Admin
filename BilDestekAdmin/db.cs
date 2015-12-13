using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BilDestekAdmin
{
    class DB
    {
        private String server;
        private String database;
        private String user;
        private String password;
        private String kullanilmayan;
        private String degisecek;
        public DB(String server, String database, String user, String password)
        {
            this.server = server;
            this.database = database;
            this.user = user;
            this.password = password;
        }
        private SqlConnection connect()
        {
            SqlConnection con = new SqlConnection("Server=" + this.server + ";Database=" + this.database + ";User Id=" + this.user + ";Password=" + this.password + ";Connection Timeout=5;");
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return con;
        }
        public int AddTask(String process,String param1,int delay,String msg, int keep)
        {
            SqlCommand com; SqlDataReader dr;
            SqlConnection con;
            int id = -1;
            

            SqlCommand com2;

            try
            {
                con = connect();
                com2 = new SqlCommand("INSERT INTO Tasks (process,param1,delay,message,keep) output INSERTED.id VALUES (@process,@param1,@delay,@message,@keep)", con);
                com2.Parameters.AddWithValue("@process", process);
                com2.Parameters.AddWithValue("@param1", param1);
                com2.Parameters.AddWithValue("@delay", delay);
                com2.Parameters.AddWithValue("@message", msg);
                com2.Parameters.AddWithValue("@keep", keep);
                id = (int)com2.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();
            return id;
        }

    }
}
