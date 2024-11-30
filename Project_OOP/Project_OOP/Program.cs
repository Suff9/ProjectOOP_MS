using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP
{
    class Task
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }

        public Task(int taskId, string name, DateTime dueDate, string priority)
        {
            TaskId = taskId;
            Name = name;
            DueDate = dueDate;
            Priority = priority;
        }

        public void DisplayTask()
        {
            Console.WriteLine("ID: " + TaskId + ", Name: " + Name + ", Due: " + DueDate.ToShortDateString() + ", Priority: " + Priority);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>();
            int choice;

            do
            {
                Console.WriteLine("\n--- To-Do List Menu ---");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. Edit Task");
                Console.WriteLine("3. Delete Task");
                Console.WriteLine("4. Search Task by ID");
                Console.WriteLine("5. Display All Tasks");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddTask(tasks);
                        break;
                    case 2:
                        EditTask(tasks);
                        break;
                    case 3:
                        DeleteTask(tasks);
                        break;
                    case 4:
                        SearchTask(tasks);
                        break;
                    case 5:
                        DisplayAllTasks(tasks);
                        break;
                    case 6:
                        Console.WriteLine("Exiting the program...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            } while (choice != 6);
        }

        static void AddTask(List<Task> tasks)
        {
            Console.Write("Enter Task ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Task Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Due Date (yyyy-mm-dd): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Priority (High/Medium/Low): ");
            string priority = Console.ReadLine();

            tasks.Add(new Task(id, name, dueDate, priority));
            Console.WriteLine("Task added successfully!");
        }

        static void EditTask(List<Task> tasks)
        {
            Console.Write("Enter Task ID to edit: ");
            int id = int.Parse(Console.ReadLine());

            Task task = tasks.Find(t => t.TaskId == id);
            if (task != null)
            {
                Console.Write("Enter new Task Name: ");
                task.Name = Console.ReadLine();

                Console.Write("Enter new Due Date (yyyy-mm-dd): ");
                task.DueDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter new Priority (High/Medium/Low): ");
                task.Priority = Console.ReadLine();

                Console.WriteLine("Task updated successfully!");
            }
            else
            {
                Console.WriteLine("Task not found!");
            }
        }

        static void DeleteTask(List<Task> tasks)
        {
            Console.Write("Enter Task ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            Task task = tasks.Find(t => t.TaskId == id);
            if (task != null)
            {
                tasks.Remove(task);
                Console.WriteLine("Task deleted successfully!");
            }
            else
            {
                Console.WriteLine("Task not found!");
            }
        }

        static void SearchTask(List<Task> tasks)
        {
            Console.Write("Enter Task ID to search: ");
            int id = int.Parse(Console.ReadLine());

            Task task = tasks.Find(t => t.TaskId == id);
            if (task != null)
            {
                task.DisplayTask();
            }
            else
            {
                Console.WriteLine("Task not found!");
            }
        }

        static void DisplayAllTasks(List<Task> tasks)
        {
            if (tasks.Count > 0)
            {
                Console.WriteLine("\n--- All Tasks ---");
                foreach (Task task in tasks)
                {
                    task.DisplayTask();
                }
            }
            else
            {
                Console.WriteLine("No tasks available.");
            }
        }
    }
}
