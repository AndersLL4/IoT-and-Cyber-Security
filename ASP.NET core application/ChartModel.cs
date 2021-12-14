using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Air_Heater_Temperature_data.Models;
using Lab3_retrive_sql_data.Models;

namespace Air_Heater_Temperature_data.Pages.Shared
{
    public class ChartModel : PageModel
    {
        public List<ChartData> chartDataList = new List<ChartData>();
        public ChartData OnGet
        {
            get
            {
                ChartData chartData1 = new ChartData();
                chartDataList = chartData1.GetChartData();
                //AirHeaterTemp temperature = new AirHeaterTemp();
                //TempDataList = temperature.GetMeasurmentParameters();
                return chartData1;
            }
        }
        //private List<ChartData> ChartData()
        //{
        //    List<ChartData> chartDataList = new List<ChartData>();
        //    ChartData chartData = new ChartData();
        //    chartDataList = chartData.GetChartData();
        //    return chartDataList;
        //}
    }
}







//namespace Air_Heater_Temperature_data.Pages
//{
//    public class ChartModel : PageModel
//    {
//        public List<AirHeaterTemp> chartDataList = new List<AirHeaterTemp>();
//        //string connectionString;
//        //readonly IConfiguration _configuration;
//        //public LineChartModel(IConfiguration configuration)
//        //{
//        //    _configuration = configuration;
//        //}
//        public void OnGet()
//        {
//            AirHeaterTemp temperature = new AirHeaterTemp();
//            chartDataList = temperature.GetMeasurmentParameters();
//        }
//        //private List<AirHeaterTemp> ChartData()
//        //{
//        //    //connectionString = _configuration.GetConnectionString("ConnectionString");
//        //    //List<AirHeaterTemp> chartDataList = new List<AirHeaterTemp>();
//        //    //AirHeaterTemp chartData = new AirHeaterTemp();
//        //    //chartDataList = AirHeaterTemp.GetMeasurmentParameters();
//        //    return chartDataList;
//        //}
//    }
//}
