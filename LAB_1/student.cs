class Student : Person, IEntity
{
    public int GroupNumber { get; set; }
    public Course Course { get; set; }
    public Student(string name, string patronymic, string lastname, int age, int groupNumber, Course course) : base(name, patronymic, lastname, age)
    {
        this.GroupNumber = groupNumber;
        this.Course = course;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($" {GroupNumber} {Course.CourseNumber}");
    }

    public void EditData(string name, string patronymic, string lastName, int? age, int? groupNumber, Course? course)
    {
        if (!String.IsNullOrEmpty(name)) this.Name = name;
        if (!String.IsNullOrEmpty(patronymic)) this.Patronymic = patronymic;
        if (!String.IsNullOrEmpty(lastName)) this.Lastname = lastName;
        if (age.HasValue) this.Age = age.Value;
        if (groupNumber.HasValue) this.GroupNumber = groupNumber.Value;
        if (course != null) this.Course = course;
    }
}