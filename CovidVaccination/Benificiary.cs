using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination
{
    public enum Gender{Select,Male,Female}
    public class Benificiary
    {
        private static int s_registerNumber=1000;
        public string  RegisterNumber { get;}
        public string  Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set;}
        public string  MobileNumber { get; set; }
        public string  City { get; set; }
        public Benificiary(string name,int age,Gender gender,string mobileNumber,string city)
        {
            RegisterNumber="BID"+(++s_registerNumber);
            Name=name;
            Age=age;
            Gender=gender;
            MobileNumber=mobileNumber;
            City=city;
        }
    }
}