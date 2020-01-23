using System;

namespace Employee_TestApp
{
    public class Employee
    {
        public string Id { get; }
        public string Name { get; }
        public string Gender { get; }
        public string DateOfBirth { get; }
        public Employee(string id, string name, string isMale, string dateOfBirth)
        {
            Id = id;
            Name = name;
            Gender = isMale;
            DateOfBirth = dateOfBirth;
        }
        public Employee(string[] pars)
        {
            if (pars.Length == 4)
            {
                Id = pars[0];
                Name = pars[1];
                Gender = pars[2];
                DateOfBirth = pars[3];
            }
        }
    }
}
