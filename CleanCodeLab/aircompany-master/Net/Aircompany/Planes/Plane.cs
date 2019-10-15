namespace Aircompany.Planes
{
    public abstract class Plane
    {
        private readonly string model;
        private readonly int maxSpeed;
        private readonly int maxFlightDistance;
        private readonly int maxLoadCapacity;

        public Plane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity)
        {
            this.model = model;
            this.maxSpeed = maxSpeed;
            this.maxFlightDistance = maxFlightDistance;
            this.maxLoadCapacity = maxLoadCapacity;
        }

        public string GetModel()
        {
            return model;
        }

        public int GetMAXSpeed()
        {
            return maxSpeed;
        }

        public int GetMAXFlightDistance()
        {
            return maxFlightDistance;
        }

        public int GetMAXLoadCapacity()
        {
            return maxLoadCapacity;
        }

        public override string ToString()
        {
            return "Plane{ model='" + model + "', maxSpeed=" + maxSpeed + ", maxFlightDistance=" + maxFlightDistance + ", maxLoadCapacity=" + maxLoadCapacity + '}';
        }
    }
}
