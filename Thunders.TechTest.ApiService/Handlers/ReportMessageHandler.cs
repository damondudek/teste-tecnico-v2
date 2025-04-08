using Rebus.Handlers;
using Thunders.TechTest.ApiService.Entities;

namespace Thunders.TechTest.ApiService.Handlers;

public class ReportMessageHandler() : IHandleMessages<Report>
{
    public Task Handle(Report message)
    {
        throw new NotImplementedException();
    }
}
