

using System.Text.Json;
using System.Threading.Tasks;

namespace note_taker
{
    public class Taskitem
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public bool completed { get; set; }


        public Taskitem(string Name, string Description, bool completed)
        {
            this.Name = Name;
            this.Description = Description;
            this.completed = completed;

        }
    }







    internal class Program
    {
        static void addTask()
        {
            string name;
            string description;




            Dictionary<int, Taskitem> keyValuePairs = readTasks();

            //                 condition > 0 ? value_if_true : value_if_false;
            int newId = keyValuePairs.Count > 0 ? keyValuePairs.Keys.Max() + 1 : 1;
            



            Console.Write("Enter task name:");

            name = Console.ReadLine();
            Console.WriteLine(name);

            Console.Write("Enter task description");

            description = Console.ReadLine();

            Taskitem newTask = new Taskitem(name, description, false);
            keyValuePairs.Add(newId, newTask);

            Console.WriteLine(newTask.Name);

            string json = JsonSerializer.Serialize(keyValuePairs, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText("tasks.json", json);

            Console.WriteLine("added task");

            Console.ReadKey();
        }

        static Dictionary<int,Taskitem> readTasks()
        {
            string json = File.ReadAllText("tasks.json");

            Dictionary<int, Taskitem> tasks = JsonSerializer.Deserialize<Dictionary<int, Taskitem>>(json);


            return(tasks);





        }
        static void printTasks(Dictionary<int, Taskitem> tasks)
        {

            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.Key} : name - {task.Value.Name} ---- description - {task.Value.Description} ---- completed {task.Value.completed}");

            }
        }




        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1: read tasks");
                Console.WriteLine("2: write tasks");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    printTasks(readTasks());
                }
                else if (choice == "2")
                {
                    addTask();
                }
            }



                

            
            













            
        }
    }
}
