


    long[] sales = {10000,12000,14000,17000,15000,19000};

    long totalsales=0;
    long highest = sales[0];
    long lowest = sales[0];
    for(long i = 1; i < sales.Length; i++)
        {
            if (sales[i] > highest)
                {
                    highest=sales[i];
                }
            if (sales[i] < lowest)
                {
                    lowest=sales[i];
                }

        }
    

    foreach(long s in sales)
    {
       Console.WriteLine(s); 
       totalsales+=s;
       
    }
    Console.WriteLine("Total sales:"+totalsales);
    Console.WriteLine("Average sales:"+totalsales/6);
    Console.WriteLine("the Heighest Sale is:"+highest);
    Console.WriteLine("the lowest Sale is:"+lowest);
    
