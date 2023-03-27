using System;
using FluentAssertions;
using RefactoringSamples;
using Xunit;


namespace RefactorintSamples.Tests
{
    public class PersonTests
    {
        // do not change sample data

        [Fact]
        public void When_DOB_Is_03032000_CanVote_Returns_True()
        {
            Person person = new Person()
            {
                Name = "First Person",
                DateOfBirth = new DateTime(2000, 3, 3)
            };
            
            person.CanVote().Should().BeTrue();
        }

        [Fact]
        public void When_DOB_Is_03282002_CanVote_Returns_False()
        {
            Person person = new Person()
            {
                Name = "First Person",
                DateOfBirth = new DateTime(2002, 3, 28) 
            };

            person.CanVote().Should().BeFalse();
        }
    }
}
