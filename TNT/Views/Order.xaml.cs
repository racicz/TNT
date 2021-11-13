using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using TNT.Helper;
using TNT_Library;
using TNT_Model;
using TNT_Model.Response;

namespace TNT.Views
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        OrderBinding ordBind;
        OrderDetailBinding ordDetailBind;
        List<FishType> fishTypes;
        List<Status> status;
        List<ContactPerson> contacts;
        List<Town> towns;
        ObservableCollection<OrderDetail> details = new ObservableCollection<OrderDetail>();
        Service vServer = new Service();

        public Order()
        {
            InitializeComponent();
            InitializeOrder();
        }

        public Order(TNT_Model.Order editOrder, Person person)
        {
            InitializeComponent();
            InitializeOrder();

            LoadOrder(editOrder, person);
        }

        private void LoadOrder(TNT_Model.Order editOrder, Person person)
        {
            CultureInfo ci = new CultureInfo("sr-Latn");
            var orderDate = Convert.ToDateTime(editOrder.OrderDate, ci);
            var delDate = Convert.ToDateTime(editOrder.DeliveryDate, ci);
            var orderTime = Convert.ToDateTime(editOrder.OrderTime,ci);
            var delTime = Convert.ToDateTime(editOrder.DeliveryTime, ci);

            ordBind.OrderId = editOrder.OrderId;
            ordBind.OrderNumber = editOrder.OrderNumber;
            ordBind.OrderDate = orderDate;
            ordBind.OrderTime = orderTime;
            ordBind.DeliveryDate = delDate;
            ordBind.DeliveryTime = delTime;

            ordBind.Name = person.Name;
            ordBind.Town = person.Town;
            ordBind.HomePhone = person.HomePhone ?? string.Empty;
            ordBind.CellPhone = person.CellPhone ?? string.Empty;

            details = new ObservableCollection<OrderDetail>(editOrder.OrderDetails);
            dgDetail.DataContext = details;
        }

        private void InitializeOrder()
        {
            Bindings();
            LoadFishTypes();
            LoadStatus();
            LoadTowns();
            LoadContacts();
            LoadDefault();
        }

        private void LoadDefault()
        {
            ordDetailBind.Status = "Poruceno";
            ordBind.DeliveryDate = DateTime.Today.AddDays(1);
            ordBind.DeliveryTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,8,0,0);

            ordBind.OrderDate = DateTime.Today;
            ordBind.OrderTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
        }

        void Bindings()
        {
            ordBind = null;
            ordBind = new OrderBinding();
            grdOrder.DataContext = ordBind;

            ordDetailBind = null;
            ordDetailBind = new OrderDetailBinding();
            grdOrderDetail.DataContext = ordDetailBind;

            details = null;
            details = new ObservableCollection<OrderDetail>();
            dgDetail.DataContext = details;
        }

        private void LoadTowns()
        {
            towns = vServer.GetTowns;
            cboTowns.ItemsSource = towns;
        }

        private void LoadContacts()
        {
            contacts = vServer.GetContacts;
            cboContact.ItemsSource = contacts;
        }

        private void LoadAutoNumber()
        {
            ordBind.OrderNumber = vServer.GetNextAutoNumber.ToString();
        }

        private void LoadStatus()
        {
            status = vServer.GetStatus;
            cboStatus.ItemsSource = status;
        }

        private void LoadFishTypes()
        {
            fishTypes = vServer.GetFishType;
            cboFishTypes.ItemsSource = fishTypes;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (IsDetailFormValid.Length == 0)
            {

                if (dgDetail.SelectedItem != null && (dgDetail.SelectedItem as OrderDetail).FishTypeId == ordDetailBind.FishTypeId)
                {
                    var detail = details.Where(t => t.FishTypeId == ordDetailBind.FishTypeId).FirstOrDefault();

                    if (detail != null)
                    {
                        detail.OrderDetailId = ordDetailBind.DetailId;
                        detail.FishTypeId = ordDetailBind.FishTypeId;
                        detail.FishType = new FishType()
                        {
                            Description = cboFishTypes.Text,
                            Price = (cboFishTypes.SelectedItem as FishType).Price,
                            Preparations = GetPreparationList
                        };
                        detail.StatusId = cboStatus.SelectedItem != null ? (cboStatus.SelectedItem as Status).StatusId : 1;
                        detail.Status = new Status()
                        {
                            StatusId = cboStatus.SelectedItem != null ? (cboStatus.SelectedItem as Status).StatusId : 1,
                            Description = ordDetailBind.Status
                        };
                        detail.OrderKg = ordDetailBind.OrderedKg;
                        detail.PricePerKg = ordDetailBind.PricePerKg;
                        detail.DeliveredKg = ordDetailBind.DeliveredKg;
                        detail.Notes = ordDetailBind.Notes;
                        detail.AmountDue = (ordDetailBind.PricePerKg * ordDetailBind.OrderedKg);
                        detail.AmountPaid = (ordDetailBind.PricePerKg * ordDetailBind.DeliveredKg);
                        detail.Preparations = GetPreparations;
                        detail.Action = "U";
                    }

                    dgDetail.Rebind();

                }
                else
                {
                    details.Add(new OrderDetail()
                    {
                        OrderDetailId = 0,
                        FishTypeId = ordDetailBind.FishTypeId,
                        FishType = new FishType()
                        {
                            Description = cboFishTypes.Text,
                            Price = (cboFishTypes.SelectedItem as FishType).Price,
                            Preparations = GetPreparationList
                        },
                        StatusId = cboStatus.SelectedItem != null ? (cboStatus.SelectedItem as Status).StatusId : 1,
                        Status = new Status()
                        {
                            StatusId = cboStatus.SelectedItem != null ? (cboStatus.SelectedItem as Status).StatusId : 1,
                            Description = ordDetailBind.Status
                        },
                        OrderKg = ordDetailBind.OrderedKg,
                        PricePerKg = ordDetailBind.PricePerKg,
                        DeliveredKg = ordDetailBind.DeliveredKg,
                        Notes = ordDetailBind.Notes,
                        AmountDue = (ordDetailBind.PricePerKg * ordDetailBind.OrderedKg),
                        AmountPaid = (ordDetailBind.PricePerKg * ordDetailBind.DeliveredKg),
                        Preparations = GetPreparations,
                        Action = "A"
                    });
                }

                clearDetails();
                ordDetailBind.Status = "Poručeno";

            }
            else
                MessageBox.Show(IsDetailFormValid, "Nedostatak Informacija", MessageBoxButton.OK);

        }

        private void btnUpd_Click(object sender, RoutedEventArgs e)
        {
            if (IsDetailFormValid.Length == 0)
            {
                if (ordDetailBind.DetailId > 0)
                {
                    var detail = details.Where(t => t.OrderDetailId == ordDetailBind.DetailId).FirstOrDefault();

                    if (detail != null)
                    {
                        detail.OrderDetailId = ordDetailBind.DetailId;
                        detail.FishTypeId = ordDetailBind.FishTypeId;
                        detail.FishType = new FishType()
                        {
                            Description = cboFishTypes.Text,
                            Price = (cboFishTypes.SelectedItem as FishType).Price,
                            Preparations = GetPreparationList
                        };
                        detail.StatusId = cboStatus.SelectedItem != null ? (cboStatus.SelectedItem as Status).StatusId : 1;
                        detail.Status = new Status()
                        {
                            StatusId = cboStatus.SelectedItem != null ? (cboStatus.SelectedItem as Status).StatusId : 1,
                            Description = ordDetailBind.Status
                        };
                        detail.OrderKg = ordDetailBind.OrderedKg;
                        detail.PricePerKg = ordDetailBind.PricePerKg;
                        detail.DeliveredKg = ordDetailBind.DeliveredKg;
                        detail.Notes = ordDetailBind.Notes;
                        detail.AmountDue = (ordDetailBind.PricePerKg * ordDetailBind.OrderedKg);
                        detail.AmountPaid = (ordDetailBind.PricePerKg * ordDetailBind.DeliveredKg);
                        detail.Preparations = GetPreparations;
                        detail.Action = "U";
                    }

                    dgDetail.Rebind();
                    dgDetail.SelectedItem = null;
                    ordDetailBind = null;
                    ordDetailBind = new OrderDetailBinding();
                    grdOrderDetail.DataContext = ordDetailBind;
                }
            }
        }

        string GetPreparations
        {
            get
            {
                string preparations = string.Empty;

                if (ordDetailBind.Pohovana || ordDetailBind.Przena || ordDetailBind.Dimljena || ordDetailBind.Sveza || ordDetailBind.Ociscena)
                {
                    if (ordDetailBind.Przena)
                        preparations = "1";

                    if (ordDetailBind.Dimljena)
                        if (!string.IsNullOrEmpty(preparations))
                            preparations += ",2";
                        else
                            preparations = "2";

                    if (ordDetailBind.Pohovana)
                        if (!string.IsNullOrEmpty(preparations))
                            preparations += ",3";
                        else
                            preparations = "3";

                    if (ordDetailBind.Sveza)
                        if (!string.IsNullOrEmpty(preparations))
                            preparations += ",4";
                        else
                            preparations = "4";

                    if (ordDetailBind.Ociscena)
                        if (!string.IsNullOrEmpty(preparations))
                            preparations += ",5";
                        else
                            preparations = "5";
                }

                if (!preparations.EndsWith(","))
                    preparations += ",";

                return preparations;
            }
        }

        List<Preparation> GetPreparationList
        {
            get
            {
                List<Preparation> preparations = new List<Preparation>();

                if (ordDetailBind.Pohovana || ordDetailBind.Przena || ordDetailBind.Dimljena || ordDetailBind.Sveza || ordDetailBind.Ociscena)
                {
                    if (ordDetailBind.Przena)
                        preparations.Add(new Preparation()
                        {
                            PreparationId = 1,
                            Description = "Przena"
                        });

                    if (ordDetailBind.Dimljena)
                        preparations.Add(new Preparation()
                        {
                            PreparationId = 2,
                            Description = "Dimljena"
                        });

                    if (ordDetailBind.Pohovana)
                        preparations.Add(new Preparation()
                        {
                            PreparationId = 3,
                            Description = "Pohovana"
                        });

                    if (ordDetailBind.Sveza)
                        preparations.Add(new Preparation()
                        {
                            PreparationId = 4,
                            Description = "Sveza"
                        });

                    if (ordDetailBind.Ociscena)
                        preparations.Add(new Preparation()
                        {
                            PreparationId = 5,
                            Description = "Ociscena"
                        });
                }


                return preparations;
            }
        }

        void clearDetails()
        {
            ordDetailBind = null;
            ordDetailBind = new OrderDetailBinding();
            grdOrderDetail.DataContext = ordDetailBind;

            btnAdd.Content = "Dodaj";
            dgDetail.SelectedItem = null;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (IsFormValid.Length == 0)
            {
                TNT_Model.Order newOrder = new TNT_Model.Order()
                {
                    OrderId = ordBind.OrderId,
                    OrderNumber = ordBind.OrderNumber,
                    OrderDate = Convert.ToDateTime(ordBind.OrderDate).ToString("d"),
                    OrderTime = Convert.ToDateTime(ordBind.OrderTime).ToString("t"),
                    DeliveryDate = Convert.ToDateTime(ordBind.DeliveryDate).ToString("d"),
                    DeliveryTime = Convert.ToDateTime(ordBind.DeliveryTime).ToString("t"),
                    SubjectId = cboContact.SelectedItem != null ? (cboContact.SelectedItem as ContactPerson).Person.SubjectId : 0,
                    Person = new Person()
                    {
                        Name = ordBind.Name,
                        Town = ordBind.Town ?? string.Empty,
                        HomePhone = ordBind.HomePhone ?? string.Empty,
                        CellPhone = ordBind.CellPhone ?? string.Empty,
                        Email = ordBind.EmailAddress ?? string.Empty,
                    },
                    OrderDetails = details.ToList()
                };

                Response rsp =  vServer.IsOrderSaved(newOrder);

                if (!rsp.Return)
                    MessageBox.Show(rsp.Msg, "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    MessageBox.Show("Poruđžbina sacuvana.", "Sacuvano!", MessageBoxButton.OK, MessageBoxImage.Information);
                    InitializeOrder();
                }
            }
            else
                MessageBox.Show(IsFormValid, "Nedostatak Informacija.", MessageBoxButton.OK);
        }

        string IsFormValid
        {
            get
            {
                if (string.IsNullOrEmpty(ordBind.Name))
                    return "Ime I Prezime je obavezno polje.";

                if (ordBind.OrderDate == null)
                    return "Datum Poruđžbine je obavezno polje.";

                if (ordBind.OrderTime == null)
                    return "Vreme Poruđžbine je obavezno polje.";

                if (string.IsNullOrEmpty(ordBind.OrderNumber))
                    return "Broj Poruđžbine je obavezno polje.";

                if (details == null || details.Count() == 0)
                    return "Detalji Poruđžbine nisu uneseni.";

                if (ordBind.DeliveryDate == null)
                    return "Datum isporuke je obavezno polje.";

                if (ordBind.DeliveryTime == null)
                    return "Vreme isporuke je obavezno polje.";

                return string.Empty;
            }
        }

        string IsDetailFormValid
        {
            get
            {
                if (ordDetailBind.FishTypeId == 0)
                    return "Vrsta ribe je obavezno polje.";

                if (ordDetailBind.OrderedKg == 0)
                    return "Poruceno kg nije uneseno.";


                if (string.IsNullOrEmpty(ordDetailBind.Status))
                    return "Status je obavezno polje.";

                return string.Empty;
            }
        }

        private void cboContact_DropDownClosed(object sender, EventArgs e)
        {
            if (cboContact.SelectedItem != null)
            {
                clearOrder();
                ordBind.OrderNumber = (cboContact.SelectedItem as ContactPerson).LastOrderNumber > 0 ? (cboContact.SelectedItem as ContactPerson).LastOrderNumber.ToString() : ordBind.OrderNumber;
                ordBind.Town = (cboContact.SelectedItem as ContactPerson).Person.Town;

                List<Contact> contacts = vServer.GetSubjectContact((cboContact.SelectedItem as ContactPerson).Person.SubjectId);

                if (contacts != null && contacts.Count() > 0)
                {
                    contacts.ForEach(t =>
                    {
                        ordBind.HomePhone = t.SubjectContactTypeId == 1 ? t.ContactValue : string.Empty;
                        ordBind.CellPhone = t.SubjectContactTypeId == 2 ? t.ContactValue : string.Empty;
                        ordBind.EmailAddress = t.SubjectContactTypeId == 3 ? t.ContactValue : string.Empty;
                    });

                }
            }
        }
        
        void clearOrder()
        {
            ordBind.OrderNumber = string.Empty;
            ordBind.Town = string.Empty;
            ordBind.HomePhone = string.Empty;
            ordBind.CellPhone = string.Empty;
        }

        private void cboFishTypes_DropDownClosed(object sender, EventArgs e)
        {
            if (cboFishTypes.SelectedItem != null)
                setFishTypeSelected = (cboFishTypes.SelectedItem as FishType);

            txtOrderKg.Focus();
        }

        FishType setFishTypeSelected
        {
            set
            {
                ordDetailBind.PricePerKg = value.Price;
                ordDetailBind.Przena = false;
                ordDetailBind.Dimljena = false;
                ordDetailBind.Pohovana = false;
                ordDetailBind.Sveza = false;
                ordDetailBind.Ociscena = false;

                if (value.Preparations != null)
                {
                    value.Preparations.ForEach(t =>
                    {
                        if (t.Description.ToUpper() == "PRZENA")
                            ordDetailBind.Przena = true;

                        if (t.Description.ToUpper() == "DIMLJENA")
                            ordDetailBind.Dimljena = true;

                        if (t.Description.ToUpper() == "POHOVANA")
                            ordDetailBind.Pohovana = true;

                        if (t.Description.ToUpper() == "SVEZA")
                            ordDetailBind.Sveza = true;

                        if (t.Description.ToUpper() == "OCISCENA")
                            ordDetailBind.Ociscena = true;
                    });
                }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnNewNumber_Click(object sender, RoutedEventArgs e)
        {
            LoadAutoNumber();
        }

        private void dgDetail_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            if (dgDetail.SelectedItem != null)
            {
                var fid = (dgDetail.SelectedItem as OrderDetail).FishTypeId;

                if (fishTypes != null && fishTypes.Where(t => t.FishTypeId == fid).Count() == 0)
                {
                    fishTypes.Add(new FishType()
                    {
                        FishTypeId = fid,
                        Description = (dgDetail.SelectedItem as OrderDetail).FishType.Description,
                        Price = (dgDetail.SelectedItem as OrderDetail).FishType.Price
                    });
                }

                ordDetailBind.FishTypeId = fid;
                setFishTypeSelected = (dgDetail.SelectedItem as OrderDetail).FishType;
                ordDetailBind.DetailId = (dgDetail.SelectedItem as OrderDetail).OrderDetailId;
                ordDetailBind.OrderedKg = Convert.ToDecimal((dgDetail.SelectedItem as OrderDetail).OrderKg.ToString("#.00"));
                ordDetailBind.DeliveredKg = Convert.ToDecimal((dgDetail.SelectedItem as OrderDetail).DeliveredKg.ToString("#.00"));
                ordDetailBind.PricePerKg = Convert.ToDecimal((dgDetail.SelectedItem as OrderDetail).PricePerKg.ToString("#.00"));
                ordDetailBind.Notes = (dgDetail.SelectedItem as OrderDetail).Notes;
                ordDetailBind.Status = (dgDetail.SelectedItem as OrderDetail).Status.Description;

                btnDel.Visibility = Visibility.Visible;
                btnUpd.Visibility = Visibility.Visible;
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (dgDetail.SelectedItem != null)
            {
                if ((dgDetail.SelectedItem as OrderDetail).OrderDetailId > 0)
                    (dgDetail.SelectedItem as OrderDetail).Action = "D";
                else
                    details.Remove((dgDetail.SelectedItem as OrderDetail));

                dgDetail.DataContext = details;
                dgDetail.Rebind();
            }
        }

        
    }
}
