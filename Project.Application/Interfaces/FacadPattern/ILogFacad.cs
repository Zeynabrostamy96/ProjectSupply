using Project.Application.Services.Log.Commands.AddLog;

namespace Project.Application.Interfaces.FacadPattern
{
    public interface ILogFacad
    {
        ILogService LogService { get; }
    }
}
