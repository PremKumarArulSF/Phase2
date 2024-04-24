using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public enum Status{Select,Admitted,Cancelled}
    public class AdmissionDetails
    {
        private static int s_admissionID=1000;
    
    public string  AdmissionID { get;}
    public string  StudentID { get; set; }
    public String  DepartmentID { get; set; }
    public DateTime AdmissionDate { get; set; }
    public Status AdmissionStatus { get; set; }
    //Constructor
    public AdmissionDetails(string studentID,String departmentID,DateTime admissionDate,Status admissionStatus)
    {
        AdmissionID="AID"+(++s_admissionID);
        StudentID=studentID;
        DepartmentID= departmentID;
        AdmissionDate=admissionDate;
        AdmissionStatus=admissionStatus;
    }
    }
}