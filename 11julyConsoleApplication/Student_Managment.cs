using System;

enum StudentType{
    Regular,
    Scholarship,
    parttime
    
}
class Student_Managment
{
    public int Id;
    public string name;
    public string dept;
    public StudentType type;

  public List<Course_Managment> EnrolledCourses = new List<Course_Managment>();
    public Student_Managment(int i , string n ,string d ,StudentType t){
        Id = i;
        name = n;
        dept = d;
        type=t;

    }

    public int TotalCredits()
    {
         int total=0;
         foreach(Course_Managment c in EnrolledCourses)
        {
           total+=c.credit; 
        }
        return total;
    }

    public double CalculateFee()
    {
        double feepercredit;
        switch (type)
        {
            case StudentType.Scholarship:
            feepercredit=250;
            break;
            case StudentType.parttime:
            feepercredit=350;
            break;
            default :
            feepercredit=500;
            break;

        }
        return TotalCredits()*feepercredit;
    }
    
    public void Display()
        {
              Console.WriteLine("Student Id:"+Id);
              Console.WriteLine("Student Name:"+name);
              Console.WriteLine("Student Department:"+dept);
              Console.WriteLine("Student Type:"+type);
              Console.WriteLine("----------------------------");
        }
    public void FullDetails()
    {
         Console.WriteLine("Student Id:"+Id);
         Console.WriteLine("Student Name:"+name);
         Console.WriteLine("Student Department:"+dept);
         Console.WriteLine("Student Type:"+type);

        if (EnrolledCourses.Count == 0)
        {
            Console.WriteLine("No Course Enrolled.");
        }
        else
        {
            Console.WriteLine("Enrolled Course:");
            foreach( Course_Managment c in EnrolledCourses)
            {
                Console.WriteLine("  - " + c.cname + " (Credits: " + c.credit + ")");
            }
        }
         Console.WriteLine("Total Credits:" + TotalCredits());
         Console.WriteLine("Total Fee:" + CalculateFee());
         Console.WriteLine("----------------------------");

    }

}