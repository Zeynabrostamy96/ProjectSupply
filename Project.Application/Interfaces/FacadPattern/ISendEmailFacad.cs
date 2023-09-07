using Project.Application.Services.Email.Queries;

namespace Project.Application.Interfaces.FacadPattern
{
    public interface ISendEmailFacad
    {
        ISendEmailForUser sendEmailForUser { get; }
    }
}
