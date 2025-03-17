namespace LAB_1;

class CourseDialog : AbstractDialog<Course>
{
    protected override string SearchCriteria(Course item) => $"{item.CourseNumber}";
    protected override void AdditionalMenu()
    {
        Console.WriteLine("Выберите Действие: \n 1. Прикрепить дисциплину к курсу \n 2. Открепить дисциплину от курса \n 0. Выход");

        int choice = -1;
        while (!new[] { 1, 2, 0 }.Contains(choice))
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
                LinkOrUnlinkCourseToDiscipline(choice);
                break;
            case 2:
                LinkOrUnlinkCourseToDiscipline(choice);
                break;
            case 0:
                return;

        }
    }

    protected override void Add()
    {
        int? courseNumber = null;

        while (courseNumber == null)
        {
            courseNumber = InputDialog<int>("Номер курса");
        }
        if (DataList.FirstOrDefault(course => course.CourseNumber == courseNumber) == null)
        {
            DataList.Add(new Course(courseNumber.Value));
        }
        else
        {
            Console.WriteLine("Такой курс уже существует");
        }
    }

    protected override void Update()
    {
        return;
    }


}
