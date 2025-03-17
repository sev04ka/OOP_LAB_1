namespace LAB_1;

class Discipline : IEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Description { get; set; }

    public Lecturer? Lecturer { get; set; } = null;

    public Discipline(string name, string description)
    {
        this.Name = name;
        this.Description = description;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"{Id} {Name} {Description} {(Lecturer != null ? Lecturer.Lastname : "Преподователь не назначен")}");
    }

    public void ChangeLecturer(Lecturer? lecturer)
    {
        this.Lecturer = lecturer;
    }

    public void EditData(string name, string description)
    {
        if (!String.IsNullOrEmpty(name)) this.Name = name;
        if (!String.IsNullOrEmpty(description)) this.Description = description;
    }
}
