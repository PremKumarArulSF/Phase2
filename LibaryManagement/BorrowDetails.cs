using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryManagement
{
    public enum BookStatus{Default,Borrowed,Returned}
    public class BorrowDetails
    {
//        •	BorrowID (Auto Increment – LB2000)
// •	BookID 
// •	UserID
// •	BorrowedDate – ( Current Date and Time )
// •	BorrowBookCount 
// •	Status –  ( Enum - Default, Borrowed, Returned )
// •	PaidFineAmount

  private static int s_borrowID=2000;
  public string  BorrowID { get;  }
   public string  BookID { get; set; }

   public string  UserID { get; set; }
   public DateTime  BorrowDate { get; set; }
   public int BorrowBookCount  { get; set; }
   public BookStatus BookStatus { get; set; }
   public int  PaidFineAmount { get; set; } 

   public BorrowDetails(string bookID,string userID,DateTime borrowDate,int borrowBookCount,BookStatus bookStatus,int paidFineAmount )
   {
     BorrowID="LB"+(++s_borrowID);
     BookID=bookID;
     UserID=userID;
     BorrowDate=borrowDate;
     BorrowBookCount=borrowBookCount;
     BookStatus=bookStatus;
     PaidFineAmount=paidFineAmount;
   }
    }
}