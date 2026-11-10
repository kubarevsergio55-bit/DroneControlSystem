using DroneControlSystem;

Console.WriteLine("=== Система управления БПЛА ===\n");

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

Console.WriteLine("Программа завершена.");
