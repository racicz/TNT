namespace TNT
{
    using System;
    using System.Windows;
    using Telerik.Reporting.Processing;
    using Telerik.Windows.Controls;

    public partial class ReportViewer : Window
    {
        string _server;
        string _reportName;
        int _parm1;
        string _date = "";
        string _time = "";


        public ReportViewer(string reportName, string server, int parm1, string date, string time)
        {
            InitializeComponent();

            _server = server;
            _reportName = reportName;
            _parm1 = parm1;
            _date = date;
            _time = time;

            this.Loaded += ReportViewer_Loaded;

        }

        private void ReportViewer_Loaded(object sender, RoutedEventArgs e)
        {
            Telerik.Reporting.InstanceReportSource instanceReportSource = new Telerik.Reporting.InstanceReportSource();
            ReportProcessor rptProc = new ReportProcessor();

            if (_reportName == "ORDER")
            {
                Reports.Order rpt = new Reports.Order();
                rpt.ReportParameters["srv"].Value = _server;
                rpt.ReportParameters["no"].Value = _parm1;
                rpt.ReportParameters["date"].Value = _date;
                rpt.ReportParameters["time"].Value = _time;
                instanceReportSource.ReportDocument = rpt;
            }
            else if (_reportName == "DETAIL")
            {
                Reports.OrderDetails rpt = new Reports.OrderDetails();
                rpt.ReportParameters["srv"].Value = _server;
                rpt.ReportParameters["no"].Value = _parm1;
                rpt.ReportParameters["date"].Value = _date;
                rpt.ReportParameters["time"].Value = _time;
                instanceReportSource.ReportDocument = rpt;
            }

            this.rvReport.ReportSource = instanceReportSource;
        }
    }
}