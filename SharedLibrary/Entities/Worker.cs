namespace SharedLibrary.Entities
{
    public class Worker
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public int Location { get; set; }

        public int Ranking { get; set; }

        public delegate void AnswerReceivedDelegate();
        public AnswerReceivedDelegate OnAnswerReceived;
    }
}
