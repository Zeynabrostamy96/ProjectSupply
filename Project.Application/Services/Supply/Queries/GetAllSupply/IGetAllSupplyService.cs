using Microsoft.EntityFrameworkCore;
using Project.Application.Interfaces.Contexts;
using Project.Common.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Project.Application.Services.Queries.GetSupply
{
    public interface IGetAllSupplyService
    {
        ResultDto<ResultSupplyDto> Execute(string? SearchKey);
    }
    public class GetAllSupplyService : IGetAllSupplyService
    {
        private readonly IDataBaseContext _dataBaseContext;
        public GetAllSupplyService(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public ResultDto<ResultSupplyDto> Execute(string? SearchKey)
        {
            var supplyQuery = _dataBaseContext.supplies.Include(p => p.user).AsQueryable();
            if (!string.IsNullOrWhiteSpace(SearchKey))
            {
                supplyQuery = supplyQuery.Where(p => p.user.Name.Contains(SearchKey)).AsQueryable();
            }
            return new ResultDto<ResultSupplyDto>
            {
                Data = new ResultSupplyDto
                {
                    UserName=SearchKey,
                    supplies=supplyQuery.Select(x=>new SupplyDto
                    {
                        Title=x.Title
                    }).ToList()
                    
                },
                Message="Success",
                IsSuccess = true,
            };
        }
    }
    public class ResultSupplyDto
    {
        public List<SupplyDto> supplies { get; set; }
        public string UserName { get; set; }
    }
    public class SupplyDto
    {
        public string  Title { get; set; }
    }
}
