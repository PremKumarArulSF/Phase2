using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PayRoll
{
    /// <summary>
    /// Branch enum  used to select a instance of <see cref="EmployeeDetails"/>
    /// Refer documentaion on <see href="www.Syncfusion.com"/>
    /// </summary>
    public enum Branch{Select,Eymard,Karuna,Mathura}
    public class EmployeeDetails
    {
      
      
      /// <summary>
      ///  Static field is used to autoincrement a variable to instance of <see cref="EmployeeDetails"/>
      ///  </summary>
      
        private static int s_empId=3000;
        /// <summary>
        /// EmployeeID is used to hold a string value to instance of <see cref="EmployeeDetails"/>
        /// </summary>
       
        public string  EmployeeId { get;  }
        /// <summary>
        /// FullName is used to hold a string value to instance of <see cref="EmployeeDetails"/>
        /// </summary>
         public string  FullName { get; set; }
         /// <summary>
         /// DOB is used to hold DateTime object to instance of <see cref="EmployeeDetails"/>
         /// </summary>
         public DateTime DOB { get; set; }
         /// <summary>
         /// PhoneNumber is used to long value to instance of <see cref="EmployeeDetails"/>
         /// </summary>
         public long  PhoneNumber { get; set; }
         public String  Gender { get; set; }
         public Branch  branch { get; set; }
         public string  TeamName { get; set; }
         
         /// <summary>
         /// Construtor EmployeeDetails used to intialise a default value to its properties.
         /// </summary>
       public EmployeeDetails()
       {
        FullName="Enter the FullName";
        branch=Branch.Select;
       }
       /// <summary>
       /// Constructor EmployeeDetails used to assign a value to its properties.
       /// </summary>
       /// <param name="fullName">fullName is used to assign a value to its properties</param>
       /// <param name="dob">dob is used to assign a value to its properties</param>
       /// <param name="phoneNumber">phoneNumber is used to assign a value to its properties</param>
       /// <param name="gender">gender is used to assign a value to its properties</param>
       /// <param name="bran">bran is used to assign a value to its properties</param>
       /// <param name="teamName">teamName is used to assign a value to its properties</param>
         
         public EmployeeDetails(string fullName,DateTime dob,long phoneNumber,string gender,Branch bran,string teamName)
         {
            EmployeeId="SF"+(++s_empId);
            FullName=fullName;
            DOB=dob;
            PhoneNumber=phoneNumber;
            Gender=gender;
            branch=bran;
            TeamName =teamName;
         }
         /// <summary>
         /// Average methods used to give a average of marks to instance of <see cref="EmployeeDetails"/> 
         /// </summary>
         
        // public return Average()
        // {
        //       return;
        // }

    }
}