using Project.Application.FacadPattern;
using Project.Application.Interfaces.Contexts;
using Project.Application.Services.Commands.AddUserSupply;
using Project.Application.Services.Commands.EditUserSupply;
using Project.Application.Services.Commands.RemoveSupply;
using Project.Application.Services.Queries.GetSupply;
using Project.Application.Services.Supply.Queries.GetSupply;

namespace Project.Application.Services.Supply.FacadPattern
{
    public class SupplyFacad : ISupplyFacad
    {
        private readonly IDataBaseContext _context;
        public SupplyFacad(IDataBaseContext context)
        {
            _context = context;
        }
        private UserSupplyService _userSupplyService;
        public UserSupplyService userSupplyService
        {
            get
            {
                return _userSupplyService = _userSupplyService ?? new UserSupplyService(_context);
            }
        }
        private EditUserSupplyService _editUserSupplyService;
        public EditUserSupplyService editUserSupplyService
        {
            get
            {
                return _editUserSupplyService = _editUserSupplyService ?? new EditUserSupplyService(_context);
            }
        }
        private RemoveSupplyService _removeSupplyService;
        public RemoveSupplyService removeSupplyService 
        {
            get
            {
                return _removeSupplyService = _removeSupplyService ?? new RemoveSupplyService(_context);
            }
        }

        private IGetAllSupplyService _getAllSupplyService;
        public IGetAllSupplyService getAllSupply
        {
            get
            {
                return _getAllSupplyService = _getAllSupplyService ?? new GetAllSupplyService(_context);
            }
        }
        private IGetSupplyService _getSupplyService;
        public IGetSupplyService getSupplyService
        {
            get
            {
                return _getSupplyService = _getSupplyService ?? new GetSupplyService(_context);
            }
        }
    }
}
