using DroneControlSystem;

Console.WriteLine("=== Система управления БПЛА (версия 2.1) ===\n");


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
    Console.WriteLine();
}

for (int i = 0; i < drones.Length; i++)
{
    if (drones[i].BatteryLevel < 50)
    {
        Console.Write($"У {drones[i].Model} заряд {drones[i].BatteryLevel}% (ниже 50%). Подзарядить на 40%? (1 — да, 0 — нет): ");
        if (Console.ReadLine() == "1")
        {
            drones[i].ChargeBattery(40);
        }
        Console.WriteLine();
    }
}

Console.WriteLine("--- Новый дрон с полным зарядом ---");
Drone fullChargedDrone = new Drone("DJI Mavic 3");
fullChargedDrone.PrintInfo();

Console.WriteLine("\nПрограмма завершена.");
