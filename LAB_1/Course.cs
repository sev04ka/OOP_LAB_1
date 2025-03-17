namespace LAB_1;

class Course : IEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int CourseNumber { get; set; }

    public List<Discipline> courseDisciplines = new List<Discipline>();

    public Course(int CourseNumber)
    {
        this.CourseNumber = CourseNumber;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"{Id} {CourseNumber}");
        foreach (Discipline d in courseDisciplines)
        {
            Console.Write($"{d.Name} ");
        }
        Console.WriteLine();
    }

    public void LinkDisciplineToCourse(Discipline discipline)
    {
        if (!courseDisciplines.Contains(discipline))
        {
            courseDisciplines.Add(discipline);
            discipline.courses.Add(this);
            Console.WriteLine("Дисцпилина успешно прикреплена к курсу");
        }
        else
        {
            Console.WriteLine("Данная дисцпилина уже прикреплена к курсу");
        }
    }

    public void UnLinkDisciplineToCourse(Discipline discipline)
    {
        if (courseDisciplines.Contains(discipline))
        {
            courseDisciplines.Remove(discipline);
            discipline.courses.Remove(this);
            Console.WriteLine("Дисцпилина успешно откреплена от курса");
        }
        else
        {
            Console.WriteLine("Данная дисцпилина не прикреплена к курсу");
        }
    }

    ~Course(){
        courseDisciplines.ForEach(x=>{
            x.course = null;
        });
    }
}
