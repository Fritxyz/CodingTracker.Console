
using CodingTracker.Library;
using HabitLogger.Library;

Console.WriteLine("MAIN MENU");

CodingTrackerCrud.CreateTable();

while (true)
{
    Console.WriteLine("\nWhat would you like to do?\n");

    Console.WriteLine("Type 0 to close the application");
    Console.WriteLine("Type 1 to view all of the data");
    Console.WriteLine("Type 2 to insert a new data");
    Console.WriteLine("Type 3 to delete the data");
    Console.WriteLine("Type 4 to update the data\n");

    Console.Write("Type a number: ");
    string? input = Console.ReadLine();

    CodingTrackerLogic.ChoiceMade(input!);
}