using SharedLibrary.Enum;

namespace SharedLibrary
{
    public class Inspection
    {
        public Inspection()
        {
        }

        public VehicleType VehicleType { get; set; }

        public int Location { get; set; }
        public int OrderNumber { get; set; }

        public Worker Worker { get; set; }

        public void AssignInspectionToProfessional(Worker worker)
        {
            this.Worker = worker;
            this.OrderNumber = 1; // TODO : Should assign a random number
        }

    }

}
