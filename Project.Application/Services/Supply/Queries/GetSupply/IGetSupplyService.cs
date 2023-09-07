using Project.Application.Interfaces.Contexts;
using System.Linq;

namespace Project.Application.Services.Supply.Queries.GetSupply
{
    public interface IGetSupplyService
    {
        DetailsSupplyDto Execute(long id);
    }
    public class GetSupplyService : IGetSupplyService
    {
        private readonly IDataBaseContext _dataBaseContext;
        public GetSupplyService(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public DetailsSupplyDto Execute(long id)
        {
            var supply=_dataBaseContext.supplies.Where(x=>x.Id==id).FirstOrDefault();
            return new DetailsSupplyDto
            {
                id=supply.Id,
                name=supply.Title,
                userid=supply.UserId,

            };
        }
    }
    public class DetailsSupplyDto
    {
        public long id { get; set; }
        public string name { get; set; }
        public long userid { get; set; }
    }
}
