using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using TNT.Views;
using TNT_Library;
using TNT_Model;
using TNT_Model.Response;

namespace TNT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ContactPerson> contacts;
        List<Town> towns;
        List<Status> status;
        Service vServer = new Service();
        RadGridView child;

        public MainWindow()
        {
            InitializeComponent();
            LoadContacts();
            LoadStatus();
            LoadTowns();
        }

        private void LoadContacts()
        {
            contacts = vServer.GetContacts;
            cboContact.ItemsSource = contacts;
        }

        
        private void btnMnuOpt_Click(object sender, RoutedEventArgs e)
        {
            OptOrderMenu.PlacementRectangle = new Rect(new Point(0, btnMnuOpt.RenderSize.Height), new Size(0, 0));
            OptOrderMenu.IsOpen = true;
        }

        private void btnOptions_Click(object sender, RoutedEventArgs e)
        {
            OptMenu.PlacementRectangle = new Rect(new Point(0, btnOptions.RenderSize.Height), new Size(0, 0));
            OptMenu.IsOpen = true;
        }

        private void dgOrder_RowActivated(object sender, RowEventArgs e)
        {
            editOrder(((sender as RadGridView).SelectedItem as TNT_Model.Order));
        }

        private void rmiNewOrder_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            Views.Order ord = new Views.Order();
            ord.Closing += Ord_Closing;
            ord.ShowDialog();
        }

        private void rmiUpdOrder_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (child != null && child.SelectedItem != null)
            {
                editOrder((child.SelectedItem as TNT_Model.Order));
            }
            else
            {
                MessageBox.Show("Poruđžbina nije izabrana", "Izaberi Poruđžbinu!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        void editOrder(TNT_Model.Order order)
        {
            Views.Order ord = new Views.Order(order, (dgPerson.SelectedItem as Search).Person);
            ord.Closing += Ord_Closing;
            ord.ShowDialog();
        }

        private void Ord_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LoadContacts();
            dgPerson.DataContext = null;
            dgDetails.DataContext = null;
        }

        private void LoadTowns()
        {
            towns = vServer.GetTowns;
            cboTowns.ItemsSource = towns;
        }

        private void LoadStatus()
        {
            status = vServer.GetStatus;
            cboStatus.ItemsSource = status;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }

        void Search()
        {
            spinner.Visibility = Visibility.Visible;
            string search = txtAccountNo.Text.Length == 0 ? GetSerachData : string.Format(" OrderNUmber = {0} ", txtAccountNo.Text);
            dgDetails.DataContext = null;

            List<Search> response = null;

            Task.Factory.StartNew(() =>
            {
                if (search.Length == 0)
                    response = vServer.GetSearchResults(string.Empty);
                else
                    response = vServer.GetSearchResults("Where " + search);

            }).ContinueWith(Task =>
            {
                this.dgPerson.DataContext = response;

                if (response != null && response.Count == 1)
                {
                    dgPerson.SelectedItem = response.FirstOrDefault();
                    dgPerson.RowDetailsVisibilityMode = GridViewRowDetailsVisibilityMode.Visible;
                }
                
                spinner.Visibility = Visibility.Hidden;
            }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());

            
            
        }

        private void ClearData()
        {
            dgPerson.DataContext = null;
            dgDetails.DataContext = null;
            this.txtAccountNo.Text = string.Empty;
            this.cboContact.Text = string.Empty;
            this.cboTowns.Text = string.Empty;
            this.dpOrderStart.SelectedValue = null;
            this.dpOrderEnd.SelectedValue = null;
            this.cboStatus.Text = string.Empty;
        }

        string GetSerachData
        {
            get
            {
                string _where = string.Empty;

                if (this.txtAccountNo.Text.Trim().Length > 0)
                    _where += string.Format("OrderNumber = {0} ", txtAccountNo.Text);

                if (this.cboContact.Text != null && this.cboContact.Text.Trim().Length > 0)
                {
                    if (_where.Length == 0)
                        _where += string.Format(" Name like '%{0}%' ", this.cboContact.Text);
                    else
                        _where += string.Format(" and Name like '%{0}%' ", this.cboContact.Text);
                }

                if (this.cboTowns.Text != null && this.cboTowns.Text.Trim().Length > 0)
                {
                    if (_where.Length == 0)
                        _where += string.Format(" TownName like '%{0}%' ", cboTowns.Text);
                    else
                        _where += string.Format(" and TownName like '%{0}%' ", cboTowns.Text);
                }


                if (this.dpOrderStart.SelectedValue != null && this.dpOrderStart.SelectedValue.ToString().Trim().Length > 0 && this.dpOrderEnd.SelectedValue != null && this.dpOrderEnd.SelectedValue.ToString().Trim().Length > 0)
                {
                    if (_where.Length == 0)
                        _where += string.Format(" Convert(date,ord.DeliveryDate) >= '{0}' and Convert(date,ord.DeliveryDate) <= '{1}'", Convert.ToDateTime(this.dpOrderStart.SelectedValue).ToString("d"), Convert.ToDateTime(this.dpOrderEnd.SelectedValue).ToString("d"));
                    else
                        _where += string.Format(" and Convert(date,ord.DeliveryDate) >= '{0}' and Convert(date,ord.DeliveryDate) <= '{1}'", Convert.ToDateTime(this.dpOrderStart.SelectedValue).ToString("d"), Convert.ToDateTime(this.dpOrderEnd.SelectedValue).ToString("d"));

                }


                if (this.cboStatus.Text != null && this.cboStatus.Text != null && this.cboStatus.Text.Trim().Length > 0)
                {
                    if (_where.Length == 0)
                        _where = string.Format(" ord.OrderId in (Select OrderId From OrderDetail where StatusId = {0}) ", (cboStatus.SelectedItem as Status).StatusId);
                    else
                        _where += string.Format(" and ord.OrderId in (Select OrderId From OrderDetail where StatusId = {0}) ", (cboStatus.SelectedItem as Status).StatusId);
                }


                return _where;
            }
        }


        private void dgPerson_LoadingRowDetails(object sender, Telerik.Windows.Controls.GridView.GridViewRowDetailsEventArgs e)
        {
            const int buffer = 50;

            FrameworkElement details = e.DetailsElement as FrameworkElement;
            RadGridView gridView = sender as RadGridView;
            e.DetailsElement.Width = gridView.ActualWidth - buffer;
            child = (e.DetailsElement as RadGridView);
            gridView.SizeChanged += new SizeChangedEventHandler((object obj, SizeChangedEventArgs args) => e.DetailsElement.Width = gridView.ActualWidth - buffer);
        }

        private void tbOrder_Checked(object sender, RoutedEventArgs e)
        {
            (sender as ToggleButton).Content = "-";

            var button = sender as ToggleButton;
            var row = button.ParentOfType<GridViewRow>();

            if (row != null)
            {
                row.DetailsVisibility = Visibility.Visible;
                row.IsSelected = true;
               
            }
                
        }

        private void tbOrder_Unchecked(object sender, RoutedEventArgs e)
        {
            (sender as ToggleButton).Content = "+";

            var button = sender as ToggleButton;
            var row = button.ParentOfType<GridViewRow>();

            if (row != null)
            {
                row.IsSelected = false;
                row.DetailsVisibility = Visibility.Collapsed;
            }
               
        }

        private void dgOrder_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            rmiDelOrder.IsEnabled =  rmiUpdOrder.IsEnabled = ((sender as RadGridView).SelectedItem != null);

            child = (sender as RadGridView);
            child.SelectedItem = (sender as RadGridView).SelectedItem;

            if (child != null && child.SelectedItem != null)
            {
                LoadDetails();
            }

            
            GridViewRow parentRow = child.ParentRow as GridViewRow;
            parentRow.IsSelected = true;
        }

        void LoadDetails()
        {
            var orderDetails = vServer.GetOrderDetails((child.SelectedItem as TNT_Model.Order).OrderId);
            (child.SelectedItem as TNT_Model.Order).OrderDetails = orderDetails;
            dgDetails.DataContext = orderDetails;
        }
        private void rmiNewAccount_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            FishPrice fp = new FishPrice();
            fp.ShowDialog();
        }

        private void rmiDelOrder_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (child != null && child.SelectedItem != null)
            {
                if (MessageBox.Show("Izbrisi Poruđžbinu?", "Da li ste sigurni?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    var order = (child.SelectedItem as TNT_Model.Order);

                    if (order.OrderDetails != null)
                    {
                        order.Person = (dgPerson.SelectedItem as Search).Person;
                        order.SubjectId = (dgPerson.SelectedItem as Search).Person.SubjectId;
                        order.OrderDetails.ForEach(t => t.Action = "D");
                        Response rsp = vServer.IsOrderSaved(order);

                        if (!rsp.Return)
                            MessageBox.Show(rsp.Msg, "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                        else
                        {

                            order.Action = "D";
                            child.Rebind();
                            dgDetails.DataContext = null;
                            MessageBox.Show("Poruđžbina izbrisana.", "Sacuvano!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Poruđžbina nije izabrana", "Izaberi Poruđžbinu!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }


        private void rmiIspo_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (!ChangeStatus(3))
            {
                MessageBox.Show("Status nije promenjen.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void rmiIspoPaid_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (!ChangeStatus(6))
                MessageBox.Show("Status nije promenjen.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void rmiCancel_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (!ChangeStatus(5))
            {
                MessageBox.Show("Status nije promenjen.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        bool ChangeStatus(int statusId)
        {
            if (child != null && child.SelectedItem != null)
            {
                var isUpdated =  vServer.IsStatusChanged((child.SelectedItem as TNT_Model.Order), statusId).Return;
                Search();
                LoadDetails();
                return isUpdated;
            }
            else
            {
                MessageBox.Show("Poruđžbina nije izabrana", "Izaberi Poruđžbinu!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return true;
            }

        }

        private void dpTo_DropDownClosed(object sender, RoutedEventArgs e)
        {
            if (dpTo.SelectedValue != null)
            {
                string date = Convert.ToDateTime(dpTo.SelectedValue).ToString("d");
                string time = dpTime.SelectedValue != null ? Convert.ToDateTime(dpTime.SelectedValue).ToString("t") : string.Empty;

                ReportViewer cwNR = new ReportViewer("ORDER", ConfigurationManager.ConnectionStrings["TNT.Conn"].ConnectionString, 0, date, time);
                cwNR.ShowDialog();
                dpTo.SelectedValue = null;
                dpTime.SelectedValue = null;
            }
            else
                MessageBox.Show("Unesite datum.", "Datum Obavezan", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void dpDetDate_DropDownClosed(object sender, RoutedEventArgs e)
        {
            if (dpDetDate.SelectedValue != null)
            {
                string date = Convert.ToDateTime(dpDetDate.SelectedValue).ToString("d");
                string time = dpDetTime.SelectedValue != null ? Convert.ToDateTime(dpDetTime.SelectedValue).ToString("t") : string.Empty;

                ReportViewer cwNR = new ReportViewer("DETAIL", ConfigurationManager.ConnectionStrings["TNT.Conn"].ConnectionString, 0, date, time);
                cwNR.ShowDialog();
                dpDetDate.SelectedValue = null;
                dpDetTime.SelectedValue = null;
            }
            else
                MessageBox.Show("Unesite datum.", "Datum Obavezan", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void btnMnuClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void txtAccountNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Search();
            }
        }

        private void rmiBackup_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog openFileDlg = new System.Windows.Forms.FolderBrowserDialog();
            var result = openFileDlg.ShowDialog();
            if (result.ToString() != string.Empty && !string.IsNullOrEmpty(openFileDlg.SelectedPath))
            {

                spinner.Visibility = Visibility.Visible;
                Task.Factory.StartNew(() =>
                {
                    var response = vServer.IsDatabaseBackedUp(openFileDlg.SelectedPath);
                    MessageBox.Show(response.Msg, "Backup", MessageBoxButton.OK, MessageBoxImage.Information);
                }).ContinueWith(Task =>
                {
                    spinner.Visibility = Visibility.Hidden;
                }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
                
            }
            
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
        }
    }
}
