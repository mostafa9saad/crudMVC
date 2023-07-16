using demo1.Models;

namespace demo1.servises
{
    public class DepartmentServises
    {
        static List<Department> list = new List<Department>()
        {
            new Department(){Id=1,Name="BI",capcity=1 },
            new Department(){Id=2,Name="net",capcity=1 },
            new Department(){Id=3,Name="mearn",capcity=1 },
        };
        ITIStudentContext studentContext = new ITIStudentContext();

        public List<Department> getAll()
        {
            return studentContext.Departments.ToList();
        }
        public int getLastId()
        {
            return studentContext.Departments.ToList().Last().Id;
        }
        public Department Add(Department dep)
        {

            studentContext.Departments.Add(dep);
            studentContext.SaveChanges();
            return dep;
        }
        public Department getDeptById(int id)
        {

            return studentContext.Departments.FirstOrDefault(a => a.Id == id);


        }
        public void removeStd(int id)
        {
            Department d = studentContext.Departments.ToList().FirstOrDefault(a => a.Id == id);

            d.capcity -= 1;
            studentContext.SaveChanges();



        }
        public Department deleteById(int id)
        {
            StudentServises SS = new StudentServises();
            DepartmentNameServises DN = new DepartmentNameServises();
            Department dept = studentContext.Departments.FirstOrDefault(a => a.Id == id);
            studentContext.Departments.Remove(dept);
            SS.deleteStdFromDept(id);
            DN.removeDept(id);

            studentContext.SaveChanges();

            return dept;

        }
        public void addStd(int id)
        {
            Department d = studentContext.Departments.FirstOrDefault(a => a.Id == id);
            d.capcity += 1;
            studentContext.SaveChanges();
        }
        public Department UpdateById(Department dept)
        {

            /*
            Department old = studentContext.Departments.FirstOrDefault(a => a.Id == dept.Id);
            if (old != null)
            {
                old.Name = dept.Name;
                old.capcity = dept.capcity;
            }*/
            studentContext.Departments.Update(dept);
            studentContext.SaveChanges();
            return dept;

        }

    }
}
