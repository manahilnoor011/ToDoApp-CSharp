using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

/* Menu           -DONE CRUD - Create, Read, Update, Delete
 * Add Task       -DONE 
 * View Task      -DONE
 * Update Task    -DONE
 * Remove Task    -DONE 
 * Search Task    -DONE
 * Exit           -DONE
 * Multiple Users - Somewhat done
 * Multiple Tasks 
*/

namespace ToDoList_Console
{
    class ToDoList
    {
        String Title;
        String Description;
        Dictionary<string, string> allTasks = new Dictionary<string, string>();

        public ToDoList()
        {
            Title = null;
            Description = null;
        }
        public void AddTask()
        {
            Console.WriteLine("Enter Task Title: ");
            Title = Console.ReadLine();

            Console.WriteLine("Enter Task Description: ");
            Description = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(Title))
            {
                Console.WriteLine("Title cannot be empty.");
                Console.WriteLine("----------------------------\n");
                return;
            }

            if (!(allTasks.Keys.Any(key => key.ToLower() == Title.ToLower())))
            {
                allTasks.Add(Title, Description);
                Console.WriteLine("Task Successfully Added!");
                Console.WriteLine("----------------------------\n");
            }
            else
            {
                Console.WriteLine("Task with this title already exists. Please use a different title.");
                Console.WriteLine("----------------------------\n");
                return;
            }  
        }
        public void ViewTask()
        {
            if (allTasks.Count == 0)
            {
                Console.WriteLine("No tasks available to view.");
                Console.WriteLine("----------------------------\n");
            }

            else
            {
                foreach (var pair in allTasks)
                {
                    Console.WriteLine($"Title: {pair.Key}\nDescription: {pair.Value}\n");
                }
            }
        }
        public void UpdateTask()
        {
            if (allTasks.Count == 0)
            {
                Console.WriteLine("No tasks available to update.");
                Console.WriteLine("----------------------------\n");
                return;
            }

            Console.WriteLine("Do you want to update Title (Yes or No): ");
            string op = Console.ReadLine();
            string newTitle = null;

            if (op.ToLower() == "yes")
            {
                do
                {
                    Console.WriteLine("Which Title would you like to update?\nTitles:" + string.Join(", ", allTasks.Keys));
                    string choice = Console.ReadLine();


                    if (!(allTasks.Keys.Any(key => key.ToLower() == choice.ToLower())))
                    {
                        Console.WriteLine("Title Does not Exist. Please try again.");
                        continue;
                    }

                    else
                    {
                        Console.WriteLine("Enter New Title: ");
                        newTitle = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(newTitle))
                        {
                            Console.WriteLine("Title cannot be empty.\nTitle not updated\n");
                            break;
                        }

                        allTasks[choice] = newTitle;

                        Console.WriteLine("Task Successfully Updated!");
                        Console.WriteLine("----------------------------\n");
                        break;
                    }
                } while (true);            
            }

            else if (op.ToLower() == "no")
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
                allTasks[newTitle] = Console.ReadLine();

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
            if (allTasks.Count == 0)
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
            if (allTasks.Count == 0)
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
                Console.Write("Please select an option (1-7): ");

                option = Console.ReadLine();

                switch (option)
                {
                    case "1": userTasks[username].AddTask(); break;
                    case "2": userTasks[username].ViewTask(); break;
                    case "3": userTasks[username].UpdateTask(); break;
                    case "4": userTasks[username].RemoveTask(); break;
                    case "5": userTasks[username].SearchTask(); break;
                    case "6":
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
                        break;

                    case "7": option = "7"; break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.WriteLine("----------------------------\n");
                        break;
                }
            } while (option != "7");
        }
    }
}
