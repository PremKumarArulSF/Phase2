using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryManagement
{
    public enum Gender{Select,Male,Female}
    public enum Department{Select,ECE,CSE,EEE}
public class UserDetails
{
//         a.	UserID (Auto Increment – SF3000)
// b.	UserName
// c.	Gender
// d.	Department – (Enum – ECE, EEE, CSE)
// e.	MobileNumber
// f.	MailID
// g.	WalletBalance
  private static int s_userID=3000;
  public string  UserID { get;  }
    public string UserName { get; set; }
    public Gender Gender { get; set; }
    public Department Department { get; set; }
    public string  MobileNumber { get; set; }
    public string  MailID { get; set; }
    public int  WalletBalance { get; set; }
    public UserDetails(string userName,Gender gender,Department department,string mobileNumber,string mailID,int walletBalance)
    {
        UserID="SF"+(++s_userID);
        UserName=userName;
        Gender=gender;
        Department=department;
        MobileNumber=mobileNumber;
        MailID=mailID;
        WalletBalance=walletBalance;
    }

   

    }
}