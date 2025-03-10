//Завдання 1
//Варіант 7. Дано список студентів. Елемент списку містить список з 
//наступною інформацією: прізвище, ім'я, по батькові, рік народження,
//курс, номер групи, оцінки з п'яти предметів. Упорядкуйте 
//студентів за курсом, причому студенти одного курсу розташовувалися 
//в алфавітному порядку. Знайдіть середній бал кожної групи 
//по кожному предмету. Визначте найстаршого і наймолодшого студентів. 
//Для кожної групи знайдіть найуспішнішого студента.

using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public int Year { get; set; }
    public int Course { get; set; }
    public int Group { get; set; }
    public int Math { get; set; }
    public int Physics { get; set; }
    public int Chemistry { get; set; }
    public int Informatics { get; set; }
    public int English { get; set; }

    public Student(string name, int year, int course, int group, int math, int physics, int chemistry, int informatics, int english)
    {
        Name = name;
        Year = year;
        Course = course;
        Group = group;
        Math = math;
        Physics = physics;
        Chemistry = chemistry;
        Informatics = informatics;
        English = english;
    }

    public List<int> GetGrades()
    {
        return new List<int> { Math, Physics, Chemistry, Informatics, English };
    }

    public double GetAvarageGrade()
    {
        return (Math + Physics + Chemistry + Informatics + English) / 5.0;
    }
    static void Main()
    {
        List<Student> Students = new List<Student>()
        {
            new Student("Олександр Іванович Петренко", 2005, 3, 43, 85, 78, 90, 88, 92),
            new Student("Белла Петрівна Акуленко", 2007, 1, 41, 82, 70, 88, 94, 98),
            new Student("Марина Сергіївна Сидоренко", 2006, 2, 41, 92, 85, 87, 90, 95),
            new Student("Дмитро Олегович Смирнов", 2006, 1, 41, 80, 70, 78, 85, 70),
            new Student("Ігор Олександрович Василенко", 2004, 3, 43, 95, 90, 88, 93, 98),
            new Student("Андрій Віталійович Мельник", 2007, 1, 41, 75, 78, 85, 88, 77),
            new Student("Вікторія Олександрівна Ткаченко", 2006, 2, 42, 87, 89, 84, 90, 92)
        };

        Console.WriteLine("Відсортовані студенти за курсом та 1 курс по алфавітному порядку:");
        Console.WriteLine();

        var sortedStudents = Students
            .OrderBy(s => s.Course)
            .ThenBy(s => s.Course == 1 ? s.Name : "");

        foreach (var student in sortedStudents)
        {
            Console.WriteLine($"{student.Name}, {student.Year} рік, Курс: {student.Course}, Група: {student.Group}, Оцінки: {string.Join(", ", student.GetGrades())}");
        }
        Console.WriteLine();

        Console.WriteLine("Середній бал кожної групи по кожному предмету:");

        var groupAverages = sortedStudents
            .GroupBy(s => s.Group)
            .Select(g => new
            {
                GroupNumber = g.Key,
                AvgMath = g.Average(s => s.Math),
                AvgPhysics = g.Average(s => s.Physics),
                AvgChemistry = g.Average(s => s.Chemistry),
                AvgInformatics = g.Average(s => s.Informatics),
                AvgEnglish = g.Average(s => s.English)
            });
        Console.WriteLine();

        foreach (var group in groupAverages)
        {
            Console.WriteLine($"Група: {group.GroupNumber}\n\tМатематика: {group.AvgMath}\n\tФізика: {group.AvgPhysics}" +
                $"\n\tХімія: {group.AvgChemistry}\n\tІнформатика: {group.AvgInformatics}\n\tАнглійська: {group.AvgEnglish}");
            Console.WriteLine();
        }

        var oldestStudent = Students.OrderBy(s => s.Year).First();
        Console.WriteLine($"Найстарший студент: {oldestStudent.Name}, {oldestStudent.Year} рік народження");
        Console.WriteLine();

        var maxYear = Students.Max(s => s.Year);
        var youngestStudents = Students.Where(s => s.Year == maxYear);

        Console.WriteLine("Наймолодші студенти:");
        foreach (var student in youngestStudents)
        {
            Console.WriteLine($"{student.Name}, {student.Year} рік народження");
        }
        Console.WriteLine();


        Console.WriteLine("Найуспішніший студент у кожній групі:");
        Console.WriteLine();

        var BestStudents = Students
            .GroupBy(s => s.Group)
            .Select(g => g.OrderByDescending(s => s.GetAvarageGrade()).First());

        foreach (var student in BestStudents)
        {
            Console.WriteLine($"Група: {student.Group}, {student.Name}, середній бал: {student.GetAvarageGrade()}");
        }
        Console.WriteLine();

        Console.WriteLine("Натисніть кнопку для виходу...");
        Console.ReadLine();
    }
}


