namespace _21july_department.Models
{
    public static class DepartmentData
    {
        public static List<Department> GetAll()
        {
            return new List<Department>
            {
                new Department { DepartmentName = "IT", DepartmentHead = "Rakesh Sharma", HeadContactNumber = "9876543210", HeadEmail = "rakesh.it@company.com" },
                new Department { DepartmentName = "HR", DepartmentHead = "Anita Verma", HeadContactNumber = "9876500000", HeadEmail = "anita.hr@company.com" },
                new Department { DepartmentName = "Finance", DepartmentHead = "Suresh Iyer", HeadContactNumber = "9876511111", HeadEmail = "suresh.fin@company.com" }
            };
        }
    }
}
