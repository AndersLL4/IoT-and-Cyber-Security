using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Air_Heater_Temperature_data.Models
{
    public class ChartData
    {
        public int TemperatureId { get; set; }
        public double Temperature { get; set; }
        public string timestamp { get; set; }
        public List<ChartData> GetChartData()
        {
            List<ChartData> chartDataList = new List<ChartData>();

            string connectionString = "DATA SOURCE=DESKTOP-NUQR2FV;UID=ALL;PWD=HiJk1;DATABASE=AirHeater";

            SqlConnection con = new SqlConnection(connectionString);
            string selectSQL = "SELECT TemperatureId, Temperature, FORMAT(timestamp, 'ss') AS timestamp FROM AIRHEATER";
            con.Open();

            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    ChartData chartData = new ChartData();
                    chartData.TemperatureId = Convert.ToInt32(dr["TemperatureId"]);
                    chartData.Temperature = Convert.ToDouble(dr["Temperature"]);
                    chartData.timestamp = Convert.ToString(dr["timestamp"]); //dr["timestamp"].ToString();
                    chartDataList.Add(chartData);
                }
            }
            return chartDataList;
        }
    }
}