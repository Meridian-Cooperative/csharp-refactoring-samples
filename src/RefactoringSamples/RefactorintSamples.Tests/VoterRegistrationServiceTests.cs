using System;
using FluentAssertions;
using RefactoringSamples;
using Xunit;

namespace RefactorintSamples.Tests
{
    public class VoterRegistrationServiceTests
    {
        [Fact]
        public void Person_Over_21_Can_Register_Successfully()
        {
            Person adult = new()
            {
                Name = "John Oliver",
                DateOfBirth = new DateTime(2000, 1, 1)
            };
            VoterRegistrationService registrationService = new VoterRegistrationService();

            var actual = registrationService.RegisterForVote(adult);

            actual.Should().BeTrue();
        }

        [Fact]
        public void Person_Under_21_Cannot_Register_Successfully()
        {
            Person underAgePerson = new()
            {
                Name = "John Stewart",
                DateOfBirth = new DateTime(2022, 1, 1)
            };
            VoterRegistrationService registrationService = new VoterRegistrationService();

            var actual = registrationService.RegisterForVote(underAgePerson);

            actual.Should().BeFalse();
        }

    }
}
