namespace Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for OrderDetails.
    /// </summary>
    public partial class OrderDetails : Telerik.Reporting.Report
    {
        public OrderDetails()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void OrderDetails_NeedDataSource(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)sender;

            this.dsReport.Parameters["@no"].Value = report.Parameters["no"].Value;
            this.dsReport.Parameters["@date"].Value = report.Parameters["date"].Value;
            this.dsReport.Parameters["@time"].Value = report.Parameters["time"].Value;
            this.dsReport.ConnectionString = report.Parameters["srv"].Value.ToString();

            report.DataSource = this.dsReport;
        }
    }
}