using LAB_1;

Console.InputEncoding = System.Text.Encoding.Unicode;

GlobalStorage.InitStorage();
while (true)
{
    Console.WriteLine("Выберите раздел: \n 1. Студенты \n 2. Преподователи \n 3. Дисциплины \n 4. Курсы \n 0. Выход");

    int choice = -1;
    while (!new[] { 1, 2, 3, 4, 0 }.Contains(choice))
    {
        while (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Некорректный ввод");
        }
    }
    Console.WriteLine(choice);
    IDialog? dialog = null;
    switch (choice)
    {
        case 1:
            dialog = new StudentDialog();
            break;
        case 2:
            dialog = new LecturerDialog();
            break;
        case 3:
            dialog = new DisciplineDialog();
            break;
        case 4:
            dialog = new CourseDialog();
            break;
        case 0:
            return;
    }
    dialog?.MainDialog();
}
