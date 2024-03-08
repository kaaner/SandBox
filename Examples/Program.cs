// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
GenerateDate(2023, 12, 15, 0, 0, 0, 0, 180);
GenerateDate(2023, 12, 14, 0, 0, 0, 0, 180);


void GenerateDate(int year, int month, int day, int hour, int minute, int second, int millisecond, int timeSpanMinute)
{
    TimeSpan offset = TimeSpan.FromMinutes(timeSpanMinute);

    DateTimeOffset dateTimeOffset = new DateTimeOffset(year, month, day, hour, minute, second, millisecond, offset);
    var utc = dateTimeOffset.UtcTicks;

    var formattedString = dateTimeOffset.ToString("yyyy-MM-ddTHH:mm:sszzz");

    if (DateTimeOffset.TryParse(formattedString, out DateTimeOffset result))
    {
        Console.WriteLine(result);
    }

    var convertedDate = new DateTime(utc);
    var dateTimeOffsetConverted = new DateTimeOffset(dateTimeOffset.Ticks, new TimeSpan(offset.Ticks));
    dateTimeOffsetConverted.ToUniversalTime();
    Console.WriteLine(dateTimeOffset);

    long dtLong = dateTimeOffsetConverted.ToUnixTimeMilliseconds();

    result = DateTimeOffset.FromUnixTimeMilliseconds(dtLong);

    Console.WriteLine(result);
}