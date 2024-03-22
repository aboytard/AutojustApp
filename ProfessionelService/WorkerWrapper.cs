using SharedLibrary;

namespace ProfessionalService
{
    public class WorkerWrapper
    {
        public WorkerWrapper() { }

        public IEnumerable<Worker> GetProfessionals()
        {
            var professionals = MockData.MockProfessional();
            return professionals; 
        }
        
        public IEnumerable<Worker> SelectPossibleProfessionals(int department)
        {
            var professionals = GetProfessionals();
            return professionals
                .Where(professional => professional.Departements.Contains(department))
                .OrderBy(pro => pro.Ranking);

        }

        public async Task SendMessageToProfessional(Inspection inspection, IEnumerable<Worker> professionals)
        {
            Console.WriteLine("SendMessageToProfessional");
            foreach(Worker professional in professionals)
            {
                var professionalProfessor = new WorkerProcessor(professional);
                await professionalProfessor.HandleDemand(inspection);
            }
        }


        // TODO : Refactor with a void

        // Il devrait y avoir un service entre les deux Professionel-Inspection
        public void AssignInspectionToProfessional(Worker professional)
        {
            // should be inside the command service
            var inspectionAssigned = new Inspection();
            inspectionAssigned.Professional = professional;
        }


    }
}
