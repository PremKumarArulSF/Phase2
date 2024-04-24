using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace NumberTwo
{
    public enum Location{
        Select,
        Chennai,
        USA,
        Kenya
    }
    public enum Gender{Select,Male,Female}
    public class Employee
    {
        private static int  s_EmpID=1000;
        public string EmployeeID { get;  }
        public string EmployeeName { get; set; }
        public String Role { get; set; }
        public Location location { get; set; }
        public string TeamName { get; set; }
        public DateTime DOJ { get; set; }
        public int NoOFDays { get; set; }
        public int LeavetTaken { get; set; }
        public Gender gender { get; set; }
        public Employee(string employeename,string role,Location loc,string teamname,DateTime doj,int noOFDays,int leavetTaken,Gender gen)
        {
            EmployeeID="SF"+(++s_EmpID);
            EmployeeName=employeename;
            Role=role;
            location=loc;
            TeamName=teamname;
            DOJ=doj;
            NoOFDays=noOFDays;
            LeavetTaken=leavetTaken;
            gender=gen;
        }
        public void CalculateSalary()
        {
            int val=NoOFDays-LeavetTaken;
            int sal=500*val;
            System.Console.WriteLine("Here the salary is :{0}",sal);
        }
        public void DisplayDetail()
        {
            System.Console.WriteLine("The Employee name is {0}",EmployeeName);
            System.Console.WriteLine("The role is {0}",Role);
             System.Console.WriteLine("The Work location is {0}",location);
             System.Console.WriteLine("The Team name {0}",TeamName);
             System.Console.WriteLine("Employee Date of joining : {0}",DOJ.ToString("dd/MM/yyyy"));
             System.Console.WriteLine("Number of days: {0}",NoOFDays);
             System.Console.WriteLine("Number of leave taken by employee {0}",LeavetTaken);
             System.Console.WriteLine("Gender : {0}",gender);
        }
    }
}