using System;
using System.Collections.Generic;


{
    List<string> book =new List<string>();
     book.Add("wings of fire");
     book.Add("experiments with truth");
     book.Add("playing it my way");
     book.Add("half girlfriend");
     book.Add("2 states");
     void printbooks(){
     foreach(string s in book)
    {
        Console.WriteLine(s);
    }
    }
    Console.WriteLine("List of books");

    printbooks();
    book.Add("Bhagwatgita");
    Console.WriteLine("new book is added......");
    printbooks();

    book.Remove("2 states");
    Console.WriteLine("one book is deleted....");
    printbooks();

    Console.WriteLine("Updated List of books:");
    printbooks();
    

    
}