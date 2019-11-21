using System;
using System.Collections.Generic;
using System.Linq;

namespace linq_exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            List<string> LFruits = fruits.Where(fruit =>
            {
                bool lFruit = fruit.StartsWith("L");
                return lFruit;
            }).ToList();

            foreach (var f in LFruits)
            {
                Console.WriteLine(f);
            }

            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            List<int> fourSixMultiples = numbers.Where(num => num % 4 == 0 || num % 6 == 0).ToList();

            Console.WriteLine();
            foreach (var num in fourSixMultiples)
            {
                Console.WriteLine(num);
            }




            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
            {
                "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                "Francisco", "Tre"
            };

            List<string> descend = names;
            descend.Sort();
            descend.Reverse();

            Console.WriteLine();
            foreach (var name in descend)
            {
                Console.WriteLine(name);
            }

            List<string> anotherDescend = names.OrderByDescending(name => name).ToList();
            Console.WriteLine();
            foreach (var name in anotherDescend)
            {
                Console.WriteLine(name);
            }


            // Build a collection of these numbers sorted in ascending order
            List<int> moreNumbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            List<int> orderedNumbers = moreNumbers.OrderBy(num => num).ToList();
            Console.WriteLine();
            foreach (var num in orderedNumbers)
            {
                Console.WriteLine(num);
            }

            moreNumbers.Sort();
            Console.WriteLine();
            foreach (var num in moreNumbers)
            {
                Console.WriteLine(num);
            }

            // Output how many numbers are in the moreNumbers list
            Console.WriteLine($"There are {moreNumbers.Count()} numbers in the moreNumbers List");

            // How much money have we made?
            List<double> purchases = new List<double>()
            {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };

            Console.WriteLine($"I spent {purchases.Sum()}. Too much!!!");

            // What is our most expensive product?
            List<double> prices = new List<double>()
            {
                879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
            };

            Console.WriteLine($"Our most expensive product is worth {prices.Max()}");


            /*
                Store each number in the following List until a perfect square
                is detected.

                Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
            */
            List<int> wheresSquaredo = new List<int>()
            {
                66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
            };

            List<int> NOTPerfectSquares = wheresSquaredo.TakeWhile(num =>
            {
                bool isSquared = Math.Sqrt(num) % 1 == 0;
                return !isSquared;
            }).ToList();

            Console.WriteLine();
            foreach (var num in NOTPerfectSquares)
            {
                Console.WriteLine(num);
            }


            List<int> moreNotSquared = wheresSquaredo
            .TakeWhile(num => Math.Sqrt(num) % 1 != 0).ToList();

            Console.WriteLine();
            foreach (var num in moreNotSquared)
            {
                Console.WriteLine(num);
            }





            /*
                Given the same customer set, display how many millionaires per bank.
                Ref: https://stackoverflow.com/questions/7325278/group-by-in-linq

                Example Output:
                WF 2
                BOA 1
                FTB 1
                CITI 1
            */
            List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
        };

            var bankGroups = customers
                .Where(cust => cust.Balance >= 1000000)
                .GroupBy(cust => cust.Bank);

            foreach (var group in bankGroups)
            {
                Console.WriteLine();
                Console.WriteLine($"{group.Key} has {group.Count()} customers.");
                foreach (Customer cust in group)
                {
                    Console.WriteLine(cust.Name);
                    Console.WriteLine(cust.Balance);
                }
            }








            List<Student> allStudents = new List<Student>()
            {
                new Student() {Name = "Madi", Cohort="27"},
                new Student() {Name = "Leah", Cohort="28"},
                new Student() {Name = "Heidi", Cohort="28"},
                new Student() {Name = "James", Cohort="28"},
                new Student() {Name = "James", Cohort="35"},
                new Student() {Name = "Keaton", Cohort="35"},
                new Student() {Name = "Dylan", Cohort="35"},
                new Student() {Name= "Dylan", Cohort="36"},
                new Student() {Name= "Dylan", Cohort="37"}

            };

            var studentGroups = allStudents.GroupBy(student => student.Name).ToList();

            Console.WriteLine();
            foreach (var group in studentGroups)
            {
                Console.WriteLine();
                Console.WriteLine($"There are {group.Count()} students named {group.Key}");
            }
            var studentThatShowsUpTheMost = allStudents
                .GroupBy(student => student.Name)
                .OrderByDescending(group => group.Count())
                .First();

            Console.WriteLine(studentThatShowsUpTheMost.Key);


        }
    }
}
