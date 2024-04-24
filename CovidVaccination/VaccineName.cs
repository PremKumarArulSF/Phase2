using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination
{
    public enum CovidVaccineName{Select,CoviShield,Covaccine}
    public class VaccineName
    {
        private static int s_vaccineID=2000;
        public string  VaccineID { get; }
        public CovidVaccineName CovidVaccineName { get; set; }
        public  int NoOfDose  { get; set; }
        public VaccineName(CovidVaccineName covidVaccineName,int noOfDays)
        {
            VaccineID="CID"+(++s_vaccineID);
            CovidVaccineName=covidVaccineName;
            NoOfDose=noOfDays;
        }
        
    }
}