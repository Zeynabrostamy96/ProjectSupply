using Microsoft.AspNetCore.Mvc;
using Project.Application.FacadPattern;
using Project.Application.Services.Queries.GetSupply;
using Project.Common.Dto;

namespace EndPointProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ISupplyFacad _supply;
        public ApiController(ISupplyFacad supply)
        {
            _supply = supply;
        }

        [HttpGet]
        [Route("api/get/{request}")]
        public IActionResult Get(string request)
        {
            return (IActionResult)_supply.getAllSupply.Execute(request);
            
        }


        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        [HttpPost]
        public void Post([FromBody] string value)
        {
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
