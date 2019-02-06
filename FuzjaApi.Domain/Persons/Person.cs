using System;

namespace FuzjaApi.Domain.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int Salary { get; set; }
        public DateTime PersonPublicationDate { get; set; }

        public bool IsActive { get; set; }

        public virtual Car Car { get; set; }

        public Person(string name, string city, bool isActive, int salary, Car car)
        {
            Merge(name, city, isActive, salary, car);
        }

        public void Update(string name, string city, bool isActive, int salary, Car car)
        {
            Merge(name, city, isActive, salary, car);
        }

        private void Merge(string name, string city, bool isActive, int salary, Car car)
        {
            Name = name;
            City = city;
            IsActive = isActive;
            Salary = salary;
            PersonPublicationDate = DateTime.Now;
            Car = car;
        }



    }
}
