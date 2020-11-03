/*
Створити абстрактний базовий клас «Транспортний засіб»
Розробіть похідні класи зображенні на малюнку. 
Пасажиру потрібно проїхати з пункту А до пункту В з використанням різних транспортних засобів. 
Кількість транспортних засобів генерується випадково.  
Обчислити час і вартість проїзду пасажира.

Базовий клас «Транспортний засіб»
Похідні класи: 
    Засоби масового перевезення:
        - маршрутне таксі;
        - тролейбус;
        - трамвай;
    Сільськогосподарська техніка:
        - трактор;
        - комбайн;
    Інші:
        - легкові автомобілі;
        - вантажні автомобілі;
        - мотоцикли;
        - скутери;
*/

using System;
using System.Linq;
using System.Text;

namespace _30102020dz
{
    class Vehicle
    {
        protected double AvgSpeed;
        protected double AvgCost;
        public double Distance { get; set; }
        public Vehicle(double dist, double speed, double cost) { Distance = dist; AvgSpeed = speed; AvgCost = cost; }
        public TimeSpan Time() => TimeSpan.FromSeconds(Distance / (AvgSpeed / 3600));
        public virtual double Cost() => Distance * AvgCost;
    }

    class MinibusTaxi : Vehicle
    {
        public MinibusTaxi(double dist) : base(dist, 31, 11) { }
        public override double Cost() => AvgCost;
        public override string ToString() => $"Маршрутним таксі";
    }

    class Trolleybus : Vehicle
    {
        public Trolleybus(double dist) : base(dist, 32, 12) { }
        public override double Cost() => AvgCost;
        public override string ToString() => $"Тролейбусом";
    }

    class Tram : Vehicle
    {
        public Tram(double dist) : base(dist, 33, 13) { }
        public override double Cost() => AvgCost;
        public override string ToString() => $"Трамваєм";
    }

    class Tractor : Vehicle
    {
        public Tractor(double dist) : base(dist, 41, 51) { }
        public override string ToString() => $"Трактором";
    }

    class Harvester : Vehicle
    {
        public Harvester(double dist) : base(dist, 42, 52) { }
        public override string ToString() => $"Комбайном";
    }

    class PassengerCar : Vehicle
    {
        public PassengerCar(double dist) : base(dist, 90, 5) { }
        public override string ToString() => $"Легковим автомобілем";
    }

    class VantageCar : Vehicle
    {
        public VantageCar(double dist) : base(dist, 80, 15) { }
        public override string ToString() => $"Вантажним автомобілем";
    }

    class Motorcycle : Vehicle
    {
        public Motorcycle(double dist) : base(dist, 100, 4) { }
        public override string ToString() => $"Мотоциклом";
    }

    class Scooter : Vehicle
    {
        public Scooter(double dist) : base(dist, 50, 3) { }
        public override string ToString() => $"Скутером";
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            Random rnd = new Random();
            int count_of_vihicles = rnd.Next(7, 15);
            int dst, distance = dst = rnd.Next(100, 1001);

            Vehicle[] arr = new Vehicle[count_of_vihicles];
            for (int i = 0; i < arr.Length; i++)
            {
                int d = rnd.Next(distance + 1);
                distance -= d;
                int r = rnd.Next(8);
                if (r == 0) arr[i] = new MinibusTaxi(d);
                else if (r == 1) arr[i] = new Trolleybus(d);
                else if (r == 2) arr[i] = new Tram(d);
                else if (r == 3) arr[i] = new Harvester(d);
                else if (r == 4) arr[i] = new PassengerCar(d);
                else if (r == 5) arr[i] = new VantageCar(d);
                else if (r == 6) arr[i] = new Motorcycle(d);
                else arr[i] = new Scooter(d);
            }

            TimeSpan TotalTime = TimeSpan.FromSeconds(0);
            double TotalCost = 0;

            string Head = "|ПАСАЖИР ПРОЇХАВ:     | км. | год. | хв. | с. | грн. |";
            Console.WriteLine(Head);
            int lenght = Head.Length;
            string delimiter = new string('-', lenght);
            Console.WriteLine(delimiter);

            foreach (var item in arr.Where(n => n.Distance != 0))
            {
                TotalTime += item.Time();
                TotalCost += item.Cost();
                Console.WriteLine($"|{item,-21}|{item.Distance,5}|{item.Time().Hours,6}|{item.Time().Minutes,5}|{item.Time().Seconds,4}|{item.Cost(),6}|");
            }

            Console.WriteLine(delimiter);

            Console.WriteLine("Загалом пасажир подолав " + dst + " км.");
            Console.WriteLine($"Подорож тривала {TotalTime.Hours} год. {TotalTime.Minutes} хв. {TotalTime.Seconds} с. ");
            Console.WriteLine("і коштувала " + TotalCost + " грн.");
        }
    }
}