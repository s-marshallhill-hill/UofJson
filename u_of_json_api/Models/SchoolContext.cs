using Microsoft.EntityFrameworkCore;

namespace u_of_json_api.Models
{
    public class SchoolContext: DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options): base(options)
        {

        }
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<Roster> Rosters { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=school2; Trusted_Connection=True;MultipleActiveResultSets=true");


        //    //optionsBuilder.UseSqlServer(@"Server=TG-INTERNAL;Database=school_steven;User Id=TYPHON1; Password=shea2238; Trusted_Connection=True;MultipleActiveResultSets=true");
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Roster>().ToTable("roster");
        //}
        //{
        //    modelBuilder.Entity<Roster>()
        //        .HasKey(t => new { t.studentId, t.courseId });

        //    modelBuilder.Entity<Roster>()
        //        .HasOne(roster => roster.Course)
        //        .WithMany(c =>c.Rosters)
        //        .HasForeignKey(r => r.courseId);

        //    modelBuilder.Entity<Roster>()
        //        .HasOne(roster => roster.Student)
        //        .WithMany(s => s.Rosters)
        //        .HasForeignKey(r => r.studentId);
    }
    
}
