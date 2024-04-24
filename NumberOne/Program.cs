using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Runtime.Intrinsics.Arm;
namespace NumberOne;
 class Program{
    public static void Main(string[] args)
    {
        List<BankAccount> StudentList=new List<BankAccount>(); 
        int choice=0;
        do{
        
         Console.WriteLine("Do you want to 1.Registration 2.Login 3.Exit");
         choice=int.Parse(Console.ReadLine());
         if(choice==1)
         { 
 
            Console.WriteLine("Enter your name : ");
            string name=Console.ReadLine();
            Console.WriteLine("Enter the balance: ");
            int balance=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your gender :");
            Gender gen=Enum.Parse<Gender>(Console.ReadLine(),true);
            Console.WriteLine("Enter you Phone number :");
            long phoneNumber=long.Parse(Console.ReadLine());
            Console.WriteLine("Enter you Mail ID :");
            string mailID=Console.ReadLine();
            Console.WriteLine("Enter you Date of birth as specified DD/MM/YYYY :");
            DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/mm/yyyy",null);
            BankAccount Employee=new BankAccount(name,balance,gen,phoneNumber,mailID,dob);
            Console.WriteLine("Thank you for the registration. You have successfully registered");
            Console.WriteLine("Your CustomerID is "+Employee.CustomerId);
            StudentList.Add(Employee);
         }  
         if(choice==2)
         {
            Console.WriteLine("Enter the User ID");
            string ID=Console.ReadLine().ToUpper();
            int flag=1;
            int check;
            foreach(BankAccount account in StudentList)
            {
               if(ID==account.CustomerId)
               {
                  flag=0;
                  do{
                  System.Console.WriteLine("Do you 1.Depoit 2.Withdraw 3. Balance check 4.Exit");
                  check=int.Parse(Console.ReadLine());
                  switch(check)
                  {
                     case 1:
                      {
                        account.Deposit();
                        break;
                      }
                      case 2:
                      {
                        account.Withdraw();
                        break;
                      }
                      case 3:
                      {
                        account.BalanceCheck();
                        break;
                      }
                      default:
                      {
                        break;
                      }
                  }
               }while(check!=4);
               }
            }
            if(flag==1)
            {
               System.Console.WriteLine("Invalid user ID");
            }
            
         }      
         }while(choice!=3);
         Console.WriteLine("Thank you");
         
    }

    
 }
