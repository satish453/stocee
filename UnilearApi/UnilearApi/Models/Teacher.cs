using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnilearApi.Models
{
    public class Teacher
    {
        public int TeacherId{ get; set; }
        public string TeacherName { get; set; }
        public string Subject { get; set; }
        public string DateOfJoining { get; set; }
    }
}
