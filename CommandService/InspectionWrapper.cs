using SharedLibrary;

namespace CommandService
{
    public class InspectionWrapper
    {
        private Dictionary<Inspection, Worker> Inspection { get; set; }

        public InspectionWrapper() { }

        public void ReceiveInspectionOrder()
        {
            throw new NotImplementedException();
        }
    }
}
