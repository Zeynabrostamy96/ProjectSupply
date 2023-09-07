using Project.Application.Interfaces.Contexts;
using Project.Infrastructure.Sender;
using System.Linq;

namespace Project.Application.Services.Email.Queries
{
    public interface ISendEmailForUser
    {
        void SendEmailForAll(bool IsSuucess);
    }
    public class SendEmailForUser : ISendEmailForUser
    {
        private readonly IDataBaseContext _dataBaseContext;
        public SendEmailForUser(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public void SendEmailForAll(bool IsSuucess)
        {
            var users = _dataBaseContext.Users.Select(x => x.Email).ToList();
            if (IsSuucess == true)
            {
                foreach (var item in users)
                {
                    SendEmail.Send(item, "اطلاع رسانی ", "");
                }
            }
        }
    }
}
