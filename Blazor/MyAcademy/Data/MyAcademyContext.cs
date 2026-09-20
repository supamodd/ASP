using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyAcademy.Models;

namespace MyAcademy.Data
{
    public class MyAcademyContext : DbContext
    {
        public MyAcademyContext (DbContextOptions<MyAcademyContext> options)
            : base(options)
        {
        }

        public DbSet<MyAcademy.Models.Direction> Directions { get; set; } = default!;
        public DbSet<MyAcademy.Models.Discipline> Disciplines { get; set; } = default!;
        public DbSet<MyAcademy.Models.Group> Groups { get; set; } = default!;
        public DbSet<MyAcademy.Models.Student> Students { get; set; } = default!;
        public DbSet<MyAcademy.Models.Teacher> Teachers { get; set; } = default!;
        public DbSet<MyAcademy.Models.TeacherDisciplineRelation> TeachersDisciplinesRelation { get; set; } = default!;
        public DbSet<MyAcademy.Models.Holiday> Holidays { get; set; } = default!;
        public DbSet<MyAcademy.Models.DayOFF> DaysOFF { get; set; } = default!;
        public DbSet<MyAcademy.Models.Schedule> Schedule { get; set; } = default!;
        public DbSet<MyAcademy.Models.Grade> Grades { get; set; } = default!;
        public DbSet<MyAcademy.Models.Attendance> Attendance { get; set; } = default!;
        public DbSet<MyAcademy.Models.Exam> Exams { get; set; } = default!;
        public DbSet<MyAcademy.Models.Salary> Salary { get; set; } = default!;
        public DbSet<MyAcademy.Models.CompleteDiscipline> CompleteDisciplines { get; set; } = default!;
        public DbSet<MyAcademy.Models.DependentDiscipline> DependentDisciplines { get; set; } = default!;
        public DbSet<MyAcademy.Models.RequiredDiscipline> RequiredDisciplines { get; set; } = default!;
        public DbSet<MyAcademy.Models.DisciplineDirectionRelation> DisciplinesDirectionsRelation { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Связи, которые EF не может вывести однозначно:
            // две ссылки на одну и ту же таблицу или ссылка на Schedule
            modelBuilder.Entity<DependentDiscipline>()
                .HasOne(d => d.Discipline).WithMany().HasForeignKey(d => d.discipline);
            modelBuilder.Entity<DependentDiscipline>()
                .HasOne(d => d.Dependent).WithMany().HasForeignKey(d => d.dependent_discipline);

            modelBuilder.Entity<RequiredDiscipline>()
                .HasOne(d => d.Discipline).WithMany().HasForeignKey(d => d.discipline);
            modelBuilder.Entity<RequiredDiscipline>()
                .HasOne(d => d.Required).WithMany().HasForeignKey(d => d.required_discipline);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Lesson).WithMany().HasForeignKey(g => g.lesson);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Lesson).WithMany().HasForeignKey(a => a.lesson);

            modelBuilder.Entity<DayOFF>()
                .HasOne(d => d.Holiday).WithMany().HasForeignKey(d => d.holiday);
        }

    }
}
