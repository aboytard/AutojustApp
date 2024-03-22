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
                        Locations = {92},
                        Ranking = 1
                    },
                new Worker()
                    {
                        Name = "Kane",
                        PhoneNumber = "numberOfKane",
                        Locations = {78},
                        Ranking = 2
                    },
                new Worker()
                    {
                        Name = "Greg",
                        PhoneNumber = "numberOfGreg",
                        Locations = {78,94,92},
                        Ranking = 3
                    }
            };
            return professionals;
        }
    }
}
