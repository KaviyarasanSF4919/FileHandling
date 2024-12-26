using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace ConsoleAppWithCSV;

class Program
{
    public static void Main(string[] args)
    {
        FileHandlings<CustomerDetails> customerFiles = new FileHandlings<CustomerDetails>(FileType.CSV);
        FileHandlings<OrderDetails> orderFiles = new FileHandlings<OrderDetails>(FileType.CSV);
        FileHandlings<ProductDetails> foodFiles = new FileHandlings<ProductDetails>(FileType.CSV);
        if(customerFiles.CanReadWrite)
        {
            Operations.UserDefaultData();
        }
        else
        {
            customerFiles.Read(out CustomList<CustomerDetails> customList);
            Operations.customers.AddRange(customList);
        }
        if(orderFiles.CanReadWrite)
        {
            Operations.OrderDefaultData();
        }
        else
        {
            orderFiles.Read(out CustomList<OrderDetails> customList);
            Operations.orders.AddRange(customList);
        }
        if(foodFiles.CanReadWrite)
        {
            Operations.ProductDefaultData();
        }
        else
        {
            foodFiles.Read(out CustomList<ProductDetails> customList);
            Operations.products.AddRange(customList);
        }
        Grid<CustomerDetails> userGrid=new Grid<CustomerDetails>();
        userGrid.ToDisplay(Operations.customers);
        Grid<OrderDetails>orderGrid=new Grid<OrderDetails>();
        orderGrid.ToDisplay(Operations.orders);
        Grid<ProductDetails>foodGrid=new Grid<ProductDetails>();
        foodGrid.ToDisplay(Operations.products);     
        Operations.MainMenu();
        customerFiles.Write(Operations.customers);
        orderFiles.Write(Operations.orders);
        foodFiles.Write(Operations.products);
        
    }
}