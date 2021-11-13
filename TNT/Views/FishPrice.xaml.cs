using System;
using System.Collections.Generic;
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
using TNT_Library;
using TNT_Model;
using TNT_Model.Response;

namespace TNT.Views
{
    /// <summary>
    /// Interaction logic for FishPrice.xaml
    /// </summary>
    public partial class FishPrice : Window
    {
        List<FishType> fishTypes;
        List<Preparation> preparations;
        Service vServer = new Service();

        public FishPrice()
        {
            InitializeComponent();
            LoadFishTypes();
            LoadPreparations();
        }

        private void LoadFishTypes()
        {
            fishTypes = vServer.GetFishType;
            dgDetail.DataContext = fishTypes;
        }

        private void LoadPreparations()
        {
            preparations = vServer.GetPreparations();
            cboPreparations.ItemsSource = preparations;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgDetail_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            if (dgDetail.SelectedItem != null)
            {
                txtFish.Text = (dgDetail.SelectedItem as FishType).Description;
                txtPrice.Value = (dgDetail.SelectedItem as FishType).Price;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFish.Text))
            {
                FishType ft = new FishType()
                {
                    FishTypeId = 0,
                    Description = txtFish.Text,
                    Price = txtPrice.Value != null ?  Convert.ToDecimal(txtPrice.Value) : 0,
                    Preparations = preparations.Where(t=>t.IsSelected == true).ToList(),
                    Status = "A"             
                };

                Response rsp = vServer.IsFishTypeSaved(ft);

                if (!rsp.Return)
                    MessageBox.Show(rsp.Msg, "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    MessageBox.Show("Vrsta ribe sacuvana.", "Sacuvano!", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadFishTypes();
                    ClearScreen();
                }
            }
            else
            {
                MessageBox.Show("Vrsta ribe je obavezno polje.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        void ClearScreen()
        {
            txtFish.Text = string.Empty;
            txtPrice.Value = 0;
            dgDetail.SelectedItem = null;

            if (preparations != null)
                preparations.ForEach(t => t.IsSelected = false);

            cboPreparations.ItemsSource = null;
            cboPreparations.ItemsSource = preparations;
        }

        private void btnUpd_Click(object sender, RoutedEventArgs e)
        {
            if (dgDetail.SelectedItem != null)
            {
                if (!string.IsNullOrEmpty(txtFish.Text))
                {

                    FishType ft = new FishType()
                    {
                        FishTypeId = (dgDetail.SelectedItem as FishType).FishTypeId,
                        Description = txtFish.Text,
                        Price = txtPrice.Value != null ? Convert.ToDecimal(txtPrice.Value) : 0,
                        Preparations = preparations.Where(t => t.IsSelected == true).ToList(),
                        Status = "U"
                    };

                    Response rsp = vServer.IsFishTypeSaved(ft);

                    if (!rsp.Return)
                        MessageBox.Show(rsp.Msg, "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                    {
                        MessageBox.Show("Vrsta ribe je azurirana.", "Sacuvano!", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadFishTypes();
                        ClearScreen();
                    }
                }
                else
                {
                    MessageBox.Show("Vrsta ribe je obavezno polje.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
                MessageBox.Show("Izaberite vrstu ribe.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (dgDetail.SelectedItem != null)
            {

                FishType ft = new FishType()
                {
                    FishTypeId = (dgDetail.SelectedItem as FishType).FishTypeId,
                    Description = txtFish.Text,
                    Price = txtPrice.Value != null ? Convert.ToDecimal(txtPrice.Value) : 0,
                    Status = "D"
                };

                Response rsp = vServer.IsFishTypeSaved(ft);

                if (!rsp.Return)
                    MessageBox.Show(rsp.Msg, "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    MessageBox.Show("Vrsta ribe je izbrisana.", "Sacuvano!", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadFishTypes();
                    ClearScreen();
                }

            }
            else
                MessageBox.Show("Izaberite vrstu ribe.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void cboPreparations_DropDownClosed(object sender, EventArgs e)
        {
            int index = 0;

            foreach (Preparation ptype in preparations)
            {
                if (ptype.IsSelected)
                {
                    cboPreparations.SelectedIndex = index;
                    cboPreparations.SelectedItem = ptype;

                    break;
                }

                index++;
            }

            

            if (preparations != null && preparations.Where(t => t.IsSelected == true).Count() == 0)
            {
                cboPreparations.SelectedItem = null;
                cboPreparations.Text = string.Empty;
            }
        }
    }
}
