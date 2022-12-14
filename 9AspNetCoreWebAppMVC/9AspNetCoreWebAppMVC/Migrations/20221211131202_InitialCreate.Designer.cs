// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _9AspNetCoreWebAppMVC.Data;

#nullable disable

namespace _9AspNetCoreWebAppMVC.Migrations
{
    [DbContext(typeof(_9AspNetCoreWebAppMVCContext))]
    [Migration("20221211131202_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("_9AspNetCoreWebAppMVC.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("_9AspNetCoreWebAppMVC.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourceId")
                        .HasColumnType("int");

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("_9AspNetCoreWebAppMVC.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CourceId")
                        .HasColumnType("int");

                    b.Property<string>("First_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Last_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourceId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("_9AspNetCoreWebAppMVC.Models.Group", b =>
                {
                    b.HasOne("_9AspNetCoreWebAppMVC.Models.Course", null)
                        .WithMany("Groups")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("_9AspNetCoreWebAppMVC.Models.Student", b =>
                {
                    b.HasOne("_9AspNetCoreWebAppMVC.Models.Group", null)
                        .WithMany("Students")
                        .HasForeignKey("CourceId");
                });

            modelBuilder.Entity("_9AspNetCoreWebAppMVC.Models.Course", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("_9AspNetCoreWebAppMVC.Models.Group", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
