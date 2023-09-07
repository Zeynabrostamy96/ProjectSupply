using Project.Application.Services.Commands.AddUserSupply;
using Project.Application.Services.Commands.EditUserSupply;
using Project.Application.Services.Commands.RemoveSupply;
using Project.Application.Services.Queries.GetSupply;
using Project.Application.Services.Supply.Queries.GetSupply;

namespace Project.Application.FacadPattern
{
    public interface ISupplyFacad
    {
        UserSupplyService userSupplyService { get; }
        EditUserSupplyService editUserSupplyService { get; }
        RemoveSupplyService removeSupplyService { get; }
        IGetAllSupplyService getAllSupply { get; }
        IGetSupplyService getSupplyService { get; }
    }
}
