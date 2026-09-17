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
    }
}
