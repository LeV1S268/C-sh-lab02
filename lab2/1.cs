using System.Security.Cryptography;
public class Pupil
{
    public virtual void Study() { Console.WriteLine("Pupil studying normally"); }
    public virtual void Read() { Console.WriteLine("Pupil reading normally"); }
    public virtual void Write() { Console.WriteLine("Pupil writing normally"); }
    public virtual void Relax() { Console.WriteLine("Pupil is relaxing"); }
}
public class ExcelentPupil : Pupil
{
    public override void Study() { Console.WriteLine("Pupil studying hard"); }
    public override void Read() { Console.WriteLine("Pupil reading a hard book"); }
    public override void Write() { Console.WriteLine("Pupil writing a PhD"); }
    public override void Relax() { Console.WriteLine("Pupil is not relaxing"); }
}
public class GoodPupil : Pupil
{
    public override void Study() { Console.WriteLine("Pupil studying good"); }
    public override void Read() { Console.WriteLine("Pupil reading a book"); }
    public override void Write() { Console.WriteLine("Pupil writing a diploma"); }
    public override void Relax() { Console.WriteLine("Pupil is relaxing"); }
}
public class BadPupil : Pupil
{
    public override void Study() { Console.WriteLine("Pupil is relaxing"); }
    public override void Read() { Console.WriteLine("Pupil reading a fantasy book"); }
    public override void Write() { Console.WriteLine("Pupil is relaxing"); }
    public override void Relax() { Console.WriteLine("Pupil is relaxing"); }
}
public class ClassRoom
{
    public Pupil[] students;
    public ClassRoom(params Pupil[] students)
    {
        this.students = new Pupil[students.Length];
        for (int i = 0; i < students.Length; ++i)
        {
            this.students[i] = students[i];
        }
    }
}
public class Vehicle
{
    public int x, y, z;
    public float cost, speed;
    public string year;
    public Vehicle(int x, int y, int z, float cost, float speed, string year)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.cost = cost;
        this.speed = speed;
        this.year = year;
    }
    public virtual void PrintSelf()
    {
        Console.WriteLine($"Координаты: {x}, {y}, {z}");
        Console.WriteLine($"Цена: {cost}");
        Console.WriteLine($"Скорость: {speed}");
        Console.WriteLine($"Год производства: {year}");
    }
}
public class Plane : Vehicle
{
    public int height;
    public int passangers_count;
    public Plane(int x, int y, int z, float cost, float speed, string year, int height, int passangers_count) : base(x, y, z, cost, speed, year)
    {
        this.height = height;
        this.passangers_count = passangers_count;
    }
    public override void PrintSelf()
    {
        base.PrintSelf();
        Console.WriteLine($"Высота полёта: {height}");
        Console.WriteLine($"Количество пассажиров: {passangers_count}");
    }
}

public class Ship : Vehicle
{
    public string port;
    public int passangers_count;
    public Ship(int x, int y, int z, float cost, float speed, string year, string port, int passangers_count) : base(x, y, z, cost, speed, year)
    {
        this.port = port;
        this.passangers_count = passangers_count;
    }
    public override void PrintSelf()
    {
        base.PrintSelf();
        Console.WriteLine($"Приписанный порт: {port}");
        Console.WriteLine($"Количество пассажиров: {passangers_count}");
    }
}
public class Car : Vehicle
{
    public Car(int x, int y, int z, float cost, float speed, string year) : base(x, y, z, cost, speed, year) { }
}

public class DocumentWorker
{
    public virtual void OpenDocument() { Console.WriteLine("Документ открыт"); }
    public virtual void EditDocument() { Console.WriteLine("Редактирование доступно в версии Pro"); }
    public virtual void SaveDocument() { Console.WriteLine("Сохранение доступно в версии Pro"); }
}

public class ProDocumentWorker : DocumentWorker
{
    public override void EditDocument() { Console.WriteLine("Документ отредактирован"); }
    public override void SaveDocument() { Console.WriteLine("Документ сохранен в старом формате, сохранение в остальных форматах доступно в версии Expert"); }
}

public class ExpertDocumentWorker : ProDocumentWorker
{
    public override void SaveDocument()
    {
        Console.WriteLine("Документ сохранен в новом формате");
    }
}
public class MainClass
{
    public static void Main(string[] args)
    {
        // 1
        Pupil a1 = new Pupil();
        GoodPupil a2 = new GoodPupil();
        BadPupil a3 = new BadPupil();
        ExcelentPupil a4 = new ExcelentPupil();

        ClassRoom clas = new ClassRoom(a1, a2, a3, a4);
        for (int i = 0; i < clas.students.Length; i++)
        {
            clas.students[i].Study();
            clas.students[i].Read();
            clas.students[i].Write();
            clas.students[i].Relax();
            Console.WriteLine("");
        }
        // 2
        Console.WriteLine("Task 2");
        Vehicle v1 = new Vehicle(1, 2, 3, 1000, 100, "2003");
        Plane v2 = new Plane(1, 2, 3, 999999, 7000, "2006", 10000, 100);
        Ship v3 = new Ship(1, 2, 3, 99999, 200, "1900", "Pearl Harbor", 340);
        Car v4 = new Car(1, 2, 3, 999, 90, "2024");
        v1.PrintSelf();
        Console.WriteLine();
        v2.PrintSelf();
        Console.WriteLine();
        v3.PrintSelf();
        Console.WriteLine();
        v4.PrintSelf();

        // 3
        Console.WriteLine("Task 3");
        Console.WriteLine("Введите ключ доступа");
        string key = Console.ReadLine();
        if (key == "1")
        {
            ProDocumentWorker doc2 = new ProDocumentWorker();
            doc2.OpenDocument();
            doc2.EditDocument();
            doc2.SaveDocument();
        }
        else if (key == "2")
        {
            ExpertDocumentWorker doc3 = new ExpertDocumentWorker();
            doc3.OpenDocument();
            doc3.EditDocument();
            doc3.SaveDocument();
        }
        else
        {
            DocumentWorker doc1 = new DocumentWorker();
            doc1.OpenDocument();
            doc1.EditDocument();
            doc1.SaveDocument();
        }

    }
}