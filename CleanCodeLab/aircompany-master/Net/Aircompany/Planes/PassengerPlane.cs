namespace Aircompany.Planes
{
    public class PassengerPlane : Plane
    {
        private readonly int passengersCapacity;

        public PassengerPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, int passengersCapacity)
            : base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            this.passengersCapacity = passengersCapacity;
        }

        public int GetPassengersCapacity()
        {
            return this.passengersCapacity;
        }

        public override string ToString()
        {
            return base.ToString().Replace("}", ", passengersCapacity=" + passengersCapacity + '}');
        }
    }
}
