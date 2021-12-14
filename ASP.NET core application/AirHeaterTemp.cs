using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Lab3_retrive_sql_data.Models
{
    public class AirHeaterTemp
    {

        public int TemperatureId { get; set; }
        public double Temperature { get; set; }
        public string timestamp { get; set; }
        public List<AirHeaterTemp> GetMeasurmentParameters()
        {
            List<AirHeaterTemp> TempDataList = new List<AirHeaterTemp>();

            string connectionString = "DATA SOURCE=tcp:airheaterserverlab3.database.windows.net,1433;UID=ALL;PWD=HiJk1234;DATABASE=AIRHEATERDB";
            //"DATA SOURCE=DESKTOP-NUQR2FV;UID=ALL;PWD=HiJk1;DATABASE=AirHeater";
            SqlConnection con = new SqlConnection(connectionString);

            string sqlQuery = "SELECT TemperatureId, Temperature, timestamp FROM AIRHEATER1"; //FORMAT(timestamp,'MM.dd HH:mm')
            con.Open();

            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    AirHeaterTemp measurmentParameter = new AirHeaterTemp();
                    measurmentParameter.TemperatureId = Convert.ToInt32(dr["TemperatureId"]);
                    measurmentParameter.Temperature = Convert.ToDouble(dr["Temperature"]); //dr["Temperature"].ToString(); //float.Parse(dr["Temperature"]); 
                    measurmentParameter.timestamp = dr["timestamp"].ToString(); // dr["timestamp"].ToString(); //.ToString(); //DateTime.Parse(dr["timestamp"]);
                    TempDataList.Add(measurmentParameter);
                }
            }
            Console.WriteLine(TempDataList);
            return TempDataList;
        }
    }
}
