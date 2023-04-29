namespace MyTime
{
    internal class Program
    {
        static void Main()
        {

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

        static int Difference(MyTime mt1, MyTime mt2)
        {
            int seconds1 = TimeSinceMidnight(mt1);
            int seconds2 = TimeSinceMidnight(mt2);
            if (seconds1 > seconds2)
            {
                return seconds1 - seconds2;
            }
            else
            {
                return seconds2 - seconds1;
            }
        }
    }
}