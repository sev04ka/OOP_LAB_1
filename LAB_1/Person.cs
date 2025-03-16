using System.Data.Common;

class Person
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Patronymic { get; set; }
    public string Lastname { get; set; }
    public int Age { get; set; }

    public Person(string name, string patronymic, string lastname, int age)
    {
        this.Name = name;
        this.Patronymic = !String.IsNullOrEmpty(patronymic) ? patronymic : "Отсутствует";
        this.Lastname = lastname;
        this.Age = age;
    }

    public virtual void DisplayInfo()
    {
        Console.Write($"{Id} {Name} {Patronymic} {Lastname} {Age}");
    }
}