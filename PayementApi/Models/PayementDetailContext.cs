using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayementApi.Models
{
    public class PayementDetailContext:DbContext
    {
        public PayementDetailContext(DbContextOptions<PayementDetailContext> options) : base(options)
        {
               
        }

        public DbSet<PayementDetail> PayementDetails { get; set; }
    }
}
