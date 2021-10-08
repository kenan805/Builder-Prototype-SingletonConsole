using System;

namespace Builder_Prototype_SingletonConsole
{
    class Car
    {
        public int Seats { get; set; }
        public double Engine { get; set; }
        public bool HasTripComputer { get; set; }
        public bool HasGPS { get; set; }

        public override string ToString() => @$"
        Car seats: {Seats}
        Car engine: {Engine}
        Car trip computer: {HasTripComputer}
        Car GPS: {HasGPS}";
    }

    interface IBuilder
    {
        public Car Car { get; set; }

        IBuilder Reset();

        IBuilder SetSeats(int seats);
        IBuilder SetEngine(double engine);
        IBuilder SetTripComputer(bool hasTripComputer);
        IBuilder SetGPS(bool hasGPS);

        Car GetResult();
    }

    class CarAutomaticBuilder : IBuilder
    {
        public Car Car { get; set; } = new Car();

        public Car GetResult() => Car;

        public IBuilder Reset()
        {
            Car = new Car();
            return this;
        }

        public IBuilder SetEngine(double engine)
        {
            Car.Engine = engine;
            return this;
        }

        public IBuilder SetGPS(bool hasGPS)
        {
            Car.HasGPS = hasGPS;
            return this;
        }

        public IBuilder SetSeats(int seats)
        {
            Car.Seats = seats;
            return this;
        }

        public IBuilder SetTripComputer(bool hasTripComputer)
        {
            Car.HasTripComputer = hasTripComputer;
            return this;
        }
    }

    class CarManualBuilder : IBuilder
    {
        public Car Car { get; set; } = new Car();

        public Car GetResult() => Car;

        public IBuilder Reset()
        {
            Car = new Car();
            return this;
        }

        public IBuilder SetEngine(double engine)
        {
            Car.Engine = engine;
            return this;
        }

        public IBuilder SetGPS(bool hasGPS)
        {
            Car.HasGPS = hasGPS;
            return this;
        }

        public IBuilder SetSeats(int seats)
        {
            Car.Seats = seats;
            return this;
        }

        public IBuilder SetTripComputer(bool hasTripComputer)
        {
            Car.HasTripComputer = hasTripComputer;
            return this;
        }
    }

    class Master
    {
        private IBuilder _builder;

        public Master(IBuilder builder)
        {
            _builder = builder;
        }

        public Car Make(string type)
        {
            _builder.Reset();

            if (type == "SUV")
            {
                Console.WriteLine($"Car type: {type}");
                return _builder
                .SetSeats(4)
                .SetEngine(4.8)
                .SetTripComputer(false)
                .SetGPS(true).GetResult();
            }
            else if (type == "Sport")
            {
                Console.WriteLine($"Car type: {type}");
                return _builder
                .SetSeats(2)
                .SetEngine(3.0)
                .SetTripComputer(true)
                .SetGPS(true).GetResult();
            }

            throw new Exception("Wrong Type");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IBuilder builder = new CarAutomaticBuilder();

                Master master = new Master(builder);

                Car car = master.Make("Sport"); // or SUV

                Console.WriteLine(car);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
