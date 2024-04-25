using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolEvent
{
    internal class Car
    {
        private static int _speedLimit = 80;
        private static int _unlegalSpeed = 120;

        public int Speed { get; set; }//текущая скорость
        public string GosNomer { get; set; }//гос номер автомобиля
        public Car(string number)
        {
            GosNomer = number;
            Speed = 0;
        }
        /// <summary>
        /// ускорение автомобиля
        /// </summary>
        /// <param name="addedSpeed"></param>
        public void Acceleration(int addedSpeed)
        {
            int prevSpeed = Speed;
            Speed += addedSpeed;
            Console.WriteLine($"{GosNomer} скорость: {Speed}");

            if (prevSpeed < _speedLimit && Speed >= _speedLimit)
                OnSpeedLimitEvent(new SpeedEvenArgs(Speed)); //генерируется событие при превышении 80
            else if (prevSpeed < _unlegalSpeed && Speed >=_unlegalSpeed)
                OnSpeedLimitEvent(new SpeedEvenArgs(Speed)); //генерируется событие при превышении 120
        }

        public event EventHandler SpeedLimitEvent; //событие
        public void OnSpeedLimitEvent(SpeedEvenArgs e) // метод запуска события
        {
            SpeedLimitEvent?.Invoke(this, e);
        }
    }

    /// <summary>
    /// аргумент события для передачи данных о скорости
    /// </summary>
    public class SpeedEvenArgs : EventArgs
    {
        public int Speed { get; set; }
        public SpeedEvenArgs(int speed) =>
            Speed = speed;
    }
}
