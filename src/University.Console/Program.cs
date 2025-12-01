using System;
using University.Core.Models;
using University.Core.Services;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("welcome to the system! проверим, что всё работает");

        var courseService = new CourseService();
        var teacherService = new TeacherService();
        var studentService = new StudentService();

        Console.WriteLine("\n+ список студентов, преподавателей и курсов:");

        var teacher1 = new Teacher(102030, "Хихи Хаха Хихиковна", "hihihaha@itmo.ru");
        var teacher2 = new Teacher(405060, "Хохо Хехе Хохокович", "hohohehe@itmo.ru");

        var student1 = new Student(123456, "Мильнюсов Зореслав Добрыниевич", 2, "Языковые модели и искусственный интеллект");
        var student2 = new Student(579215, "Мошкин Тузик Аркадиевич", 3, "Мобильные и сетевые технологии");
        var student3 = new Student(138732, "НоваяФамилия НовоеИмя НовоеОтчество", 1, "AI360");

        var onlineCourse = new OnlineCourse(1, "основы с++", "Zoom", "https://zoom.us/");
        var offlineCourse = new OfflineCourse(2, "математический анализ", "ауд 205", "ПН/СР 10:00-12:00");

        Console.WriteLine($"преподаватели: {teacher1.Name}, {teacher2.Name}");
        Console.WriteLine($"студенты: {student1.Name} (курс: {student1.Year}), {student2.Name} (курс: {student2.Year}), {student3.Name} (курс: {student3.Year})");
        Console.WriteLine($"курсы: {onlineCourse.Title}, {offlineCourse.Title}");

        Console.WriteLine("\n+ инициализируем систему (добавляем студентов, преподавателей, курсы)...");
        teacherService.AddTeacher(teacher1);
        teacherService.AddTeacher(teacher2);
        studentService.AddStudent(student1);
        studentService.AddStudent(student2);
        studentService.AddStudent(student3);
        courseService.AddCourse(onlineCourse);
        courseService.AddCourse(offlineCourse);

        Console.WriteLine("всё добавлено успешно! :)");

        Console.WriteLine("\n+ распределяем преподавателей на курсы...");
        courseService.AssignTeacher(onlineCourse.Id, teacher1);
        courseService.AssignTeacher(offlineCourse.Id, teacher2);

        Console.WriteLine($"{onlineCourse.Title} -> {onlineCourse.Teacher?.Name ?? "преподаватель не был добавлен"}");
        Console.WriteLine($"{offlineCourse.Title} -> {offlineCourse.Teacher?.Name ?? "преподаватель не был добавлен"}");

        Console.WriteLine("\n+ распределяем студентов...");
        courseService.EnrollStudent(onlineCourse.Id, student1);
        courseService.EnrollStudent(onlineCourse.Id, student2);
        courseService.EnrollStudent(offlineCourse.Id, student2);
        courseService.EnrollStudent(offlineCourse.Id, student3);

        Console.WriteLine($"на заочный курс {onlineCourse.Title} теперь записаны: {string.Join(", ", onlineCourse.Students.Select(s => s.Name))}");
        Console.WriteLine($"на очный курс {offlineCourse.Title} теперь записаны: {string.Join(", ", offlineCourse.Students.Select(s => s.Name))}");

        Console.WriteLine("\nполучим курс, который ведёт Хихи Хаха Хихиковна:");
        var coursesByTeacher1 = courseService.GetCoursesByTeacher(teacher1.Id);
        Console.WriteLine($"{string.Join(", ", coursesByTeacher1.Select(c => c.Title))}");

        Console.WriteLine("\nнемного похимичим с курасми и их участниками!");
        var foundStudent = studentService.GetStudent(579215);
        Console.WriteLine($"ого, студент с ИСУ 579215 - {foundStudent?.Name ?? "не найден :("}");

        var foundTeacher = teacherService.GetTeacher(405060);
        Console.WriteLine($"ого, преподаватель с ИСУ 405060 - {foundTeacher?.Name ?? "не найден :("}");

        Console.WriteLine($"надвигается сокращение! сейчас курсов от {teacher2.Name} {courseService.GetCoursesByTeacher(teacher2.Id).Count} шт.");
        courseService.RemoveCourse(2);
        Console.WriteLine($"курс под номером 2 попал под горячую руку, теперь курсов осталось {courseService.GetCoursesByTeacher(teacher2.Id).Count} шт.");

        var coursesByTeacher2 = courseService.GetCoursesByTeacher(teacher2.Id);
        Console.WriteLine($"после сокращения преподаватель {teacher2.Name} не ведёт ни одного курса :(");
    }
}