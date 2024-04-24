using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public static class Operations
    {
        static StudentDetails currentLoggedInStudent;
     
        static List<StudentDetails> studentList = new List<StudentDetails>();
        static List<DepartmentDetails> departmentList = new List<DepartmentDetails>();
        static List<AdmissionDetails> admissionList = new List<AdmissionDetails>();
        public static void MainMenu()
        {

            System.Console.WriteLine("Welcome to Syncfusion College of Engineering and Technology");
            string mainChoice = "yes";
            do
            {
           
                System.Console.WriteLine("MainMenu\n1. Student Registration \n2. Login\n3. Department Wise Seat Availabitity\n4. Exit");
             
                System.Console.WriteLine("Select Option:");
                int mainOption = int.Parse(Console.ReadLine());

                switch (mainOption)
                {
                    case 1:
                        {
                            System.Console.WriteLine("----->Registration<-----");
                            StudentRegistration();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("----->Student Login<-----");
                            StudentLogin();
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("------>Department Wise Seat Availablity<------");
                            DepartmentWiseSeatAvailabitiy();
                            break;
                        }
                    case 4:
                        {
                            System.Console.WriteLine("Application Succesfully");
                            mainChoice = "no";
                            break;
                        }

                }
            } while (mainChoice == "yes");
          



        }

     
        public static void StudentRegistration()
        {
            

            System.Console.Write("Enter the Name: ");
            string studentName = Console.ReadLine();
            System.Console.Write("Enter the Father Name: ");
            string fatherName = Console.ReadLine();
            System.Console.Write("Enter the date of birth as specified DD/MM/YYYY: ");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            System.Console.Write("Enter the gender(Male/Female): ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            System.Console.Write("Enter the Physics mark :");
            int physicsMark = int.Parse(Console.ReadLine());
            System.Console.Write("Enter the Chemistry mark: ");
            int chemistryMark = int.Parse(Console.ReadLine());
            System.Console.Write("Enter the Maths mark: ");
            int mathsMark = int.Parse(Console.ReadLine());

         
            StudentDetails student = new StudentDetails(studentName, fatherName, dob, gender, physicsMark, chemistryMark, mathsMark);

            
            studentList.Add(student);

            
            System.Console.WriteLine("Registration Sucessfully completed and StudentID is " + student.StudentID);
        }

         public static void StudentLogin()
        {
            
            System.Console.Write("Enter the Student ID : ");
            string loginID = Console.ReadLine().ToUpper();
            bool check = true;
            
            foreach (StudentDetails student in studentList)
            {
                if (loginID.Equals(student.StudentID))
                {
                    System.Console.WriteLine("Login Successfully.");
                    check = false;
                    
                    currentLoggedInStudent = student;
                    
                    Submenu();
                    break;
                }
            }
            if (check)
            {
                System.Console.WriteLine("Invalid Student ID");
            }
            
        }
        public static void Submenu()
        {
            string subChoice = "yes";
            do
            {
             
                System.Console.WriteLine("---->Sub Menu<-----");
                System.Console.WriteLine("1. Check Eligibility \n2. Show Details \n3. Take Admission \n4. Cancel Admission \n5. Show Admmisson Details \n6.Exit");
                
                System.Console.Write("Enter the option : ");
                int subOption = int.Parse(Console.ReadLine());
                
                switch (subOption)
                {
                    case 1:
                        {
                            System.Console.WriteLine("---->Check Eligibility<------");
                            CheckEligibity();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("------>Show Details<-----");
                            ShowDetail();
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("------>Take Admission<------");
                            TakeAdmission();
                            break;
                        }
                    case 4:
                        {
                            System.Console.WriteLine("------>Cancel Admission<------");
                            CancelAdmission();
                            break;
                        }
                    case 5:
                        {
                            System.Console.WriteLine("------>Show Admission details<------");
                            ShowAdmissionDetail();
                            break;
                        }
                    case 6:
                        {
                            subChoice = "no";
                            System.Console.WriteLine("Taking back to MainMenu");
                            break;
                        }
                }

            } while (subChoice == "yes");
        }
        public static void CheckEligibity()
        {
            
            System.Console.WriteLine("Enter the cut-off value");
            double cutOff = double.Parse(Console.ReadLine());

            
            if (currentLoggedInStudent.CheckEligibity(cutOff))
            {
                System.Console.WriteLine("Student is eligible.");
            }
            else
            {
                System.Console.WriteLine("Student is not eligible.");
            }
        }
        public static void ShowDetail()
        {
            
            System.Console.WriteLine("|Student ID|Student Name|Fathe rName|DOB|Gender|Physics Mark|Chemsitr yMark|Maths Mark");
            System.Console.WriteLine($"|{currentLoggedInStudent.StudentID}|{currentLoggedInStudent.StudentName}|{currentLoggedInStudent.FatherName}|{currentLoggedInStudent.DOB}|{currentLoggedInStudent.Gender}|{currentLoggedInStudent.PhysicsMark}|{currentLoggedInStudent.ChemistryMark}|{currentLoggedInStudent.MathsMark}");
            System.Console.WriteLine();
        }
        public static void TakeAdmission()
        {
            
            DepartmentWiseSeatAvailabitiy();
           
            System.Console.Write("Enter the department id: ");
            string departmentID = Console.ReadLine().ToUpper();
            bool flag = true;
           
            foreach (DepartmentDetails department in departmentList)
            {
                if (departmentID.Equals(department.DepartmentID))
                {
                    flag = false;
                   
                    if (currentLoggedInStudent.CheckEligibity(75.0))
                    {
                        
                        if (department.NumberOfSeats > 0)
                        {
                            
                            int count = 0;
                            foreach (AdmissionDetails admission in admissionList)
                            {
                                if (currentLoggedInStudent.StudentID.Equals(admission.StudentID) && admission.AdmissionStatus.Equals(Status.Admitted))
                                {
                                    count++;
                                }

                            }
                            if (count == 0)
                            {
                                
                                AdmissionDetails admissionTaken = new AdmissionDetails(currentLoggedInStudent.StudentID, department.DepartmentID, DateTime.Now, Status.Admitted);
                               
                                System.Console.WriteLine("Admission taken sucessfully.Your Admission Id is " + admissionTaken.AdmissionID);
                               
                                department.NumberOfSeats--;
                            }
                            else
                            {
                                System.Console.WriteLine("You've already taken a admission.");
                            }

                        }
                        else
                        {
                            System.Console.WriteLine("Seat not available");
                        }

                    }
                    else
                    {
                        System.Console.WriteLine("Student not eligible for admission due to low cutoff");
                    }

                    break;
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Invalid Department ID");
            }


        }
        public static void CancelAdmission()
        {
            
            bool flag=true;
            foreach (AdmissionDetails admission in admissionList)
            {
                if (currentLoggedInStudent.StudentID.Equals(admission.AdmissionID) && admission.AdmissionStatus.Equals(Status.Admitted))
                {
                    flag=false;
                    
                    admission.AdmissionStatus=Status.Cancelled;
                    
                    foreach(DepartmentDetails department in departmentList)
                    {
                        if(admission.DepartmentID.Equals(department.DepartmentID))
                        {
                            department.NumberOfSeats++;
                            break;
                        }

                    } 
                    break;
                }
            }
            if(flag)
            {
                System.Console.WriteLine("You have no admission to cancel.");
            }
 }

 public static void ShowAdmissionDetail()
        {
           
            System.Console.WriteLine("|Admission Id|Student ID|Department ID|Admission Date|Admission Status");
            foreach (AdmissionDetails admission in admissionList)
            {
                if (currentLoggedInStudent.StudentID.Equals(admission.StudentID))
                    System.Console.WriteLine($"|{admission.AdmissionID}|{admission.StudentID}|{admission.DepartmentID}|{admission.AdmissionDate.ToString("dd/MM/yyyy")}|{admission.AdmissionStatus}");
            }

        }
        public static void DepartmentWiseSeatAvailabitiy()
        {
           
            System.Console.WriteLine("|DepartmentID|DepartmentName|NumberOfSeats|");
            foreach (DepartmentDetails department in departmentList)
            {

                System.Console.WriteLine($"|{department.DepartmentID}|{department.DepartmentName}|{department.NumberOfSeats}");
            }
            System.Console.WriteLine();

        }
         public static void AddDefaultData()

        {
           
            StudentDetails student1 = new StudentDetails("Ravichandran E", "Ettapparajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);
            StudentDetails student2 = new StudentDetails("Baskaran S", "Sethurajan", new DateTime(1999, 11, 22), Gender.Male, 95, 95, 95);
            
            studentList.AddRange(new List<StudentDetails> { student1, student2 });
        
            DepartmentDetails department1 = new DepartmentDetails("EEE", 29);
            DepartmentDetails department2 = new DepartmentDetails("CSE", 29);
            DepartmentDetails department3 = new DepartmentDetails("MECH", 30);
            DepartmentDetails department4 = new DepartmentDetails("ECE", 30);
            departmentList.AddRange(new List<DepartmentDetails> { department1, department2, department3, department4 });
            
            AdmissionDetails admission1 = new AdmissionDetails("SF3001", "DID101", new DateTime(2022, 05, 11), Status.Admitted);
            AdmissionDetails admission2 = new AdmissionDetails("SF3002", "DID102", new DateTime(2022, 05, 12), Status.Admitted);
            admissionList.AddRange(new List<AdmissionDetails> { admission1, admission2 });
            

        }



    }
}