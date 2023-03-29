using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringSamples
{
    public class ElectionsRepository
    {
        readonly String _connectionString = "DATA SOURCE=10.1.1.1:1521/voterdb;User Id=user1;Password=pwd1;Pooling=True;Connection Timeout=1";

        public int RecordVote(int electionId, string candidateName)
        {
            using (OracleConnection conn = new OracleConnection(_connectionString))
            {
                conn.Open();

                OracleCommand insertCommand = conn.CreateCommand();
                insertCommand.CommandText = $"update election_votes set vote_count = vote_count+1 where id = {electionId} and candidate_name =  '{candidateName}'";
                return insertCommand.ExecuteNonQuery();
            }
        }

    }
}
