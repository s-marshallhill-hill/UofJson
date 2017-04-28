using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using u_of_json_api.Models;

namespace u_of_json_api.Migrations
{
    [DbContext(typeof(SchoolContext))]
    partial class SchoolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("u_of_json_api.Models.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("code")
                        .HasColumnName("course")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("u_of_json_api.Models.Grade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("grade")
                        .HasMaxLength(1);

                    b.HasKey("ID");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("u_of_json_api.Models.Roster", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("courseId");

                    b.Property<int?>("gradeId");

                    b.Property<int>("studentId");

                    b.HasKey("ID");

                    b.HasIndex("courseId");

                    b.HasIndex("gradeId");

                    b.HasIndex("studentId");

                    b.ToTable("roster");
                });

            modelBuilder.Entity("u_of_json_api.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("address")
                        .HasMaxLength(150);

                    b.Property<int>("age");

                    b.Property<string>("city")
                        .HasMaxLength(150);

                    b.Property<string>("email")
                        .HasMaxLength(50);

                    b.Property<string>("first")
                        .HasMaxLength(150);

                    b.Property<int>("gradYear");

                    b.Property<string>("last")
                        .HasMaxLength(150);

                    b.Property<string>("state")
                        .HasMaxLength(50);

                    b.Property<string>("zip")
                        .HasMaxLength(10);

                    b.HasKey("ID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("u_of_json_api.Models.Roster", b =>
                {
                    b.HasOne("u_of_json_api.Models.Course", "Course")
                        .WithMany("Rosters")
                        .HasForeignKey("courseId");

                    b.HasOne("u_of_json_api.Models.Grade", "Grade")
                        .WithMany()
                        .HasForeignKey("gradeId");

                    b.HasOne("u_of_json_api.Models.Student", "Student")
                        .WithMany("Rosters")
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
