namespace SharedLibrary
{
    public static class MockData
    {
        public static IEnumerable<Professional> MockProfessional()
        {
            var professionals = new List<Professional>()
            {
                new Professional()
                    {
                        Name = "Alban",
                        PhoneNumber = "numberOfAlban",
                        Departements = {92},
                        Ranking = 1
                    },
                new Professional()
                    {
                        Name = "Kane",
                        PhoneNumber = "numberOfKane",
                        Departements = {78},
                        Ranking = 2
                    },
                new Professional()
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
