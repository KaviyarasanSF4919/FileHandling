using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ConsoleAppWithCSV
{
    /// <summary>
    /// Grid<typeparamref name="DataType"/> is a Generic class
    /// </summary>
    /// <typeparam name="DataType"></typeparam>
    public class Grid<DataType>
    {
        /// <summary>
        /// ToDisplay() is a method which accepts List <typeparamref name="DataType"/> as parameter to display application's database in GridView
        /// </summary>
        /// <param name="list"></param>
        public void ToDisplay(CustomList<DataType> list)
        {
            if(list!=null  &&  list.Count>0){
                PropertyInfo [] properties=typeof(DataType).GetProperties();
                //Line
                System.Console.WriteLine(new string('-',properties.Length*20));
                //property names
                System.Console.Write("|");
                foreach(var property in properties)
                {
                    System.Console.Write($" {property.Name,-17} |");
                }
                System.Console.WriteLine();
                //Line
                System.Console.WriteLine(new string('-',properties.Length*20));
                //traverse list
                foreach(var data in list)
                {
                    System.Console.Write("|");
                    //to form a row getting one by one
                    foreach(var property in properties) 
                    {
                        //can read -->get property availabele?
                        if(property.CanRead){
                            if(property.PropertyType==typeof(DateTime))
                            {
                                //incase of property as DateTime variable 
                                var value=((DateTime)property.GetValue(data)).ToString("dd/MM/yyyy");
                                System.Console.Write($" {value,-17} |");
                            }
                            else{
                                var value=property.GetValue(data);
                                System.Console.Write($" {value,-17} |");
                            }
                        }
                    }
                    Console.WriteLine();
                }
                System.Console.WriteLine(new string('-',properties.Length*20));
            }
        }
    }
}