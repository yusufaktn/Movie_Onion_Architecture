using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class MyContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-1623\\MSSQLSERVER1;Database=Movie_DB;Trusted_Connection=True;Encrypt=False;");
            //Bu methot sql bağlantı adresizime ulaşmamızı sağlıyor.

        }

        //Veritabanında oluşacak tabloları DbSet<T> ile tanımlıyoruz.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags{ get; set; }
        public DbSet<Genre> Genres { get; set; }


    }
}
