using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ConverterWebApi.DataAccessLayer
{
    public class ConversionDAL
    {
        private SqlConnection con;
        string connectionString = string.Empty;
        public ConversionDAL()
        {
            connectionString = ConfigurationManager.AppSettings["DBConnection"].ToString();
        }

        public string GetConversionFactor(ConversionModel conversion)
        {
            string result = "";
            try
            {
                con = new SqlConnection(connectionString);
                string sql = "select ConversionExpression from Conversion where  UPPER(FromUnit)= UPPER(@FromUnit) and  UPPER(ToUnit)= UPPER(@ToUnit)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@FromUnit", conversion.FromUnit);
                cmd.Parameters.AddWithValue("@ToUnit", conversion.ToUnit);
                con.Open();

                var returnValue = cmd.ExecuteScalar();
                if (returnValue != null)
                    result = Convert.ToString(returnValue);

            }
            catch
            {
                return result;
            }
            finally
            {
                con.Close();
            }
            return result;
        }
    }
}
