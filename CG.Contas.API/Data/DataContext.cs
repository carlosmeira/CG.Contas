using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CG.Contas.API.Models;

namespace CG.Contas.API.Data
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ContasDB");

        }

        public DbSet<Conta> Conta { get; set; }
    }
}