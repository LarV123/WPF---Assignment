using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;
using System.Text;

namespace MVVM_Assginment {
	class MVVMHistoryContext : HistoryContext {
		public MVVMHistoryContext(DbConnection dbConnection, string defaultSchema) : base(dbConnection, defaultSchema) {

		}

		protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<HistoryRow>().Property(p => p.MigrationId).HasMaxLength(100).IsRequired();
			modelBuilder.Entity<HistoryRow>().Property(p => p.ContextKey).HasMaxLength(200).IsRequired();
		}
	}

	class ModelConfiguration : DbConfiguration {
		public ModelConfiguration() {
			SetHistoryContext("MySql.Data.MySqlClient", (c, s) => new MVVMHistoryContext(c, s));
		}
	}
}
