using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_Converts.Models
{
    public class Parcel : INotifyPropertyChanged
    {


        private string _recipient;
        private float? _surcharge;
        private float _ratePerKg;
        private float _weight;

        public float Weight
        {
            get => _weight;
            set
            {
                if (_weight != value)
                {
                    if (value < 0)
                    {
                        _weight = value * (-1);
                    }
                    else { _weight = value; }

                    OnPropertyChanged();
                    OnPropertyChanged(nameof(DeliveryCost));
                    OnPropertyChanged(nameof(DeliveryCostWithoutSurcharge));
                }
            }
        }

        
        public string Recipient
        {
            get => _recipient;
            set
            {
                if (_recipient != value)
                {
                    _recipient = value;
                    OnPropertyChanged();
                }
            }
        }
        public float RatePerKg
        {
            get => _ratePerKg;
            set
            {
                if (_ratePerKg != value)
                {
                    if (value < 0)
                    {
                        _ratePerKg = value * (-1);
                    }
                    else { _ratePerKg = value; }
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(DeliveryCost));
                    OnPropertyChanged(nameof(DeliveryCostWithoutSurcharge));
                }
            }
        }
        public float? Surcharge 
        { 
            get => _surcharge;
            set 
            {
                if (_surcharge != value)
                {
                    if (value < 0)
                    {
                        _surcharge = value * (-1);
                    }
                    else { _surcharge = value; }

                        OnPropertyChanged();
                    OnPropertyChanged(nameof(DeliveryCost));
                }    
            } 
        }

        public float DeliveryCostWithoutSurcharge
        {
            get
            {
                var deliveryCost = (RatePerKg * Weight);
                return deliveryCost;
            }
        }
        public float DeliveryCost
        {
            get 
            {
                var deliveryCost = (Surcharge ?? 0) + (RatePerKg * Weight);
                return deliveryCost;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
