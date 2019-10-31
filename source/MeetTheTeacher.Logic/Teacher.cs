using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MeetTheTeacher.Logic
{
    /// <summary>
    /// Verwaltet einen Eintrag in der Sprechstundentabelle
    /// Basisklasse für TeacherWithDetail
    /// </summary>
    public class Teacher : IComparable
    {
        private string _to = null;
        public string Name { get; set; }
        public string Day { get; set; }
        public string Unity { get; set; }
        public string Period { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Room { get; set; }
        public string Remark { get; set; }

        public Teacher(string name, string day, string unity, string period, string room, string remark)
        {
            Name = name;
            Day = day;
            Unity = unity;
            Period = period;
            //From = SplitPeriod(period, 1);
            //To = SplitPeriod(period, 2);
            Room = room;
            Remark = remark;
        }


        public virtual string GetHtmlForName()
        {
            return Name;
        }

        public int CompareTo(object obj)
        {
            var teacher = obj as Teacher;
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            return Name.CompareTo(teacher.Name) * -1;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}:{Name}, {nameof(Day)}:{Day}, {nameof(Unity)}:{Unity}, " +
                $"{nameof(From)}:{From}, {nameof(To)}:{To}, {nameof(Room)}:{Room}, {nameof(Remark)}:{Remark}";
        }

        #region private
        //private string SplitPeriod(string period, int position)
        //{
        //    string val = " ";
        //    if (period != " ")
        //    {
        //        string[] hoursAndMinutes = period.Trim(' ', 'h').Split('-');
        //        if (position == 1)
        //        {
        //            val = hoursAndMinutes[0].Trim(' ');
        //        }
        //        else
        //        {
        //            val = hoursAndMinutes[1].Trim(' ');
        //        }
        //    }
        //    return val;
        //}
        #endregion
    }
}
