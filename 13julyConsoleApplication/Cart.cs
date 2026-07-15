using System;
using System.Collections.Generic;

public class Cart
{
    public string ProductName;
    public int ProductQuantity;


    public Cart(string pn,int pq)
    {
        ProductName=pn;
        ProductQuantity=pq;
    }

    public void Display()
    {
        Console.WriteLine("Product Name:"+ProductName);
        Console.WriteLine("Quantity:"+ProductQuantity);
    }

}