using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Segal.Data.DatabaseContext
{
   public class SegalDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(connectionString: @"data source=.;initial catalog=SegalDB;user id=sa;password=123456;MultipleActiveResultSets=True;App=EntityFramework"));
        }
    }
}
