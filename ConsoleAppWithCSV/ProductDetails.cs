using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleAppWithCSV
{
    /// <summary>
    /// <see cref="ProductDetails"/> is a class holds product detail blue print
    /// </summary
    public class ProductDetails
    {
        //properties and and members
        private static long s_productId=2000;
        public string ProductId{get;set;}
        public string ProductName{get;set;}
        public int Stock{get;set;}
        public double Price{get;set;}
        public double ShippingDuration{get;set;}
        //to generrate id
        /// <summary>
        /// constructo to generate Product Id
        /// </summary>
        public ProductDetails()
        {
            ProductId=$"PID{++s_productId}";
            ProductName="";
        }
        //to deduct the number of stoc when purchase done
        /// <summary>
        /// Method to Reduce stock for a specific Product
        /// </summary>
        /// <param name="count"></param>
        public void DeductStock(int count)
        {
            Stock-=count;
        }
    }
}