using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace MVVM_Assginment {
	class SaveCommand : ICommand{

		private ItemPenjualanViewModel viewModel;

		public SaveCommand(ItemPenjualanViewModel viewModel) {
			this.viewModel = viewModel;
		}

		public event EventHandler CanExecuteChanged {
			add {
				CommandManager.RequerySuggested += value;
			}
			remove {
				CommandManager.RequerySuggested -= value;
			}
		}

		public bool CanExecute(object parameter) {
			return viewModel.Model.Total() > 0;
		}

		public void Execute(object parameter) {
			using(var db = new MVVMContext()) {
				db.Database.Log = Console.Write;
				db.DaftarItemPenjualan.Add(viewModel.Model);
				db.SaveChanges();
				MessageBox.Show("Data berhasil disimpan ke database");
			}
		}
	}
}
