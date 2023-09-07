using Project.Application.Interfaces.Contexts;
using Project.Common.Dto;
using System.Linq;

namespace Project.Application.Services.Commands.AddUserSupply
{
    public interface IUserSupplyService
    {
        ResultDto Execute(long userId, string title);
    }
    public class UserSupplyService : IUserSupplyService
    {
        private readonly IDataBaseContext _dataBaseContext;

        public UserSupplyService(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;

        }
        public ResultDto Execute(long userId, string title)
        {
            var departementid = _dataBaseContext.departments.Where(x => x.UserId == userId).Select(x=>x.Id).FirstOrDefault();
            Project.Domain.Entites.Users.Supply supply = new Project.Domain.Entites.Users.Supply
            {
                DeparetmentId = departementid,
                Title = title,
                UserId = userId,
            };
            _dataBaseContext.supplies.Add(supply);
            _dataBaseContext.SaveChanges();
            var result = new ResultDto
            {
                IsSuccess = true,
                Message = "Success"
            };
            return result;
        }
    }
}
