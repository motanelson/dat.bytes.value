using System;
using System.IO;


class DATAS
{

    public static void Main(string[] argv) 
    {
        Byte [] c;
        int counter = 0;
        int counter1 = 0;
        string s = "";
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        if (argv.Length < 2) return;
        c = File.ReadAllBytes(argv[0]);
        foreach (byte b in c)
        {
            s=s+ b.ToString();
            counter++;
            counter1++;
            if (counter > 15)

            {
                s = s + "\r\n";
                counter = 0;
            }
            else 
            {
                
                if(counter1!=c.Length)s= s + ",";
            }
            File.WriteAllText(argv[1], s);
        }
    
    }




}