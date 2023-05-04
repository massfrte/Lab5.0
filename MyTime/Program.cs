namespace MyTime
{
    internal class Program
    {
        static void Main()
        {
            MyTime myTime = new MyTime(23, 59, 59);
            Console.WriteLine(myTime);

            Console.WriteLine(TimeSinceMidnight(myTime));

            Console.WriteLine(TimeSinceMidnight(86399));

            Console.WriteLine(AddOneSecond(myTime));
            Console.WriteLine(AddOneMinute(myTime));
            Console.WriteLine(AddOneHour(myTime));
            Console.WriteLine(AddSeconds(myTime, 12));

            Console.WriteLine(Difference(myTime, new MyTime(23, 59, 0)));
        }

        static int TimeSinceMidnight(MyTime t)
        {
            return t.hour * 3600 + t.minute * 60 + t.second;
        }

        static MyTime TimeSinceMidnight(int t)
        {
            int hour = t / 3600 % 24;
            int minute = t / 60 % 60;
            int second = t % 60;

            return new MyTime(hour, minute, second);
        }

        static MyTime AddOneSecond(MyTime t)
        {
            int secondsSinceMidnight = TimeSinceMidnight(t);
            secondsSinceMidnight = (secondsSinceMidnight + 1) % (24 * 3600);
            return TimeSinceMidnight(secondsSinceMidnight);
        }

        static MyTime AddOneMinute(MyTime t)
        {
            int secondsSinceMidnight = TimeSinceMidnight(t);
            secondsSinceMidnight = (secondsSinceMidnight + 60) % (24 * 3600);

            return TimeSinceMidnight(secondsSinceMidnight);
        }

        static MyTime AddOneHour(MyTime t)
        {
            int secondsSinceMidnight = TimeSinceMidnight(t);
            secondsSinceMidnight = (secondsSinceMidnight + 3600) % (24 * 3600);

            return TimeSinceMidnight(secondsSinceMidnight);
        }

        static MyTime AddSeconds(MyTime t, int s)
        {
            int secondsSinceMidnight = TimeSinceMidnight(t);
            secondsSinceMidnight = (secondsSinceMidnight + s) % (24 * 3600);

            return TimeSinceMidnight(secondsSinceMidnight);
        }

        static int Difference(MyTime mt1, MyTime mt2) => Math.Abs(TimeSinceMidnight(mt1) - TimeSinceMidnight(mt2));
    }
}