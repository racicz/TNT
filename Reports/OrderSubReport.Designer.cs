
namespace Reports
{
    partial class OrderSubReport
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.Group group2 = new Telerik.Reporting.Group();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter4 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.groupFooterSection1 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection1 = new Telerik.Reporting.GroupHeaderSection();
            this.shape4 = new Telerik.Reporting.Shape();
            this.groupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.textBox32 = new Telerik.Reporting.TextBox();
            this.textBox22 = new Telerik.Reporting.TextBox();
            this.groupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.detail = new Telerik.Reporting.DetailSection();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.shape1 = new Telerik.Reporting.Shape();
            this.textBox30 = new Telerik.Reporting.TextBox();
            this.textBox31 = new Telerik.Reporting.TextBox();
            this.textBox27 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox20 = new Telerik.Reporting.TextBox();
            this.productNrTextBox = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // groupFooterSection1
            // 
            this.groupFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.288D);
            this.groupFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.shape1,
            this.textBox2,
            this.textBox1});
            this.groupFooterSection1.Name = "groupFooterSection1";
            this.groupFooterSection1.PrintOnEveryPage = true;
            // 
            // groupHeaderSection1
            // 
            this.groupHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.548D);
            this.groupHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.shape4,
            this.textBox11,
            this.textBox13,
            this.textBox27,
            this.textBox31,
            this.textBox20,
            this.productNrTextBox});
            this.groupHeaderSection1.Name = "groupHeaderSection1";
            this.groupHeaderSection1.PrintOnEveryPage = true;
            // 
            // shape4
            // 
            this.shape4.Docking = Telerik.Reporting.DockingStyle.Bottom;
            this.shape4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.496D));
            this.shape4.Name = "shape4";
            this.shape4.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.shape4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.086D), Telerik.Reporting.Drawing.Unit.Inch(0.052D));
            this.shape4.Style.LineStyle = Telerik.Reporting.Drawing.LineStyle.Dashed;
            // 
            // groupFooterSection
            // 
            this.groupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.208D);
            this.groupFooterSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox14,
            this.textBox32,
            this.textBox22,
            this.textBox30});
            this.groupFooterSection.Name = "groupFooterSection";
            // 
            // textBox14
            // 
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5D), Telerik.Reporting.Drawing.Unit.Inch(0.208D));
            this.textBox14.StyleName = "Normal.TableHeader";
            this.textBox14.Value = "= Fields.FishType";
            // 
            // textBox32
            // 
            this.textBox32.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.5D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2D), Telerik.Reporting.Drawing.Unit.Inch(0.208D));
            this.textBox32.StyleName = "Normal.TableHeader";
            this.textBox32.Value = "= Fields.Preparation";
            // 
            // textBox22
            // 
            this.textBox22.Culture = new System.Globalization.CultureInfo("sr-Latn");
            this.textBox22.Format = "{0:N2}";
            this.textBox22.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.8D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.114D), Telerik.Reporting.Drawing.Unit.Inch(0.208D));
            this.textBox22.Style.Font.Bold = true;
            this.textBox22.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox22.StyleName = "Normal.TableHeader";
            this.textBox22.Value = "= Sum(Fields.DeliveredKg)";
            // 
            // groupHeaderSection
            // 
            this.groupHeaderSection.CanShrink = true;
            this.groupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.052D);
            this.groupHeaderSection.Name = "groupHeaderSection";
            this.groupHeaderSection.Style.Visible = false;
            // 
            // detail
            // 
            this.detail.CanShrink = true;
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.052D);
            this.detail.Name = "detail";
            this.detail.Style.Visible = true;
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.2D);
            this.pageFooterSection1.Name = "pageFooterSection1";
            this.pageFooterSection1.Style.Visible = false;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "Reports.Properties.Settings.TNT";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.Parameters.Add(new Telerik.Reporting.SqlDataSourceParameter("@no", System.Data.DbType.Int32, null));
            this.sqlDataSource1.Parameters.Add(new Telerik.Reporting.SqlDataSourceParameter("@date", System.Data.DbType.AnsiString, "11/14/2021"));
            this.sqlDataSource1.Parameters.Add(new Telerik.Reporting.SqlDataSourceParameter("@time", System.Data.DbType.AnsiString, null));
            this.sqlDataSource1.SelectCommand = "dbo.Order_Report";
            this.sqlDataSource1.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.252D);
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // shape1
            // 
            this.shape1.Docking = Telerik.Reporting.DockingStyle.Top;
            this.shape1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.shape1.Name = "shape1";
            this.shape1.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.shape1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.086D), Telerik.Reporting.Drawing.Unit.Inch(0.052D));
            this.shape1.Style.LineStyle = Telerik.Reporting.Drawing.LineStyle.Dashed;
            // 
            // textBox30
            // 
            this.textBox30.Culture = new System.Globalization.CultureInfo("sr-Latn");
            this.textBox30.Format = "{0:C2}";
            this.textBox30.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.914D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.473D), Telerik.Reporting.Drawing.Unit.Inch(0.208D));
            this.textBox30.Style.Font.Bold = true;
            this.textBox30.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox30.StyleName = "Normal.TableHeader";
            this.textBox30.Value = "= Sum((Fields.DeliveredKg * Fields.PricePerKg))";
            // 
            // textBox31
            // 
            this.textBox31.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.5D), Telerik.Reporting.Drawing.Unit.Inch(0.34D));
            this.textBox31.Name = "textBox31";
            this.textBox31.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2D), Telerik.Reporting.Drawing.Unit.Inch(0.156D));
            this.textBox31.Style.Font.Bold = false;
            this.textBox31.Style.Font.Italic = true;
            this.textBox31.StyleName = "Normal.TableHeader";
            this.textBox31.Value = "Priprema";
            // 
            // textBox27
            // 
            this.textBox27.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.914D), Telerik.Reporting.Drawing.Unit.Inch(0.34D));
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.486D), Telerik.Reporting.Drawing.Unit.Inch(0.156D));
            this.textBox27.Style.Font.Bold = false;
            this.textBox27.Style.Font.Italic = true;
            this.textBox27.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox27.StyleName = "Normal.TableHeader";
            this.textBox27.Value = "Isporučeno Cena";
            // 
            // textBox13
            // 
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.8D), Telerik.Reporting.Drawing.Unit.Inch(0.34D));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.114D), Telerik.Reporting.Drawing.Unit.Inch(0.156D));
            this.textBox13.Style.Font.Bold = false;
            this.textBox13.Style.Font.Italic = true;
            this.textBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox13.StyleName = "Normal.TableHeader";
            this.textBox13.Value = "Isporučeno Kg";
            // 
            // textBox11
            // 
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.34D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4D), Telerik.Reporting.Drawing.Unit.Inch(0.156D));
            this.textBox11.Style.Font.Bold = false;
            this.textBox11.Style.Font.Italic = true;
            this.textBox11.StyleName = "Normal.TableHeader";
            this.textBox11.Value = "Vrsta Ribe";
            // 
            // textBox20
            // 
            this.textBox20.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2D), Telerik.Reporting.Drawing.Unit.Inch(0.24D));
            this.textBox20.Style.Font.Bold = true;
            this.textBox20.Style.Font.Italic = false;
            this.textBox20.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox20.StyleName = "Normal.TableHeader";
            this.textBox20.Value = "Ukupno za dan";
            // 
            // productNrTextBox
            // 
            this.productNrTextBox.Culture = new System.Globalization.CultureInfo("sr-Latn");
            this.productNrTextBox.Format = "{0:d}";
            this.productNrTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2D), Telerik.Reporting.Drawing.Unit.Inch(0.018D));
            this.productNrTextBox.Name = "productNrTextBox";
            this.productNrTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6D), Telerik.Reporting.Drawing.Unit.Inch(0.222D));
            this.productNrTextBox.Style.Font.Bold = true;
            this.productNrTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.productNrTextBox.StyleName = "Normal.DetailBody";
            this.productNrTextBox.Value = "= Fields.DeliveryDate";
            // 
            // textBox1
            // 
            this.textBox1.Culture = new System.Globalization.CultureInfo("sr-Latn");
            this.textBox1.Format = "{0:C2}";
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.914D), Telerik.Reporting.Drawing.Unit.Inch(0.052D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.473D), Telerik.Reporting.Drawing.Unit.Inch(0.208D));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox1.StyleName = "Normal.TableHeader";
            this.textBox1.Value = "= Sum((Fields.DeliveredKg * Fields.PricePerKg))";
            // 
            // textBox2
            // 
            this.textBox2.Culture = new System.Globalization.CultureInfo("sr-Latn");
            this.textBox2.Format = "{0:N2}";
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.8D), Telerik.Reporting.Drawing.Unit.Inch(0.052D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.114D), Telerik.Reporting.Drawing.Unit.Inch(0.208D));
            this.textBox2.Style.Font.Bold = true;
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox2.StyleName = "Normal.TableHeader";
            this.textBox2.Value = "= Sum(Fields.DeliveredKg)";
            // 
            // OrderSubReport
            // 
            group1.GroupFooter = this.groupFooterSection1;
            group1.GroupHeader = this.groupHeaderSection1;
            group1.Name = "group";
            group2.GroupFooter = this.groupFooterSection;
            group2.GroupHeader = this.groupHeaderSection;
            group2.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.FishType + \" \" + Fields.Preparation"));
            group2.Name = "FishType";
            group2.Sortings.Add(new Telerik.Reporting.Sorting("=Fields.FishType", Telerik.Reporting.SortDirection.Asc));
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1,
            group2});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection1,
            this.groupFooterSection1,
            this.groupHeaderSection,
            this.groupFooterSection,
            this.detail,
            this.pageFooterSection1,
            this.pageHeaderSection1});
            this.Name = "OrderSubReport";
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "date";
            reportParameter2.Name = "no";
            reportParameter2.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter3.Name = "srv";
            reportParameter4.Name = "time";
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            this.ReportParameters.Add(reportParameter4);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(7.086D);
            this.NeedDataSource += new System.EventHandler(this.OrderSubReport_NeedDataSource);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection;
        private Telerik.Reporting.GroupFooterSection groupFooterSection;
        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.TextBox textBox32;
        private Telerik.Reporting.TextBox textBox22;
        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.Shape shape4;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection1;
        private Telerik.Reporting.GroupFooterSection groupFooterSection1;
        private Telerik.Reporting.Shape shape1;
        private Telerik.Reporting.TextBox textBox30;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox27;
        private Telerik.Reporting.TextBox textBox31;
        private Telerik.Reporting.TextBox textBox20;
        private Telerik.Reporting.TextBox productNrTextBox;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox1;
    }
}