//Завдання 2
//Дано словник. Видалити елемент з найбільшим ключем. 
//Значення найменшого ключа замінити на видалене значення 
//найбільшого ключа.

//class Words
//{
//    static void Main()
//    {
//        Dictionary<int, string> dic = new Dictionary<int, string>();

//        dic.Add(1, "Один");
//        dic.Add(2, "Два");
//        dic.Add(3, "Три");
//        dic.Add(4, "Чотири");
//        dic.Add(5, "П'ять");
//        dic.Add(6, "Шість");
//        dic.Add(7, "Сім");
//        dic.Add(8, "Вісім");
//        dic.Add(9, "Дев'ять");
//        dic.Add(10, "Десять");

//        if (dic.Count > 0)
//        {
//            int MaxKey = dic.Keys.Max();
//            string MaxValue = dic[MaxKey];
//            dic.Remove(MaxKey);

//            int MinKey = dic.Keys.Min();
//            dic[MinKey] = MaxValue;

//            Console.WriteLine($"Елемент з найбільшим значеннням видалено: {MaxKey}, значення: {MaxValue}");
//        }
//        foreach (KeyValuePair<int, string> i in dic)
//        {
//            Console.WriteLine($"{i.Key} {i.Value}");
//        }


//        Console.ReadKey();
//    }
//}

//Завдання 3
//Програма створює словник даних Dictionary 
//продуктів харчування: ключ - товар, значення - ціна.
//Створити дві цінові групи: товари дорожче і дешевше 300 гривень (1) (3)

//(1)-First, FirstOrDefault, Last, LastOrDefault, Single, SingleOrDefault (поелементні операції)
//- Count, Sum, Average, Max, Min, Aggregate (агрегування); • Range(генерування послідовностей).

//(2)-Select, SelectMany, Where

//class FruitShop
//{
//    static void Main()
//    {
//        Dictionary<string, int> d = new Dictionary<string, int>();

//        d.Add("банани", 200);
//        d.Add("яблука", 100);
//        d.Add("виноград", 320);
//        d.Add("персик", 250);
//        d.Add("груша", 90);
//        d.Add("манго", 350);
//        d.Add("апельсини", 300);

//        var PricerThan300 = d.Where(p => p.Value < 300).ToList();
//        var CheaperThan300 = d.Where(p => p.Value >= 300).ToList();

//        Console.WriteLine("Товар дешевший 300 грн:");
//        foreach (var i in CheaperThan300)
//        {
//            Console.WriteLine($"\tтовар - {i.Key}, ціна: {i.Value} грн");
//        }

//        Console.WriteLine("Товар дорожчий за 300 грн:");
//        foreach (var i in PricerThan300)
//        {
//            Console.WriteLine($"\tтовар - {i.Key}, ціна: {i.Value} грн");
//        }

//        Console.ReadKey();
//    }
//}

//class FruitShop
//{
//    static void Main()
//    {
//        Dictionary<string, int> d = new Dictionary<string, int>
//        {
//            { "банани", 200 },
//            { "яблука", 100 },
//            { "виноград", 320 },
//            { "персик", 250 },
//            { "груша", 90 },
//            { "манго", 350 },
//            { "апельсини", 300 }
//        };

//        var result = d.Aggregate(
//            new { Cheaper = "", Pricier = "" },
//            (acc, item) => item.Value < 300
//                ? new { Cheaper = acc.Cheaper + $"\tтовар - {item.Key}, ціна: {item.Value} грн\n", Pricier = acc.Pricier }
//                : new { Cheaper = acc.Cheaper, Pricier = acc.Pricier + $"\tтовар - {item.Key}, ціна: {item.Value} грн\n" }
//        );

//        Console.WriteLine("Товар дешевший за 300 грн:");
//        Console.Write(result.Cheaper);

//        Console.WriteLine("Товар дорожчий або рівний 300 грн:");
//        Console.Write(result.Pricier);

//        Console.ReadKey();
//    }
//}
