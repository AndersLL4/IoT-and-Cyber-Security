using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab3_retrive_sql_data.Models;

namespace Lab3_retrive_sql_data.Pages.Shared
{
    public class AirHeaterModel : PageModel
    {
        public List<AirHeaterTemp> TempDataList = new List<AirHeaterTemp>();
        
        public void OnGet()
        {
            AirHeaterTemp temperature = new AirHeaterTemp();
            TempDataList = temperature.GetMeasurmentParameters();
        }
    }
}
