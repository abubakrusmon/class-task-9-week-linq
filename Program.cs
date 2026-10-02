using System.ComponentModel;
using System.Security.Cryptography;

var cities = new List<City>
{
    new() { Id = 1, Name = "Astana" },
    new() { Id = 2, Name = "Almaty" },
    new() { Id = 3, Name = "Berlin" },
    new() { Id = 4, Name = "Paris" },
    new() { Id = 5, Name = "Dushanbe" },
    new() { Id = 6, Name = "Amsterdam" }
};

var people = new List<Person>
{
    new() { Id = 1,  Name = "Anna",  Age = 30, CityId = 1 },
    new() { Id = 2,  Name = "Alex",  Age = 25, CityId = 2 },
    new() { Id = 3,  Name = "Bob",   Age = 30, CityId = 3 },
    new() { Id = 4,  Name = "Ivan",  Age = 5,  CityId = 1 },
    new() { Id = 5,  Name = "Olga",  Age = 7,  CityId = 2 },
    new() { Id = 6,  Name = "Boris", Age = 4,  CityId = 1 },
    new() { Id = 7,  Name = "Eva",   Age = 3,  CityId = 4 },
    new() { Id = 8,  Name = "Umar",  Age = 40, CityId = 5 },
    new() { Id = 9,  Name = "Alice", Age = 25, CityId = 6 },
    new() { Id = 10, Name = "Oleg",  Age = 6,  CityId = 6 }
};

// 1 Task 
var task1 = people.Where(s => s.Age > 25)
.Select(s => new{s.Name , s.Age});
foreach(var a in task1)
{
    System.Console.WriteLine($"{a.Name} - {a.Age}");
}

// Task 2
var task2 = people.OrderBy(s => s.Age)
.ThenBy(s => s.Name);
foreach(var a in task2)
{
    System.Console.WriteLine($"{a.Name} - {a.Age}");
}

// Task 3
var task3 = people.GroupBy(s => s.Name[0]);
foreach(var a in task3)
{
    System.Console.WriteLine(a.Key+" ");
    foreach(var b in a)
    {
        System.Console.WriteLine($" {b.Name}");
    }
}

// Task 4
var task4 = people.Join(cities, p => p.CityId , c => c.Id , (p,c) => new{Person = p.Name, City = c.Name});
foreach(var a in task4)
{
    System.Console.WriteLine(a.Person + " " + a.City);
}

// Task 5
var task5 = people.Where(p => "AOUIE".Contains(p.Name[0]));
System.Console.WriteLine(task5.Sum(x => x.Age));

// Task 6
var task6 = people.GroupBy(s => s.Name[0])
.Select(c => new { d = c.Key, v = c.Count() });
foreach (var a in task6)
{
    System.Console.WriteLine($"{a.d} - {a.v}");
}

// Task 7
var task7 = people.GroupBy(c => c.CityId)
.OrderByDescending(s => s.Count())
.First();
var f = cities.First(f => f.Id == task7.Key).Name;
System.Console.WriteLine($"{f} - {task7.Count()}");

// Task 8
var task8 = people.Join(cities,p=>p.CityId,c=>c.Id,(p,c)=>new{Person = p.Name , age = p.Age , city = c.Name});
var res = task8.Where(x => x.age>=2 && x.age<=7 && x.city.StartsWith("A"));
foreach(var a in res)
{
    System.Console.WriteLine(a.Person + " " + a.city + " " + a.age);
}