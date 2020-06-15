﻿// <auto-generated />
using System;
using MAVN.Service.AuditLogs.MsSqlRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MAVN.Service.AuditLogs.MsSqlRepositories.Migrations
{
    [DbContext(typeof(AuditLogsContext))]
    [Migration("20200615112013_AddDatePropertyWithIndex")]
    partial class AddDatePropertyWithIndex
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("audit_logs")
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MAVN.Service.AuditLogs.MsSqlRepositories.Entities.AuditLogEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionContextJson")
                        .HasColumnName("action_context")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ActionType")
                        .HasColumnName("action_type")
                        .HasColumnType("int");

                    b.Property<Guid>("AdminUserId")
                        .HasColumnName("admin_user_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnName("timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ActionType");

                    b.HasIndex("AdminUserId");

                    b.HasIndex("Date");

                    b.ToTable("audit_logs");
                });
#pragma warning restore 612, 618
        }
    }
}
