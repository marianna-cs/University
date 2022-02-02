using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Models;

namespace University.Domain.Interfaces
{
    public interface IStudentRepository : IDisposable
    {
        Student GetStudent(int id);
    }
}
