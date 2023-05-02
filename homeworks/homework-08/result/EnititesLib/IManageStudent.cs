using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlindyukHW8
{
    internal interface IManageStudent
    {
        public string AddStudent(string name,
                               byte age,
                               char gender,
                               byte grade);
        public string UpdateStudentInfo(uint id,
                                        string name,
                                        byte age,
                                        char gender,
                                        byte grade);
        public string RemoveStudent(uint id);
        public string GetInfoById(uint id);
        public string GetInfoByName(string name);
        public string GetAllStudentInfo();
    }
}
