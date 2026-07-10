
    double totalPackages = 0;
    int x =0;
    int y =0;
    int z =0;
    double PackageId;
   

    for(PackageId=1001; PackageId<=1020; PackageId++)
{   
    
    if (PackageId % 4 == 0)
        {  x++;
        Console.WriteLine("Quality Check Required.");
        }
    
    else if (PackageId % 5 == 0)
       { y++;
         Console.WriteLine("Priority Shipment.");
       }
        
    
    else
       { z++;
       Console.WriteLine("Normal Processing.");
       }
        
    totalPackages++;
    
}
Console.WriteLine("-------SUMMARY---------");
Console.WriteLine("total packages processed:"+totalPackages);
Console.WriteLine("total no of quality check required is:"+x);
Console.WriteLine("total no of Priority shipment:"+y);
Console.WriteLine("total no of Normal Processing:"+z);