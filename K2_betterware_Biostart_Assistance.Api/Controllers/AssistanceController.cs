using K2_betterware_Biostart_Assistance.Core.Interfases;
using K2_betterware_Biostart_Assistance.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace K2_betterware_Biostart_Assistance.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssistanceController : ControllerBase
    {

        private readonly IRepository _repository;

        public AssistanceController(IRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public IActionResult GetAssistance(string f_ini, string f_nal, string limit, string type)
        //public async Task<string[]> GetAssistance(string f_ini, string f_nal, string limit, string type)
        {
            dynamic orchesting;

            if (f_ini == null || f_nal == null || limit == null || type == null) 
            {
                orchesting = "Error;  debe ingresar fecha de inicio, fecha final, limite de registros y tipo de registro por ejemplo: https://localhost:44354/api/Assistance?df27f4c5b655409bb94c471e5c314aba&f_ini=\"2021-06-20T10:26:57\"&f_nal=\"2021-06-20T20:26:57\"&limit=\"51\"&type=\"4867\"";

            }

            else
            {
                string jsonb = "{\"Query\":{\"limit\":" + limit + ",\"conditions\":[{\"column\":\"datetime\",\"operator\":3,\"values\":[\"" + f_ini + ".00Z\",\"" + f_nal + ".00Z\"]},{\"column\":\"event_type_id.code\",\"operator\":0,\"values\":[\"" + type + "\"],\"descending\":true}]}}";

                /////////////////////////////////////////////////////////////////////////////////////////
                /////////////////////////////// métodos Biostar /////////////////////////////////////////
                var tk_bio = _repository.Token_bio();
                orchesting = _repository.bio_event_search(tk_bio.ToString(), jsonb);
                //////////////////////////////////////////////////////////////////////////////////////////
            }


            //return Ok(assistance+"WWWWWWWWWWWWWWWWWWWW_"+ emp_resp_empl+"WWWWWWWWWWWWWWWWWWWWW_"+ emp_resp_per+"WWWWWWWWWWWWWWWWWWWW_"+response_check);
            //return Ok("BBBBBBBBBBBBBBBBBBB_" + tk_bio + "BBBBBBBBBBBBBBBB_"+ Usr_bio + "BBBBBBBBBBBBBBB_"+ Ev_bio + "BBBBBBBBBBBBBBBBBBB_"+ Dev_bio);
            return Ok(orchesting);
        }
    }
}
