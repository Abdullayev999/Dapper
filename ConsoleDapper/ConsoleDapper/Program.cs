using System;

namespace ConsoleDapper
{
    class Program
    {
        static void Main(string[] args)
        {
             var db = new PersonRepository();
            //foreach (var item in db.GetAll())
            //{
            //    Console.WriteLine(item);
            //}

            Console.WriteLine(db.GetById(1).Department);

            //db.Create(new Person() { FullName = "Ivan Ivanov", Age = 11 });


            //  db.Create(new Person() { FullName = "Hesen Hesenov", Age = 11 }, new Person() { FullName = "Oruc Orucov", Age = 11 });
            //db.Delete(new Person { Id = 6 });

            // db.Update(new Person() {Id = 5, FullName = "Qara Qarayev", Age = 11 });

            //foreach (var item in db.GetAll())
            //{
            //    Console.WriteLine(item);
            //}


            // Console.WriteLine(db.GetCount());

            //foreach (var item in db.GetPersonAndDepartmentByAll(3))
            //{
            //    Console.WriteLine(item + "   " + item.Department.Name.PadRight(8,' ') + " " + item.Department.Country);
            //}


            //foreach (var item in db.GetDepartmentAndPerson())
            //{
            //    Console.WriteLine(item.Name.PadRight(15,' ') + item.Country);
            //    foreach (var item2 in item.People)
            //    {
            //        Console.WriteLine(item2);
            //    }
            //}

            //db.DeleteAllAndInsert("Test");

            //db.AppendedAgeAllPersons(500);

            foreach (var item in db.GetAll())
            {
                Console.WriteLine(item);
            }
        }
    }
}
