using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDapper
{
    public class PersonRepository : IPersonRepository
    {
        readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DapperDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void Create(Person person)
        {
            using var db = new SqlConnection(connectionString);
            var query = "INSERT INTO Person(FullName,Age) VALUES (@FullName,@Age)";
            //db.Execute(query, person);
            //OR
            var parametrs = new DynamicParameters();
            parametrs.Add("@FullName", person.FullName, DbType.String, ParameterDirection.Input);
            parametrs.Add("@Age", person.Age, DbType.Int32, ParameterDirection.Input);

            db.Execute(query, parametrs); 
        } 
        public void Create(params Person[] person)
        {
           using var db = new SqlConnection(connectionString);
            var query = "INSERT INTO Person(FullName,Age) VALUES (@FullName,@Age)";
            db.Execute(query, person);
        } 
        public void Delete(Person person)
        {
            using var db = new SqlConnection(connectionString);
            var query = "DELETE FROM Person WHERE Id = @id";
            db.Execute(query, person);
        } 
        public List<Person> GetAll()
        {
            //IDbConnection
            using var db = new SqlConnection(connectionString);
            db.Open();

            var query = "SELECT * FROM Person";
            var people = db.Query<Person>(query);
            return people.ToList();
        } 
        public Person GetById(int id)
        {
            using var db = new SqlConnection(connectionString);
            var query = "SELECT * FROM Person WHERE Id = @id";
            var person =  db.QueryFirstOrDefault<Person>(query, new { id });
            return person;
        } 
        public int GetCount()
        {
            using var db = new SqlConnection(connectionString);
            // var query = "SELECT Count(*) FROM Person";
            // var count = db.QueryFirst<int>(query);
            // var count = db.QueryFirstOrDefault<int>(query);
            //  var count = db.ExecuteScalar<int>(query); 
           // return count;


            var query = "SELECT @count = Count(*) FROM Person";
            var parametr = new DynamicParameters();
            parametr.Add("@count", 0, DbType.Int32, ParameterDirection.Output);
            db.Execute(query, parametr);
            return parametr.Get<int>("@count");
        }

        public List<Person> GetPersonAndDepartmentByAll(int id)
        {
            using var db = new SqlConnection(connectionString);
            var query = @"SELECT * FROM Person
                          JOIN Department ON Person.DepartmentId = Department.Id";

            var people = db.Query<Person, Department, Person>(query, 
           (person, department) =>
            {
                person.Department = department;
                return person;
            });

            return people.ToList();
        }

       public List<Department> GetDepartmentAndPerson()
        {
            using var db = new SqlConnection(connectionString);
            var query = @"SELECT * FROM Department
                          JOIN Person ON Person.DepartmentId = Department.Id";

            Dictionary<int, Department> dictionary = new Dictionary<int, Department>();

            var departments = db.Query<Department, Person, Department>(query,
           (department,person) =>
           {
               if (dictionary.ContainsKey(department.Id))
               {
                      dictionary[department.Id].People.Add(person);
               }
               else
               {
                   dictionary.Add(department.Id, department);
                   department.People = new List<Person>();
                   department.People.Add(person);
               }
               
               return department;
               ////////////////////////////////////////////////////////
               ///NEPRAVILNO
               //department.People = new List<Person>();
               //department.People.Add(person);
               //return department;
               ///NEPRAVILNO
               ////////////////////////////////////////////////////////
           });

            return departments.ToList();
        }

        public void Update(Person person)
        {
            using var db = new SqlConnection(connectionString);
            var query = "UPDATE Person SET FullName = @fullname , Age = @age WHERE Id = @id";
            db.Execute(query, person);
        } 
        public void Update(params Person[] person)
        {
            using var db = new SqlConnection(connectionString);
            var query = "UPDATE Person SET FullName = @fullname , Age = @age WHERE Id = @id";
            db.Execute(query, person);
        }


        public void DeleteAllAndInsert(string FullName)
        {
            using var db = new SqlConnection(connectionString);
            db.Open();
            using var transaction = db.BeginTransaction();
            try
            {
                db.Execute("DELETE FROM Person");
                  
                db.Execute("INSERT INTO Person(FullName) VALUES (@FullName)",FullName);
                transaction.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                transaction.Rollback();
            }
        }

        public void AppendedAgeAllPersons(int age)
        {
            using var db = new SqlConnection(connectionString);
            var query = "EXEC AppendedAgeAllPersons @age";
            db.Execute(query, new { age });
        }
    }
}
