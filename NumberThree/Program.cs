using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
namespace NumberThree;
class Program{
    public static void Main(string[] args)
    {
        List<Bill> billList=new List<Bill>();
        int choice;
        do{
        System.Console.WriteLine("1.Registration 2.Login 3.Exit");
        choice=int.Parse(Console.ReadLine());
        if(choice==1)
        {
            System.Console.WriteLine("Enter the Username");
            string userName=Console.ReadLine();
            System.Console.WriteLine("Enter the Phone number");
            long phoneNumber=long.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter the Mail Id");
            string mailID=Console.ReadLine();
            Bill detail=new Bill(userName,phoneNumber,mailID);
            System.Console.WriteLine("The MeterID is "+detail.MeterID);
            billList.Add(detail);
            
        }
        else if(choice==2)
        {
            System.Console.WriteLine("Enter the MeterID");
            string id=Console.ReadLine().ToUpper();
            bool flag=true;
            int check;
            foreach(Bill item in billList)
            {
                if(item.MeterID==id)
                {
                   flag=false;
                   do{
                   System.Console.WriteLine("1.Calculate Amount 2.Display detail 3.Exit");
                   check=int.Parse(Console.ReadLine());
                   switch(check)
                   {
                    case 1:
                    {
                      item.Calculate();
                       break; 
                    }
                    case 2:
                    {
                        foreach(Bill list in billList)
                        {
                            System.Console.WriteLine("MeterID is "+list.MeterID);
                            System.Console.WriteLine("UserName is "+list.UserName);
                            System.Console.WriteLine("PhoneNumber is "+list.PhoneNumber);
                            System.Console.WriteLine("Mail ID is "+list.MailId);
                        }
                        break;
                    }
                   }
                   }while(check!=3);
                }
            }
            if(flag)
            {
                System.Console.WriteLine("Invalid ID");
            }
        }
        }while(choice!=3);
    }
}
