﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using FacultyAppointmentSystem.Data;

namespace FacultyAppointmentSystem.Migrations
{
    [DbContext(typeof(FContext))]
    partial class SpaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FacultyAppointmentSystem.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Orari");

                    b.Property<int>("dega_id");

                    b.Property<string>("Dega");

                    b.Property<string>("Pershkrimi");

                    b.Property<int>("lenda_id");

                    b.Property<string>("Lendet");

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("FacultyAppointmentSystem.Models.Deget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Deget_F");
                });

            modelBuilder.Entity("FacultyAppointmentSystem.Models.lenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("lendet");
                });
#pragma warning restore 612, 618
        }
    }
}