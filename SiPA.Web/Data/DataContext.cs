using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SiPA.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Parishioner> Parishioners { get; set; }
        public DbSet<RequestType> RequestTypes { get; set; }
        public DbSet<Sacrament> Sacraments { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Request> Requests { get; set; }

        internal Task<Sacrament> FindAsync(string sacramentName)
        {
            throw new NotImplementedException();
        }

        public DbSet<Manager> Managers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Christening> Christenings { get; set; }
        public DbSet<Confirmation> Confirmations { get; set; }
        public DbSet<FirstCommunion> FirstCommunions { get; set; }
        public DbSet<Wedding> Weddings { get; set; }
        public DbSet<SacramentType> SacramentTypes { get; set; }   
    }
}
