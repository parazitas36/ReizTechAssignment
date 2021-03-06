
public class Program
{
    private const int OneMinuteWorthInDegrees = 360 / 60;
    private const int HourTicksInClock = 12;
    private const int MinutesTicksInClock = 60;
    // How much ticks does minutes hour has between 2 hours. 
    private const int HourTickWorthInMinutes = MinutesTicksInClock / HourTicksInClock;
    // How much degrees hour arrow rotates because of minutes. For example if the time is 2:30, the hour arrow points in the middle of between 2 and 3 hours
    private const int HourArrowOffset = MinutesTicksInClock / HourTickWorthInMinutes; 

    // Hour validation
    private static bool IsHourValid(string hourString)
    {
        // Check if user's input is not empty
        if (String.IsNullOrEmpty(hourString))
        {
            Console.WriteLine("You must enter something!");
            return false;
        }
        // Check if the value user has entered contains non-digit characters
        if (hourString.Where(x => !Char.IsDigit(x)).Any())
        {
            Console.WriteLine("Hour must be a number! Please enter a Hour value again.");
            return false;
        }

        // Check if the value user has entered is in analogue clock's hours range
        int hour = Convert.ToInt32(hourString);
        if (hour > 12 || hour < 1)
        {
            Console.WriteLine("Hour must be in the range of [1-12]! Please enter a Hour value again.");
            return false;
        }

        return true;
    }

    // Minutes validation
    private static bool IsMinutesValid(string minutesString)
    {
        // Check if user's input is not empty
        if (String.IsNullOrEmpty(minutesString))
        {
            Console.WriteLine("You must enter something!");
            return false;
        }
        // Check if the value user has entered contains non-digit characters
        if (minutesString.Where(x => !Char.IsDigit(x)).Any())
        {
            Console.WriteLine("Minutes must be a number! Please enter a Minutes value again.");
            return false;
        }

        // Check if the value user has entered is in minutes range
        int minutes = Convert.ToInt32(minutesString);
        if (minutes > 59 || minutes < 0)
        {
            Console.WriteLine("Minutes must be in the range of [0-59]! Please enter a Minutes value again.");
            return false;
        }

        return true;
    }

    // Get lesser angle in degress between hours arrow and minutes arrow
    private static int GetAngle(int hour, int minutes)
    {
        // Convert "hour arrow" to "minute arrow"
        int hourInMinutesRange = (hour % HourTicksInClock * HourTickWorthInMinutes) + (minutes / HourArrowOffset);

        // Convert hour and minutes into degrees
        int hourInDegrees = hourInMinutesRange * OneMinuteWorthInDegrees;
        int minutesInDegrees = minutes * OneMinuteWorthInDegrees;

        return Math.Min(Math.Abs((360 - (hourInDegrees - minutesInDegrees)) % 360),
                        Math.Abs((360 - (minutesInDegrees - hourInDegrees)) % 360));
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Please enter the time");
        Console.Write("Hour: ");
        string hourString = Console.ReadLine();

        // Ask user to enter the hour until user's entered value is valid
        while (!IsHourValid(hourString))
        {
            Console.Write("Hour: ");
            hourString = Console.ReadLine();
        }

        Console.Write("Minute: ");
        string minutesString = Console.ReadLine();

        // Ask user to enter the minutes until user's entered value is valid
        while (!IsMinutesValid(minutesString))
        {
            Console.Write("Minute: ");
            minutesString = Console.ReadLine();
        }

        int angle = GetAngle(Convert.ToInt32(hourString), Convert.ToInt32(minutesString));
        Console.WriteLine($"The lesser angle between hour: {hourString} and minutes: {minutesString} is: {angle} degrees.");
    }
}
