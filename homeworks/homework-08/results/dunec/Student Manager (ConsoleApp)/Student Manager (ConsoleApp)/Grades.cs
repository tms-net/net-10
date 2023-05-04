using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Manager__ConsoleApp_
{
    internal enum Grade
    {
        Zero = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10
    }
    /// <summary>
    /// Class describe groip info of Grade of a Subject
    /// </summary>
    internal class GradeOfSubject
    {
        /// <summary>
        /// Name of Subject
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Grade of Subject
        /// </summary>
        public Grade Grade { get; set; }
        /// <summary>
        /// Create new GradeOfSubject object with params (Subject, Grade)
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="grade"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public GradeOfSubject(string subject, int grade)
        {
            if (grade < 0 || grade > 10) 
            {
                throw new ArgumentOutOfRangeException("Inputted grade is out of range of the grades: " + nameof(grade));
            }

            if (subject == null || subject == string.Empty)
            { 
                throw new ArgumentNullException("Inputted name of the subject is uncorrect: " + nameof(subject));
            }
            Subject = subject;
            Grade = (Grade)grade;
        }
        /// <summary>
        /// Convert full info of a grade of a student to string
        /// </summary>
        /// <returns>Info of Grade of Subhect as 'string'</returns>
        public override string ToString()
        {
            return Subject + " - " + Grade;
        }

        //*/
    }
}
