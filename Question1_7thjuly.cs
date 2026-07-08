
        double Package_ID;
        int x=0;
        int y=0;
        int z=0;
        

        for (Package_ID = 1001; Package_ID <= 1020; Package_ID ++)
        {   
            if (Package_ID % 4 == 0)       
            x++;
            else if(Package_ID % 5 == 0)
            y++;   
            else
            z++;      
        }
        
        Console.WriteLine("Number of packages requiring quality check:"+x);
        Console.WriteLine("Number of priority shipments:"+y);
        Console.WriteLine("Number of normal packages:"+z);
    
