using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Threading;
namespace PayRoll;
class Program{
    public static void Main(string[] args)
    {
        List<EmployeeDetails> employeeList=new List<EmployeeDetails>();
        List<AttendenceDetails> attendenceList=new List<AttendenceDetails>();
        int choice;
        do{
            System.Console.WriteLine("1.Employee Registration  2.Employee Login  3.Exit");
            choice =int.Parse(Console.ReadLine());
             if(choice==1)
             {
                System.Console.WriteLine("Enter the Full name");
                string fullName=Console.ReadLine();
                System.Console.WriteLine("Enter the date of birth as specified DD/MM/YYYY");
                DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                System.Console.WriteLine("Enter the Mobile Number");
                long phoneNumber=long.Parse(Console.ReadLine());
                System.Console.WriteLine("Enter the gender");
                string gender=Console.ReadLine();
                System.Console.WriteLine("Enter the branch");
                Branch bran=Enum.Parse<Branch>(Console.ReadLine(),true);
                System.Console.WriteLine("Enter the team name");
                string teamName=Console.ReadLine();
                EmployeeDetails payroll=new EmployeeDetails(fullName,dob,phoneNumber,gender,bran,teamName);
                System.Console.WriteLine("Employee Added sucessfully and Id is "+payroll.EmployeeId);
                employeeList.Add(payroll);
             }
             else if(choice==2)
             {
                System.Console.WriteLine("Enter the Employeee Id");
                string id=Console.ReadLine().ToUpper();
                bool flag=true;
                char symbol; 
                foreach(EmployeeDetails i in employeeList )
                {
                     if(i.EmployeeId==id)
                     {
                        flag=false;
                        do{
                        System.Console.WriteLine("a.Add attendence  b.Display detail  c.Calculate Salary  d.Exit");
                        symbol=char.Parse(Console.ReadLine());
                        switch(symbol)
                        {
                            case 'a':
                            {
                                System.Console.WriteLine("Enter the Check-in date and time as specified DD/MM/YYYY hh:mm:ss tt");
                                DateTime checkIn=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy hh:mm:ss tt",null);
                                System.Console.WriteLine("Enter the Check-out date and time as specified DD/MM/YYYY hh:mm:ss tt");
                                DateTime checkOut=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy hh:mm:ss tt",null);
                                TimeSpan ts=checkOut-checkIn;
                                int hours=(int)ts.TotalHours;
                                if(hours>=8)
                                {
                                    string attEmployeeId=i.EmployeeId;
                                    string  attDate=checkIn.ToString("dd/MM/yyyy");
                                    string attCheckIn=checkIn.ToString("hh:mm tt");
                                    string attCheckout=checkOut.ToString("hh:mm tt");
                                    int totalHours=8;
                                    AttendenceDetails attendence=new AttendenceDetails(attEmployeeId,attDate,attCheckIn,attCheckout,totalHours);
                                    attendenceList.Add(attendence);
                                    System.Console.WriteLine("Check-in and Check-Out Successfully and today you have worked 8 hours");
                                }
                                break;
                            }
                            case 'b':
                            {
                                System.Console.WriteLine("EmployeeId\t\tFullName\t\tDOB\t\t\tPhoneNumber\t\tGender\t\tBranch\t\tTeam");
                                System.Console.WriteLine(i.EmployeeId+"\t\t\t"+i.FullName+"\t\t"+i.DOB.ToString("dd/MM/yyyy")+"\t\t"+i.PhoneNumber+"\t\t    "+i.Gender+"\t\t"+i.branch+"\t\t"+i.TeamName);
                                break;
                            }
                            case 'c':
                            {
                                System.Console.WriteLine("AttendenceID\tEmployeeID\tDate\tChechInTime\tCheckOutTime\tHourWorked");
                                int count=0;
                                foreach(AttendenceDetails item in attendenceList)
                                {
                                    System.Console.WriteLine(item.AttendenceId+"\t\t"+item.AttEmployeeId+"\t    "+item.AttDate+"\t"+item.AttCheckIn+"\t"+item.AttCheckout+"\t"+item.TotalHours);
                                    if(item.AttEmployeeId==id)
                                    {
                                        count++;
                                    }
                                }
                                double Salary=count*500;
                                System.Console.WriteLine("The Salary for the month is {0}",Salary);
                                break;
                            }
                        }
                        }while(symbol!='d');
                     }
                }
                if(flag)
                {
                    System.Console.WriteLine("Invalid EmployeeID");
                }
             }
            
        }while(choice!=3);
    }
}
