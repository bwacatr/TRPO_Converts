using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_Converts.Models
{
    public class Product : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private float? _discount;
        private float _price;
        private string _description;

        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Id { get => _id;
            set 
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            } }
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }
        public float Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(PriceDiscount));
                }
            }
        }
        public float? Discount 
        { 
            get => _discount;
            set 
            {
                if (_discount != value)
                {
                    _discount = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(PriceDiscount));
                }    
            } 
        }


        public float PriceDiscount
        {
            get 
            {
                var discountAmount = Price * (Discount ?? 0);
                return discountAmount == 0 ? 0 : Price - discountAmount;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
