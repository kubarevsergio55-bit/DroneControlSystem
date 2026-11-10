using DroneControlSystem;

Console.WriteLine("=== Система управления БПЛА ===\n");

<<<<<<< HEAD
Drone[] drones = new Drone[]
=======
Drone myDrone = new Drone("DJI Mini 3", 85);

myDrone.PrintInfo();
Console.WriteLine();

Console.Write("Введите команду (1 — взлёт, 0 — выход): ");
int command = int.Parse(Console.ReadLine());

while (command != 0)
>>>>>>> feature/battery-check
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
while (myDrone.BatteryLevel < 50)
{
    Console.Write($"У {myDrone.Model} низкий заряд ({myDrone.BatteryLevel}%). Подзарядить на 30%? (1 — да, 0 — нет): ");
    int chargeChoice = int.Parse(Console.ReadLine());
    if (chargeChoice == 1)
    {
        myDrone.ChargeBattery(30);
    }
    else
    {
        break;
    }
}
Console.WriteLine("Программа завершена.");
