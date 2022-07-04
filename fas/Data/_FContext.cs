using Microsoft.EntityFrameworkCore;
using FacultyAppointmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacultyAppointmentSystem.Data
{
    public class FContext : DbContext, IReadOnly_FContext
    {
        public FContext(DbContextOptions<FContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>().HasKey(x => x.Id).ForSqlServerIsClustered();
            modelBuilder.Entity<Appointment>().Property(x => x.Id).UseSqlServerIdentityColumn();
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Deget> Deget_F { get; set; }
        public DbSet<lenda> lendet { get; set; }

        IQueryable<Appointment> IReadOnly_FContext.Appointments { get => Appointments.AsNoTracking(); }
        IQueryable<Deget> IReadOnly_FContext.Deget_F { get => Deget_F.AsNoTracking(); }
        IQueryable<lenda> IReadOnly_FContext.lendet { get => lendet.AsNoTracking(); }
    }
}
