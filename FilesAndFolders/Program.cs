using System;
using System.IO;
namespace FilesAndFolders;

class Program 
{
    public static void Main(string[] args)
    {
        //creating directory
        if(!Directory.Exists("TestFolder"))
        {
            Console.WriteLine($"Creating Test Folder...");
            Directory.CreateDirectory("TestFolder");
        }
        //if already exist 
        else
        {
            Console.WriteLine($"Already Exists");           
        }
        //creating a file in already created directory
        if(!File.Exists("TestFolder/TestFile.txt"))
        {
            Console.WriteLine($"Creating Test file...");
            //creating file "TestFile" in "TestFolder" directory
            File.Create("TestFolder/TestFile.txt").Close();
        }
        //if  the specified file already exist
        else
        {
            Console.WriteLine($"File already Exist!");
        }
        //to Read and Write
        Console.WriteLine($"Select an option to do\n1.Read\n2.Write");
        int option=int.Parse(Console.ReadLine());
        switch(option)
        {
            case 1:
            {
                //reading the file
                StreamReader stream=new StreamReader("TestFolder/TestFile.txt");
                //line in a that file
                string data=stream.ReadLine();
                while(data!=null)
                {
                    //writing to the console
                    Console.WriteLine(data);
                    data=stream.ReadLine();
                }
                //closing reading function
                stream.Close();
                break;
            }
            case 2:
            {
                //reading  the file to string array
                string[] file=File.ReadAllLines("TestFolder/TestFile.txt");
                //onject for writing functions
                StreamWriter streamWriter=new StreamWriter("TestFolder/TestFile.txt");
                Console.WriteLine("enter the content you want to write in the file:");
                //contents to be written
                string data=Console.ReadLine();
                string result="";

                foreach(string line in file)
                {
                    result+=line+"\n";
                }
                result=result+data;
                //writing to the file
                streamWriter.WriteLine(result);
                streamWriter.Close();
                break;
            }
            default:
            {
                Console.WriteLine($"Invalid choice");
                break;
            }
        }
    }
}