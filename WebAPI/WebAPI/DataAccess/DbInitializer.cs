using WebAPI.Models;

namespace WebAPI.DataAccess
{
    public class DbInitializer
    {
        public static void Initialize(EmployeeContext context)
        {
            context.Database.EnsureCreated();

            if (context.Employees.Any())
            {
                return;   // DB has been seeded
            }

            var employees = new Employee[]
            {
                new Employee
                {
                    EmployeeName = "Roger", DepartmentName = "Support", DateOfJoining = "2022-01-01",
                    PhotoFileName = "random.png"
                },
                new Employee
                {
                    EmployeeName = "Mike", DepartmentName = "IT", DateOfJoining = "2022-06-01",
                    PhotoFileName = "random.png"
                },
                new Employee
                {
                    EmployeeName = "Cringer", DepartmentName = "IT", DateOfJoining = "2022-05-01",
                    PhotoFileName = "random.png"
                },
                new Employee
                {
                    EmployeeName = "Flex", DepartmentName = "Support", DateOfJoining = "2022-11-01",
                    PhotoFileName = "random.png"
                },
                new Employee
                {
                    EmployeeName = "Steve", DepartmentName = "IT", DateOfJoining = "2023-01-01",
                    PhotoFileName = "random.png"
                },
            };

            foreach (Employee e in employees)
            {
                context.Employees.Add(e);
            }
            bool hasChanges = context.ChangeTracker.HasChanges();
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department{DepartmentName = "IT"},
                new Department{DepartmentName = "Support"},
            };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }

            context.SaveChanges();
        }
        
    }
}