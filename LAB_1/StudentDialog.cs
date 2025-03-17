namespace LAB_1;

class StudentDialog : AbstractDialog<Student>
{
    protected override string SearchCriteria(Student item) => $@"{item.Name}{item.Patronymic}{item.Lastname}{item.Age}{item.GroupNumber}{item.Course.CourseNumber}";

    protected override void Add()
    {
        string? name = null;
        string? patronymic = null;
        string? lastname = null;
        int? age = null;
        int? groupNumber = null;
        Course? course = null;

        while (name == null)
        {
            name = InputDialog<string>("Имя");
        }

        patronymic = InputDialog<string>("Отчество", false);

        while (lastname == null)
        {
            lastname = InputDialog<string>("Фамилия");
        }

        while (age == null)
        {
            age = InputDialog<int>("Возраст");
        }

        while (groupNumber == null)
        {
            groupNumber = InputDialog<int>("Номер группы");
        }

        while (course == null)
        {
            course = InputDialog<Course>("Курс", true);
        }
        DataList.Add(new Student(name, patronymic, lastname, age.Value, groupNumber.Value, course));
    }

    protected override void Update()
    {
        Console.WriteLine("Изменение данных студента");
        Guid studentId = InputDialog<Guid>("Идентификатор студента");
        Student? student = DataList.FirstOrDefault(x => x.Id == studentId);
        if (student == null)
        {
            Console.WriteLine("Нет студента с таким идентфиикатором");
        }
        else
        {
            student.EditData(
            InputDialog<string>("Имя"),
            InputDialog<string>("Отчество"),
            InputDialog<string>("Фамилия"),
            InputDialog<int>("Возраст"),
            InputDialog<int>("Номер Группы"),
            InputDialog<Course>("Курс"));
        }
    }


}
