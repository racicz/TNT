using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.Reporting;
using Telerik.Reporting.Drawing;

namespace Reports
{
    /// <summary>
    /// Summary description for OrderSubReport.
    /// </summary>
    public partial class OrderSubReport : Telerik.Reporting.Report
    {
        public OrderSubReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void OrderSubReport_NeedDataSource(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)sender;

            this.sqlDataSource1.Parameters["@no"].Value = report.Parameters["no"].Value;
            this.sqlDataSource1.Parameters["@date"].Value = report.Parameters["date"].Value;
            this.sqlDataSource1.Parameters["@time"].Value = report.Parameters["time"].Value;
            this.sqlDataSource1.ConnectionString = report.Parameters["srv"].Value.ToString();

            report.DataSource = this.sqlDataSource1;
        }
    }
}