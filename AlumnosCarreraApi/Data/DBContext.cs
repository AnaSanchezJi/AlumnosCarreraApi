using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlumnosCarreraApi.Models;

namespace AlumnosCarreraApi.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        public DbSet<eva_alumnos_carreras> eva_alumnos_carreras { get; set; }
        public DbSet<eva_cat_carreras> eva_cat_carreras { get; set; }
        public DbSet<eva_cat_especialidades> eva_cat_especialidades { get; set; }
        public DbSet<eva_cat_reticulas> eva_cat_reticulas { get; set; }
        public DbSet<cat_generales> cat_generales { get; set; }
        public DbSet<cat_periodos> cat_periodos { get; set; }
        public DbSet<cat_tipos_generales> cat_tipos_generales { get; set; }
        public DbSet<rh_cat_alumnos> rh_cat_alumnos { get; set; }
        public DbSet<rh_cat_personas> rh_cat_personas { get; set; }
        



    }
}
