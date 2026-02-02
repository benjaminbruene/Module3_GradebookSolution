

using System.Security.Cryptography.X509Certificates;

namespace GradebookApp
{
    internal static class Program
    {
        public static void Main()
        {
            //Instantiate an instance of Gradebook
            var book = new Gradebook();

            Console.WriteLine("=== Gradebook Utility ===");

            bool running = true;

            //While loop to handle user input continuously
            while (running)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add a grade");
                Console.WriteLine("2. View summary");
                Console.WriteLine("3. Clear all grades");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Choose: ");

                //String to capture user choice
                string choice = Console.ReadLine();


                switch (choice)
                {
                    case "1":
                        AddGrades(book);
                        break;
                    case "2":
                        ShowSummary(book);
                        break;
                    case "3":
                        book.Clear();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Option, try again.");
                        break;
                }
            }

        }

        //Method to add grades from user input into the gradebook
        private static void AddGrades(Gradebook book)
        {
            //Get user input (reject empty strings)
            Console.Write("Enter grades separated by spaces: ");
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) return;

            //Foreach to create a list from user input 
            var grades = new List<double>();
            foreach(var part in input.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                if (double.TryParse(part, out double g))
                    grades.Add(g);
                else
                    Console.WriteLine($"'{part}; is not a valid number");
            }

            //Validate and add grades
            try
            {
                book.AddGrade(grades);
                Console.WriteLine($"{grades.Count} grades(s) added.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        //Method to print a Grade Summary
        private static void ShowSummary(Gradebook book)
        {
            Console.WriteLine("\n--- Grade Summary ---");
            Console.WriteLine($"Grades Entered: {book.GetCount()}");
            Console.WriteLine($"Highest Grade: {book.GetHighest():F2}");
            Console.WriteLine($"Lowest Grade: {book.GetLowest():F2}");
            Console.WriteLine($"Average Grade: {book.GetAverage():F2}");
        }


    }
}
