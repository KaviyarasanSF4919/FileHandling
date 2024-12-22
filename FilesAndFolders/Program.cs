using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;
namespace FilesAndFolders;

class Program 
{
    public static void Main(string[] args)
    {
        string directory=@"D:\MyFolder";
        string folderPath=directory+"/folder1";
        if(!Directory.Exists(folderPath))
        {
            Console.WriteLine($"Creating Folder...");
            Directory.CreateDirectory(folderPath);
        }
        else
        {
            Console.WriteLine($"Folder already exists!");          
        }
        string filePath=directory+"/MyFile.txt";
        if(!File.Exists(filePath))
        {
            Console.WriteLine($"Creating file...");
            File.Create(filePath).Close();
        }
        else 
        {
            Console.WriteLine($"File already existed!");
        }
        Console.WriteLine($"Select an option\n1.Create Folder\n2.Create File\n3.Delete Folder\n4.Delete File");
        Console.WriteLine($"Enter your option");        
        int option =int.Parse(Console.ReadLine());
        switch(option)
        {
            case 1:
            {
                Console.WriteLine($"Enter the name of the folder to be created");
                string folderName=Console.ReadLine();
                string folderPath1=directory+"/"+folderName;
                if(!Directory.Exists(folderPath1))
                {                                   
                    Directory.CreateDirectory(folderPath1);
                    Console.WriteLine($"folder created successfully");   
                }
                else
                {
                    Console.WriteLine($"Folder with {folderName} already exists in current directory");                   
                }
                break;
            }
            case 2:
            {
                Console.WriteLine($"Enter the name of the file to be created");
                string fileName=Console.ReadLine();
                Console.WriteLine($"Enter the extension of that file");
                string extension=Console.ReadLine();
                string file=folderPath+"/"+fileName+"."+extension;
                if(!File.Exists(file))
                {                   
                    File.Create(file);
                    Console.WriteLine($"File created successfully");
                    
                }
                else
                {
                    Console.WriteLine($"The file with name {fileName} already existed");                   
                }
                break;
            }
            case 3:
            {
                foreach(string path in Directory.GetDirectories(directory))
                {
                    Console.WriteLine(path);                   
                }
                Console.WriteLine($"Enter the Folder name To be deleted");
                string folderName=Console.ReadLine();
                foreach(string path in Directory.GetDirectories(directory))
                {
                    if(path.Contains(folderName))
                    {      
                        Directory.Delete(path);
                        Console.WriteLine($"Folder deleted.");
                        
                    }
                }                
                break;
            }
            case 4:
            {
                foreach(string path in FileSystem.GetFiles(directory))
                {
                    Console.WriteLine(path);                   
                }
                Console.WriteLine($"Enter the File name To be deleted");
                string fileName=Console.ReadLine();
                Console.WriteLine($"enter the extension of that file");
                string extension=Console.ReadLine();
                string file=directory+"\\"+fileName+"."+extension;
                Console.WriteLine(file);
                foreach(string path in FileSystem.GetFiles(directory))
                {
                    if(path.Contains(file))
                    {      
                        File.Delete(file);
                        Console.WriteLine($"Files deleted.");
                    }
                }                
                break;
            }

        }
        
    }
}