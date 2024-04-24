using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace LibaryManagement
{
    public static class Operations
    {
        static UserDetails currentUser;
        static BookDetails currentBookUser;
        static List<UserDetails> userList = new List<UserDetails>();
        static List<BookDetails> bookList = new List<BookDetails>();
        static List<BorrowDetails> borrowList = new List<BorrowDetails>();

        public static void MainMenu()
        {
            System.Console.WriteLine("Online Library Management and Book tracking for the \"Syncfusion college\".");
            string mainChoice = "yes";
            do
            {
                System.Console.WriteLine("******Main Menu*******");
                System.Console.WriteLine("1. User Registration \n2. User Login \n3.Exit");
                int mainOption = int.Parse(Console.ReadLine());
                switch (mainOption)
                {
                    case 1:
                        {
                            System.Console.WriteLine("***Registration***");
                            Registration();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("***Login***");
                            Login();
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("Exit from the application.Thank you");
                            mainChoice = "no";
                            break;
                        }
                }

            } while (mainChoice == "yes");
        }

        public static void Registration()
        {
            System.Console.Write("Enter the Name: ");
            string userName = Console.ReadLine();
            System.Console.Write("Enter the Gender (Male/Female):");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            System.Console.Write("Enter the department (ECE,CSE,EEE): ");
            Department department = Enum.Parse<Department>(Console.ReadLine(), true);
            System.Console.Write("Enter the Mobile Number: ");
            string mobileNumber = Console.ReadLine();
            System.Console.Write("Enter the mail id: ");
            string mailID = Console.ReadLine();
            System.Console.Write("Enter the Wallet balance");
            int walletBalance = int.Parse(Console.ReadLine());
            UserDetails user = new UserDetails(userName, gender, department, mobileNumber, mailID, walletBalance);
            System.Console.WriteLine("Registration Successfully completed and UserID is " + user.UserID);
            userList.Add(user);
        }

        public static void Login()
        {
            System.Console.WriteLine("Enter the UserID");
            string loginID = Console.ReadLine().ToUpper();
            bool flag = true;
            foreach (UserDetails user in userList)
            {
                if (loginID.Equals(user.UserID))
                {
                    System.Console.WriteLine("Welcome to User Login");
                    flag = false;
                    currentUser = user;
                    SubMenu();
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Invalid User ID");
            }

        }


        public static void SubMenu()
        {
            string subChoice = "yes";
            do
            {
                System.Console.WriteLine("*****Sub Menu*****");
                System.Console.WriteLine("1.Borrow book \n2.Show Borrow histroy \n3.Return book  \n4.Wallet recharge  \n5.Exit");
                int subOption = int.Parse(Console.ReadLine());

                switch (subOption)
                {
                    case 1:
                        {
                            System.Console.WriteLine("Borrow book");
                            BorrowBook();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("Show Borrrow Histroy");
                            ShoWBorroWHistroy();
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("Return book");
                            ReturnBook();
                            break;
                        }
                    case 4:
                        {
                            System.Console.WriteLine("Wallent recharge");
                            WalletBalance();
                            break;
                        }
                    case 5:
                        {
                            System.Console.WriteLine("Exit from Sub menu taking back to main menu");
                            subChoice = "no";
                            break;
                        }
                }
            } while (subChoice == "yes");
        }

        public static void BorrowBook()
        {
            System.Console.WriteLine("|BookID|BookName|AuthorName|Bookcount");
            foreach (BookDetails book in bookList)
            {
                System.Console.WriteLine($"|{book.BookID}|{book.BookName}|{book.AuthorName}|{book.BookCount}");
            }
            System.Console.WriteLine();
            System.Console.WriteLine("Enter the Book ID: ");
            string borrowBookID = Console.ReadLine().ToUpper();
            bool flag = true;
            foreach (BookDetails book in bookList)
            {
                if (borrowBookID.Equals(book.BookID))
                {
                    currentBookUser = book;
                    flag = false;
                    System.Console.WriteLine("Enter the count of the book: ");
                    int borrowBookCount = int.Parse(Console.ReadLine());
                    if (book.BookCount >= borrowBookCount)
                    {

                        foreach (BorrowDetails borrow in borrowList)
                        {
                            if (borrow.BookID.Equals(book.BookID))
                            {
                                if (borrow.BorrowBookCount > 3)
                                {
                                    System.Console.WriteLine($"You can have maximum of 3 borrowed books. Your already borrowed books count is{borrow.BorrowBookCount} and current request count is {borrowBookCount},which exceed 3");

                                }
                                else if (borrow.BorrowBookCount == 3)
                                {
                                    System.Console.WriteLine("You have borrowed 3 books already");
                                }
                                else
                                {
                                    borrow.PaidFineAmount = 0;
                                    borrow.BookStatus = BookStatus.Borrowed;
                                    BorrowDetails borrowTaken = new BorrowDetails(book.BookID, currentUser.UserID, DateTime.Now, borrowBookCount, BookStatus.Borrowed, 0);
                                    System.Console.WriteLine("Book Borrow Successfully.");
                                    borrowList.Add(borrowTaken);
                                    break;
                                }
                            }


                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Books are not available for the selected count.");
                        foreach (BorrowDetails borrow in borrowList)
                        {
                            if (borrow.BookID.Equals(book.BookID))
                            {
                                DateTime addDays = borrow.BorrowDate.AddDays(15);
                                System.Console.WriteLine("The book will be avaiable  on {0}", addDays.ToString("dd/MM/yyyy"));

                            }
                        }
                    }
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Invalid Book ID,Please enter valid ID");

            }

        }



        public static void ReturnBook()
        {
            BorrowDetails currentBorrowUser;

            System.Console.WriteLine("|BorrowID|BookID|UserID|BorrowDate|BorrowBookCount|Status|PaidFineAmount");
            foreach (BorrowDetails borrow in borrowList)
            {
                if (currentUser.UserID.Equals(borrow.UserID) && (borrow.BookStatus == BookStatus.Borrowed))
                {
                    currentBorrowUser = borrow;
                    System.Console.WriteLine($"|{borrow.BorrowID}|{borrow.BookID}|{borrow.UserID}|{borrow.BorrowDate.ToString("dd/MM/yyyy")}|{borrow.BorrowBookCount}|{borrow.BookStatus}|{borrow.PaidFineAmount}");
                }
            }
            System.Console.WriteLine();
            foreach (BorrowDetails borrow in borrowList)
            {
                if (currentUser.UserID.Equals(borrow.UserID) && (borrow.BookStatus == BookStatus.Borrowed))
                {
                    DateTime returnDate = DateTime.Now;
                    System.Console.WriteLine($"The Return date of BookID {borrow.BookID} is {returnDate.ToString("dd/MM/yyyy")}");
                    DateTime startDate = borrow.BorrowDate;

                    TimeSpan ts = returnDate - startDate;

                    if (ts.TotalDays > 15)
                    {
                        int fineDays = (int)ts.TotalDays - 15;
                        int fineAmount = fineDays * 1;
                        System.Console.WriteLine($"The fine amount for BookID {borrow.BookID} is {fineAmount}");

                    }

                }
            }
            System.Console.Write("Enter the Borrow ID :");
            string returnBorrowID = Console.ReadLine().ToUpper();

            foreach (BorrowDetails borrow in borrowList)
            {
                foreach (BookDetails book in bookList)
                {
                    if (book.BookID.Equals(borrow.BookID))
                    {
                        currentBookUser = book;
                    }
                }
                if (currentUser.UserID.Equals(borrow.UserID) && (borrow.BookStatus == BookStatus.Borrowed))
                {
                    if (returnBorrowID.Equals(borrow.BorrowID))
                    {
                        DateTime returnDate = DateTime.Now;
                        DateTime startDate = borrow.BorrowDate;
                        TimeSpan ts = returnDate - startDate;

                        if (ts.TotalDays > 15)
                        {
                            int fineDays = (int)ts.TotalDays - 15;
                            int fineAmount = fineDays * 1;
                            if (currentUser.WalletBalance > fineAmount)
                            {
                                currentUser.WalletBalance -= fineAmount;
                                borrow.BookStatus = BookStatus.Returned;
                                borrow.PaidFineAmount = fineAmount;
                                System.Console.WriteLine("Book return Sucessfully.After paid a fine");
                                System.Console.WriteLine("Your Upadated wallet balance is " + currentUser.WalletBalance);

                                currentBookUser.BookCount += borrow.BorrowBookCount;


                            }
                            else
                            {
                                System.Console.WriteLine("Insufficient balance. Please rechange and proceed");

                            }


                        }
                        else
                        {
                            borrow.BookStatus = BookStatus.Returned;
                            System.Console.WriteLine("Book return Sucessfully.");
                            currentBookUser.BookCount += borrow.BorrowBookCount;

                        }
                        break;
                    }


                }
            }



        }
        public static void ShoWBorroWHistroy()
        {
            System.Console.WriteLine("|BorrowID|BookID|UserID|BorrowDate|BorrowBookCount|Status|PaidFineAmount");
            foreach (BorrowDetails borrow in borrowList)
            {
                if (currentUser.UserID.Equals(borrow.UserID))
                    System.Console.WriteLine($"|{borrow.BorrowID}|{borrow.BookID}|{borrow.UserID}|{borrow.BorrowDate.ToString("dd/MM/yyyy")}|{borrow.BorrowBookCount}|{borrow.BookStatus}|{borrow.PaidFineAmount}");
            }
            System.Console.WriteLine();
        }

        public static void WalletRecharge(int recharge)
        {
            currentUser.WalletBalance += recharge;
            System.Console.WriteLine("You Upadated balance is {0}", currentUser.WalletBalance);
        }

        public static void WalletBalance()
        {
            System.Console.Write("Do you want to recharge (yes/no): ");
            string rechargeOption = Console.ReadLine();
            if (rechargeOption == "yes")
            {
                System.Console.Write("Enter the amount to recharge: ");
                int rechargeWallet = int.Parse(Console.ReadLine());
                WalletRecharge(rechargeWallet);
            }
            else
            {
                System.Console.WriteLine("Thank you");
            }
        }


        public static void AddDefaultData()
        {
            UserDetails user1 = new UserDetails("Ravichandran", Gender.Male, Department.ECE, "9938388333", "ravi@gmail.com", 500);
            UserDetails user2 = new UserDetails("Priyadharshini", Gender.Female, Department.CSE, "9944444455", "priya@gmail.com", 150);
            userList.AddRange(new List<UserDetails> { user1, user2 });
            BookDetails book1 = new BookDetails("C#", "Author1", 3);
            BookDetails book2 = new BookDetails("HTMl", "Author2", 5);
            BookDetails book3 = new BookDetails("CSS", "Author3", 3);
            BookDetails book4 = new BookDetails("JS", "Author4", 3);
            BookDetails book5 = new BookDetails("TS", "Author5", 2);
            bookList.AddRange(new List<BookDetails> { book1, book2, book3, book4, book5 });
            BorrowDetails borrow1 = new BorrowDetails("BID1001", "SF3001", new DateTime(2023, 09, 10), 2, BookStatus.Borrowed, 0);
            BorrowDetails borrow2 = new BorrowDetails("BID1003", "SF3001", new DateTime(2023, 09, 12), 1, BookStatus.Borrowed, 0);
            BorrowDetails borrow3 = new BorrowDetails("BID1004", "SF3001", new DateTime(2023, 09, 14), 1, BookStatus.Returned, 16);
            BorrowDetails borrow4 = new BorrowDetails("BID1002", "SF3002", new DateTime(2023, 09, 11), 2, BookStatus.Borrowed, 0);
            BorrowDetails borrow5 = new BorrowDetails("BID1005", "SF3002", new DateTime(2023, 09, 09), 1, BookStatus.Returned, 20);
            borrowList.AddRange(new List<BorrowDetails> { borrow1, borrow2, borrow3, borrow4, borrow5 });
            System.Console.WriteLine("|UserID|UserName|Gender|Department|MobilNumber|MailID|WalletBalance");
            foreach (UserDetails user in userList)
            {
                System.Console.WriteLine($"|{user.UserID}|{user.UserName}|{user.Gender}|{user.Department}|{user.MobileNumber}|{user.MailID}|{user.WalletBalance}");
            }
            System.Console.WriteLine();

            System.Console.WriteLine("|BookID|BookName|AuthorName|Bookcount");
            foreach (BookDetails book in bookList)
            {
                System.Console.WriteLine($"|{book.BookID}|{book.BookName}|{book.AuthorName}|{book.BookCount}");
            }



        }
    }
}