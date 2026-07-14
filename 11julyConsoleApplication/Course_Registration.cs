using System;

public class Course_Registration
{   
    public int StudentId;
    public int CourserId;


    public Course_Registration(int studentid,int courseid)
    {
        StudentId=studentid;
        CourserId=courseid;
    }

    public void Display()
    {
        Console.WriteLine("Student Id:"+StudentId);
        
        Console.WriteLine("Course Id:"+CourserId);
    }
    
}