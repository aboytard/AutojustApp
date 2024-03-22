using SharedLibrary;

namespace ProfessionalService
{
    public class ProfessionalWrapper
    {
        public ProfessionalWrapper() { }

        public IEnumerable<Professional> GetProfessionals()
        {
            var professionals = MockData.MockProfessional();
            return professionals; 
        }
        
        public IEnumerable<Professional> SelectPossibleProfessionals(int department)
        {
            var professionals = GetProfessionals();
            return professionals
                .Where(professional => professional.Departements.Contains(department))
                .OrderBy(pro => pro.Ranking);

        }

        public async Task SendMessageToProfessional(Inspection inspection, IEnumerable<Professional> professionals)
        {
            Console.WriteLine("SendMessageToProfessional");
            foreach(Professional professional in professionals)
            {
                var professionalProfessor = new ProfessionalProcessor(professional);
                await professionalProfessor.HandleDemand(inspection);
            }
        }


        // TODO : Refactor with a void

        // Il devrait y avoir un service entre les deux Professionel-Inspection
        public void AssignInspectionToProfessional(Professional professional)
        {
            // should be inside the command service
            var inspectionAssigned = new Inspection();
            inspectionAssigned.Professional = professional;
        }


    }
}
