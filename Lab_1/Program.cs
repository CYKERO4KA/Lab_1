using System.Text.Json;
namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1 task1 = new Task1();
            task1.DoTask1();

            Task2 task2 = new Task2();
            task2.DoTask2();

            string json = JsonSerializer.Serialize(task2);
            Console.WriteLine(json);

            Task2? restoredTask2 = JsonSerializer.Deserialize<Task2>(json);
            Console.WriteLine(restoredTask2?.Coincedence1);
            Console.WriteLine(restoredTask2?.Coincedence2);
            
            Task3 task3 = new Task3();
            task3.DoTask3();

            Console.ReadKey();
        }
    }
    

    class Task1
    {

        public void DoTask1()
        {
            Console.WriteLine("\nTask 1:");
            List<int> food = new List<int>()
            {
                1, 5, 6, 64, 3, 76, 34
            };

            for (int i = 0; i < food.Count; i++)
            {
                Console.WriteLine(food[i]);
            }

            Console.Write("\n");
            Console.Write("Write index: ");
            int index = Convert.ToInt32(Console.ReadLine());
            while (index > food.Count || index < 0)
            {
                Console.WriteLine("Incorrect index!");
                Console.Write("Write index: ");
                index = Convert.ToInt32(Console.ReadLine());
            }
            food.RemoveAt(index - 1);

            for (int i = 0; i < food.Count; i++)
            {
                Console.WriteLine(food[i]);
            }
        }
    }

    class Task2
    {
        public string Coincedence1 { get; set; }
        
        public string Coincedence2 { get; set; }
        
        public async void DoTask2()
        {
            Console.WriteLine("\nTask 2:");

            Dictionary<string, int> values1 = new Dictionary<string, int>()
            {
                { "key1", 1 }, { "key2", 3 }, { "key3", 2 }
            };

            Dictionary<string, int> values2 = new Dictionary<string, int>()
            {
                { "key1", 1 }, { "key2", 2 }
            };
            Dictionary<string, int> saved = new Dictionary<string, int>();

            foreach (var (key1, value1) in values1)
            {
                foreach (var (key2, value2) in values2)
                {
                    if (value2 == value1)
                    {
                        if (Coincedence1 == null)
                        {
                            Coincedence1 = $"{key1} and {key2} == {value1}";
                        }
                        else
                        {
                            Coincedence2 = $"{key1} and {key2} == {value2}";
                        }
                    }
                }
            }
        }
    }

    class Task3
    {
        public void DoTask3()
        {
            Console.WriteLine("\nTask 3:");
            
            int[] numbers = {1,3,4,6,9,5,7,1,6,9,4,6 };

            var filtered = from n in numbers where n%2 != 0 orderby n select n;
            var filtered2 = numbers.Where(n => n % 2 != 0).OrderBy(n => n.ToString());

            foreach (var sorted in filtered2)
            {
                Console.WriteLine(sorted);
            }
        }
    }
}