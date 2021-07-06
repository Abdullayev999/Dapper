using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDapper
{
    //CRUD
    public interface IPersonRepository
    {
        List<Person> GetPersonAndDepartmentByAll(int id);
        public List<Department> GetDepartmentAndPerson();
        void DeleteAllAndInsert(string FullName);
        void AppendedAgeAllPersons(int age);
        List<Person> GetAll();
        Person GetById(int id);
        void Create(Person person);
        void Create(params Person[] person);
        void Update(params Person[] person);
        void Update(Person person);
        void Delete(Person person);
        int GetCount();
    }
}
