using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MeetTheTeacher.Logic
{
    /// <summary>
    /// Klasse, die einen Detaileintrag mit Link auf dem Namen realisiert.
    /// </summary>
    public class TeacherWithDetail : Teacher
    {
        public int Id { get; set; }

        public TeacherWithDetail(string name, string day, string unity, string period, 
            string room, string remark, int id)
            : base(name, day, unity, period, room, remark)
        {
            Id = id;
        }

        public override string GetHtmlForName()
        {
            return $"<a href=\"?id={Id}\">{base.GetHtmlForName()}</a>";
        }

        public override string ToString()
        {
            return base.ToString() + $" {nameof(Id)}:{Id}";
        }
    }
}
