namespace DroneControlSystem;

public class Mission
{
    public string Name { get; set; }
    public Drone AssignedDrone { get; set; }
    public double TargetAltitude { get; set; }

    public Mission(string name, Drone drone, double targetAltitude)
    {
        Name = name;
        AssignedDrone = drone;
        TargetAltitude = targetAltitude;
    }

    public void Start()
    {
        Console.WriteLine($"Миссия «{Name}» начата. Целевая высота: {TargetAltitude} м.");
        AssignedDrone.TakeOff();
        if (AssignedDrone.Altitude < TargetAltitude)
        {
            Console.WriteLine("Дрон не достиг целевой высоты.");
        }
        else
        {
            Console.WriteLine("Целевая высота достигнута.");
        }
    }
}
