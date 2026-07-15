using System;

class Product
{
   public int  ProductId;
    public string ProductName;
    public long Price;
    public int Stock;

    public int Quantity;


    public Product(int pi,string pn,long p,int s)
    {
        ProductId=pi;
        ProductName=pn;
        Price=p;
        Stock=s;
    }

    


    public void Display1()
    {
        Console.WriteLine("Product Id:"+ProductId);
        Console.WriteLine("Product Name:"+ProductName);
        Console.WriteLine("Product Price:"+Price);
        Console.WriteLine("Product Stock:"+Stock);
        Console.WriteLine("--------------------------");
    }

    

}