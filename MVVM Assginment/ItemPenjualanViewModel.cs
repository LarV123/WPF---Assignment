using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MVVM_Assginment {
	class ItemPenjualanViewModel : INotifyPropertyChanged{

        public event PropertyChangedEventHandler PropertyChanged;

        private ItemPenjualan model;

        public ItemPenjualanViewModel(ItemPenjualan itemPenjualan = null) {
            this.model = itemPenjualan ?? new ItemPenjualan();
        }

        public string NamaBarang {
            get { return model.NamaBarang; }
            set {
                if (value != model.NamaBarang) {
                    model.NamaBarang = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("NamaBarang"));
                }
            }
        }

        public int Jumlah {
            get { return model.Jumlah; }
            set {
                if (value != model.Jumlah) {
                    model.Jumlah = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Jumlah"));
                    PropertyChanged(this, new PropertyChangedEventArgs("Total"));
                }
            }
        }

        public decimal Harga {
            get { return model.Harga; }
            set {
                if (value != model.Harga) {
                    model.Harga = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Harga"));
                    PropertyChanged(this, new PropertyChangedEventArgs("Total"));
                }
            }
        }

        public decimal DiskonPersen {
            get { return model.DiskonPersen; }
            set {
                if (value != model.DiskonPersen) {
                    model.DiskonPersen = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("DiskonPersen"));
                    PropertyChanged(this, new PropertyChangedEventArgs("Total"));
                }
            }
        }

        public string Total {
            get {
                decimal? total = model.Total();
                if (!total.HasValue) {
                    return "-";
                } else {
                    return total.Value.ToString("C");
                }
            }
        }

        public ItemPenjualan Model {
            get { return model; }
        }

    }
}
