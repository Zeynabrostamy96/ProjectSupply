using Project.Application.Interfaces.Contexts;
using Project.Application.Interfaces.FacadPattern;
using Project.Application.Services.Log.Commands.AddLog;

namespace Project.Application.Services.Log.FacadPattern
{
    public class LogFacad : ILogFacad
    {
        private readonly IDataBaseContext _context;
        public LogFacad(IDataBaseContext context)
        {
            _context = context;
        }
        private ILogService _LogService;
        public ILogService LogService 
        {
            get
            {
                return _LogService = _LogService ?? new LogService(_context);
            }
        }

    }
}
