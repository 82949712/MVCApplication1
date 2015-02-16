using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Core
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudentCourses(int studentId);
    }
}
