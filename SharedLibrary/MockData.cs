namespace SharedLibrary
{
    public static class MockData
    {
        public static IEnumerable<Worker> MockProfessional()
        {
            var professionals = new List<Worker>()
            {
                new Worker()
                    {
                        Name = "Alban",
                        PhoneNumber = "numberOfAlban",
                        Departements = {92},
                        Ranking = 1
                    },
                new Worker()
                    {
                        Name = "Kane",
                        PhoneNumber = "numberOfKane",
                        Departements = {78},
                        Ranking = 2
                    },
                new Worker()
                    {
                        Name = "Greg",
                        PhoneNumber = "numberOfGreg",
                        Departements = {78,94,92},
                        Ranking = 3
                    }
            };
            return professionals;
        }
    }
}
