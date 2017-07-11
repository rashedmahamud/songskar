using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using songskar.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace songskar.DAL
{
    public class SongskarContext : DbContext
    {
        public SongskarContext() : base("SongskarContext")
        {
            
        }

        public DbSet<quran> qurans { get; set; }
        public DbSet<hadis> hadises { get; set; }
        public DbSet<article> articles { get; set; }
        public DbSet<aungkur> aungkur { get; set; }
        public DbSet<contact> contacts { get; set; }
        public DbSet<editorial> editorials { get; set; }
        public DbSet<health> healths { get; set; }
        public DbSet<inthismonth> inthismonths { get; set; }
        public DbSet<islamicworld> islamicworlds { get; set; }
        public DbSet<news> newses { get; set; }
        public DbSet<other> others { get; set; }
        public DbSet<poem> poems { get; set; }
        public DbSet<technology> technologies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}