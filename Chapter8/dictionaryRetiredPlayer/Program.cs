using System;
using System.Collections.Generic;

namespace dictionaryRetiredPlayer
{
    class RetiredPlayer
    {
        public string Name { get; private set; }
        public int YearRetired { get; private set; }

        public RetiredPlayer(string player, int yearRetired)
        {
            Name = player;
            YearRetired = yearRetired;

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Dictionary<int, RetiredPlayer> retiredYankees = new Dictionary<int, RetiredPlayer>()
            {
                { 3, new RetiredPlayer("Babe Ruth", 1948) },
                { 4, new RetiredPlayer("Lou Gehrig", 1939) },
                { 5, new RetiredPlayer("Joe DiMaggio", 1952) },
                { 7, new RetiredPlayer("Mickey Mantle", 1969) },
                { 10, new RetiredPlayer("Phil Rizzuto", 1985) },
                { 44, new RetiredPlayer("Reggie Jackson", 1993) },
            };

            foreach (var jerseyNumber in retiredYankees.Keys)
            {
                RetiredPlayer player = retiredYankees[jerseyNumber];
                Console.WriteLine($"{player.Name} #{jerseyNumber} retired in {player.YearRetired}");
            }
        }
    }
}
