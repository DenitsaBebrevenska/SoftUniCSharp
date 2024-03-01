using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    internal class Program
    {
        static void Main()
        {
            Queue<int> guests = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> plates = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int wastedFood = 0;

            while (guests.Count > 0 && plates.Count > 0)
            {
                int currentGuest = guests.Dequeue();

                while (currentGuest > 0) //no case where the food goes 0 in this scenario
                {
                    int currentPlate = plates.Pop();

                    if (currentPlate > currentGuest)
                    {
                        wastedFood += currentPlate - currentGuest;
                    }
                    currentGuest -= currentPlate;
                }
            }

            Console.WriteLine(guests.Count == 0
                ? $"Plates: {string.Join(' ', plates)}"
                : $"Guests: {string.Join(' ', guests)}");

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
