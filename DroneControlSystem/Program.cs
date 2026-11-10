using DroneControlSystem;

Console.WriteLine("=== Система управления БПЛА (версия 1.0) ===\n");

Drone myDrone = new Drone("DJI Mini 3", 85);

myDrone.PrintInfo();
Console.WriteLine();

Console.Write("Введите команду (1 — взлёт, 0 — выход): ");
int command = int.Parse(Console.ReadLine());

while (command != 0)
{
    if (command == 1)
    {
        myDrone.TakeOff();
    }
    else
    {
        Console.WriteLine("Неизвестная команда.");
    }

    Console.Write("Введите команду (1 — взлёт, 0 — выход): ");
    command = int.Parse(Console.ReadLine());
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
