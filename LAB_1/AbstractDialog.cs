using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq.Expressions;
using Microsoft.VisualBasic.FileIO;

public abstract class AbstractDialog<T> : IDialog
where T : IEntity
{
    protected List<T>? DataList = GlobalStorage.GetList<T>();
    protected abstract string SearchCriteria(T item);
    public void MainDialog()
    {
        Console.WriteLine("Выберите Действие: \n 1. Добавить \n 2. Удалить \n 3. Изменить \n 4. Вывести Все данные раздела \n 5. Поиск \n 6. Дополнительное меню \n 0. Выход");

        int choice = -1;
        while (!new[] { 1, 2, 3, 4, 5, 0 }.Contains(choice))
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
                Add();
                break;
            case 2:
                Delete();
                break;
            case 3:
                Update();
                break;
            case 4:
                ViewData();
                break;
            case 5:
                Search();
                break;
            case 6:
                AdditionalMenu();
                return;
            case 0:
                return;

        }
    }

    protected virtual void AdditionalMenu() { }

    protected abstract void Add();

    protected void Delete()
    {
        Guid id = InputDialog<Guid>("идентификатор");
        var objectToDelete = DataList.FirstOrDefault(x => x.Id == id);
        if (objectToDelete == null)
        {
            Console.WriteLine("Элемент с данным идентификатором не найден");
        }
        else
        {
            DataList.Remove(objectToDelete);
            Console.WriteLine("Удаление успешно");
        }
    }

    protected abstract void Update();

    protected P? InputDialog<P>(string propertyName, bool requiredProperty = true)
    {
        Console.WriteLine($"Введите знаечние свойства {propertyName}.\n{(requiredProperty ? "Это свойство обязетельно." : "Это свойство не обязательно, оставьте поле ввода пустым чтобы пропустить его")}");

        string? input = Console.ReadLine();

        if (String.IsNullOrEmpty(input))
        {
            if (requiredProperty)
            {
                Console.WriteLine("Это свойство обязтельное!");
            }
            return default(P);
        }

        if (typeof(P) == typeof(string))
        {
            Console.WriteLine(input);
            return (P)(object)input;
        }

        if (typeof(P) == typeof(int))
        {
            if (int.TryParse(input, out int value))
            {
                return (P)(object)value;
            }
            else
            {
                Console.WriteLine("Неверный формат ввода (требуется: int)");
                return default(P);
            }
        }

        if (typeof(P) == typeof(Guid))
        {
            if (Guid.TryParse(input, out Guid id))
            {
                return (P)(object)id;
            }
            else
            {
                Console.WriteLine("Неверный формат ввода (требуется: Guid)");
                return default(P);
            }
        }

        if (typeof(P) == typeof(Course))
        {
            if (int.TryParse(input, out int courseNumber))
            {
                Course? course = GlobalStorage.GetList<Course>().FirstOrDefault(course => course.CourseNumber == courseNumber);
                if (course == null)
                {
                    Console.WriteLine("Курса с таким номером не существует");
                    return default(P);
                }
                else
                {
                    return (P)(object)course;
                }
            }
            else
            {
                Console.WriteLine("Неверный формат ввода (требуется: int) ");
                return default(P);
            }
        }
        return default(P);
    }

    protected void ViewData()
    {
        foreach (var element in DataList)
        {
            element.DisplayInfo();
        }
    }

    protected virtual void Search()
    {
        Console.WriteLine("Введите данные для поиска через пробел");
        string? input = "";
        while (String.IsNullOrEmpty(input))
        {
            input = Console.ReadLine();
        }
        var parametrs = input.ToLower().Split(" ");
        DataList.Where(x =>
        {
            foreach (var elem in parametrs)
            {
                if (!SearchCriteria(x).ToLower().Contains(elem)) return false;
            }
            return true;
        }).ToList().ForEach(x => x.DisplayInfo());
    }

    protected void LinkOrUnlinkLecturerAndDiscipline(int choice = 1)
    {
        Guid lecturerId = InputDialog<Guid>("Идентификатор преподователя");
        Lecturer? lecturer = GlobalStorage.GetList<Lecturer>().FirstOrDefault(x => x.Id == lecturerId);
        string? disciplineName = InputDialog<string>("Название диспицплины");
        Discipline? discipline = GlobalStorage.GetList<Discipline>().FirstOrDefault(y => y.Name == disciplineName);
        if (lecturer == null)
        {
            Console.WriteLine("Такого преподователя не существует");
            return;
        }
        else if (discipline == null)
        {
            Console.WriteLine("Такой дисциплины не существует");
            return;
        }
        switch (choice)
        {
            case 1:
                break;
                lecturer.LinkDiscipline(discipline);
            case 2:
                break;
                lecturer.UnLinkDiscipline(discipline);
            default:
                Console.WriteLine("Такой опции нет");
                break;
        }
    }

    protected void LinkOrUnlinkCourseToDiscipline(int choice = 1)
    {
        int courseNumber = InputDialog<int>("номер курса");
        Course? course = GlobalStorage.GetList<Course>().FirstOrDefault(x => x.CourseNumber == courseNumber);
        string? disciplineName = InputDialog<string>("Название диспицплины");
        Discipline? discipline = GlobalStorage.GetList<Discipline>().FirstOrDefault(y => y.Name == disciplineName);
        if (course == null)
        {
            Console.WriteLine("Такого курса не существует");
            return;
        }
        else if (discipline == null)
        {
            Console.WriteLine("Такой дисциплины не существует");
            return;
        }
        switch (choice)
        {
            case 1:
                break;
                course.LinkDisciplineToCourse(discipline);
            case 2:
                break;
                course.UnLinkDisciplineToCourse(discipline);
            default:
                Console.WriteLine("Такой опции нет");
                break;
        }
    }

}
