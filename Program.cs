using System;
public class Car
{
    // Поля класса
    private string Name;
    private int Maxspeed;
    private int Color;
    private int Position;
    private int Mesto;

    // Конструктор класса
    public Car(string Name, int Maxspeed,int Color)
    {
        this.Name = Name;
        this.Maxspeed = Maxspeed;
        this.Color = Color;
        this.Mesto = 0;
    }

    // Метод для вывода информации о автомобиле
    public void print()
    {
        Console.WriteLine($"Car name: {Name}");
        Console.WriteLine($"Maxspeed: {Maxspeed} km/h");
    }

    public void Move()
    {
        this.Position += this.Maxspeed;
    }

    public int GetPosition()
    {
       return this.Position;
    }

    public int GetMesto()
    {
       return this.Mesto;
    }

    public void Win(int Mesto)
    {
        if (this.Mesto == 0)
        this.Mesto = Mesto; 
    }

    public ConsoleColor GetColor()
    {
        if (this.Color == 0) return ConsoleColor.Green;
        if (this.Color == 1) return ConsoleColor.Yellow;
        if (this.Color == 2) return ConsoleColor.Blue;
        return ConsoleColor.Red;
    }

    // Метод для вывода информации о автомобиле
    public void printroad()
    {
        if (this.Mesto != 0)
        {
            Console.ForegroundColor = this.GetColor();
            Console.WriteLine($"{Name} goes {this.Mesto}st");
            Console.ResetColor();
            return;
        }
        for (int i = 0; i < 100; i++) {
            if (i == this.Position) {
                Console.ForegroundColor = this.GetColor();
                Console.Write('x');
                Console.ResetColor();
            } else
            {
                Console.Write('.');
            }
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        int last_Mesto = 1;
        Random random = new Random();
        Car[] Drivers = new Car[4];
        for (int i = 0; i < 4; i++) {
            Drivers[i] = new Car(
                $"Driver #{i}", random.Next(1,5), i
            );
        }
        while (true) 
        {
            Console.Clear();
            for (int i = 0; i < 4; i++)
            {
                Drivers[i].printroad();
                Drivers[i].Move();
                if (Drivers[i].GetPosition() >= 100 && Drivers[i].GetMesto()==0) {
                    Drivers[i].Win(last_Mesto);
                    last_Mesto++;
                }
            }
            System.Threading.Thread.Sleep(50);
        }
    }
}
