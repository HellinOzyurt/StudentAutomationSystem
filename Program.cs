using System;
using System.IO;

namespace StudentAutomationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateFile();


            Console.WriteLine("*** WELCOME TO STUDENT AUTOMATION SYSTEM ***\n");
            int choice;

            do
            {

                Console.WriteLine("\n1-) Add Record");
                Console.WriteLine("2-) Exit\n");
                Console.WriteLine("Please Select the Transaction You Want to Perform : ");

                choice = int.Parse(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        addRecord();
                        break;
                    case 2:
                        Console.WriteLine("\nExited from the Program...");
                        break;
                    default:
                        Console.WriteLine("\nPlease Select Valid Transaction!\n");
                        break;


                }

            } while (choice != 2);


            Console.ReadLine();
        }


        static void CreateFile()
        {
            if (!File.Exists("C:\\Users\\Hellin\\Desktop\\Pratik Kodlar\\C#\\C# Udemy Kursu\\StudentAutomationSystem\\StudentData\\studentsInfo.txt"))
            {
                File.Create("C:\\Users\\Hellin\\Desktop\\Pratik Kodlar\\C#\\C# Udemy Kursu\\StudentAutomationSystem\\StudentData\\studentsInfo.txt");

            }
        }

        static void addRecord()
        {
            //Student attributes
            string name;
            int age;
            double grade;

            Console.WriteLine("\nPlease Enter the Student's Name : ");
            name = Console.ReadLine();

            Console.WriteLine("Please Enter the Student's Age : ");
            age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please Enter the Student's Grade : ");
            grade = Convert.ToDouble(Console.ReadLine());


            File.AppendAllText("C:\\Users\\Hellin\\Desktop\\Pratik Kodlar\\C#\\C# Udemy Kursu\\StudentAutomationSystem\\StudentData\\studentsInfo.txt"
                , name + " " + age + " " + grade + Environment.NewLine);
        }

        static void updateRecord()
        {

        }

    }
}
