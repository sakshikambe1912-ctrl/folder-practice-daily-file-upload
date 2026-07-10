using System;
using System.Collections.Generic;

// Abstract Class
abstract class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public int LeaveBalance { get; set; }

    public abstract void SetLeaveBalance();

    public void DisplayDetails()
    {
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Employee ID : " + EmployeeId);
        Console.WriteLine("Name        : " + Name);
        Console.WriteLine("Department  : " + Department);
        Console.WriteLine("Leave Balance : " + LeaveBalance + " Days");
    }
}

// Permanent Employee
class PermanentEmployee : Employee
{
    public override void SetLeaveBalance()
    {
        LeaveBalance = 24;
    }
}

// Contract Employee
class ContractEmployee : Employee
{
    public override void SetLeaveBalance()
    {
        LeaveBalance = 12;
    }
}

// Leave Request Class
class LeaveRequest
{
    public int LeaveId { get; set; }
    public int EmployeeId { get; set; }
    public int NumberOfDays { get; set; }
    public string Reason { get; set; }

    public void DisplayLeave()
    {
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Leave ID      : " + LeaveId);
        Console.WriteLine("Employee ID   : " + EmployeeId);
        Console.WriteLine("Leave Days    : " + NumberOfDays);
        Console.WriteLine("Reason        : " + Reason);
    }
}

class Program
{
    static void Main()
    {
        // Task 1
        List<Employee> employees = new List<Employee>();

        PermanentEmployee emp1 = new PermanentEmployee()
        {
            EmployeeId = 101,
            Name = "Amit",
            Department = "HR"
        };
        emp1.SetLeaveBalance();

        ContractEmployee emp2 = new ContractEmployee()
        {
            EmployeeId = 102,
            Name = "Priya",
            Department = "IT"
        };
        emp2.SetLeaveBalance();

        PermanentEmployee emp3 = new PermanentEmployee()
        {
            EmployeeId = 103,
            Name = "Rahul",
            Department = "Finance"
        };
        emp3.SetLeaveBalance();

        ContractEmployee emp4 = new ContractEmployee()
        {
            EmployeeId = 104,
            Name = "Sneha",
            Department = "Sales"
        };
        emp4.SetLeaveBalance();

        employees.Add(emp1);
        employees.Add(emp2);
        employees.Add(emp3);
        employees.Add(emp4);

        // Task 2
        Console.WriteLine("ALL EMPLOYEES");
        foreach (Employee emp in employees)
        {
            emp.DisplayDetails();
        }

        // Task 3
        List<LeaveRequest> leaveRequests = new List<LeaveRequest>();

        leaveRequests.Add(new LeaveRequest()
        {
            LeaveId = 1,
            EmployeeId = 101,
            NumberOfDays = 3,
            Reason = "Medical"
        });

        leaveRequests.Add(new LeaveRequest()
        {
            LeaveId = 2,
            EmployeeId = 103,
            NumberOfDays = 5,
            Reason = "Vacation"
        });

        leaveRequests.Add(new LeaveRequest()
        {
            LeaveId = 3,
            EmployeeId = 102,
            NumberOfDays = 2,
            Reason = "Personal"
        });

        // Task 4
        Console.WriteLine("\nALL LEAVE REQUESTS");
        foreach (LeaveRequest leave in leaveRequests)
        {
            leave.DisplayLeave();
        }

        // Task 5
        Console.WriteLine("\nPERMANENT EMPLOYEES");
        foreach (Employee emp in employees)
        {
            if (emp is PermanentEmployee)
            {
                emp.DisplayDetails();
            }
        }

        // Task 6
        Console.WriteLine("\nEMPLOYEE WITH ID 103");
        foreach (Employee emp in employees)
        {
            if (emp.EmployeeId == 103)
            {
                emp.DisplayDetails();
                break;
            }
        }

        // Task 7
        Console.WriteLine("\nTotal Employees = " + employees.Count);

        // Task 8
        Console.WriteLine("Total Leave Requests = " + leaveRequests.Count);
    }
}
