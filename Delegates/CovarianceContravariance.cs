using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class CovarianceContravariance
    {
        public abstract class Car
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public virtual string GetCarDetails()
            {
                return $"{Id} - {Name}";
            }
        }

        public class ICECar : Car
        {
            public override string GetCarDetails()
            {
                return $"{base.GetCarDetails()} - Internal Combustion Engine";
            }
        }

        public class EVCar : Car
        {
            public override string GetCarDetails()
            {
                return $"{base.GetCarDetails()} - Eletric";
            }
        }

        public static class CarFactory
        {
            public static ICECar ReturnICECar(int id, string name)
            {
                return new ICECar { Id = id, Name = name };
            }
            public static EVCar ReturnEVCar(int id, string name)
            {
                return new EVCar { Id = id, Name = name };
            }
        }

        static void LogCarDetails(Car car)
        {
            if (car is ICECar)
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ICEDetails.txt"), true))
                {
                    sw.WriteLine($"Object Type: {car.GetType()}");
                    sw.WriteLine($"Car Detials: {car.GetCarDetails()}");
                };

            }
            else if (car is EVCar)
            {
                Console.WriteLine($"Object Type: {car.GetType()}");
                Console.WriteLine($"Car Detials: {car.GetCarDetails()}");
            }
            else
            {
                throw new ArgumentException();
            }
        }

        delegate Car CarFactoryDel(int id, string name);
        delegate void LogICECarDetailsDel(ICECar car);
        delegate void LogEVCarDetailsDel(EVCar car);

        public CovarianceContravariance()
        {
            CarFactoryDel carFactoryDel = CarFactory.ReturnICECar;

            Car iceCar = carFactoryDel(1, "Fusca Azul");

            Console.WriteLine($"Tipo: {iceCar.GetType()}");
            Console.WriteLine($"Car details: {iceCar.GetCarDetails()}");

            carFactoryDel = CarFactory.ReturnEVCar;

            var evCar = carFactoryDel(2, "Kombi Branca");

            LogICECarDetailsDel logICECarDetailsDel = LogCarDetails;

            logICECarDetailsDel(iceCar as ICECar);

            LogEVCarDetailsDel logEVCarDetailsDel = LogCarDetails;

            logEVCarDetailsDel(evCar as EVCar);
        }
    }
}
