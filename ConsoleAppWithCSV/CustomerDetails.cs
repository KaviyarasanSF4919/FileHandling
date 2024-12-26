using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ConsoleAppWithCSV
{
    /// <summary>
    /// CustomerDetails <see cref="CustomerDetails"/>\is a class, Holds the properties of the Customer Details
    /// </summary>
    public class CustomerDetails
    {
        //properties of class customerDetails
        private static long s_customerId=3000;
        
        public string CustomerId{get;set;}
        private double _walletBalance;
        public string CustomerName{get;set;}
        public string CityName{get;set;}
        public string PhoneNumber{get;set;}
        public double WalletBalance{get{return _walletBalance;}}
        public string EmailId{get;set;}
        /// <summary>
        /// CustomerDetails() is a Default constructor
        /// </summary>
        public CustomerDetails()
        {
        }
        /// <summary>
        /// CustomerDetails() is a parameterized Constructor used for initializing Class members
        /// </summary>
        /// <param name="customerName"></param>
        /// <param name="cityName"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="walletBalance"></param>
        /// <param name="emailId"></param>
        public CustomerDetails(string customerName,string cityName,string phoneNumber,double walletBalance,string emailId)
        {
            CustomerId=$"CID{++s_customerId}";
            CustomerName=customerName;
            CityName=cityName;
            PhoneNumber=phoneNumber;
            _walletBalance=walletBalance;
            EmailId=emailId;

        }
        /// <summary>
        /// WalletRecharge() is a method which accepts integer amount as a parameter and add it to the class member _walletBalance
        /// </summary>
        /// <param name="amount"></param>
        public void WalletRecharge(double amount)
        {
            _walletBalance+=amount;
        }
        /// <summary>
        /// DeductWalletBalance is a method used to deduct amount from _walletBalance class member
        /// </summary>
        /// <param name="amount"></param>
        public void DeductWalletBalance(double amount)
        {
            _walletBalance-=amount;
        }
        public string GetPrimaryKey()
        {
            return CustomerId;
        }
    }
}