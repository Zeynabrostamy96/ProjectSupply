using Project.Application.Interfaces.Contexts;
using Project.Common.Dto;
using System.Linq;

namespace Project.Application.Services.Commands.RemoveSupply
{
    public interface IRemoveSupplyService
    {
        ResultDto Execute(long UserId,long SupplyId);
    }
    public class RemoveSupplyService:IRemoveSupplyService
    {
        private readonly IDataBaseContext _dataBaseContext;
        public RemoveSupplyService(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public ResultDto Execute(long UserId, long SupplyId)
        {
            var supply = _dataBaseContext.supplies.Where(x=>x.UserId==UserId && x.Id==SupplyId).FirstOrDefault();
            if (supply == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "Unsuccessful"
                };
            }
            supply.IsRemoved = true;
            _dataBaseContext.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "successful"
            };
        }
    }
}
