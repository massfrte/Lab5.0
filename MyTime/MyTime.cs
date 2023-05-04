namespace MyTime
{
    struct MyTime
    {
        public int hour, minute, second;

        public MyTime(int h, int m, int s)
        {
            hour = h;
            minute = m;
            second = s;
        }

        public override string ToString()
        {
            return $"{hour:D2}:{minute:D2}:{second:D2}";
        }
    }
}
