using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination
{
    public class VaccinationDetails
    {
//         •	VaccinationID (Auto increment – VID3001)
// •	Registration Number (Beneficiary Reg. num)
// •	VaccineID
// •	DoseNumber – (1,2,3)
// •	Vaccinated Date (DateTime.Now)
    private static int s_vaccinationID=3000;
    public string  VaccinationID { get; }
    public string  RegisterNumber { get; set; }
    public String VaccineID { get; set; }
    public int DoseNumber { get; set; }
    public DateTime VaccinateDate { get; set; }
    public VaccinationDetails(string registerNumber,string vaccineID,int doseNumber,DateTime vaccinateDate)
    {
        VaccinationID="VID"+(++s_vaccinationID);
        RegisterNumber=registerNumber;
        VaccineID=vaccineID;
        DoseNumber=doseNumber;
        VaccinateDate=vaccinateDate;
        
    }

    }
}