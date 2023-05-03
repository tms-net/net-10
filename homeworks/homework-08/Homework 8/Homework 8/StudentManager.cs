using System;
namespace Homework_8
{
	public class StudentManager
	{
		private Dictionary<Guid, Student> _students; //contains unique Id and a reference to student
		private Dictionary<Guid, string> _studentsId; //contans <"first_name+last_name" , unique_id> for searching by firstname/lastname

		public Dictionary<Guid, Student> Students => _students;

		public StudentManager()
		{
			_students = new Dictionary<Guid, Student>();
			_studentsId = new Dictionary<Guid, string>();
		}

		public void AddStudent(Student newStudent)
		{
			_students.Add(newStudent.ID, newStudent);
			_studentsId.Add(newStudent.ID, $"{newStudent.FirstName.ToLower()}{newStudent.LastName.ToLower()}");
		}

		public bool RemoveStudent(Student student)
		{
			if (_students.ContainsKey(student.ID))
			{
				_students.Remove(student.ID);
				_studentsId.Remove(student.ID);
				return true;
			}

			return false;
		}

		public void EditFirstName(Student student, string newFirstName)
		{
			if(_students.ContainsKey(student.ID))
			{
				student.FirstName = newFirstName;
				UpdateNames(student);
			}
		}

		public void EditLastName(Student student, string newLastName)
		{
            if (_students.ContainsKey(student.ID))
            {
                student.LastName = newLastName;
				UpdateNames(student);
			}
		}

		public void EditGender(Student student, Gender newGender)
		{
            if (_students.ContainsKey(student.ID))
			{
                student.Gender = newGender;
            }
        }

		public void EditAge(Student student, int newAge)
		{
            if (_students.ContainsKey(student.ID))
            {
                student.Age = newAge;
			}
		}

		public void AddMark(Student student, int mark)
		{
            if (_students.ContainsKey(student.ID))
			{
                student.AddMark(mark);
            }
        }

		public void RemoveLastMark(Student student)
		{
			if(_students.ContainsKey(student.ID))
			{
				student.RemoveLastMark();
			}
		}

		//search by guid
		public Student SearchById(Guid guid)
		{
			if(_students.ContainsKey(guid))
			{
				return _students[guid];
			}

			return new Student();
		}

		//update dictionary of students names if first/lastname was changed
		public void UpdateNames(Student student)
		{
			foreach(Guid key in _studentsId.Keys)
			{
				if (key == student.ID)
				{					
					_studentsId[key] = $"{student.FirstName.ToLower()}{student.LastName.ToLower()}";
				}
			}
		}

		//search by firstname/lastname
		public List<Student> SearchByName(string pattern)
		{
            List<Student> foundStudents = new List<Student>();
            var keys = _studentsId.Keys;

			foreach(Guid key in keys)
			{
				if (_studentsId[key].Contains(pattern.ToLower()))
				{
					foundStudents.Add(_students[key]);
				}
			}

			return foundStudents;
		}

		//for testing purposes
		public void ConsoleOutCurrentListOfUsers()
		{
            Console.Write("\nGroup:");

            if (_students.Count == 0)
			{
				Console.Write("\nNo students");
				return;
			}

			foreach (Guid key in _students.Keys)
			{
				Console.Write($"\n{key} - {_students[key].ToString()}, Marks: ");

				if (_students[key].Marks.Count > 0)
				{
					foreach (int mark in _students[key].Marks)
					{
						Console.Write($"{mark} ");
					}
				}
				else
				{
					Console.Write("N/A");
				}
			}
		}
    }
}

