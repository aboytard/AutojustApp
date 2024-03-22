namespace SharedLibrary
{
    public class Worker
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public List<int> Locations { get; set; }

        public int Ranking { get; set; }

        public delegate void AnswerReceivedDelegate();
        public AnswerReceivedDelegate OnAnswerReceived;
    }
}
