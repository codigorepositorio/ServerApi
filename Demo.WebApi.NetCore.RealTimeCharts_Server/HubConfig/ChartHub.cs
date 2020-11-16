using Demo.WebApi.NetCore.RealTimeCharts_Server.Model;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.WebApi.NetCore.RealTimeCharts_Server.HubConfig
{
    public class ChartHub : Hub
    {
       public async Task BroadcastChartData(List<ChartModel> data) => await Clients.All.SendAsync("broadcastchartdata", data);
    }
}
