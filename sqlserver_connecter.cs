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
        DateTime last_date = DateTime.Now.AddHours(-1);

        public void last_date_add()
        {
            last_date.AddHours(1);
        }

        string get_date_span_sqlstring_last()
        {
            return last_date.ToString("yyyyMMddHH0000");
        }

        string get_date_span_sqlstring_now()
        {
            DateTime returndate = new DateTime(last_date.ToBinary());
            returndate.AddHours(1);
            return returndate.ToString("yyyyMMddHH0000");
        }

        DataSet get_input_panel(string commandstring)
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

        public DataSet get_oninspect_mission()
        {
            string commandstring = string.Format(@"SELECT[EqpID],
                                    [InspDate]
                                    ,[ModelID]
                                    ,[InnerID]
                                    ,[VcrID]
                                    ,[MviUser]
                                    ,[LastResult]
                                    ,[LastJudge]
                                    ,[DbInTime]
                                    ,[OperationID]
                                    ,[StageID]
                                    ,[LastResultName]
                                    ,[ProductType]
                                    ,[MergeToolJudge]
                                    ,[DefectName]
                                    FROM[EDIAS_DB].[dbo].[TAX_PRODUCT_TEST]
                                    WHERE InspDate BETWEEN '{0}' AND '{1}'", get_date_span_sqlstring_last(), get_date_span_sqlstring_now());
            DataSet newdata = get_input_panel(commandstring);
            return newdata;

        }
    }
}
