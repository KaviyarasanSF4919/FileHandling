using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadWriteCSV
{
    public class StudentDetails
    {
        public string StudentName{get;set;}
        public string FatherName{get;set;}
        public DateTime DOB{get;set;}
        public int Marks{get;set;}

        public StudentDetails()
        {

        }

        public StudentDetails(string name,string fatherName,DateTime dob,int marks)
        {
            StudentName=name;
            FatherName=fatherName;
            DOB=dob;
            Marks=marks;
        }
    }
}