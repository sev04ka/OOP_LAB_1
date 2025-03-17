namespace LAB_1;

class DisciplineDialog : AbstractDialog<Discipline>
{
    protected override string SearchCriteria(Discipline item) => $"{item.Name}{item.Description}";
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
        string? description = null;
        Lecturer? lecturer = null;

        while (name == null)
        {
            name = InputDialog<string>("Название дисциплины");
        }

        while (description == null)
        {
            description = InputDialog<string>("Описание дисциплины", false);
        }


        DataList.Add(new Discipline(name, description));
    }

    protected override void Update()
    {
        Console.WriteLine("Изменение данных дисиплины");
        Guid disciplineId = InputDialog<Guid>("Идентификатор дисциплины");
        Discipline? discipline = DataList.FirstOrDefault(x => x.Id == disciplineId);
        if (discipline == null)
        {
            Console.WriteLine("Нет студента с таким идентфиикатором");
        }
        else
        {
            discipline.EditData(
            InputDialog<string>("Название Дисциплины"),
            InputDialog<string>("Описание дисциплины"));
        }
    }


}
