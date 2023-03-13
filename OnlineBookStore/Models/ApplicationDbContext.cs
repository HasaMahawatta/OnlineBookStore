using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineBookStore.Models
{
    public class ApplicationDbContext : DbContext  //inheritts from Dbcontext of Ef
    {
        public ApplicationDbContext() : base("ConnectionString")   //add the connection string
        {

        }

        //create database tables
        public DbSet<Book> Books { get; set; }

        public DbSet<ReserveDetails> ReserveDetails { get; set; }
    }
}