using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampResourcesCheckoutSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WCCI Bootcamp Resources Checkout System");
            Console.WriteLine("\n \n\n");

            List<string> students = new List<string> { "Ashley Stewart", "Krista Scholdberg", "Imari Childress", "Lawrence Hudson", "Jacob Lockyer" }; //students in system
            List<string> resources = new List<string> { "Visual C#", "Java for Kids", "C# Player's Guide", "Beginner's Guide to Visual Studio", "Programming for Dummies", "Intro to Java Script", "SQL Databases", "HTML and CSS", "Database Design for Mere Mortals", "ASP.Net MVC 5" }; //lists resources in system

            for (int i=0; i<students.Count; i++)
            {
                students[i]= students[i].ToLower();
            }

            for (int j=0; j<resources.Count; j++)
            {
                resources[j] = resources[j].ToLower();
            }

            List<List<string>> studentResources = new List<List<string>>(); // this makes a list of lists
            string[] menu = { "1-View Students", "2-View Avalable Resources", "3-View Student Accounts", "4-Checkout Item", "5-Return Item", "6-Exit" };

            while (true)
            {
                int namePosition = 0;
                Console.WriteLine("\n"+"Menu:");
               
                for(int m=0; m<menu.Length; m++)
                {
                    Console.WriteLine(menu[m] + "\n");
                }

                Console.WriteLine("Enter the menu number you would like to select");
                string choice= Console.ReadLine();
                int menuChoice;
                bool res = int.TryParse(choice, out menuChoice);

                if (res== false)
                {
                    Console.WriteLine("Enter your choice as an integer."+ "\n\a");
                }

                if (menuChoice==6) // allows the user to exit the program breaking the while loop
                {
                    Console.WriteLine("Exiting");
                    break;
                }
          
                for (int k=0; k<students.Count; k++) // this for loop is to create a list for each student, eventually will put resources in these individual lists that are checked out
                {
                    studentResources.Add(new List<string>());
                }
               
                switch (menuChoice)
                {
                    case 1: // view students section
                        students.Sort();

                        for (int i = 0; i < students.Count; i++)
                        {
                            Console.WriteLine(students[i] + "\n");
                        }

                        Console.WriteLine();
                        break;

                    case 2: // available resources section
                        resources.Sort();

                        for (int j = 0; j < resources.Count; j++)
                        {
                            Console.WriteLine(  resources[j] + "\n");
                        }

                        if (resources.Count == 0)// this lets the user know no resourse available
                        {
                            Console.WriteLine("All resources are checked out."+ "\n\a");
                        }

                        break;

                    case 3:// this section is for student accounts
                        while (true)
                        {
                            Console.WriteLine("\nEnter students name");
                            string nameInput = Console.ReadLine().ToLower();
                            namePosition = students.IndexOf(nameInput);

                            if (students.Contains(nameInput) == false)
                            {
                                Console.WriteLine("\nError: request unavailable"+ "\n\a");
                                continue;
                            }

                            if (studentResources[namePosition].Count == 0)
                            {
                                Console.WriteLine("\nNothing is checked out..."+ "\n");
                                break;
                            }
                            else
                            {
                                for (int i = 0; i < studentResources[namePosition].Count; i++)
                                {
                                    Console.WriteLine(studentResources[namePosition][i]+"\n");
                                }
                            }

                            break;
                        }
                        
                        break;
                    case 4:// this section checks out resources
                        while (true)
                        {
                            Console.WriteLine("\nEnter Students Name:\n");
                            string checkOutName = Console.ReadLine().ToLower();

                            if (students.Contains(checkOutName))// makes sure a valid name is entered
                            {
                                while (true)
                                {
                                    if (studentResources[namePosition].Count == 3)
                                    {
                                        Console.WriteLine("\n"+checkOutName + " has checked out the max number of resources." + "\n");
                                        break;
                                    }

                                    Console.WriteLine("\nEnter Resource to check out:\n");
                                    string resourceOutInput = Console.ReadLine().ToLower();
                                    namePosition = students.IndexOf(checkOutName);

                                    if (resources.Contains(resourceOutInput))
                                    {
                                        studentResources[namePosition].Add(resourceOutInput);// this assigns a resource to a student
                                        resources.Remove(resourceOutInput);
                                        Console.WriteLine("\n" + checkOutName + " checked out " + resourceOutInput+ "\n");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nError:Request Unavailable."+ "\n\a");
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("\n Error:Request Unavailable."+ "\n\a");
                                continue;
                            }
                                break;
                        }
                        break;

                    case 5:// returns an item
                           
                        while (true)
                        {
                            Console.WriteLine("\nEnter students name");
                            string studentReturn = Console.ReadLine().ToLower();
                            namePosition = students.IndexOf(studentReturn);

                            if (students.Contains(studentReturn))
                            {
                                if (studentResources[namePosition].Count > 0 )
                                {
                                    for (int i = 0; i < studentResources[namePosition].Count; i++)
                                    {
                                        Console.WriteLine(studentResources[namePosition][i]+"\n");
                                    }

                                    Console.WriteLine("\nWhich resource would you like to return?" + "\n");
                                    string returnResource = Console.ReadLine().ToLower();

                                    if (studentResources[namePosition].Contains(returnResource))
                                    {
                                        studentResources[namePosition].Remove(returnResource);
                                        resources.Add(returnResource);
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nError:Request Unavailable.\n");
                                        continue;
                                    }
                                }
                               
                                else
                                {
                                    Console.WriteLine("\nStudent has no resources to return." + "\n");
                                }
                                break;
                            }

                            else
                            {
                                Console.WriteLine("\nError:Request Unavailable.\n\a");
                                continue;
                            }
                        }

                        break;
                 
                    default: // if an invalid NUMBER option is entered this will return to the main menu
                        Console.WriteLine("\nYou entered an invalid option, Please try again"+ "\n\a");
                        break;
                }
            }
        }
    }
}
