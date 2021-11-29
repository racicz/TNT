using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Helper
{
    public class OrderBinding : INotifyPropertyChanged
    {
        int orderId = 0;
        string orderNumber;
        string name;
        string company;
        string town;
        string homePhone;
        string workPhone;
        string emailAddress;
        bool isreadonly = true;
        DateTime? deliveryDate;
        DateTime? deliveryTime;


        public int OrderId
        {
            get { return orderId; }
            set
            {
                orderId = value;
                OnPropertyChanged("OrderId");
            }
        }

        public DateTime? DeliveryDate
        {
            get { return deliveryDate; }
            set
            {
                
                deliveryDate = value;
                OnPropertyChanged("DeliveryDate");

            }
        }

        public DateTime? DeliveryTime
        {
            get { return deliveryTime; }
            set
            {

                deliveryTime = value;
                OnPropertyChanged("DeliveryTime");

            }
        }

        [Display(Name = "Type of Ownership")]
        public string OrderNumber
        {
            get { return orderNumber; }
            set
            {
                orderNumber = value;
                OnPropertyChanged("OrderNumber");
            }
        }

       

        public string Name
        {
            get { return name; }
            set
            {
                if (value != null && value.Length > 0)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }

            }
        }

        public string Company
        {
            get { return company; }
            set
            {
                if (value != null && value.Length > 0)
                {
                    company = value;
                    OnPropertyChanged("Company");
                }

            }
        }

        public string Town
        {
            get { return town; }
            set
            {
                town = value;
                OnPropertyChanged("Town");
            }
        }

        public string HomePhone
        {
            get { return homePhone; }
            set
            {

                homePhone = value;
                OnPropertyChanged("HomePhone");


            }
        }

        public string CellPhone
        {
            get { return workPhone; }
            set
            {

                workPhone = value;
                OnPropertyChanged("CellPhone");


            }
        }

        //[RegularExpression(@"\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b")]
        public string EmailAddress
        {
            get { return emailAddress; }
            set
            {
                emailAddress = value;
                this.OnPropertyChanged("EmailAddress");
            }
        }

        
        public bool IsReadOnly
        {
            get { return isreadonly; }
            set
            {
                if (value != isreadonly)
                {
                    isreadonly = value;
                    OnPropertyChanged("IsReadOnly");
                }

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
