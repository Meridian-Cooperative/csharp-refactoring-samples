// See https://aka.ms/new-console-template for more information
using RefactoringSamples;


List<Person> people = new List<Person>();

people.Add(new Person()
{
    Name = "John Silver",
    DateOfBirth = new DateTime(1992, 1, 1)
});

people.Add(new Person()
{
    Name = "Jack Sparrow",
    DateOfBirth = new DateTime(1899, 1, 1)
});

people.Add(new Person()
{
    Name = "Baby Groot",
    DateOfBirth = new DateTime(2005, 8, 1)
});

Console.WriteLine($"Of total population of {people.Count}, {people.Count(p => p.CanVote())} can vote");
