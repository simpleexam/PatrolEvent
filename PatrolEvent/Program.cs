namespace PatrolEvent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Patrol patrol = new Patrol();

            patrol.AddCarsToPatrol(
                new Car("562HGJH"),
                new Car("54 JHL")
                );

            for(int i=0; i< 10; i++)
            {
                patrol.Cars[0].Acceleration(i+5);
                patrol.Cars[1].Acceleration(i+10);
            }
        }
    }
}
