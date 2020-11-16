using Demo.WebApi.NetCore.RealTimeCharts_Server.DataStorage;
using Demo.WebApi.NetCore.RealTimeCharts_Server.HubConfig;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

[Route("api/chart")]
[ApiController]
public class ChartController : ControllerBase
{
    private IHubContext<ChartHub> _hub;

    public ChartController(IHubContext<ChartHub> hub)
    {
        _hub = hub;
    }

    public IActionResult Get()
    {
        var timerManager = new TimerManager(() => _hub.Clients.All.SendAsync("transferchartdata", DataManager.GetData()));

        return Ok(new { Message = "Request Completed" });
    }
}