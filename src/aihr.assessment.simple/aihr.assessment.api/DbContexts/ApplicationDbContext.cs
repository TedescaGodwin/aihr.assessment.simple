using aihr.assessment.api.Courses.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace aihr.assessment.api.Courses.Api.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 1,
                Name = "Blockchain and HR",
                Hours = 8.0D

            });
            modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 2,
                Name = "Compensation and Benefits",
                Hours = 32.0D

            });
            modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 3,
                Name = "Digital HR",
                Hours = 40.0D

            }); modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 4,
                Name = "Digital HR Strategy",
                Hours = 10.0D

            }); modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 5,
                Name = "Digital HR Transformation ",
                Hours = 8.0D

            }); modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 6,
                Name = "Diversity and Inclusion",
                Hours = 20.0D

            }); modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 7,
                Name = "Employee Experience and Design Thinking",
                Hours = 12.0D

            }); modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 8,
                Name = "Employer Branding",
                Hours = 6.0D

            }); modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 9,
                Name = "Global Data Integrity",
                Hours = 12.0D

            }); modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 24,
                Name = "Hiring and Recruitment Strategy",
                Hours = 15.0D

            }); modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 10,
                Name = "HR Analytics Leader",
                Hours = 21.0D

            }); modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 11,
                Name = "HR Business Partner 2.0",
                Hours = 40.0D

            }); modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 12,
                Name = "HR Data Analyst",
                Hours = 18.0D

            }); modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 13,
                Name = "HR Data Science in R",
                Hours = 12.0D

            }); modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 14,
                Name = "HR Data Visualization",
                Hours = 12.0D

            }); modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 15,
                Name = "HR Metrics and Reporting",
                Hours = 40.0D

            }); modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 16,
                Name = "Learning and Development",
                Hours = 30.0D

            }); modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 17,
                Name = "Organizational Development",
                Hours = 30.0D

            }); modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 18,
                Name = "People Analytics",
                Hours = 40.0D

            }); modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 19,
                Name = "Statistics in HR",
                Hours = 15.0D

            }); modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 20,
                Name = "Strategic HR Leadership",
                Hours = 34.0D

            }); modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 21,
                Name = "Strategic HR Metrics",
                Hours = 17.0D

            }); modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 22,
                Name = "Talent Acquisition",
                Hours = 40.0D

            });
        }
    }
}
