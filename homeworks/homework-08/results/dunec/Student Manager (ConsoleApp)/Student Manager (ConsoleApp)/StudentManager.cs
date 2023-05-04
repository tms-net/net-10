using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Manager__ConsoleApp_
{
    /// <summary>
    /// Class decribe Manager for Group of Students
    /// </summary>
    internal class StudentManager
    {
        private void BackUp(Dictionary<Student, List<GradeOfSubject>?> from, Dictionary<Student, List<GradeOfSubject>?> to)
        {
            to.Clear();
            foreach (Student student in from.Keys)
            {
                Student copyStudent = new Student(student.StudentName, student.Age, student.Gender);
                copyStudent.CopyStudentID(student.ID);
                List<GradeOfSubject>? copyList = new List<GradeOfSubject>();
                for (int i = 0; i < from[student].Count - 1; i++)
                {
                    copyList.Add(new GradeOfSubject(from[student][i].Subject, (int)from[student][i].Grade));
                }
                to.Add(copyStudent, copyList);
            }
        }

        /// <summary>
        /// Dictionary of a Student's and List of Subjects's Grades
        /// </summary>
        public Dictionary<Student, List<GradeOfSubject>?> GradesOfStudent { get; set; }
        /// <summary>
        /// One stap Backup of Dictionary of a Student's and List of Subjects's Grades
        /// </summary>
        public Dictionary<Student, List<GradeOfSubject>?> GradesOfStudent_Rollback { get; set; }
        public StudentManager()
        {
            GradesOfStudent = new Dictionary<Student, List<GradeOfSubject>?>(); 
            GradesOfStudent_Rollback = new Dictionary<Student, List<GradeOfSubject>?>();
        }

        /// <summary>
        /// Add info about new student
        /// </summary>
        /// <param name="studentName"></param>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        /// <returns>'true' if student was added succesfully; otherwise, 'false'</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public bool AddStudent(string studentName, int age, string gender)
        {
            if (studentName == "")
            {
                throw new ArgumentNullException($"Empty student's info: {nameof(studentName)}");
            }
            if (age < 5)
            {
                throw new ArgumentOutOfRangeException($"Uncorrect student's info: {nameof(age)}");
            }
            if (gender == "")
            {
                throw new ArgumentNullException($"Empty student's info: {nameof(gender)}");
            }
            SaveBackUp();
            return GradesOfStudent.TryAdd(new Student(studentName, age, gender), new List<GradeOfSubject>());         
        }
        /// <summary>
        /// Add new info about a Grade of a Subject for Student by Name or ID
        /// </summary>
        /// <param name="studentNameOrId"></param>
        /// <param name="subject"></param>
        /// <param name="grade"></param>
        /// <returns>'true' if Grade of a Subject was added succesfully; otherwise, 'false'</returns>
        public bool AddGrade(string studentNameOrId, string subject, int grade)
        {
            foreach (Student student in GradesOfStudent.Keys)
            {
                if (student.EqualsName(studentNameOrId) || student.EqualsID(studentNameOrId))
                {
                    SaveBackUp();
                    GradesOfStudent[student].Add(new GradeOfSubject(subject,grade));                   
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Update some of Student's information (Name, Age, Gender) by Name or ID in a StudenManager
        /// </summary>
        /// <param name="studentNameOrId">Name of </param>
        /// <param name="newStudentName"></param>
        /// <param name="newAge"></param>
        /// <param name="newGender"></param>
        /// <returns>'true' if student's information was updated succesfully; otherwise, 'false'</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public bool UpdateStudentInfo(string studentNameOrId, string newStudentName = "EmptyField", int newAge = 666, string newGender = "EmptyField")
        {
            foreach (Student student in GradesOfStudent.Keys)
            {
                if (student.EqualsName(studentNameOrId) || student.EqualsID(studentNameOrId))
                {
                    if (newStudentName == "")
                    {
                        throw new ArgumentNullException($"Empty student's info: {nameof(newStudentName)}");
                    }
                    if (newAge < 5 && newAge != 666)
                    {
                        throw new ArgumentOutOfRangeException($"Uncorrect student's info: {nameof(newAge)}");
                    }
                    if (newGender == "")
                    {
                        throw new ArgumentNullException($"Empty student's info: {nameof(newGender)}");
                    }
                    if (newStudentName != "EmptyField" || newAge != 666 || newGender != "EmptyField")
                    {
                        SaveBackUp();
                        student.UpdateInfo(newStudentName, newAge, newGender);
                        return true;
                    }
                    else
                        return false;
                    
                }               
            }
            return false;
        }
        /// <summary>
        /// Remove info about Student from a StudenManager by Name or ID
        /// </summary>
        /// <param name="studentNameOrId"></param>
        /// <returns>'true' if student's information was deleted succesfully; otherwise, 'false'</returns>
        public bool RemoveStudent(string studentNameOrId) 
        {
            foreach (Student student in GradesOfStudent.Keys)
            {
                if (student.EqualsName(studentNameOrId) || student.EqualsID(studentNameOrId))
                {
                    GradesOfStudent.Remove(student);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Return full info about a Student from a StudenManager by Name or ID
        /// </summary>
        /// <param name="studentNameOrId"></param>
        /// <returns>Info about a student as 'string'</returns>
        public string GetStudent(string studentNameOrId) 
        {
            foreach (Student student in GradesOfStudent.Keys)
            {
                if (student.EqualsName(studentNameOrId) || student.EqualsID(studentNameOrId))
                {
                    GradesOfStudent.TryGetValue(student, out List<GradeOfSubject>? bufferList);
                    if (bufferList != null && bufferList.Count > 0)
                    {
                        string stringOfGrades = "";
                        foreach(GradeOfSubject gradeOfSubject in bufferList)
                        {
                            stringOfGrades += $"\n{gradeOfSubject}";
                        }    
                        return $"\nStudent: {student}\nGrades of Subjects: {stringOfGrades}\n";
                    }
                    else
                    {
                        return $"\nStudent: {student}\nGrades of Subjects are not found\n";
                    }                    
                }
            }            
                /*
                foreach (Student student in ListOfStudents.Values) 
                {
                    if (student.EqualsName(studentName))
                    { 
                        return student.ToString();
                    }
                }//*/
            return "Not found\n";
        }
        /// <summary>
        /// Return full info about Students from a StudenManager
        /// </summary>
        /// <returns>All info about Students as 'string'</returns>
        public override string ToString()
        {
            string result = "";
            if (GradesOfStudent.Count != 0)
            {
                foreach (Student student in GradesOfStudent.Keys)
                {
                    result += GetStudent(student.ID);
                }
            }
            else
                result = "Non students\n";
            
            return result;
        }
        public void SaveBackUp()
        {
            BackUp(GradesOfStudent, GradesOfStudent_Rollback);
        }
        /// <summary>
        /// Return previous state of a StudenManager
        /// </summary>
        public void RollBack()
        {
            BackUp(GradesOfStudent_Rollback, GradesOfStudent);
        }
    }

}
