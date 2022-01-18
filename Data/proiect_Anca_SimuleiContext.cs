using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proiect_Anca_Simulei.Models;

namespace proiect_Anca_Simulei.Data
{
    public class proiect_Anca_SimuleiContext : DbContext
    {
        public proiect_Anca_SimuleiContext (DbContextOptions<proiect_Anca_SimuleiContext> options)
            : base(options)
        {
        }

        public DbSet<proiect_Anca_Simulei.Models.Vin> Vin { get; set; }

        public DbSet<proiect_Anca_Simulei.Models.Domeniu> Domeniu { get; set; }
    }
}
