namespace SharedLibrary
{
    public class Inspection
    {
        public Inspection()
        {
        }

        public VehicleType VehicleType { get; set; }

        public int Department { get; set; }
        public int OrderNumber { get; set; }

        public Professional Professional { get; set; }

        public void AssignInspectionToProfessional(Professional professional)
        {
            this.Professional = professional;
            this.OrderNumber = 1; // TODO : Should assign a random number
        }

    }

    public enum VehicleType
    {
        None,
        Car
    }
}
