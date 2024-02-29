using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiWebBasicPlatFrom.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) { }


        #region 
        //DBset ở đây
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // cấu hình fluent API
        }
    }
}