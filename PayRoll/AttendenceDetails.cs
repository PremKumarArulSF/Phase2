using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayRoll
{
    public class AttendenceDetails
    {
         private static int a_empId=100;
        public string  AttEmployeeId { get; set; }
         public string  AttDate { get; set; }
         public string  AttCheckIn{ get; set; }
         public string  AttCheckout { get; set; }
         public int  TotalHours { get; set; }
         public string  AttendenceId { get; set; }
         /// <summary>
         /// AttendenceDetails used to assign value to its properties.
         /// </summary>
         /// <param name="attEmployeeId">This is used to assign a value to its properties.</param>
         /// <param name="attDate"></param>
         /// <param name="attCheckIn"></param>
         /// <param name="attCheckout"></param>
         /// <param name="totalHours"></param>
         public AttendenceDetails(string attEmployeeId,string attDate,string attCheckIn,string attCheckout,int totalHours)
         {
           AttendenceId="AID"+(++a_empId);
           AttEmployeeId=attEmployeeId;
           AttDate=attDate;
           AttCheckIn=attCheckIn;
           AttCheckout=attCheckout;
           TotalHours=totalHours;
         }
    }
}