namespace Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for Order.
    /// </summary>
    public partial class Order : Telerik.Reporting.Report
    {
        public Order()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void Order_NeedDataSource(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)sender;

            this.OrderSource.Parameters["@no"].Value = report.Parameters["no"].Value;
            this.OrderSource.Parameters["@date"].Value = report.Parameters["date"].Value;
            this.OrderSource.Parameters["@time"].Value = report.Parameters["time"].Value;
            this.OrderSource.ConnectionString = report.Parameters["srv"].Value.ToString();

            report.DataSource = this.OrderSource;
        }
    }
}