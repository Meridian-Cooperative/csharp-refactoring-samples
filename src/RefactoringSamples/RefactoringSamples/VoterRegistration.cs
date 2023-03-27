namespace RefactoringSamples
{
    public class VoterRegistrationService
    {
        // make this class testable
        public bool RegisterForVote(Person person)
        {
            if (person.CanVote())
            {
                VoterRegistryRepository.AddToRegistry(person);
                return true;
            }
            return false;
        }
    }

    // cannot change this class as its used widely in system
    public static class VoterRegistryRepository
    {
        static List<Person> _listOfVoters = new List<Person>();

        public static void AddToRegistry(Person p)
        {
            _listOfVoters.Add(p);
        }
    }
}
