﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WembleyScada.Infrastructure;

#nullable disable

namespace WembleyScada.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231123152949_remove-moldSlot")]
    partial class removemoldSlot
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WembleyScada.Domain.AggregateModels.DeviceAggregate.Device", b =>
                {
                    b.Property<string>("DeviceId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DeviceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeviceType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DisplayPriority")
                        .HasColumnType("int");

                    b.HasKey("DeviceId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("WembleyScada.Domain.AggregateModels.MachineStatusAggregate.MachineStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeviceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ShiftNumber")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.ToTable("MachineStatus");
                });

            modelBuilder.Entity("WembleyScada.Domain.AggregateModels.ShiftReportAggregate.ShiftReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DefectCount")
                        .HasColumnType("int");

                    b.Property<string>("DeviceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ProductCount")
                        .HasColumnType("int");

                    b.Property<int>("ShiftNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.ToTable("ShiftReports");
                });

            modelBuilder.Entity("WembleyScada.Domain.AggregateModels.MachineStatusAggregate.MachineStatus", b =>
                {
                    b.HasOne("WembleyScada.Domain.AggregateModels.DeviceAggregate.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("WembleyScada.Domain.AggregateModels.ShiftReportAggregate.ShiftReport", b =>
                {
                    b.HasOne("WembleyScada.Domain.AggregateModels.DeviceAggregate.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("WembleyScada.Domain.AggregateModels.ShiftReportAggregate.Shot", "Shots", b1 =>
                        {
                            b1.Property<int>("ShiftReportId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<double>("CycleTime")
                                .HasColumnType("float");

                            b1.Property<double>("ExecutionTime")
                                .HasColumnType("float");

                            b1.Property<DateTime>("TimeStamp")
                                .HasColumnType("datetime2");

                            b1.HasKey("ShiftReportId", "Id");

                            b1.ToTable("Shot");

                            b1.WithOwner()
                                .HasForeignKey("ShiftReportId");
                        });

                    b.Navigation("Device");

                    b.Navigation("Shots");
                });
#pragma warning restore 612, 618
        }
    }
}
