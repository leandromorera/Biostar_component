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
            /// acceso al token
            ///var assistance = _repository.getToken();
            /////// metodo de acceso a los empleados
            ///string emp = "/v3/asi/empleados";
            ///var emp_resp = _repository.get_employed(emp);
            ///var emp_resp_empl = _repository.get_empleado(emp);
            /////// metodo de acceso a la persona en particuar
            ///string emp1 = "/v3/asi/personas/";
            ///string npt = "1201651";
            ///var emp_resp_per = _repository.get_persona(emp1, npt);
            ///string p_id = "8251";
            ///string fechahora = "2019-11-05T09:04:08";
            ///string dispositivoId = "11948";
            ///string posi = "[E|1|N]";
            ///var response_check = _repository.checando(p_id, fechahora, dispositivoId, posi);

            /////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////// métodos Biostar /////////////////////////////////////////
            var tk_bio = _repository.Token_bio();
            var Usr_bio = _repository.User_bio();
            var Ev_bio = _repository.Event_search_bio();
            var Dev_bio = _repository.Device_bio();
            var Comp_bio = _repository.bio_event_search(tk_bio.ToString());
            //////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////

            //var orchesting = _repository.registrando_bio_beat();



            //return Ok(assistance+"WWWWWWWWWWWWWWWWWWWW_"+ emp_resp_empl+"WWWWWWWWWWWWWWWWWWWWW_"+ emp_resp_per+"WWWWWWWWWWWWWWWWWWWW_"+response_check);
            //return Ok("BBBBBBBBBBBBBBBBBBB_" + tk_bio + "BBBBBBBBBBBBBBBB_"+ Usr_bio + "BBBBBBBBBBBBBBB_"+ Ev_bio + "BBBBBBBBBBBBBBBBBBB_"+ Dev_bio);
            return Comp_bio;
        }
    }
}
