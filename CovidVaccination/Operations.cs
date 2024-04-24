using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace CovidVaccination
{
    public static class Operations
    {
        static Benificiary currentUser;
        static List<Benificiary> BenificiaryList = new List<Benificiary>();
        static List<VaccineName> VaccineNameList = new List<VaccineName>();
        static List<VaccinationDetails> VaccinationList = new List<VaccinationDetails>();
        public static void MainMenu()
        {
            string mainChoice = "yes";
            do
            {
                System.Console.WriteLine("1. Registration \n2. Login \n3. Get info \n4.Exit");
                int mainOption = int.Parse(Console.ReadLine());
                switch (mainOption)
                {
                    case 1:
                        {
                            System.Console.WriteLine("Registeration");
                            Registration();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("Login");
                            Login();
                            break;

                        }
                    case 3:
                        {
                            System.Console.WriteLine("Get Info");
                            break;
                        }
                    case 4:
                        {
                            System.Console.WriteLine("Exit");
                            mainChoice = "no";
                            break;
                        }
                }
            } while (mainChoice != "no");
        }

        public static void Registration()
        {
            System.Console.Write("Enter the Name: ");
            string name = Console.ReadLine();
            System.Console.Write("Enter the age: ");
            int age = int.Parse(Console.ReadLine());
            System.Console.Write("Enter the Gender: ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            System.Console.Write("Enter the mobile number :");
            string mobile = Console.ReadLine();
            System.Console.Write("Enter the City: ");
            string city = Console.ReadLine();
            Benificiary benificiary = new Benificiary(name, age, gender, mobile, city);
            System.Console.WriteLine("REgistration suceesfully completed and RegisterNumber is " + benificiary.RegisterNumber);
            BenificiaryList.Add(benificiary);
        }

        public static void Login()
        {
            System.Console.WriteLine("Enter the RegisterNumber: ");
            string loginId = Console.ReadLine().ToUpper();
            bool flag = true;
            foreach (Benificiary benificiary in BenificiaryList)
            {
                if (loginId.Equals(benificiary.RegisterNumber))
                {
                    flag = false;
                    System.Console.WriteLine("Login successfully completed");
                    currentUser = benificiary;
                    SubMenu();
                    break;
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Invalid RegisterNumber..");
            }

        }

        public static void SubMenu()
        {
            string subChoice = "yes";
            do
            {
                System.Console.WriteLine(" SubMenu \n1.Show my details  \n2.Take vaccination \n3.My vaccination details \n4.Next due date  \n5.Exit");
                int subOption = int.Parse(Console.ReadLine());
                switch (subOption)
                {
                    case 1:
                        {
                            System.Console.WriteLine("Show details");
                            ShowDetails();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("Take vaccination");
                            TakeVaccination();
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("My vaccination details");
                            MyVacinationDetails();
                            break;
                        }
                    case 4:
                        {
                            System.Console.WriteLine("Next due date");
                            NextDueDate();
                            break;
                        }
                    case 5:
                        {
                            System.Console.WriteLine("Exit fromsubmenu taking back to main menu");
                            subChoice = "no";
                            break;
                        }
                }

            } while (subChoice != "no");
        }
        public static void ShowDetails()
        {
            System.Console.WriteLine("Register Number	Name	Age	Gender	Mobile	City");
            System.Console.WriteLine($"{currentUser.RegisterNumber} | {currentUser.Name} | {currentUser.Age} | {currentUser.Gender} | {currentUser.MobileNumber} | {currentUser.City}");

        }

        public static void TakeVaccination()
        {
            System.Console.WriteLine("VaccineID	   VaccineName	  NoOfDoseAvailable");
            foreach (VaccineName vaccine in VaccineNameList)
            {
                System.Console.WriteLine($"{vaccine.VaccineID} | {vaccine.CovidVaccineName} | {vaccine.NoOfDose}");
            }
            System.Console.WriteLine("Enter the vaccination id:");
            string userVacinnationID = Console.ReadLine().ToUpper();
            bool flag = true;
            foreach (VaccineName vaccine in VaccineNameList)
            {
                if (vaccine.VaccineID.Equals(userVacinnationID))
                {
                    flag = false;
                    bool check = true;
                    foreach (VaccinationDetails vaccination in VaccinationList)
                    {
                        if (vaccination.RegisterNumber.Equals(currentUser.RegisterNumber))
                        {
                            check = false;
                            if (vaccination.DoseNumber == 3)
                            {
                                System.Console.WriteLine("All the three Vaccination are completed, you cannot be vaccinated now.");
                            }
                            else
                            {
                                if (vaccination.VaccineID.Equals(vaccine.VaccineID))
                                {
                                    DateTime d1 = vaccination.VaccinateDate;
                                    DateTime d2 = DateTime.Now;
                                    TimeSpan ts = d2 - d1;
                                    int NoOfDays = (int)ts.TotalDays;
                                    if (NoOfDays >= 30)
                                    {
                                        int doseNumber=vaccination.DoseNumber+1;
                                        VaccinationDetails vaccination1 = new VaccinationDetails(currentUser.RegisterNumber, vaccine.VaccineID, doseNumber, DateTime.Now);
                                        VaccinationList.Add(vaccination1);
                                        vaccine.NoOfDose -= 1;
                                        System.Console.WriteLine("Vaccination stored sucessfully..");
                                        break;
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("30days still not completed...");
                                    }

                                }
                                else
                                {
                                    System.Console.WriteLine($"You have selected different vaccine”. You can vaccine with {userVacinnationID}");
                                    int doseNumber=vaccination.DoseNumber+1;
                                       
                                    VaccinationDetails vaccination1 = new VaccinationDetails(currentUser.RegisterNumber, vaccine.VaccineID, doseNumber, DateTime.Now);
                                    VaccinationList.Add(vaccination1);

                                    vaccine.NoOfDose -= 1;
                                    System.Console.WriteLine("Vaccination stored sucessfully..");


                                }
                            }
                        }
                    }
                    if (check)
                    {
                        if (currentUser.Age > 14)
                        {

                            VaccinationDetails vaccination = new VaccinationDetails(currentUser.RegisterNumber, vaccine.VaccineID, 1, DateTime.Now);
                            VaccinationList.Add(vaccination);
                            vaccine.NoOfDose--;
                            System.Console.WriteLine("Vaccination stored sucessfully..");

                        }
                    }
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Invalid vaccineID");
            }
        }


        public static void NextDueDate()
        {
            bool check = true;
            foreach (VaccinationDetails vaccination in VaccinationList)
            {
                if (vaccination.RegisterNumber.Equals(currentUser.RegisterNumber))
                {
                    check = false;
                }
            }
            if (!check)
            {
                bool flag = true;
                //System.Console.WriteLine("VaccinationID	RegisterNumber	VaccineID	DoseNumber	VaccinatedDate");
                foreach (VaccinationDetails vaccination in VaccinationList)
                {
                    if (vaccination.RegisterNumber.Equals(currentUser.RegisterNumber))
                    {
                        flag = false;
                        if (vaccination.DoseNumber == 3)
                        {
                            System.Console.WriteLine("You have completed all vaccination. Thanks for your participation in the vaccination drive.");
                        }
                        else
                        {
                            DateTime d1 = vaccination.VaccinateDate.AddDays(30);
                            System.Console.WriteLine($"Your next due date vaccineID {vaccination.VaccineID} is {d1.ToString("dd/MM/yyyy")}");

                        }
                    }
                }
                if (flag)
                {
                    System.Console.WriteLine("you can take vaccine now");
                }
            }
            else
            {
                System.Console.WriteLine("No record...");
            }
        }
        public static void MyVacinationDetails()
        {
            System.Console.WriteLine("VaccinationID	RegisterNumber	VaccineID	DoseNumber	VaccinatedDate");
            foreach (VaccinationDetails vaccination in VaccinationList)
            {
                if (vaccination.RegisterNumber.Equals(currentUser.RegisterNumber))
                {
                    System.Console.WriteLine($"{vaccination.VaccinationID}  | {vaccination.RegisterNumber} | {vaccination.VaccineID} |{vaccination.DoseNumber} |{vaccination.VaccinateDate.ToString("dd/MM/yyyy")}");
                }
            }
        }
        public static void AddDefaultDate()
        {
            Benificiary BenificiaryDetails1 = new Benificiary("Ravichandran", 21, Gender.Male, "8484484", "Chennai");
            Benificiary BenificiaryDetails2 = new Benificiary("Baskaran", 22, Gender.Male, "8484747", "Chennai");
            BenificiaryList.AddRange(new List<Benificiary> { BenificiaryDetails1, BenificiaryDetails2 });
            System.Console.WriteLine("Register Number	Name	Age	Gender	Mobile	City");
            foreach (Benificiary benificiary in BenificiaryList)
            {
                System.Console.WriteLine($"{benificiary.RegisterNumber} | {benificiary.Name} | {benificiary.Age} | {benificiary.Gender} | {benificiary.MobileNumber} | {benificiary.City}");
            }


            VaccineName VaccineDetails1 = new VaccineName(CovidVaccineName.CoviShield, 50);
            VaccineName VaccineDetails2 = new VaccineName(CovidVaccineName.Covaccine, 50);
            VaccineNameList.AddRange(new List<VaccineName> { VaccineDetails1, VaccineDetails2 });
            System.Console.WriteLine("VaccineID	VaccineName	  NoOfDoseAvailable");
            foreach (VaccineName vaccine in VaccineNameList)
            {
                System.Console.WriteLine($"{vaccine.VaccineID} | {vaccine.CovidVaccineName} | {vaccine.NoOfDose}");
            }

            VaccinationDetails vaccination1 = new VaccinationDetails("BID1001", "CID2001", 1, new DateTime(2021, 11, 11));
            VaccinationDetails vaccination2 = new VaccinationDetails("BID1001", "CID2001", 2, new DateTime(2022, 03, 11));
            VaccinationDetails vaccination3 = new VaccinationDetails("BID1002", "CID2002", 1, new DateTime(2022, 04, 04));

            VaccinationList.AddRange(new List<VaccinationDetails> { vaccination1, vaccination2, vaccination3 });

            System.Console.WriteLine("VaccinationID	RegisterNumber	VaccineID	DoseNumber	VaccinatedDate");
            foreach (VaccinationDetails vaccination in VaccinationList)
            {
                System.Console.WriteLine($"{vaccination.VaccinationID}  | {vaccination.RegisterNumber} | {vaccination.VaccineID} |{vaccination.DoseNumber} |{vaccination.VaccinateDate.ToString("dd/MM/yyyy")}");
            }


        }
    }
}