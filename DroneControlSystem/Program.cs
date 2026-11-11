using DroneControlSystem;

Console.WriteLine("*******************************************");
Console.WriteLine("*** Система управления БПЛА (версия 2.0) ***");
Console.WriteLine("*******************************************\n");

Drone[] drones = new Drone[]
{
    new Drone("DJI Mini 3", 85),
    new Drone("Autel EVO Lite", 45),
    new Drone("Parrot Anafi", 15)
};

foreach (Drone drone in drones)
{
    drone.PrintInfo();
    if (drone.BatteryLevel < 20)
    {
        Console.WriteLine($"ВНИМАНИЕ! Критически низкий заряд у {drone.Model}!");
    }

    drone.TakeOff();
    if (drone.IsEngineOn)
    {
        int flightTime = drone.CalculateFlightTime();
        Console.WriteLine($"Расчётное время полёта: {flightTime} мин.");
    }

    Console.WriteLine();
}

try
{
    for (int i = 0; i < drones.Length; i++)
    {
        if (drones[i].BatteryLevel < 50)
        {
            Console.Write($"У {drones[i].Model} заряд {drones[i].BatteryLevel}% (ниже 50%). Подзарядить на 40%? (1 — да, 0 — нет): ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Ошибка: введите число (1 или 0). Подзарядка пропущена.");
                continue;
            }

            if (choice == 1)
            {
                drones[i].ChargeBattery(40);
            }
            Console.WriteLine();
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Произошла ошибка при вводе данных: {ex.Message}");
}

Console.WriteLine("--- Новый дрон с полным зарядом ---");
Drone fullChargedDrone = new Drone("DJI Mavic 3");
fullChargedDrone.PrintInfo();

Console.WriteLine("\nПрограмма завершена.");
