using kortlagning_vefur.Models;
using kortlagning_vefur.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MySqlX.XDevAPI;


namespace kortlagning_vefur.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VorsluController : ControllerBase
    {
        

        public kortLagningService _kortLagningService;
        public VorsluController(kortLagningService kortLagningService) 
        {
            _kortLagningService = kortLagningService;   
        }
        [HttpGet]
        public IEnumerable<vorslustofnun> Get()
        {
            return _kortLagningService.GetKVorslustofnanir();
        }

        [Route("/update")]
        [HttpPut]
        public ActionResult UppdataVarsla(int iVarlsa, string strHeiti)
        {

            _kortLagningService.updateVorslustofnanir(iVarlsa, strHeiti);
            return Ok();
        }
    }
}
