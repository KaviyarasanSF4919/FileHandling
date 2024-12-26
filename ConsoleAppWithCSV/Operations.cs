using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ConsoleAppWithCSV
{
    /// <summary>
    /// operation <see cref="Operation"/> is a static class which initializes default details on premise
    /// </summary>
    public static class Operations
    {
        //create database for application
        public static CustomList<CustomerDetails> customers = new CustomList<CustomerDetails>();
        public static CustomList<ProductDetails> products = new CustomList<ProductDetails>();
        public static CustomList<OrderDetails> orders = new CustomList<OrderDetails>();
        public static CustomerDetails currentLoggedInCustomer;
        /// <summary>
        /// defaultData() is a method which loads default data into the system
        /// </summary>
        public static void UserDefaultData()
        {
            //creating objects for the default customer, product and order details
            //filling  default customer details
            CustomerDetails customer1 = new CustomerDetails("Ravi", "Chennai", "9885858588", 50000, "ravi@mail.com");
            CustomerDetails customer2 = new CustomerDetails("Baskaran", "Chennai", "9888475757", 60000, "baskaran@mail.com");
            //adding instances to the customer list
            customers.AddRange(new CustomList<CustomerDetails>() { customer1, customer2 });
        }
        public static void ProductDefaultData()
        {
            //filling default product Details
            ProductDetails product1 = new ProductDetails();
            product1.ProductName = "Mobile(Samsung)";
            product1.Stock = 10;
            product1.Price = 10000;
            product1.ShippingDuration = 3;
            ProductDetails product2 = new ProductDetails();
            product2.ProductName = "Tablet (Lenovo)";
            product2.Stock = 5;
            product2.Price = 15000;
            product2.ShippingDuration = 2;
            ProductDetails product3 = new ProductDetails();
            product3.ProductName = "Camera(Sony)";
            product3.Stock = 3;
            product3.Price = 20000;
            product3.ShippingDuration = 4;
            ProductDetails product4 = new ProductDetails();
            product4.ProductName = "iPhone";
            product4.Stock = 3;
            product4.Price = 50000;
            product4.ShippingDuration = 6;
            ProductDetails product5 = new ProductDetails();
            product5.ProductName = "Laptop(Lenovo i3)";
            product5.Stock = 3;
            product5.Price = 40000;
            product5.ShippingDuration = 3;
            ProductDetails product6 = new ProductDetails();
            product6.ProductName = "HeadPhone (Boat)";
            product6.Stock = 5;
            product6.Price = 1000;
            product6.ShippingDuration = 2;
            ProductDetails product7 = new ProductDetails();
            product7.ProductName = "Speakers (Boat)";
            product7.Stock = 4;
            product7.Price = 500;
            product7.ShippingDuration = 2;
            //adding details to the Product list
            products.AddRange(new CustomList<ProductDetails>() { product1, product2, product3, product4, product5, product6, product7 });
        }
        public static void OrderDefaultData()
        {
    
            //filling default orders details
            OrderDetails order1 = new OrderDetails("CID3001", "PID2001", 20000, DateTime.Now, 2, OrderStatus.Ordered);
            OrderDetails order2 = new OrderDetails("CID3002", "PID2003", 40000, DateTime.Now, 2, OrderStatus.Ordered);
            orders.AddRange(new CustomList<OrderDetails>() { order1, order2 });
        }
        /// <summary>
        /// MainMenu() is a method which diplay main menu to the user
        /// </summary>
        public static void MainMenu()
        {
            Console.WriteLine($"****** MAIN MENU **********");
            try
            {
                bool flag = true;
                do
                {
                    //show mennu with 1.Registration 2.Login 3.Exit
                    Console.WriteLine($"Main Menu :\n1.Registration\n2.Login\n3.Exit");
                    //users choice
                    Console.WriteLine($"Enter Your Choice :");
                    int choice = int.Parse(Console.ReadLine());
                    //1.Registration 2.Login 3.Exit
                    switch (choice)
                    {
                        case 1:
                            {
                                Registration();
                                break;
                            }
                        case 2:
                            {
                                Login();
                                break;
                            }
                        case 3:
                            {
                                flag = false;
                                Console.WriteLine($"Thanks For choosing SynCartE !!");
                                break;
                            }
                    }

                } while (flag);
            }
            //incase of wrong input format
            catch (FormatException ex)
            {
                Console.WriteLine($"Enter a valid Entry");
                Console.WriteLine(ex.Message);

            }
            //any other exception
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        /// <summary>
        /// SubMainMenu() is a method used for showing sub main menu to the user
        /// </summary>
        public static void SubMainMenu()
        {
            Console.WriteLine($"******* SUB MENU ********");
            //options in sub menu a.Purchase b.OrderHistory c.CancelOrder d.WalletBalance e.WalletRecharge f.Exit
            bool flag = true;
            do
            {
                try
                {
                    Console.WriteLine($"1.Purchase \n2.OrderHistory \n3.CancelOrder \n4.WalletBalance \n5.WalletRecharge \n6.Exit");
                    //user's choice
                    Console.WriteLine($"Enter Your choice :");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                //to purchase product
                                Purchase();
                                break;
                            }
                        case 2:
                            {
                                //order history
                                OrderHistory();
                                break;
                            }
                        case 3:
                            {
                                //to cance order
                                CancelOrder();
                                break;
                            }
                        case 4:
                            {
                                //to check available balance
                                WalletBalance();
                                break;
                            }
                        case 5:
                            {
                                //to recharge wallet
                                WalletRecharge();
                                break;
                            }
                        case 6:
                            {
                                //exit;
                                flag = false;
                                break;
                            }
                    }
                }
                //handling exception incase of wrong format entry
                catch (FormatException ex)
                {
                    Console.WriteLine($"You Entered a Invalid choice");
                    Console.WriteLine(ex.Message);
                }
                //any other exception may occur
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (flag);

        }
        /// <summary>
        /// Registration() is a method used to register new user to the system
        /// </summary>
        public static void Registration()
        {
            //try block to continue the flow of execution incase of exception occur due to input 
            try
            {
                //getting user input
                Console.WriteLine($"Enter Your Name :");
                string customerName = Console.ReadLine();
                Console.WriteLine($"Enter Your City Name :");
                string cityName = Console.ReadLine();
                Console.WriteLine($"Enter Your Mobile Number :");
                string phoneNumber = Console.ReadLine();
                Console.WriteLine($"Enter Your Initaial Wallet Balance :");
                double walletBalance = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"Enter Your Email iD :");
                string emailId = Console.ReadLine();
                //creating customerDetails object
                CustomerDetails customer = new CustomerDetails(customerName, cityName, phoneNumber, walletBalance, emailId);
                //showing custoomer Id to the registered user
                Console.WriteLine($"Your Registration is Successfull This is your Customer ID {customer.CustomerId}");
                //add customer to customer details list
                customers.Add(customer);
            }
            //formatException
            catch (FormatException ex)
            {
                Console.WriteLine($"You Entered Invalid Data Please Try Again!");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Console.WriteLine(ex.StackTrace);      //Incase of Ecxception logging
            }

        }
        /// <summary>
        /// Login() is a method used to authenticate the user with valid user id
        /// </summary>       
        public static void Login()
        {
            Console.WriteLine($"*******LOGIN MENU********");
            //get customer id
            Console.WriteLine($"enter your customer id");
            try
            {
                string eneteredCustomerId = Console.ReadLine().ToUpper();
                //validate customer id
                bool exist = customers.BinarySearch("CustomerId", eneteredCustomerId, out CustomerDetails currentUser);
                if (exist)
                {
                    currentLoggedInCustomer = currentUser;
                    SubMainMenu();
                }
                else
                {
                    Console.WriteLine($"Invalid Customer ID!");

                }
            }
            //wrong Format
            catch (FormatException ex)
            {
                Console.WriteLine($"Enter a valid Entry !");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        /// <summary>
        /// Purchase() is a Method used to purchase product listed in system database
        /// </summary>
        public static void Purchase()
        {
            //show productList
            Grid<ProductDetails> grid = new Grid<ProductDetails>();
            grid.ToDisplay(products);
            //get product id from the user
            try
            {
                Console.WriteLine($"Enter product ID to buy product:");
                string enteredProductId = Console.ReadLine().ToUpper();
                //check the product id is valid if no show invalid product id
                bool exist = products.BinarySearch("ProductId", enteredProductId, out ProductDetails product);
                if (exist)
                {
                    //quantity of the product
                    Console.WriteLine($"Enter the quantity of the selected product");
                    int quantity = int.Parse(Console.ReadLine());
                    //if valid ID check  for quantity is available if no shoe required quantity is unavailable
                    if (product.Stock >= quantity)
                    {
                        //if yes- calculate total with delivery charge 50 rs
                        double amount = (quantity * product.Price) + 50;
                        //check user ha required balance to buy if no show insufficient balance
                        if (amount <= currentLoggedInCustomer.WalletBalance)
                        {
                            //if he has balance deduct amount from his walletbalance
                            currentLoggedInCustomer.DeductWalletBalance(amount);
                            //reduce product count 
                            product.Stock -= quantity;
                            //create order object
                            OrderDetails order = new OrderDetails(currentLoggedInCustomer.CustomerId, product.ProductId, amount, DateTime.Now, quantity, OrderStatus.Ordered);
                            //order successfull
                            Console.WriteLine($"Your are order is placed !");
                            //add to order list   
                            orders.Add(order);
                        }
                        else
                        {
                            Console.WriteLine($"Insufficient Balance!");
                        }
                    }//showing insufficient balance incase user dont have enough money
                    else
                    {
                        Console.WriteLine($"Insufficient Stock Unavailable");
                    }
                    
                }
                else
                {
                    Console.WriteLine($"Invalid Product ID");
                    
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Enter a valid Entry");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        /// <summary>
        /// OrderHistory() is a static method in <see cref="Operations"/> used to show history of orders by the user
        /// </summary>
        public static void OrderHistory()
        {
            CustomList<OrderDetails> userHistory=new CustomList<OrderDetails>();
            bool orderFlag=true;
            foreach(OrderDetails order in orders)
            {
                if(order.CustomerId.Equals(currentLoggedInCustomer.CustomerId))
                {
                    orderFlag=false;
                    userHistory.Add(order);
                }
            }
            if(orderFlag)
            {
                Console.WriteLine($"No order History Found");
                
            }
            else
            {
                Grid<OrderDetails> grid=new Grid<OrderDetails>();
                grid.ToDisplay(userHistory);
            }
        }
        public static void CancelOrder()
        {
            CustomList<OrderDetails> orderedProducts=new CustomList<OrderDetails>();
            //show order details of current user whose order status is Ordered.if no show no order history
            bool flag = true;
            foreach (OrderDetails order in orders)
            {
                //if user has history the display the order  details
                if (order.CustomerId.Equals(currentLoggedInCustomer.CustomerId) && order.OrderStatus.Equals(OrderStatus.Ordered))
                {
                    flag = false;
                    orderedProducts.Add(order);
                }
            }
            if (flag)
            {
                //if no order list fount
                Console.WriteLine($"No order History found");
            }
            else
            {
                Grid<OrderDetails> grid=new Grid<OrderDetails>();
                grid.ToDisplay(orderedProducts);
                //if present then get order id
                Console.WriteLine($"Enter Order id");
                try
                {
                    string enteredorderedId = Console.ReadLine().ToUpper();
                    //validate the orderId incase of wrong entery notify user with invalid id
                    bool orderCheck = orders.BinarySearch("OrderId",enteredorderedId,out OrderDetails order);
                    if(orderCheck)
                    {
                        if (currentLoggedInCustomer.CustomerId.Equals(order.CustomerId) && order.OrderStatus.Equals(OrderStatus.Ordered) && order.OrderId.Equals(enteredorderedId))
                        {
                            //return ordered amount to the user for cancellatoin
                            currentLoggedInCustomer.WalletRecharge(order.TotalPrice - 50);
                            //change the order status
                            order.OrderStatus = OrderStatus.Cancelled;
                            //return ordered product to product list
                            foreach (ProductDetails product in products)
                            {
                                if (product.ProductId.Equals(order.ProductId))
                                {
                                    product.Stock += order.Quantity;
                                    break;
                                }
                            }
                            Console.WriteLine($"Order cancelled Successfully");
                        }
                    }
                    //if no oderId matchs Show invalid order Id
                    else
                    {
                        Console.WriteLine($"Invalid Order Id");

                    }
                }
                //format exception by user input
                catch (FormatException ex)
                {
                    Console.WriteLine($"Enter a valid Entry");
                    Console.WriteLine(ex.Message);
                }
                //other exceptions
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
        }
        /// <summary>
        /// Walletbalance() is a method used to check wallet balance
        /// </summary>
        public static void WalletBalance()
        {
            //displaying current wallet balance
            Console.WriteLine($"your current Walllet balance is {currentLoggedInCustomer.WalletBalance}");

        }
        /// <summary>
        /// WalletRecharge() is a method to recharge amount to the user's wallet
        /// </summary>
        public static void WalletRecharge()
        {
            //get the amount to recharge
            Console.WriteLine($"Enter amount to recharge:");
            try
            {
                double amount = Convert.ToDouble(Console.ReadLine());
                if (amount > 0)
                {
                    //if it is valid amount - add to  user's balance aand show the wallet baldance
                    currentLoggedInCustomer.WalletRecharge(amount);
                    Console.WriteLine($"Cerrent Balance : {currentLoggedInCustomer.WalletBalance}");
                }
                //else show invalid amount
                else
                {
                    Console.WriteLine($"Invalid Amount!");

                }
            }
            //incase of wrong input format
            catch (FormatException ex)
            {
                Console.WriteLine($"enter a valid Amount");
                Console.WriteLine(ex.Message);
            }
            //other exception
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

    }

}