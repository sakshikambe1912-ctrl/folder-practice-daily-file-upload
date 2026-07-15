using System;
using Microsoft.VisualBasic;

public class CustomerRegistration
{
    public int CustomerId;
    public string CustomerName;
    public string CustomerEmailId;
    public string CustomerPassword;
    public int FailedAttemts;
    public bool IsLocked=false;


    public CustomerRegistration(int ci,string cn,string ce,string cp)
    {
        CustomerId=ci;
        CustomerName=cn;
        CustomerEmailId=ce;
        CustomerPassword=cp;


    }

    public void Display()
    {
        Console.WriteLine("Customer Id:"+CustomerId);
        Console.WriteLine("Customer Name:"+CustomerName);
        Console.WriteLine("Customer Email Id:"+CustomerEmailId);
        Console.WriteLine("Password:"+CustomerPassword);
        Console.WriteLine("---------------------------");
    }
}