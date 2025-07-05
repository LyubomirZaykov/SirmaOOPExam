using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOP.Interfaces
{
    public interface ICustomer  //Basically I do not need this interface, but I am keeping it for future use if needed...Also keep good OOP coding practices
    {
        string Name { get; }
        int Id { get; }
        DateOnly DateOfBirth { get; }
    }
}
