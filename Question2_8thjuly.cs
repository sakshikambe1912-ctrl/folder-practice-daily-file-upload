using System.Collections.Generic;

{
    List<string> Books = new List<string>();
    Books.Add("wings of fire");
    Books.Add("playing it my way");
    Books.Add("experiments with truth");
    Books.Add("five point someone");
    Books.Add("2 states");
    //Original list of library books
    Console.WriteLine("All Books:");
        int x =0;
    foreach(string s in Books)
    {    x++;
        Console.WriteLine(s);
        

    }
    Console.WriteLine("total no of Books:"+x);
    //added a new book into the library list
    Books.Add("Vikram Betal");
    Console.WriteLine("Updated list:");
    int y=0;
    foreach(string s in Books)
    {   y++;
        Console.WriteLine(s);
    }
    Console.WriteLine("total no of Books:"+y);
    //deleted a book from library list
    Books.Remove("five point someone");
     int z =0;
    Console.WriteLine("Updated list:");
    foreach(string s in Books)
    {   z++;
        Console.WriteLine(s);
    }
    Console.WriteLine("total no of Books:"+z);
    

}