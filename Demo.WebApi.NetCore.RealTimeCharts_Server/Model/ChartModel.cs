using System.Collections.Generic;

namespace Demo.WebApi.NetCore.RealTimeCharts_Server.Model
{
    public class ChartModel
    {
        public List<int> Data { get; set; }
        public string Label { get; set; }
        public ChartModel()
        {
            Data = new List<int>();
        }
    }
}
