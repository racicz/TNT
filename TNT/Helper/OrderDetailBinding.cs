using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Helper
{
    public class OrderDetailBinding : INotifyPropertyChanged
    {

        int detailId = 0;
        int fishTypeId;
        decimal orderedKg;
        decimal deliveredKg;
        decimal priceperkg;
        bool przena;
        bool dimljena;
        bool pohovana;
        bool sveza;
        bool ociscena;
        bool dimljenaPrzena;
        bool pecenaRostilj;
        string notes;
        string status;


        public int DetailId
        {
            get { return detailId; }
            set
            {
                detailId = value;
                OnPropertyChanged("DetailId");

            }
        }

        public int FishTypeId
        {
            get { return fishTypeId; }
            set
            {
                fishTypeId = value;
                OnPropertyChanged("FishTypeId");

            }
        }

        public decimal OrderedKg
        {
            get { return orderedKg; }
            set
            {
                if (value != orderedKg)
                {
                    orderedKg = value;
                    OnPropertyChanged("OrderedKg");
                }

            }
        }

        public decimal DeliveredKg
        {
            get { return deliveredKg; }
            set
            {
                if (value != deliveredKg)
                {
                    deliveredKg = value;
                    OnPropertyChanged("DeliveredKg");
                }

            }
        }

        public bool Przena
        {
            get { return przena; }
            set
            {
                if (value != przena)
                {
                    przena = value;
                    OnPropertyChanged("Przena");
                }

            }
        }

        public bool Dimljena
        {
            get { return dimljena; }
            set
            {
                if (value != dimljena)
                {
                    dimljena = value;
                    OnPropertyChanged("Dimljena");
                }

            }
        }

        public bool Pohovana
        {
            get { return pohovana; }
            set
            {
                if (value != pohovana)
                {
                    pohovana = value;
                    OnPropertyChanged("Pohovana");
                }

            }
        }

        public bool Sveza
        {
            get { return sveza; }
            set
            {
                if (value != sveza)
                {
                    sveza = value;
                    OnPropertyChanged("Sveza");
                }

            }
        }

        public bool Ociscena
        {
            get { return ociscena; }
            set
            {
                if (value != ociscena)
                {
                    ociscena = value;
                    OnPropertyChanged("Ociscena");
                }

            }
        }

        public bool DimljenaPrzena
        {
            get { return dimljenaPrzena; }
            set
            {
                if (value != dimljenaPrzena)
                {
                    dimljenaPrzena = value;
                    OnPropertyChanged("DimljenaPrzena");
                }

            }
        }

        public bool PecenaRostilj
        {
            get { return pecenaRostilj; }
            set
            {
                if (value != pecenaRostilj)
                {
                    pecenaRostilj = value;
                    OnPropertyChanged("PecenaRostilj");
                }

            }
        }

        public string Notes
        {
            get { return notes; }
            set
            {
                if (value != null && value.Length > 0)
                {
                    notes = value;
                    OnPropertyChanged("Notes");
                }

            }
        }

        public string Status
        {
            get { return status; }
            set
            {
                if (value != null && value.Length > 0)
                {
                    status = value;
                    OnPropertyChanged("Status");
                }

            }
        }

        public decimal PricePerKg
        {
            get { return priceperkg; }
            set
            {
                priceperkg = value;
                OnPropertyChanged("PricePerKg");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
