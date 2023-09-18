using Project.Application.Interfaces.Contexts;
using System.Linq;

namespace Project.Application.Services.Log.Commands.AddLog
{
    public interface ILogService
    {
        void AddLog(long user, string description);
    }
    public class LogService : ILogService
    {
        private readonly IDataBaseContext _dataBaseContext;

        public LogService(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;

        }
        public void AddLog(long user, string description)
        {
            var userid = _dataBaseContext.Users.Where(x => x.Id == user).FirstOrDefault().Id;
            Project.Domain.Entites.Log.Log log = new Project.Domain.Entites.Log.Log
            {
                UserId = userid,
                Description = description

            };
            _dataBaseContext.logs.Add(log);
            _dataBaseContext.SaveChanges();
        }
    }
}
