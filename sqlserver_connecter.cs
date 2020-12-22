using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    class sqlserver_connecter
    {
        SqlConnection data_base = new SqlConnection("server=172.16.150.200;UID=sa;PWD=1qaz@WSX;Database=EDIAS_DB;Trusted_connection=False");

        public DataSet get_input_panel(string commandstring)
        {
            SqlCommand newcommand = new SqlCommand(commandstring, data_base);
            SqlDataAdapter selectadapter = new SqlDataAdapter();
            selectadapter.SelectCommand = newcommand;
            DataSet newdata = new DataSet();
            data_base.Open();
            selectadapter.SelectCommand.ExecuteNonQuery();
            selectadapter.Fill(newdata);
            data_base.Close();
            return newdata;
        }
    }
}
