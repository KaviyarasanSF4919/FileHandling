using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleAppWithCSV
{
    /// <summary>
    /// <see cref="OrderDetails"/> is a class which creates instances of order details
    /// </summary>
    public class OrderDetails
    {
        private static int s_orderId=1000;
       
        public string OrderId{get;set;}
        public string CustomerId{get;set;}
        public string ProductId{get;set;}
        public double TotalPrice{get;set;}
        public DateTime PurchaseDate{get;set;}
        public int Quantity{get;set;}
        public  OrderStatus OrderStatus{get;set;}
        /// <summary>
        /// OrderDetails() is a default constructor
        /// </summary>
        public OrderDetails()
        {
            
        }
        /// <summary>
        /// OrderDetails() is a parameterized constructor to create instance of the class with its class member
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="productId"></param>
        /// <param name="totalPrice"></param>
        /// <param name="purchaseDate"></param>
        /// <param name="quantity"></param>
        /// <param name="orderStatus"></param>
        public OrderDetails(string customerId,string productId,double totalPrice,DateTime purchaseDate,int quantity,OrderStatus orderStatus)
        {
            OrderId=$"OID{++s_orderId}";
            CustomerId=customerId;
            ProductId=productId;
            TotalPrice=totalPrice;
            PurchaseDate=purchaseDate;
            Quantity=quantity;
            OrderStatus=orderStatus;
        }

    }
}