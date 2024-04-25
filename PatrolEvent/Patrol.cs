using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolEvent
{
    internal class Patrol
    {
        public List<Car> Cars { get; set; } //наблюдаемые автомобили

        public Patrol()
        {
            Cars = new List<Car>();
        }
        /// <summary>
        /// добавление автомобилей для наблюдения с подпиской на событие
        /// </summary>
        /// <param name="cars"></param>
        public void AddCarsToPatrol(params Car[] cars)
        {
            foreach (var car in cars)
            {
                Cars.Add(car);
                car.SpeedLimitEvent += CarSpeedLimitCheck; //подписка на событие
            }
        }

        /// <summary>
        /// метод-реакция на событие превышения скорости
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void CarSpeedLimitCheck(object source, EventArgs e)
        {
            if(source is Car && e is SpeedEvenArgs)
            {
                Car car = (Car)source;
                SpeedEvenArgs carSpeed = (SpeedEvenArgs)e;

                
                if(carSpeed.Speed >= 80 && carSpeed.Speed < 120)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"скорость автомобиля {car.GosNomer}: {car.Speed}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (carSpeed.Speed >= 120)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"скорость автомобиля {car.GosNomer}: {car.Speed}");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
            
        }
    }
}
