using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Web.Entity
{
	public class ApplicationDb : DbContext
	{
		public static string ConnectionString { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (optionsBuilder.IsConfigured) return;
			optionsBuilder.UseNpgsql(
				Environment.GetEnvironmentVariable("ConnectionString"));
			base.OnConfiguring(optionsBuilder);
		}
	}
}
