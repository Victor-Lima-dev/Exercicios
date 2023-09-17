using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercicios.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercicios.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)

        {

        }

        public DbSet<Remedio> Remedioss { get; set; }

        public DbSet<SinalClinico> SinaisClinicoss { get; set; }

        public DbSet<Especie> Especiess { get; set; }
    }
}