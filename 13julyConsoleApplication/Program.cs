using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

public class Program
{   

     static List<CustomerRegistration>customerRegistrations=new List<CustomerRegistration>();
     static List<Product>products=new List<Product>();
     static List<Cart>cart=new List<Cart>();
    static void Main(String[] args)
    {    
        while (true)
            {       Console.WriteLine("Welcome To ECOMMERCE Website...........");
                    Console.WriteLine("1.Registration:");
                    Console.WriteLine("2.Login");
                    Console.WriteLine("3.Add to Cart");
                    Console.WriteLine("4.Total Amount");
                    Console.WriteLine("5.Payment");
                    Console.WriteLine("6.Exit");
                    Console.WriteLine("Enter your choice");
                    string choice=Console.ReadLine();

                    if (choice == "1")
                    {
                        Registration();
                    }
                    else if(choice == "2")
                    {
                        Login();
            
                    }
                    else if (choice == "3")
                    {
                        AddCart();
                    }
                    else if(choice=="4")
                    {
                        TotalAmount();
                    }
                    else if (choice == "5")
                    {
                        Payment();
                    }
                    else if (choice == "6")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Choice");
                    }
            }
    }

             static void Registration(){
                
                Console.WriteLine("Registration:");
                Console.WriteLine("Enter Customer Id:");
                int customerid=Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Customer Name:");
                string customername=Console.ReadLine();
                Console.WriteLine("Enter Customer Email Address:");
                string customeremail=Console.ReadLine();
                Console.WriteLine("Enter Password");
                string password=Console.ReadLine();
                CustomerRegistration customerregistration=new CustomerRegistration(customerid,customername,customeremail,password);
                customerRegistrations.Add(customerregistration);
                Console.WriteLine("---------Customer Details----------");
                customerregistration.Display();
                Console.WriteLine("Registeration Succesful.......");
        }

            static void Login(){
                
                Console.WriteLine("---------LOGIN---------");
                Console.WriteLine("Enter Email:");
                string customerEmail=Console.ReadLine();
                
                CustomerRegistration matchcustomer=customerRegistrations.Find(c=>c.CustomerEmailId==customerEmail);
                
                if (matchcustomer == null)
                {
                    Console.WriteLine("Please Register Email First.");
                    Registration();
                    Login();
                    return;
                
                }
            if (matchcustomer.IsLocked)
            {
                Console.WriteLine("too many attempts,so account is locked");
                return;
            }
                Console.WriteLine("Enter Password:");
                string password1=Console.ReadLine();
                if (matchcustomer.CustomerPassword == password1)
                {
                    Console.WriteLine("--------Login Successfully----------");
                    Console.WriteLine("Welcome "+matchcustomer.CustomerName);
                    AddProduct();
                
                    

                }

                
                else
                {
                    Console.WriteLine("Password do not Maches");
                    Login();
                if (matchcustomer.FailedAttemts>=3)
                {   matchcustomer.IsLocked=true;
                    Console.WriteLine("Locked Account");
                    return;
                }
                }
            }
            static void AddProduct(){
                
            Console.WriteLine("how many product do you want:");
            try{
                    int choice=Convert.ToInt32(Console.ReadLine());
                    for(int i=1;i<=choice;i++)
                        {   Console.WriteLine("Enter Product Id:");
                            int productid=Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Product Name:");
                            string productname=Console.ReadLine();
                            Console.WriteLine("Enter Product Price:");
                            long productprice=long.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Product Stock:");
                            int stock=Convert.ToInt32(Console.ReadLine());
                            Product p=new Product(productid,productname,productprice,stock);
                            products.Add(p);
                        }
                        Console.WriteLine("--------List Of All Products--------");
                        foreach(Product pd in products)
                    {
                        
                        pd.Display1();
                    }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please Enter Number Only");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
            Console.WriteLine("Enter Product Name:");
            string pname=Console.ReadLine();
            bool found =false;
            foreach(Product pt in products)
        {
            if (pt.ProductName == pname)
            {
                found=true;
                pt.Display1();
                continue;
                
                AddCart();
            } 
            if (!found)
            {
                Console.WriteLine("Product not found.");
            }
        }
        }

        static void AddCart()
    
    {
        Console.WriteLine("--------List Of All Products--------");
                        foreach(Product pd in products)
                    {
                        
                        pd.Display1();
                    }
        while(true){
        Console.WriteLine("Enter Product Id:");
        int pid=Convert.ToInt32(Console.ReadLine());
        

        Product foundproduct=products.Find(p =>p.ProductId==pid);
        if(foundproduct == null)
            {
                Console.WriteLine("This Product is not available");
                break;
            }
        Console.WriteLine("Enter Product Quantity:");
        int pquantity=Convert.ToInt32(Console.ReadLine());
            if (pquantity > foundproduct.Stock)
            {
                Console.WriteLine("only"+foundproduct.Stock+"items are available");
                break;
            }
            Console.WriteLine("Add to Cart: yes/no");
            string ch =Console.ReadLine();

            if (ch.ToLower() == "yes")
            {
                cart.Add(new Cart (foundproduct.ProductName, pquantity));
                foundproduct.Stock=-pquantity;
                Console.WriteLine("Add to Cart");
                Console.WriteLine("Add another product(yes/no)");
                string cchoice=Console.ReadLine();
                if (cchoice.ToLower() != "yes")
                {
                    break;
                }

            }
            else
            {
                Console.WriteLine("Item is not added to cart.");
                Console.WriteLine("Add another product(yes/no)");
                string cchoice=Console.ReadLine();
                if (cchoice.ToLower() != "yes")
                {
                    break;
                }

            }
                
        }Console.WriteLine("------Summary of Cart------");
        if (cart.Count == 0)
        {
            Console.WriteLine("No item is added into the cart");
        }
        foreach(Cart item in cart)
        {
            item.Display();
            
        }TotalAmount();

    }
       static void TotalAmount()
    {
       long total=0;
       long Discount;
       long FinalAmount;

       foreach(Cart c in cart)
        {
            Product pd=products.Find(p=>p.ProductName==c.ProductName);
            if(pd != null)
            {
                long amount=pd.Price*c.ProductQuantity;
                total+=amount;
            }
        }
        if (total <= 1000)
        {   
            total=total;
            Discount=0;
            
            
        }else if ((total > 1000) && (total <= 4999))
        {
            total=total;
            Discount=total*10/100;
            
        }else if ((total >= 5000) && (total <= 9999))
        {
            total=total;
            Discount=total*20/100;
            
        }else 
        {
            total=total;
            Discount=total*30/100;
           
        }
        FinalAmount=total-Discount;
        Console.WriteLine("----------------------");
        Console.WriteLine("Total Amount:"+total);
        Console.WriteLine("Discount:"+Discount);
        Console.WriteLine("Final Amount:"+FinalAmount);
        Payment();
        
       
    }

    static void Payment()
    {
        while (true)
        {   Console.WriteLine("---------------");
            Console.WriteLine("1.UPI");
            Console.WriteLine("2.Credit Card");
            Console.WriteLine("3.Debit Card");
            Console.WriteLine("4.Cash on Delivery");
            Console.WriteLine("5.Any other Way");

            try
            {
              Console.WriteLine("Enter your choice:");
              int choice=Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                    Console.WriteLine("Payment Successful");
                    return;
                    break;
                    case 2:
                    Console.WriteLine("Payment Successful");
                    return;
                    break;
                    case 3:
                    Console.WriteLine("Payment Successful");
                    return;
                    break;
                    case 4:
                    Console.WriteLine("Payment Successful");
                    return;
                    break;
                    case 5:
                    string py=Console.ReadLine();
                    Console.WriteLine("Payment Successful");
                    return;
                    break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please Enter Number Only");
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    }
        




        
            
        
    

