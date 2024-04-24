using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public enum Gender{Select,Male,Female}
    public class StudentDetails
    {

    private static int s_studentID=3000;
      
     
        public string  StudentID { get; }
        public string  StudentName { get; set; }
        public string  FatherName { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public int PhysicsMark { get; set; }
        public int  ChemistryMark { get; set; }
        public int MathsMark { get; set; }

        public StudentDetails(string studentName,string fatherName,DateTime dob,Gender gender,int physicsMark,int chemistryMark,int mathsMark)
        {
           
            StudentID="SF"+(++s_studentID);
            StudentName=studentName;
            FatherName =fatherName;
            DOB=dob;
            Gender=gender;
            PhysicsMark=physicsMark;
            ChemistryMark=chemistryMark;
            MathsMark=mathsMark;
        }
      
        public double Average()
        {
            int total=PhysicsMark+ChemistryMark+MathsMark;
            double average=(double)total/3;
            return average;
        }
        public bool CheckEligibity(double cutOff)
        {
            if(Average()>=cutOff)
            {
                return true;
            }
            else{
                return false;
            }
        }
    }
}