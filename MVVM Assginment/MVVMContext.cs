using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace MVVM_Assginment {
	[DbConfigurationType(typeof(MySqlEFConfiguration))]
	class MVVMContext : DbContext {
		public DbSet<ItemPenjualan> DaftarItemPenjualan { get; set; }
	}
}
