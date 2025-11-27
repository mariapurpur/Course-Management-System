using Xunit;
using University.Core.Models;

public class OnlineCourseTests
{
    [Fact]
    public void Constructor_Correct()
    {
        int id = 123;
        string title = "основы c++";
        string platform = "Zoom";
        string link = "https://zoom.us/";

        var course = new OnlineCourse(id, title, platform, link);

        Assert.Equal(id, course.Id);
        Assert.Equal(title, course.Title);
        Assert.Equal(platform, course.Platform);
        Assert.Equal(link, course.Link);
        Assert.Empty(course.Students);
        Assert.Null(course.Teacher);
    }

    [Fact]
    public void Inherits()
    {
        var course = new OnlineCourse(456, "тестовый онлайн курс", "LMS", "https://lms.com");

        Assert.IsAssignableFrom<Course>(course);
    }
}

public class OfflineCourseTests
{
    [Fact]
    public void Constructor_Correct()
    {
        int id = 789;
        string title = "математический анализ";
        string classroom = "ауд 205";
        string schedule = "ПН/СР 10:00-12:00";

        var course = new OfflineCourse(id, title, classroom, schedule);

        Assert.Equal(id, course.Id);
        Assert.Equal(title, course.Title);
        Assert.Equal(classroom, course.Classroom);
        Assert.Equal(schedule, course.Schedule);
        Assert.Empty(course.Students);
        Assert.Null(course.Teacher);
    }

    [Fact]
    public void Inherits()
    {
        var course = new OfflineCourse(999, "тест оффлайн курс", "ауд 101", "ПТ 14:00-16:00");

        Assert.IsAssignableFrom<Course>(course);
    }
    [Fact]
    public void Course_Correct()
    {
        var courseId = 1;
        var courseTitle = "тестовый базовый курс";

        var course = new OnlineCourse(courseId, courseTitle, "LMS", "https://lms");

        Assert.Equal(courseId, course.Id);
        Assert.Equal(courseTitle, course.Title);
        Assert.Empty(course.Students);
        Assert.Null(course.Teacher);
    }
}