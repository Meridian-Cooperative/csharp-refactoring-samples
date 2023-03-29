using Oracle.ManagedDataAccess.Client;

namespace RefactoringSamples
{
    // make this class testable
    public class VoterRegistrationService
    {
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
        static readonly String _connectionString = "DATA SOURCE=10.1.1.1:1521/voterdb;User Id=user1;Password=pwd1;Pooling=True;Connection Timeout=1";
        public static void AddToRegistry(Person p)
        {
            using (OracleConnection conn = new OracleConnection(_connectionString))
            {
                conn.Open();

                OracleCommand insertCommand = conn.CreateCommand();
                insertCommand.CommandText = $"insert into voters values ('{p.Name}')";
                insertCommand.ExecuteNonQuery();
            }
        }

        public static bool IsRegistered(Person p)
        {
            using (OracleConnection conn = new OracleConnection(_connectionString))
            {
                conn.Open();

                OracleCommand selectCommand = conn.CreateCommand();
                selectCommand.CommandText = "select count(1) from voters where name = '{p.Name}'";
                int count = (int) selectCommand.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
