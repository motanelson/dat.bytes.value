using Cosmos.HAL.BlockDevice.Registers;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.IO;
using System.Text;
using Sys = Cosmos.System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


public class Kernel : Sys.Kernel
{
    Sys.FileSystem.CosmosVFS fs;
    protected override void BeforeRun()
    {
        fs = new Sys.FileSystem.CosmosVFS();
        Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
    }

    protected override void Run()
    {
        string[] s = new string[2];
        while (true)
        {
            var fs_type = fs.GetFileSystemType(@"0:\");
            Console.WriteLine("File System Type: " + fs_type);
            var directory_list = Directory.GetFiles(@"0:\");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            foreach (var file in directory_list)
            {
                Console.WriteLine(file);
            }
            var available_space = fs.GetAvailableFreeSpace(@"0:\");
            Console.WriteLine("Available Free Space: " + available_space);
            Console.WriteLine("give me the input file");
            s[0] = "0:\\" + Console.ReadLine();
            Console.WriteLine("give me the output file");
            s[1] = "0:\\" + Console.ReadLine();
            Main(s);


        }
    }


    public static void Main(string[] argv)
    {
        Byte[] c;
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
            s = s + b.ToString();
            counter++;
            counter1++;
            if (counter > 15)

            {
                s = s + "\r\n";
                counter = 0;
            }
            else
            {

                if (counter1 != c.Length) s = s + ",";
            }

        }
        File.WriteAllText(argv[1], s);
    }


}

