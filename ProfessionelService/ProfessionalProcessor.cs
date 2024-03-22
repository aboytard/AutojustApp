using SharedLibrary;

namespace ProfessionalService
{
    // ATTENTION : Possibilite qu un professionel doivent repondre a plusieurs demandes en meme temps
    // il y aurait des soucis
    public class ProfessionalProcessor
    {

        private Professional professional;
        public ProfessionalProcessor(Professional professional) 
        {
            this.professional = professional;

            professional.OnAnswerReceived += OnAnswerReceivedHandler;
        }

        public async Task HandleDemand(Inspection inspection)
        {
            // send message to 
            await SendMessageToProfessional(inspection);
            await WaitForProfessionalAnswer(inspection, professional);
        }



        private TaskCompletionSource professionalCommand;
        protected CancellationTokenSource professionalCommandCancellationToken;
        private int waitForProfessionalAnswerTimeout = 20 * 60 * 1000; // 20 min
        public async Task WaitForProfessionalAnswer(Inspection inspection, Professional professional)
        {
            professionalCommandCancellationToken = new CancellationTokenSource(waitForProfessionalAnswerTimeout);
            professionalCommand = new TaskCompletionSource();
            try
            {
                await Task.Run(async () =>
                {
                    await professionalCommand.Task;
                    Console.WriteLine("WaitForProfessional task completed");
                    inspection.AssignInspectionToProfessional(professional);
                    return true;
                }, professionalCommandCancellationToken.Token);
            }
            catch (OperationCanceledException)
            {
                // Operation Cancelled --> dispose 
            }
        }

        public async Task SendMessageToProfessional(Inspection inspection)
        {
            Console.WriteLine("SendMessageToProfessional");
            //throw new NotImplementedException();
        }

        public async void OnAnswerReceivedHandler()
        {
            Console.WriteLine("ReceiveMessageFromProfessional");
            professionalCommand.TrySetResult();
        }
    }
}
