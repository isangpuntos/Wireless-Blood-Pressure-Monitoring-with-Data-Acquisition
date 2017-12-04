using System;

namespace CalanderControl.Design.HitTest
{
    public class MonthCalanderHitTestInfo
    {
        private HitTestArea area;
        private DateTime? day;
        private DayOfWeek? markerDay;
        private int month = -1;
        private int year = -1;
        private int yearRangeEnd = -1;
        private int yearRangeStart = -1;

        public HitTestArea Area
        {
            get { return area; }
            protected internal set { area = value; }
        }

        public DateTime? Day
        {
            get { return day; }
            protected internal set { day = value; }
        }

        public int Month
        {
            get { return month; }
            protected internal set { month = value; }
        }

        public int Year
        {
            get { return year; }
            protected internal set { year = value; }
        }

        public int YearRangeStart
        {
            get { return yearRangeStart; }
            protected internal set { yearRangeStart = value; }
        }

        public int YearRangeEnd
        {
            get { return yearRangeEnd; }
            protected internal set { yearRangeEnd = value; }
        }

        public DayOfWeek? MarkerDay
        {
            get { return markerDay; }
            protected internal set { markerDay = value; }
        }
    }
}