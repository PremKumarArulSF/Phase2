using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using System.Collections.Generic;
using NumberTwo;
namespace Numbertwo;
class Program{
    public static void Main(string[] args)
    {
        List<Employee> employeeList=new List<Employee>();
        int choice;
        do{
            System.Console.WriteLine("Do you want 1.Registration 2.Login 3.Exit");
            choice=int.Parse(Console.ReadLine());
            if(choice==1)
            {
                Console.WriteLine("Enter the Employee name :");
                string employeename=Console.ReadLine();
                System.Console.WriteLine("Enter the Role:");
                string role=Console.ReadLine();
                System.Console.WriteLine("Enter the location:");
                Location loc=Enum.Parse<Location>(Console.ReadLine(),true);
                System.Console.WriteLine("Enter the team name:");
                string teamname=Console.ReadLine();
                System.Console.WriteLine("Enter the date of joining as specified DD/MM/YYYY");
                DateTime doj=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                System.Console.WriteLine("Enter the number of working days:");
                int noOFDays=int.Parse(Console.ReadLine());
                System.Console.WriteLine("Enter the number of leave taken:");
                int leavetTaken=int.Parse(Console.ReadLine());
                System.Console.WriteLine("Enter the gender:");
                Gender gen=Enum.Parse<Gender>(Console.ReadLine(),true);
                Employee detail=new Employee(employeename,role,loc,teamname,doj,noOFDays,leavetTaken,gen);
                Console.WriteLine("Thank you for the registration.Your EmployeeID is "+detail.EmployeeID);
                employeeList.Add(detail);
            }
            else if(choice==2)
            {
                 System.Console.WriteLine("Enter the EmployeeID:");
                 string Id=Console.ReadLine().ToUpper();
                 int flag=1;
                 int valid;
                 foreach (Employee item in employeeList)
                 {
                    if(item.EmployeeID==Id)
                    {
                         flag=0;
                         do{
                         System.Console.WriteLine("Choose 1.Calculate Salary  2.Display details  3.exit");
                         valid=int.Parse(Console.ReadLine());
                         switch(valid)
                         {
                            case 1:
                            {
                                item.CalculateSalary();
                                break;
                            }
                            case 2:
                            {
                                item.DisplayDetail();
                                break;
                            }
                            default:{
                                break;
                            }
                         }
                         }while(valid!=3);
                    }
                 }
                 if(flag==1)
                 {
                     System.Console.WriteLine("Invalid UserID");
                 }

            }

        }while(choice!=3);
        System.Console.WriteLine("Thank you");
    }
}