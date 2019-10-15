namespace Aircompany.Planes
{
    using Aircompany.Models;

    public class MilitaryPlane : Plane
    {
        private readonly MilitaryType type;

        public MilitaryPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, MilitaryType type)
            : base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            this.type = type;
        }

        public MilitaryType GetMilitaryPlaneType()
        {
            return this.type;
        }

        public override string ToString()
        {
            return base.ToString().Replace("}", ", type=" + type + '}');
        }
    }
}
