using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

class Course_Managment
{
    public int cId;
    public string cname;
    public int credit;

    public Course_Managment(int c,string cn,int e)
    {
        cId=c;
        cname=cn;
        credit=e;
    }

    public void show()
    {
        Console.WriteLine("Course Id:"+cId);
        Console.WriteLine("Course Name:"+cname);
        Console.WriteLine("Course Credit:"+credit);
        Console.WriteLine("----------------------------------");
    }
}