﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeStudentCourses
{
    public class Grades
    {
        public Student Student { get; set; }
        public Course Course { get; set; }
        public int Grade { get; set; }
    }
}