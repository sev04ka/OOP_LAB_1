class LecturerDialog : AbstractDialog<Lecturer>
{
    protected override string SearchCriteria(Lecturer item) => $"{item.Name}{item.Patronymic}{item.Lastname}{item.Age}{item.AcademicTitle}";
    protected override void AdditionalMenu()
    {
        Console.WriteLine("Выберите Действие: \n 1. Прикрепить преподователя \n 2. Открепить преподователя \n 0. Выход");

        int choice = -1;
        while (!new[] { 1, 0 }.Contains(choice))
        {
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Некорректный ввод");
            }
        }
        Console.WriteLine(choice);

        switch (choice)
        {
            case 1:
                LinkOrUnlinkLecturerAndDiscipline(choice);
                break;
            case 2:
                LinkOrUnlinkLecturerAndDiscipline(choice);
                break;
            case 0:
                return;

        }
    }

    protected override void Add()
    {
        string? name = null;
        string? patronymic = null;
        string? lastname = null;
        string? academicTitle = null;
        int? age = null;

        while (name == null)
        {
            name = InputDialog<string>("Имя");
        }

        patronymic = InputDialog<string>("Отчество", false);

        while (lastname == null)
        {
            lastname = InputDialog<string>("Фамилия");
        }

        while (academicTitle == null)
        {
            academicTitle = InputDialog<string>("Учёное звание");
        }

        while (age == null)
        {
            age = InputDialog<int>("Возраст");
        }

        DataList.Add(new Lecturer(name, patronymic, lastname, age.Value, academicTitle));
    }

    protected override void Update()
    {
        Console.WriteLine("Изменение данных преподователя");
        Guid lecturerId = InputDialog<Guid>("Идентификатор преподователя");
        Lecturer? lecturer = DataList.FirstOrDefault(x => x.Id == lecturerId);
        if (lecturer == null)
        {
            Console.WriteLine("Нет студента с таким идентфиикатором");
        }
        else
        {
            lecturer.EditData(
            InputDialog<string>("Имя"),
            InputDialog<string>("Отчество"),
            InputDialog<string>("Фамилия"),
            InputDialog<int>("Возраст"),
            InputDialog<string>("Учёное звание"));
        }
    }
}