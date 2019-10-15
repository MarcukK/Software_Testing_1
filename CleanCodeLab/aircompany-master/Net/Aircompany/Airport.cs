namespace Aircompany
{
    using System.Collections.Generic;
    using System.Linq;
    using Aircompany.Models;
    using Aircompany.Planes;

    public class Airport
    {
        private readonly List<Plane> planes;

        public Airport(IEnumerable<Plane> planes)
        {
            this.planes = planes.ToList();
        }

        public List<PassengerPlane> GetPassengersPlanes()
        {
            List<PassengerPlane> passengerPlanes = new List<PassengerPlane>();
            foreach (Plane p in planes.Where(p => p.GetType() == typeof(PassengerPlane)).Select(p => p))
            {
                passengerPlanes.Add((PassengerPlane)p);
            }

            return passengerPlanes;
        }

        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            List<MilitaryPlane> militaryPlanes = new List<MilitaryPlane>();
            foreach (Plane p in planes.Where(p => p.GetType() == typeof(MilitaryPlane)).Select(p => p))
            {
                militaryPlanes.Add((MilitaryPlane)p);
            }

            return militaryPlanes;
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            return GetPassengersPlanes().OrderByDescending(item => item.GetPassengersCapacity()).First();
        }

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            return GetMilitaryPlanes().FindAll(p => p.GetMilitaryPlaneType().Equals(MilitaryType.TRANSPORT));
        }

        public Airport SortByMaxDistance()
        {
            return new Airport(planes.OrderBy(w => w.GetMAXFlightDistance()));
        }

        public Airport SortByMaxSpeed()
        {
            return new Airport(planes.OrderBy(w => w.GetMAXSpeed()));
        }

        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(planes.OrderBy(w => w.GetMAXLoadCapacity()));
        }

        public IEnumerable<Plane> GetPlanes()
        {
            return planes;
        }

        public override string ToString()
        {
            return "Airport{ planes=" + string.Join(", ", planes.Select(x => x.GetModel())) + '}';
        }
    }
}
