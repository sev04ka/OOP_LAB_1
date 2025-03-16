class Lecturer : Person, IEntity
{
    public string AcademicTitle { get; set; }
    public List<Discipline> disciplines = new List<Discipline>();
    public Lecturer(string name, string patronymic, string lastname, int age, string academicTitle) : base(name, lastname, patronymic, age)
    {
        this.AcademicTitle = academicTitle;
    }


    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($" {AcademicTitle}");
        Console.Write("Преподоваемые дисцплины: ");
        if (disciplines.Count != 0)
        {
            foreach (Discipline discipline in disciplines)
            {
                Console.Write($"{discipline.Name} ");
            }
        }
        else
        {
            Console.WriteLine("Отсутсвуют");
        }
    }

    public void EditData(string name, string patronymic, string lastName, int? age, string academicTitle)
    {
        if (!String.IsNullOrEmpty(name)) this.Name = name;
        if (!String.IsNullOrEmpty(patronymic)) this.Patronymic = patronymic;
        if (!String.IsNullOrEmpty(lastName)) this.Lastname = lastName;
        if (age.HasValue) this.Age = age.Value;
        if (!String.IsNullOrEmpty(academicTitle)) this.AcademicTitle = academicTitle;
    }

    public void LinkDiscipline(Discipline discipline)
    {
        if (!disciplines.Contains(discipline))
        {
            disciplines.Add(discipline);
            discipline.ChangeLecturer(this);
            Console.WriteLine("Дисцпилина успешно прикреплена");
        }
        else
        {
            Console.WriteLine("Данная дисцпилина уже прикреплена");
        }
    }

    public void UnLinkDiscipline(Discipline discipline)
    {
        if (disciplines.Contains(discipline))
        {
            disciplines.Remove(discipline);
            discipline.ChangeLecturer(null);
            Console.WriteLine("Дисцпилина успешно откреплена");
        }
        else
        {
            Console.WriteLine("Данная дисцпилина не прикрреплена");
        }
    }
}

