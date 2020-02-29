using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using sms_uic.Models.Schools;
using sms_uic.Models;
using System.Linq;

namespace sms_uic.Data
{
    public class StudentRepository{
        private DbSet<Student> students;
        private SMSDbContext dbContext;
        public StudentRepository(){
            string connectionString = "";
            dbContext = SMSDbContextFactory.Create(connectionString);

            DbSet<Student> students = dbContext.Student;
        }

        public List<Student> getGradeLevel(int level, School school){
            return students.Where( s =>  s.GradeLevel == level && s.SchoolId == school.SchoolId).ToList();
        } 
        
        public List<Student> getAllStudents(School school){
            return students.Where( s =>  s.SchoolId == school.SchoolId)
            .OrderBy(student => student.LastName).OrderBy(student => student.GradeLevel).ToList();
        }

        public Student getStudent(int id){
            return students.Where( s =>  s.StudentId == id).Single();
        }

        public void addStudent(Student student){
            students.Add(student);
        }
    }
}