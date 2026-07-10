int Light_number;
float total_power=0;
int Light_no=0;
int maintencecount =0;
int normalcount=0;
int energycount=0;

for (Light_number = 1; Light_number <= 30; Light_number++)
{
    float Power = 80 +(Light_number*5);

    if (Power > 180)
    {   maintencecount++;
        Console.WriteLine("Maintanence is Required.");
    }
    else if (Power >140 && Power < 180)
    {   normalcount++;
        Console.WriteLine("Normal Operation");
    }
    else
    {   energycount++;
        Console.WriteLine("Energy efficient.");
    }
    total_power+=Power;
    Light_no++;
}
Console.WriteLine("------Summary------");
Console.WriteLine("Total Power Consumed is:"+total_power+"W");
Console.WriteLine("Average Power Consumed:"+total_power/Light_no+"W");
Console.WriteLine("total no of street light required maintanence:"+ maintencecount++);
Console.WriteLine("total no of normal operation required:"+normalcount);
Console.WriteLine("total no of energy efficient street light:"+energycount);

