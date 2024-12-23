using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.Json;
namespace ReadWriteCSV;

class Program
{
    public static void Main(string[] args)
    {
        if(!Directory.Exists("TestFolder"))
        {
            Console.WriteLine($"creating a folder...");
            Directory.CreateDirectory("TestFolder");            
        }
        else 
        {
            Console.WriteLine($"Folder already existed");
        }
        if(!File.Exists("TestFolder/test.csv"))
        {
            Console.WriteLine($"Creating csv file");
            File.Create("TestFolder/test.csv");
        }
        else
        {
            Console.WriteLine($"Csv file already existed");
        }
        if(!File.Exists("TestFolder/test.json"))
        {
            Console.WriteLine($"Creating json file");
            File.Create("TestFolder/test.json");
        }
        else
        {
            Console.WriteLine($"json file already existed");
        }
        List<StudentDetails> students=new List<StudentDetails>();
        students.Add(new StudentDetails("ravi","chandran",new DateTime(1999,06,07),355));
        students.Add(new StudentDetails("baskaran","sethu",new DateTime(1998,03,11),455));
        students.Add(new StudentDetails("indran","chandran",new DateTime(1997,08,12),595));
        // WriteToCSV(students);
        // ReadFromCSV();
        // WriteToJson(students);
        ReadFromJson();
    }
    public static void WriteToCSV(List<StudentDetails> list)
    {
        StreamWriter streamWriter=new StreamWriter("TestFolder\\test.csv");
        foreach(StudentDetails student in list)
        {
            string line=student.StudentName+","+student.FatherName+","+student.DOB.ToString("dd/MM/yyyy")+","+student.Marks;
            streamWriter.WriteLine(line);
        }
        streamWriter.Close();
    }
    public static void ReadFromCSV()
    {
        List<StudentDetails> newlist=new List<StudentDetails>();
        StreamReader streamReader=new StreamReader("TestFolder\\test.csv");
        string line=streamReader.ReadLine();
        while(line!=null)
        {
            string[] row=line.Split(",");
            if(row[0]!="")
            {
                StudentDetails student=new StudentDetails(row[0],row[1],DateTime.ParseExact(row[2],"dd/MM/yyyy",null),int.Parse(row[3]));
                newlist.Add(student);
            }
            line=streamReader.ReadLine();
            
        }
        streamReader.Close();
        foreach(StudentDetails studentDetail in newlist)
        {
            Console.WriteLine($"Student Name: {studentDetail.StudentName}\nFather Name: {studentDetail.FatherName}\nDate Of birth: {studentDetail.DOB.ToString("dd/MM/yyyy")}\nMarks: {studentDetail.Marks}");         
        }
    }
    public static void WriteToJson(List<StudentDetails> list)
    {
        StreamWriter sw=new StreamWriter("TestFolder\\test.json");
        var option=new JsonSerializerOptions
        {
            WriteIndented=true
        };
        string jsonData=JsonSerializer.Serialize(list,option);
        sw.WriteLine(jsonData);
        sw.Close();
    }
    public static void ReadFromJson()
    {
        List<StudentDetails> students=JsonSerializer.Deserialize<List<StudentDetails>>(File.ReadAllText("TestFolder/test.json"));
        foreach(StudentDetails student in students)
        {
            Console.WriteLine($"Student Name : {student.StudentName}\nFather name : {student.FatherName}\nDate of birth : {student.DOB.ToString("dd/MM/yyyy")}\nMarks : {student.Marks}");
        }
    }
}