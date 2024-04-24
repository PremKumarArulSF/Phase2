using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace NumberOne
{
    public enum Gender {
        Select,
        Male,
        Female
    }
    public class BankAccount
    {
        private static int s_employeeID=1000;
        public String CustomerId { get;  }
        public  string CustomerName  { get; set; }
        public int Balance { get; set; }
        public Gender gender { get; set; }
        public long PhoneNumber { get; set; }
        public string  MailID { get; set; }
        public DateTime DOB{get; set;}
         
        public BankAccount(string name,int balance,Gender gen,long phoneNumber,string mailID,DateTime dob)
        {
            CustomerId="HDFC"+(++s_employeeID);
            CustomerName=name;
            Balance=balance;
            gender=gen;
            PhoneNumber=phoneNumber;
            MailID=mailID;
            DOB=dob;
        }
        
        public void Deposit()
        {
            Console.WriteLine("Enter the deposit amount :");
            int dep=int.Parse(Console.ReadLine());
            Balance+=dep;

        }
        public void Withdraw()
        {
               Console.WriteLine("Enter the Withdraw amount :");
               int amt= int.Parse(Console.ReadLine());
              if(Balance>=amt)
              {
               Balance=Balance-amt;
               System.Console.WriteLine("Your current balance is : {0}",Balance);
              }
              else{
                System.Console.WriteLine("Your bank balance is low kindly check it.");
              }
        }
        public void BalanceCheck()
        {
                System.Console.WriteLine("Here is your is bank balance :{0}",Balance);
        }



    }
}