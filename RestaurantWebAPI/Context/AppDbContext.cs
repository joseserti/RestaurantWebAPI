using Microsoft.EntityFrameworkCore;
using RestaurantWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebAPI.Context
{
    public class AppDbContext: DbContext
    {

        //Construir el constructor que permita pasar las caracteristicas de nuestro Context hacia
        //la clase base DbContext de EntityFramework
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        //Especificar las tablas que formarán parte de nuestro contexto
        public DbSet<Platillo> tbPlatillos { get; set; }
    }
}
