using demo1.Models;

namespace demo1.servises
{
    public class DepartmentNameServises
    {
        static List<DepartmentNames> names = new List<DepartmentNames>()
        {
            new DepartmentNames(){Id=1,Name="BI"},
            new DepartmentNames(){Id=2,Name="dotNet"},
            new DepartmentNames(){Id=3,Name="mearn"},

        };
        ITIStudentContext studentContext = new ITIStudentContext();
        public List<DepartmentNames> GetAll()
        {
            return studentContext.DepartmentNames.ToList();
        }
        public void addDept(Department d)
        {
            DepartmentNames departmentNames = new DepartmentNames();
            departmentNames.Id = d.Id;
            departmentNames.Name = d.Name;
            studentContext.DepartmentNames.Add(departmentNames);
            studentContext.SaveChanges();
        }
        public void removeDept(int id)
        {

            studentContext.DepartmentNames.Remove(studentContext.DepartmentNames.FirstOrDefault(x => x.Id == id));
            studentContext.SaveChanges();
        }
    }
}
