using Project.Application.Interfaces.Contexts;
using Project.Application.Interfaces.FacadPattern;
using Project.Application.Services.Email.Queries;

namespace Project.Application.Services.Email.FacadPattern
{
    public class SendEmailFacad : ISendEmailFacad
    {
        private readonly IDataBaseContext _context;
        public SendEmailFacad(IDataBaseContext context)
        {
            _context = context;
        }
        private ISendEmailForUser _sendEmailForUser;
        public ISendEmailForUser sendEmailForUser
        {
            get
            {
                return _sendEmailForUser = _sendEmailForUser ?? new SendEmailForUser(_context);
            }
        }
    }
}
