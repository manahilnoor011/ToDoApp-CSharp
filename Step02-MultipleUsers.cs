using System;
using System.Collections.Generic;

/* Menu        -DONE CRUD - Create, Read, Update, Delete
 * Add Task    -DONE 
 * View Task   -DONE
 * Update Task -DONE
 * Remove Task -DONE 
 * Search Task -DONE
 * Exit        -DONE
 * Multiple Users
*/

namespace ToDoList_Console
{
    class ToDoList
    {
        String Title;
        String Description;

        public ToDoList()
        {
            Title = null;
            Description = null;
        }

        //ToDoList(string title, string description)
        //{
        //    Title = title;
        //    Description = description;
        //}
        public void AddTask()
        {
            Console.WriteLine("Enter Task Title: ");
            Title = Console.ReadLine();

            Console.WriteLine("Enter Task Description: ");
            Description = Console.ReadLine();

            Console.WriteLine("Task Successfully Added!");
            Console.WriteLine("----------------------------\n");
        }
        public void ViewTask()
        {
            if (Title == null)
            {
                Console.WriteLine("No tasks available to view.");
                Console.WriteLine("----------------------------\n");
            }

            else
            {
                Console.WriteLine($"Title: {Title}");
                Console.WriteLine($"Description: {Description}");
                Console.WriteLine("----------------------------\n");
            }
        }
        public void UpdateTask()
        {
            if (Title == null)
            {
                Console.WriteLine("No tasks available to update.");
                Console.WriteLine("----------------------------\n");
                return;
            }

            Console.WriteLine("Do you want to update Title (Yes or No): ");
            string newTitle = Console.ReadLine();

            if (newTitle.ToLower() == "yes")
            {
                Console.WriteLine("Enter New Title: ");
                Title = Console.ReadLine();
            }

            else if (newTitle.ToLower() == "no")
            {
                Console.WriteLine("Title remains unchanged.");
                Console.WriteLine("----------------------------\n");
            }

            else
            {
                Console.WriteLine("Invalid input. Title remains unchanged.");
                Console.WriteLine("----------------------------\n");
            }

            Console.WriteLine("Do you want to update Description (Yes or No): ");
            string newDesc = Console.ReadLine();

            if (newDesc.ToLower() == "yes")
            {
                Console.WriteLine("Enter New Description: ");
                Description = Console.ReadLine();

                Console.WriteLine("Description Successfully Updated!");
                Console.WriteLine("----------------------------\n");
            }

            else if (newDesc.ToLower() == "no")
            {
                Console.WriteLine("Description remains unchanged.");
                Console.WriteLine("----------------------------\n");
            }

            else
            {
                Console.WriteLine("Invalid input. Description remains unchanged.");
                Console.WriteLine("----------------------------\n");
            }
        }
        public void RemoveTask()
        {
            if (Title == null)
            {
                Console.WriteLine("List is already empty.");
                Console.WriteLine("----------------------------\n");
                return;
            }

            Title = null;
            Description = null;

            Console.WriteLine("Task Successfully Removed!");
            Console.WriteLine("----------------------------\n");
        }
        public void SearchTask()
        {
            if (Title == null)
            {
                Console.WriteLine("No Tasks Available to Search");
                Console.WriteLine("----------------------------\n");
                return;
            }

            Console.WriteLine("Search Title: ");
            string searchTerm = Console.ReadLine();

            if (searchTerm.ToLower() == Title.ToLower())
            {
                Console.WriteLine("Task Found!");
                Console.WriteLine($"Title: {Title} \nDescription: {Description}");
                Console.WriteLine("----------------------------\n");
            }
            else
            {
                Console.WriteLine("No matching tasks found.");
                Console.WriteLine("----------------------------\n");
            }
        }
    }
    class Program
    {
        public static void Main()
        {
            string option = null;
            Dictionary<string, ToDoList> userTasks = new Dictionary<string, ToDoList>();

            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            if (!userTasks.ContainsKey(username))
            {
                userTasks.Add(username, new ToDoList());
                Console.WriteLine($"Welcome {username}!");
            }
            else
            {
                Console.WriteLine($"Welcome back {username}!");
            }

            do
            {   
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Task");
                Console.WriteLine("3. Update Task");
                Console.WriteLine("4. Remove Task");
                Console.WriteLine("5. Search Task");
                Console.WriteLine("6. Change Users");
                Console.WriteLine("7. Exit\n");
                Console.Write("Please select an option (1-6): ");
                option = Console.ReadLine();

                if (option == "1")
                {
                    userTasks[username].AddTask();
                }

                else if (option == "2")
                {
                    userTasks[username].ViewTask();
                }

                else if (option == "3")
                {
                    userTasks[username].UpdateTask();
                }

                else if (option == "4")
                {
                    userTasks[username].RemoveTask();
                }

                else if (option == "5")
                {
                    userTasks[username].SearchTask();
                }

                else if (option == "6")
                {
                    Console.Write("Enter your username: ");
                    username = Console.ReadLine();

                    if (!userTasks.ContainsKey(username))
                    {
                        userTasks.Add(username, new ToDoList());
                        Console.WriteLine($"Welcome {username}!");
                        Console.WriteLine("----------------------------\n");
                    }
                    else
                    {
                        Console.WriteLine($"Welcome back {username}!");
                        Console.WriteLine("----------------------------\n");
                    }
                    //Console.WriteLine("User Successfully Changed!");
                }

                else if (option == "7")
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.WriteLine("----------------------------\n");
                    continue;
                }
            } while (true);
        }
    }
}

