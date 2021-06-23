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
        // public IActionResult GetAssistance()
        public async Task<string[]> GetAssistance()
        {
            

            /////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////// métodos Biostar /////////////////////////////////////////
            var tk_bio = _repository.Token_bio();
            var Usr_bio = _repository.User_bio();
            var Ev_bio = _repository.Event_search_bio();
            var Dev_bio = _repository.Device_bio();
            var Comp_bio = _repository.bio_event_search(tk_bio.ToString());
            //////////////////////////////////////////////////////////////////////////////////////////
            


            //return Ok(assistance+"WWWWWWWWWWWWWWWWWWWW_"+ emp_resp_empl+"WWWWWWWWWWWWWWWWWWWWW_"+ emp_resp_per+"WWWWWWWWWWWWWWWWWWWW_"+response_check);
            //return Ok("BBBBBBBBBBBBBBBBBBB_" + tk_bio + "BBBBBBBBBBBBBBBB_"+ Usr_bio + "BBBBBBBBBBBBBBB_"+ Ev_bio + "BBBBBBBBBBBBBBBBBBB_"+ Dev_bio);
            return Comp_bio;
        }
    }
}
