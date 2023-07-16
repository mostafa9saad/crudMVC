using demo1.Models;
using System.Collections.Generic;

namespace demo1.servises
{
    public class StudentServises
    {
        static List<Student> std = new List<Student>()
        {
            new Student(){Id=1,Name="mostafa",Email="mostafa@gmail.com",age=24,Deptid=1 },
            new Student(){Id=2,Name="ahmed",Email="ahmed@gmail.com",age=25,Deptid=2},
            new Student(){Id=3,Name="saad",Email="saad@gmail.com",age=26,Deptid=3 },

        };
        DepartmentServises DS = new DepartmentServises();
        ITIStudentContext studentContext = new ITIStudentContext();
        public Student AddStd(Student student)
        {
            studentContext.Students.Add(student);
            DS.addStd(student.Deptid);
            studentContext.SaveChanges();
            return student;
        }
        public List<Student> getAll()
        {
            return studentContext.Students.ToList();
        }
        public int getLastId()
        {
            if (studentContext.Students.ToList().Count == 0) { return 0; }
            return studentContext.Students.ToList().Last().Id;
        }
        public Student getStdById(int id)
        {

            return studentContext.Students.FirstOrDefault(a => a.Id == id);
        }
        public Student deleteById(int id)
        {
            Student s = studentContext.Students.FirstOrDefault(a => a.Id == id);
            studentContext.Students.Remove(s);
            DS.removeStd(id);
            studentContext.SaveChanges();
            return s;

        }
        public void deleteStdFromDept(int id)
        {
            List<Student> std = getAll().Where(a => a.Deptid == id).ToList();


            for (int i = 0; i < std.Count; i++)
            {
                studentContext.Students.Remove(std[i]);
            }



            studentContext.SaveChanges();

        }
        public Student UpdateById(Student s)
        {
            studentContext.Students.Update(s);
            studentContext.SaveChanges();

            return s;

        }
    }
}
