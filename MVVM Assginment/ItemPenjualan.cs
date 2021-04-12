using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MVVM_Assginment {
	class ItemPenjualan {

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }

		[StringLength(50)]
		public string NamaBarang { get; set; }

		public int Jumlah { get; set; }

		public decimal Harga { get; set; }

		public decimal DiskonPersen { get; set; }

		public ItemPenjualan() {
			DiskonPersen = 0;
		}

		public decimal Total() {
			decimal total = Jumlah * Harga;
			return total - (DiskonPersen / 100 * total);
		}

	}
}
