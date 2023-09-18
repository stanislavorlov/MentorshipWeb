// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

Console.WriteLine("Hello, World!");

SchoolContext schoolContext = new SchoolContext(new DbContextOptions<SchoolContext>());

using var transaction = schoolContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);

try
{
    var student = new Student { ID = 1000 };
    student.EnrollmentDate = DateTime.Now;

    schoolContext.Students.Attach(student).State = EntityState.Modified;

    schoolContext.SaveChanges();

    //schoolContext.Database.SqlQuery<Student>("select * from Students");


    transaction.Commit();
}
catch
{
    transaction.Rollback();
}


public class SchoolContext : DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Course>().ToTable("Course");
        modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
        //modelBuilder.Entity<Student>().HasMany(s => s.Enrollments).WithOne(e => e.Student)
        //    .HasForeignKey(s => s.EnrollmentID);

        modelBuilder.Entity<Student>().ToTable("BestStudents");


    }
}

public enum Grade
{
    A, B, C, D, F
}

public class Student
{
    private string _lastName;
    private delegate void OnChanged(string paramName);

    public int ID { get; set; }
    public string LastName
    {
        get { return _lastName; }
        set 
        {
            _lastName = value;
            // OnChanged("_lastName");
        }
    }
    public string FirstMidName { get; set; }
    public DateTime EnrollmentDate { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; }

    private void ChangePropertyValue(string propertyName)
    {
        // ToDo: 
    }
}

public class Enrollment
{
    public int EnrollmentID { get; set; }
    public int CourseID { get; set; }
    public int StudentID { get; set; }
    public Grade? Grade { get; set; }

    public Course Course { get; set; }
    public Student Student { get; set; }
}

public class Course
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int CourseID { get; set; }
    public string Title { get; set; }
    public int Credits { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; }
}