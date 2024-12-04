using System;

public struct Date
{
    public int Day;
    public int Month;
    public int Year;

    public Date(int day, int month, int year)
    {
        if (day <= 0 || month <= 0 || year <= 0)
        {
            throw new ArgumentException("День, місяць і рік повинні бути додатніми значеннями.");
        }
        if (month > 12 || day > DateTime.DaysInMonth(year, month))
        {
            throw new ArgumentException("Неправильний день або місяць.");
        }
        Day = day;
        Month = month;
        Year = year;
    }

    public Date AddDays(int days)
    {
        DateTime date = new DateTime(Year, Month, Day).AddDays(days);
        return new Date(date.Day, date.Month, date.Year);
    }

    public Date SubtractDays(int days)
    {
        DateTime date = new DateTime(Year, Month, Day).AddDays(-days);
        return new Date(date.Day, date.Month, date.Year);
    }

    public bool IsLeapYear()
    {
        return (Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0);
    }

    public int DifferenceInDays(Date other)
    {
        DateTime thisDate = new DateTime(Year, Month, Day);
        DateTime otherDate = new DateTime(other.Year, other.Month, other.Day);
        return (thisDate - otherDate).Days;
    }

    public override string ToString()
    {
        return $"{Day:D2}.{Month:D2}.{Year}";
    }

    public string ToFormattedString()
    {
        string[] months = { "January", "February", "March", "April", "May", "June",
                            "July", "August", "September", "October", "November", "December" };
        return $"{months[Month - 1]} {Day}, {Year}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // Встановлюємо UTF-8 для консолі

        try
        {
            Date today = new Date(4, 12, 2024);

            Console.WriteLine($"Сьогоднішня дата: {today}");
            Console.WriteLine($"Чи є рік високосним: {today.IsLeapYear()}");

            Date futureDate = today.AddDays(30);
            Console.WriteLine($"Дата через 30 днів: {futureDate}");

            Date pastDate = today.SubtractDays(30);
            Console.WriteLine($"Дата 30 днів тому: {pastDate}");

            Date anotherDate = new Date(1, 1, 2025);
            int difference = today.DifferenceInDays(anotherDate);
            Console.WriteLine($"Різниця між {today} і {anotherDate}: {difference} днів");

            Console.WriteLine($"Форматований вигляд дати: {today.ToFormattedString()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}
