using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeStudentCourses
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void assignment1Button_Click(object sender, EventArgs e)
        {
            /*
             * Create a List of Courses (add three example Courses ...
             * make up the details).  Each Course should have at least two
             * Students enrolled in them.  Use Object and Collection
             * Initializers.  Then, iterate through each Course and print
             * out the Course's details and the Students that are enrolled in
             * each Course.
             */

            List<Course> courses = new List<Course>();

            courses.Add(new Course
            {
                CourseId = 1,
                Name = "Astronomy 201",
                Students = new List<Student>()
            {
                new Student() {StudentId = 1, Name = "Rick Sanchez"},
                new Student() {StudentId = 2, Name = "Tina Belcher"},
            }
            });
            courses.Add(new Course
            {
                CourseId = 2,
                Name = "Philosophy 101",
                Students = new List<Student>()
            {
                new Student() {StudentId = 3, Name = "James Franco"},
                new Student() {StudentId = 4, Name = "Michael Scott"}
            }
            });
            courses.Add(new Course
            {
                CourseId = 3,
                Name = "Underwater Basketweaving",
                Students = new List<Student>()
            {
                new Student() {StudentId = 5, Name = "Ilana Glazer"},
                new Student() {StudentId = 6, Name = "Tormund Giantsbane"}
            }
            });

            foreach (var course in courses)
            {
                resultLabel.Text += String.Format("<br />Course {0} - {1}", course.CourseId, course.Name);
                    foreach (var student in course.Students)
                {
                    resultLabel.Text += String.Format("<br />&nbsp;&nbsp;Student: {0} - {1}", student.StudentId, student.Name);
                }
            }

        }

        protected void assignment2Button_Click(object sender, EventArgs e)
        {
            /*
             * Create a Dictionary of Students (add three example Students
             * ... make up the details).  Use the StudentId as the 
             * key.  Each student must be enrolled in two Courses.  Use
             * Object and Collection Initializers.  Then, iterate through
             * each student and print out to the web page each Student's
             * info and the Courses the Student is enrolled in.
             */
            Course course1 = new Course() { CourseId = 1, Name = "Quantum Mechanics" };
            Course course2 = new Course() { CourseId = 2, Name = "Spanish" };
            Course course3 = new Course() { CourseId = 3, Name = "Art History" };

            Dictionary<int, Student> students = new Dictionary<int, Student>()
            {
                {1, new Student { StudentId = 1, Name = "Ron Burgandy", Courses = new List<Course> { course2, course3} } },
                {2, new Student { StudentId = 2, Name = "Shia LeBouf", Courses = new List<Course> { course1, course3} } },
                {3, new Student { StudentId = 3, Name = "Lil B", Courses = new List<Course> { course1, course2} } }
            };

            foreach (var student in students)
            {
                resultLabel.Text += String.Format("<br />Student: {0} - {1}", student.Value.StudentId, student.Value.Name);
                foreach (var course in student.Value.Courses)
                {
                    resultLabel.Text += String.Format("<br />&nbsp;&nbsp;Course: {0} {1}", course.CourseId, course.Name);
                }
            }
        }

        protected void assignment3Button_Click(object sender, EventArgs e)
        {
            /*
             * We need to keep track of each Student's grade (0 to 100) in a 
             * particular Course.  This means at a minimum, you'll need to add 
             * another class, and depending on your implementation, you will 
             * probably need to modify the existing classes to accommodate this 
             * new requirement.  Give each Student a grade in each Course they
             * are enrolled in (make up the data).  Then, for each student, 
             * print out each Course they are enrolled in and their grade.
             */

            Student student1 = new Student();
            student1.Name = "Lil Uzi Vert";
            student1.StudentId = 9;
            student1.Grades = new List<Grades>()
            {
                new Grades { Grade = 96, Course = new Course { CourseId = 1, Name = "Electrodynamics Physics 323"} },
                new Grades {Grade = 89, Course = new Course { CourseId = 2, Name = "Statistical Mechanics Physics 328"} }
            };

            resultLabel.Text += String.Format("<br />Student: {0} {1}", student1.StudentId, student1.Name);
            foreach (var Grade in student1.Grades)
            {
                resultLabel.Text += String.Format("<br />Enrolled in: {0} - Grade: {1}", Grade.Course.Name, Grade.Grade);
            }
        }
    }
}