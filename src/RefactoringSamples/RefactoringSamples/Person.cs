namespace RefactoringSamples
{
    public  class Person
    {
        public String Name { get; set; } = String.Empty;
        public DateTime DateOfBirth { get; set; }

        public bool CanVote()
        {
            int age = DateTime.Now.Year - DateOfBirth.Year;

            if(DateTime.Now.Month < DateOfBirth.Month || 
                (DateTime.Now.Month == DateOfBirth.Month && DateTime.Now.Day < DateOfBirth.Day))
            {
                age--;
            }

            return age >= 21;
        }

    }
}
