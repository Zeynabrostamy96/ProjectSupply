using Microsoft.AspNetCore.Mvc;
using Project.Application.FacadPattern;
using Project.Application.Interfaces.FacadPattern;
using Project.Application.Services.Commands.EditUserSupply;
using Project.Common.Log;

namespace EndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplyController : ControllerBase
    {
        private readonly ISupplyFacad _supply;
        private readonly ILogFacad _logFacad;
        private readonly ISendEmailFacad _sendEmailFacad;
        public SupplyController(ISupplyFacad supply, ILogFacad logFacad,ISendEmailFacad sendEmailFacad)
        {
            _supply = supply;
            _logFacad = logFacad;
            _sendEmailFacad = sendEmailFacad;
        }

        [HttpGet]
        public IActionResult Get(string? request)
        {
            return Ok(_supply.getAllSupply.Execute(request));

        }
        [HttpPost]
        public IActionResult add(long userId, string title)
        {
            var result=_supply.userSupplyService.Execute(userId, title);
            _logFacad.LogService.AddLog(userId, LogUser.add);
            _sendEmailFacad.sendEmailForUser.SendEmailForAll(result.IsSuccess);
            return Ok(result);

        }
        [HttpPut]
        public IActionResult GetDetails(long id)
        {
            return Ok(_supply.getSupplyService.Execute(id));
        }
        [HttpPatch]
        public IActionResult Edit(RequestEditUserSupplyDto request)
        {
             var result= _supply.editUserSupplyService.Execute(request);
            _logFacad.LogService.AddLog(request.UserId, LogUser.Edit);
            return Ok(result);  
        }
        [HttpDelete]
        public IActionResult Delete(long UserId, long SupplyId)
        {
             var result= _supply.removeSupplyService.Execute(UserId, SupplyId);
            _logFacad.LogService.AddLog(UserId, LogUser.Delete);
            return Ok(result);
        }


    }
}
