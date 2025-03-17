namespace LAB_1;

static public class GlobalStorage
{
    private static List<Student> studentList = new List<Student>();
    private static List<Lecturer> lecturerList = new List<Lecturer>();
    private static List<Discipline> disciplineList = new List<Discipline>();
    private static List<Course> courseList = new List<Course>();

    public static List<T>? GetList<T>()
    {
        switch (typeof(T).Name.ToString())
        {
            case "Student":
                return (List<T>)(object)studentList;
            case "Lecturer":
                return (List<T>)(object)lecturerList;
            case "Discipline":
                return (List<T>)(object)disciplineList;
            case "Course":
                return (List<T>)(object)courseList;
            default:
                return null;
        }
    }

    public static void InitStorage()
    {
        courseList.Add(new Course(1));
        courseList.Add(new Course(2));
        courseList.Add(new Course(3));
        courseList.Add(new Course(4));

        studentList.Add(new Student("Егор", "Дмитриевич", "Иванов", 18, 105, courseList[0]));
        studentList.Add(new Student("Иван", "Данилович", "Петров", 19, 205, courseList[1]));
        studentList.Add(new Student("Александр", "Егорович", "Данилов", 20, 305, courseList[2]));
        studentList.Add(new Student("Дмитрий", "Иванович", "Артёмов", 21, 405, courseList[3]));
        studentList.Add(new Student("Василий", "Петрович", "Ильин", 18, 105, courseList[0]));
        studentList.Add(new Student("Петр", "Александрович", "Иванов", 19, 205, courseList[1]));
        studentList.Add(new Student("Степан", "Ильич", "Александров", 20, 305, courseList[2]));
        studentList.Add(new Student("Аристарх", "Акакиевич", "Дятлов", 21, 405, courseList[3]));
        studentList.Add(new Student("Даниил", "Алексеевич", "Васильев", 21, 405, courseList[3]));
        studentList.Add(new Student("Олег", "Афанасиевич", "Чепурко", 18, 105, courseList[0]));

        disciplineList.Add(new Discipline("Объектно-ориентированное программирование", ""));
        disciplineList.Add(new Discipline("Сети и телекоммуникации", ""));
        disciplineList.Add(new Discipline("Экономика отрасли", ""));
        disciplineList.Add(new Discipline("Иностранный язык", ""));
        disciplineList.Add(new Discipline("Авиационные материалы и технологии", ""));
        disciplineList.Add(new Discipline("Основы менеджмента", ""));
        disciplineList.Add(new Discipline("Базы данных", ""));
        disciplineList.Add(new Discipline("Математический анализ", ""));
        disciplineList.Add(new Discipline("Компьютерная графика", ""));
        disciplineList.Add(new Discipline("Объектно-ориентированное программирование", ""));

        lecturerList.Add(new Lecturer("Борис", "Борисович", "Новиков", 31, "нет"));
        lecturerList.Add(new Lecturer("Александр", "Витальевич", "Челпанов", 46, "доцент кафедры \"Моделирования систем и информационных технологий\""));
        lecturerList.Add(new Lecturer("Ольга", "Викторовна", "Степнова", 56, "доцент кафедры \"Экономика и управление\""));
        lecturerList.Add(new Lecturer("Ирина", "Юрьевна", "Старчикова", 60, "нет"));
        lecturerList.Add(new Lecturer("Игорь", "Михайлович", "Мамонов", 65, "Доцент кафедры \"Прикладная математика\""));
        lecturerList.Add(new Lecturer("Светлана", "Александровна", "Курашова", 41, "нет"));
        lecturerList.Add(new Lecturer("Павел", "Алексеевич", "Антонов", 30, "нет"));
        lecturerList.Add(new Lecturer("Елена", "Сергеевна", "Каратаева", 25, "нет"));
        lecturerList.Add(new Lecturer("Людмила", "Ивановна", "Еременская", 65, "нет"));
        lecturerList.Add(new Lecturer("Юлия", "Борисовна", "Егорова", 67, "Доцент кафедры «Прикладная математика», Профессор кафедры «Материаловедение и пластическая деформация металлов»"));
    }
}







