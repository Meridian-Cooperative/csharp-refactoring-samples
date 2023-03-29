namespace RefactoringSamples
{
    public class ElectionsService
    {
        private int _electionId;
        const string SIGNATURE_IMAGES_BASE_PATH = @"C:\signatures";

        public ElectionsService(int electionId)
        {
            _electionId = electionId;
        }

        // Consider this to be part of an imagniary application that helps conduct elections
        // This system supports voting by two methods In Person or By Mail
        // If voting by mail, the signature on the ballot is scanned and saved. You have to be pre-registered to vote by mail
        // If voting in person, if not already registered, voter will be registered.
        // With both options this class updates the record for the given candidate
        public bool RecordVote(Person voter, String candidate, VotingMethod methodOfVoting, byte[] signatureImage)
        {
            bool voteRecorded = false;
            ElectionsRepository electionsRepository = new ElectionsRepository();

            if (methodOfVoting == VotingMethod.ByMail)
            {
                if (VoterRegistryRepository.IsRegistered(voter))
                {
                    FileStream signatureStream = File.Create($"{SIGNATURE_IMAGES_BASE_PATH}\\{voter.Name}_signature.jpg");
                    signatureStream.Write(signatureImage, 0, signatureImage.Length);

                    voteRecorded = electionsRepository.RecordVote(_electionId, candidate) == 1;
                }
            }
            else if (methodOfVoting == VotingMethod.InPerson)
            {
                bool isRegisteredVoter = VoterRegistryRepository.IsRegistered(voter);
                if (!isRegisteredVoter)
                {
                    isRegisteredVoter = new VoterRegistrationService().RegisterForVote(voter);
                }

                if (isRegisteredVoter)
                {
                    voteRecorded = electionsRepository.RecordVote(_electionId, candidate) == 1;
                }
            }

            return voteRecorded;
        }
    }
}
