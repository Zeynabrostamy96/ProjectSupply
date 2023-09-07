using Project.Application.Interfaces.Contexts;
using Project.Common.Dto;
using System.Linq;

namespace Project.Application.Services.Commands.EditUserSupply
{
    public interface IEditUserSupplyService
    {
        ResultDto Execute(RequestEditUserSupplyDto request);
    }
    public class EditUserSupplyService : IEditUserSupplyService
    {
        private readonly IDataBaseContext _dataBaseContext;
        public EditUserSupplyService(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public ResultDto Execute(RequestEditUserSupplyDto request)
        {
            var supply = _dataBaseContext.supplies.Where(x=>x.UserId==request.UserId&&x.Id==request.SupplyId).FirstOrDefault();
            if (supply == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "Unsuccessful"
                };
            }
            supply.Title = request.Title;
            _dataBaseContext.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "successful"
            };
        }
    }
    public class RequestEditUserSupplyDto
    {
        public long SupplyId { get; set; }
        public long UserId { get; set; }
        public string Title { get; set; }
    }
}
