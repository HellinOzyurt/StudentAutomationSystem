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
                Console.WriteLine("2-) Update Record");
                Console.WriteLine("3-) Show Record");
                Console.WriteLine("4-) Delete Record");
                Console.WriteLine("5-) Show Average of Grades");
                Console.WriteLine("6-) Exit\n");
                Console.WriteLine("Please Select the Transaction You Want to Perform : ");

                choice = int.Parse(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        AddRecord();
                        break;
                    case 2:
                        UpdateRecord();
                        break;
                    case 3:
                        ShowRecord();
                        break;
                    case 4:
                        DeleteRecord();
                        break;
                    case 5:
                        NotesAverage();
                        break;
                    case 6:
                        Console.WriteLine("\nExited from the Program...");
                        break;
                    default:
                        Console.WriteLine("\nPlease Select Valid Transaction!\n");
                        break;


                }

            } while (choice != 6);


            Console.ReadLine();
        }


        static void CreateFile()
        {
            if (!File.Exists("C:\\Users\\Hellin\\Desktop\\Pratik Kodlar\\C#\\C# Udemy Kursu\\StudentAutomationSystem\\StudentData\\studentsInfo.txt"))
            {
                File.Create("C:\\Users\\Hellin\\Desktop\\Pratik Kodlar\\C#\\C# Udemy Kursu\\StudentAutomationSystem\\StudentData\\studentsInfo.txt");

            }
        }

        static void AddRecord()
        {
            //Student attributes
            int id; // identity
            string name;
            int age;
            double grade;

            Console.WriteLine("\nPlease Enter the Student's ID : ");
            id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nPlease Enter the Student's Name : ");
            name = Console.ReadLine();

            Console.WriteLine("Please Enter the Student's Age : ");
            age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please Enter the Student's Grade : ");
            grade = Convert.ToDouble(Console.ReadLine());


            File.AppendAllText("C:\\Users\\Hellin\\Desktop\\Pratik Kodlar\\C#\\C# Udemy Kursu\\StudentAutomationSystem\\StudentData\\studentsInfo.txt", id + " " + name + " " + age + " " + grade + Environment.NewLine);
        }

        static void UpdateRecord()
        {
            string[] students = File.ReadAllLines("C:\\Users\\Hellin\\Desktop\\Pratik Kodlar\\C#\\C# Udemy Kursu\\StudentAutomationSystem\\StudentData\\studentsInfo.txt");
            int updatedID;

            Console.WriteLine("\nPlease enter the ID you want to update :");
            updatedID = int.Parse(Console.ReadLine());

            int[] ids = new int[students.Length];
            string[] names = new string[students.Length];
            int[] ages = new int[students.Length];
            double[] grades = new double[students.Length];

            string[] splitData;

            int i = 0;
            foreach (var student in students)
            {
                //0 id
                //1 name
                //2 age
                //3 grade

                splitData = student.Split(' ');

                ids[i] = int.Parse(splitData[0]);
                names[i] = splitData[1];
                ages[i] = int.Parse(splitData[2]);
                grades[i] = double.Parse(splitData[3]);
                i++;
            }

            int updatedRowIndex = 0; //index of the row to be updated
            while (true)
            {
                if (ids[updatedRowIndex] == updatedID)
                {
                    break;
                }
                updatedRowIndex++;
            }
            string name = names[updatedRowIndex];
            int age = ages[updatedRowIndex];
            double grade = grades[updatedRowIndex];


            int choice;
            Console.WriteLine("\nSelect The Data You Want To Update");
            Console.WriteLine("1-) Name");
            Console.WriteLine("2-) Age");
            Console.WriteLine("3-) Grade");
            Console.WriteLine("4-) Cancel");
            choice = int.Parse(Console.ReadLine());

            do
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Please enter new name : ");
                        name = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Please enter new age : ");
                        age = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 3:
                        Console.WriteLine("Please enter new grade : ");
                        grade = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 4:
                        Console.WriteLine("Update Canceled : ");
                        break;
                    default:
                        Console.WriteLine("\nPlease Select Valid Transaction!\n");
                        break;

                }
            } while (choice > 4 || choice < 1);

            string newAddedDatas = updatedID + " " + name + " " + age.ToString() + " " + grade.ToString();


            students[updatedRowIndex] = newAddedDatas;
            File.WriteAllLines("C:\\Users\\Hellin\\Desktop\\Pratik Kodlar\\C#\\C# Udemy Kursu\\StudentAutomationSystem\\StudentData\\studentsInfo.txt", students);

        }
        static void ShowRecord()
        {
            string[] students = File.ReadAllLines("C:\\Users\\Hellin\\Desktop\\Pratik Kodlar\\C#\\C# Udemy Kursu\\StudentAutomationSystem\\StudentData\\studentsInfo.txt");

            int[] ids = new int[students.Length];
            string[] names = new string[students.Length];
            int[] ages = new int[students.Length];
            double[] grades = new double[students.Length];
            string[] splitData;


            int i = 0;
            foreach (var student in students)
            {
                splitData = student.Split(' ');

                //0 id
                //1 name
                //2 age
                //3 grade 

                ids[i] = int.Parse(splitData[0]);
                names[i] = splitData[1];
                ages[i] = int.Parse(splitData[2]);
                grades[i] = double.Parse(splitData[3]);

                i++;
            }

            Console.WriteLine("**********************************");
            for (i = 0; i < ids.Length; i++)
            {
                Console.WriteLine(ids[i] + " " + names[i] + " " + ages[i] + " " + grades[i]);
            }
            Console.WriteLine("**********************************");


        }
        static void DeleteRecord()
        {
            string[] students = File.ReadAllLines("C:\\Users\\Hellin\\Desktop\\Pratik Kodlar\\C#\\C# Udemy Kursu\\StudentAutomationSystem\\StudentData\\studentsInfo.txt");
            int deletedID;

            Console.WriteLine("Please Enter The ID You Want To Delete");
            deletedID = int.Parse(Console.ReadLine());

            int[] ids = new int[students.Length];
            string[] names = new string[students.Length];
            int[] ages = new int[students.Length];
            double[] grades = new double[students.Length];

            string[] splitData;

            int i = 0;
            foreach (var student in students)
            {
                //0 id
                //1 name
                //2 age
                //3 grade

                splitData = student.Split(' ');

                ids[i] = int.Parse(splitData[0]);
                names[i] = splitData[1];
                ages[i] = int.Parse(splitData[2]);
                grades[i] = double.Parse(splitData[3]);
                i++;
            }

            int deletedRowIndex = 0; //index of the row to be deleted
            while (true)
            {
                if (ids[deletedRowIndex] == deletedID)
                {
                    break;
                }
                deletedRowIndex++;
            }

            //Records to be transferred to the new file
            string[] newStudents = new string[students.Length - 1];
            int counter = 0;
            for (i = 0; i < students.Length; i++)
            {
                if (i != deletedRowIndex)
                {
                    newStudents[counter] = students[i];
                    counter++;
                }
            }

            File.WriteAllLines("C:\\Users\\Hellin\\Desktop\\Pratik Kodlar\\C#\\C# Udemy Kursu\\StudentAutomationSystem\\StudentData\\studentsInfo.txt", newStudents);


        }
        static void NotesAverage()
        {
            //We reached all the lines
            string[] students = File.ReadAllLines("C:\\Users\\Hellin\\Desktop\\Pratik Kodlar\\C#\\C# Udemy Kursu\\StudentAutomationSystem\\StudentData\\studentsInfo.txt");

            double notes;
            double sum = 0;

            for (int i = 0; i < students.Length; i++)
            {
                notes = Convert.ToDouble(students[i].Split(' ')[3]);
                sum += notes;
            }


            Console.WriteLine("Average student grade: " + sum / students.Length);


        }

    }
}
