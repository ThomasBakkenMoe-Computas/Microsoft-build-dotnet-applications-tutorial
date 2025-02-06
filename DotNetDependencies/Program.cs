using Humanizer;

Console.WriteLine("Quantities:");
HumanizeQuantities();

int n1 = 1;

float n2 = 1.0f;

Console.WriteLine("\nDate/Time Manipulation:");
HumanizeDates();

static void HumanizeQuantities()
{
    Console.WriteLine("Thomas".ToQuantity(99));
    Console.WriteLine("case".ToQuantity(1));
    Console.WriteLine("case".ToQuantity(5));
}

static void HumanizeDates()
{
    Console.WriteLine(DateTime.UtcNow.AddHours(-24).Humanize());
    Console.WriteLine(DateTime.UtcNow.AddHours(-2).Humanize());
    Console.WriteLine(TimeSpan.FromDays(1).Humanize());
    Console.WriteLine(TimeSpan.FromMinutes(9000).Humanize());
}