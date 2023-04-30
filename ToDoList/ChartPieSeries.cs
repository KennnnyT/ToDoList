using Syncfusion.SfChart.XForms;

namespace ToDoList
{
    internal class ChartPieSeries : ChartSeries
    {
        public ChartDataPoint[] ItemsSource { get; set; }
        public string XBindingPath { get; set; }
        public string YBindingPath { get; set; }
    }
}