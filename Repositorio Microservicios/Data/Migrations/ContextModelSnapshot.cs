﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.ENTITIES.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserRoleUsuarioId")
                        .HasColumnType("int");

                    b.HasKey("RoleId");

                    b.HasIndex("UserRoleUsuarioId");

                    b.ToTable("role");
                });

            modelBuilder.Entity("Domain.ENTITIES.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserRoleUsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("gmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("uid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserRoleUsuarioId");

                    b.ToTable("user");
                });

            modelBuilder.Entity("Domain.ENTITIES.UsersRoles", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Domain.ENTITIES.Role", b =>
                {
                    b.HasOne("Domain.ENTITIES.UsersRoles", "UserRole")
                        .WithMany("Role")
                        .HasForeignKey("UserRoleUsuarioId");
                });

            modelBuilder.Entity("Domain.ENTITIES.Users", b =>
                {
                    b.HasOne("Domain.ENTITIES.UsersRoles", "UserRole")
                        .WithMany("User")
                        .HasForeignKey("UserRoleUsuarioId");
                });
#pragma warning restore 612, 618
        }
    }
}
