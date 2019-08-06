using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace TempApi.Models
{
    public class TempContext : DbContext
    {
        public TempContext(DbContextOptions<TempContext> options)
            : base(options)
        {
        }

        public DbSet<TempItem> TempItems { get; set; }
    }
}