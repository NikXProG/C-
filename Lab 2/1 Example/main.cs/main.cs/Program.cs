using System;

public class Student : IEquatable<Student>
{
    private string fullName;
    private string academicGroup;
    private string studentId;
    private int course;

    public Student(string fullName, string academicGroup, string studentId, int course)
    {
        // Проверка на null для строковых параметров
        if (fullName == null || academicGroup == null || studentId == null)
        {
            throw new ArgumentNullException("Строковые параметры не могут быть null.");
        }

        // Проверка корректности курса
        if (course < 1 || course > 4)
        {
            throw new ArgumentException("Курс должен быть целым числом от 1 до 4.", nameof(course));
        }

        this.fullName = fullName;
        this.academicGroup = academicGroup;
        this.studentId = studentId;
        this.course = course;
    }

    // Свойства для доступа к полям объекта
    public string FullName => fullName;
    public string AcademicGroup => academicGroup;
    public string StudentId => studentId;
    public int Course => course;

    // Переопределение методов object
    public override string ToString()
    {
        return $"Student: {FullName}, Group: {AcademicGroup}, ID: {StudentId}, Course: {Course}";
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Student);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(fullName, academicGroup, studentId, course);
    }

    // Реализация интерфейса IEquatable<Student>
    public bool Equals(Student other)
    {
        if (other == null)
            return false;

        return string.Equals(fullName, other.fullName) &&
               string.Equals(academicGroup, other.academicGroup) &&
               string.Equals(studentId, other.studentId) &&
               course == other.course;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Пример использования
            Student student1 = new Student("John Doe", "GroupA", "12345", 2);
            Student student2 = new Student("Jane Smith", "GroupB", "67890", 3);

            Console.WriteLine(student1);
            Console.WriteLine(student2);

            // Демонстрация переопределения Equals
            Console.WriteLine($"Are students equal?\n{student1.Equals(student2)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }
}