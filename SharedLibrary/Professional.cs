namespace SharedLibrary
{
    public class Professional
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public List<int> Departements { get; set; }

        public int Ranking { get; set; }

        public delegate void AnswerReceivedDelegate();
        public AnswerReceivedDelegate OnAnswerReceived;
    }
}
