using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;

namespace NumberThree
{
    public class Bill
    {
        private static int s_id=1000;
        public string  MeterID { get; }
        public string UserName { get; set; }
        public long PhoneNumber { get; set; }
        public string  MailId { get; set; }
        public Bill(string userName,long phoneNumber,string mailID)
        {
             MeterID="EB"+(++s_id);
             UserName= userName;
             PhoneNumber=phoneNumber;
             MailId =mailID; 
        }
        public void Calculate()
        {
            System.Console.WriteLine("Enter the unit");
            int unit=int.Parse(Console.ReadLine());
            int amount=unit*5;
            System.Console.WriteLine("The amount is {0}",amount);
        }
    }
}