using SharedLibrary.Enum;

namespace SharedLibrary.Entities
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
            Worker = worker;
            OrderNumber = 1; // TODO : Should assign a random number
        }

    }

}
