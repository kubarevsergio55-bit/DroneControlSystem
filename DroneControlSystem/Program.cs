using DroneControlSystem;

Drone[] drones = new Drone[]
{
    new Drone("DJI Mini 3", 85),
    new Drone("Autel EVO Lite", 45),
    new Drone("Parrot Anafi", 15),
    new Drone("DJI Mavic 3")
};

while (true)
{
    Console.WriteLine("\n=== Система управления БПЛА (версия 3.0) ===");
    Console.WriteLine("1. Показать информацию о всех дронах");
    Console.WriteLine("2. Взлёт выбранного дрона");
    Console.WriteLine("3. Подзарядка выбранного дрона");
    Console.WriteLine("4. Расчёт времени полёта");
    Console.WriteLine("5. Сохранить состояние в файл");
    Console.WriteLine("6. Загрузить состояние из файла");
    Console.WriteLine("0. Выход");
    Console.Write("Выберите действие: ");

    string choiceInput = Console.ReadLine();
    if (!int.TryParse(choiceInput, out int action))
    {
        Console.WriteLine("Ошибка: введите число от 0 до 6.");
        continue;
    }

    if (action == 0)
    {
        Console.WriteLine("Выход из программы...");
        break;
    }

    try
    {
        switch (action)
        {
            case 1:
                Console.WriteLine("\n--- Список БПЛА ---");
                for (int i = 0; i < drones.Length; i++)
                {
                    Console.WriteLine($"[Дрон №{i + 1}]");
                    drones[i].PrintInfo();
                    if (drones[i].BatteryLevel < 20)
                    {
                        Console.WriteLine($"ВНИМАНИЕ! Критически низкий заряд у {drones[i].Model}!");
                    }
                    Console.WriteLine();
                }
                break;

            case 2:
                int takeOffIndex = SelectDroneIndex(drones);
                if (takeOffIndex != -1)
                {
                    drones[takeOffIndex].TakeOff();
                }
                break;

            case 3:
                int chargeIndex = SelectDroneIndex(drones);
                if (chargeIndex != -1)
                {
                    Console.Write("Введите процент подзарядки (например, 40): ");
                    if (int.TryParse(Console.ReadLine(), out int amount) && amount > 0)
                    {
                        drones[chargeIndex].ChargeBattery(amount);
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: введите положительное число.");
                    }
                }
                break;

            case 4:
                int timeIndex = SelectDroneIndex(drones);
                if (timeIndex != -1)
                {
                    int minutes = drones[timeIndex].CalculateFlightTime();
                    if (drones[timeIndex].IsEngineOn)
                    {
                        Console.WriteLine($"Расчётное время полёта {drones[timeIndex].Model}: {minutes} мин.");
                    }
                }
                break;

            case 5:
            case 6:
                Console.WriteLine("Функция работы с файлами будет добавлена в следующем обновлении.");
                break;

            default:
                Console.WriteLine("Неизвестная команда. Выберите пункт от 0 до 6.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Произошла ошибка: {ex.Message}");
    }
}

static int SelectDroneIndex(Drone[] drones)
{
    if (drones.Length == 0)
    {
        Console.WriteLine("Список дронов пуст.");
        return -1;
    }

    Console.Write($"Выберите номер дрона (от 1 до {drones.Length}): ");
    if (!int.TryParse(Console.ReadLine(), out int number) || number < 1 || number > drones.Length)
    {
        Console.WriteLine("Ошибка: некорректный номер дрона.");
        return -1;
    }
    return number - 1;
}
