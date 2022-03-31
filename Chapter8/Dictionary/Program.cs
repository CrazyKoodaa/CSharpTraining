using System;
using System.Collections.Generic;

namespace Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Dictionary<string, string> favoriteFoods = new Dictionary<string, string>();
            favoriteFoods["Alex"] = "hot dogs";
            favoriteFoods["Ajja"] = "pizza";
            favoriteFoods["Jules"] = "falafel";

            // You can add an item to the dictionary eiter with:
            favoriteFoods["Naima"] = "spaghetti";
            // or with
            favoriteFoods.Add("ben", "pizza");



            string name;
            Console.Write("Which favorite Food should I check: ");
            while ((name = Console.ReadLine()) != "")
            {
                if (favoriteFoods.ContainsKey(name))
                    Console.WriteLine($"{name}'s favorite food is {favoriteFoods[name]}"); // favoriteFoods[name] uses the indexer to check the dictionary
                else Console.WriteLine($"I don't know {name}'s favorite food");
            }

            // to delete an key :
            favoriteFoods.Remove("Alex");

            // get a list of keys:
            foreach (var key in favoriteFoods.Keys)
            {
                Console.WriteLine($"There's a {key} : {favoriteFoods[key]} in my DB");
            }

            // and to count the pairs in the dictionary
            int howMany = favoriteFoods.Count;
            Console.WriteLine($"I've got {howMany} items in my DB");

            // You can also create a dictionary with 2 different types. Like
            /*
             *  Dictionary<int, Duck> duckIds = new Dictionary<int, Duck>();
             *  duckIds.Add(376, new Duck() { Kind = KindOfDuck.Mallard, Size = 15 }); // KindOfDuck is an enum
             */
        }
    }
}
