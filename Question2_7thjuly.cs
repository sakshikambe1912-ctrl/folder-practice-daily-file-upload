
       
        int light_number;
        int x=0;
        int y=0;
        int z=0;
        double power=0;
        double totalpower=0;
        for (light_number = 1; light_number <= 30; light_number++)
        {
        
        power = 80+light_number*5;
        if (power > 180)
        x++;
        else if ((180 >=power)&& (power> 140))
        y++;
        else
        z++;
        totalpower+=power;
        }
        Console.WriteLine("the total power consumed by all lamps is:"+totalpower);
        Console.WriteLine("the average power consumed by lamps is:"+totalpower/30);
        Console.WriteLine("Number of lights in Maintenance Required:"+x);
        Console.WriteLine("Number of lights in Normal Operation:"+y);
        Console.WriteLine("Number of lights in Energy Efficient:"+z);

    