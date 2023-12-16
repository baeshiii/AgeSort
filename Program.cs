using System;

class Program
{
    static void Main()
    {
        string[] names = { "Ace", "Bella", "Clyde", "Donna", "Evan", "Fiona" };
        int[] ages = { 21, 18, 27, 4, 30, 6 };

        Console.WriteLine("Choose sorting order for age:");
        Console.WriteLine("1. Ascending");
        Console.WriteLine("2. Descending");

        int choice;
        if (int.TryParse(Console.ReadLine(), out choice))
        {
            switch (choice)
            {
                case 1:
                    SortArrays(names, ages, sortOrder: SortOrder.Ascending, sortBy: SortBy.Age);
                    break;

                case 2:
                    SortArrays(names, ages, sortOrder: SortOrder.Descending, sortBy: SortBy.Age);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    enum SortOrder
    {
        Ascending,
        Descending
    }

    enum SortBy
    {
        Age
    }

    static void SortArrays(string[] names, int[] ages, SortOrder sortOrder, SortBy sortBy)
    {
        int n = names.Length;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                int comparisonResult = ages[j].CompareTo(ages[j + 1]);

                if ((sortOrder == SortOrder.Ascending && comparisonResult > 0) ||
                    (sortOrder == SortOrder.Descending && comparisonResult < 0))
                {
                    string tempName = names[j];
                    names[j] = names[j + 1];
                    names[j + 1] = tempName;

                    int tempAge = ages[j];
                    ages[j] = ages[j + 1];
                    ages[j + 1] = tempAge;
                }
            }
        }

        Console.WriteLine("Sorted Arrays:");

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Name: {names[i]}, Age: {ages[i]}");
        }
    }
}
