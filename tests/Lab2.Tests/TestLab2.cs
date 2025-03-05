using Itmo.ObjectOrientedProgramming.Lab2.Labs;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects.Credit;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Xunit;

namespace Lab2.Tests;

public class TestLab2
{
    [Fact]
    public void ChangeEntityWithNoPermission()
    {
        // arrange
        var userRepository = new UserRepository();
        var aboba = new User("Aboba");
        var boba = new User("boba");

        userRepository.Add(aboba);
        userRepository.Add(boba);

        var labBuilder = new LabBuilder();
        int labScores = 12;

        ILab lab1 = labBuilder
            .WithAuthor(aboba)
            .WithScores(labScores)
            .WithDescription("aboba lab description")
            .WithCriterias("some criterias")
            .WithName("OOP")
            .Build();

        // act
        EditLabResult result = lab1.SetCriterias(boba, "new criterias");

        // assert
        Assert.True(result is EditLabResult.UserHasNoPermission);
    }

    [Fact]
    public void CheckEntityIdBasedOnOtherEntity()
    {
        // arrange
        var userRepository = new UserRepository();

        var aboba = new User("Aboba");
        var boba = new User("boba");

        userRepository.Add(aboba);
        userRepository.Add(boba);
        var labBuilder = new LabBuilder();
        int firstLabScores = 12;

        ILab originLab = labBuilder
            .WithAuthor(aboba)
            .WithScores(firstLabScores)
            .WithDescription("aboba lab description")
            .WithCriterias("some criterias")
            .WithName("OOP")
            .Build();

        // act
        ILab labCreatedFromFirst = originLab.Clone();

        // assert
        Assert.Equal(labCreatedFromFirst.OriginLabId, originLab.Id);
    }

    [Fact]
    public void CheckIfScoresForSubjectAreNotEqualToHundred()
    {
        // arrange
        var aboba = new User("Aboba");
        var labBuilder = new LabBuilder();

        int scoresNotValidForSubject = 21;
        ILab labWithScoresNotValidToCounstructSujectFrom = labBuilder
            .WithAuthor(aboba)
            .WithScores(scoresNotValidForSubject)
            .WithDescription("aboba lab description")
            .WithCriterias("some criterias")
            .WithName("OOP")
            .Build();

        var subjectBuilderFactory = new CreditSubjectBuilder();

        // act and assert
        Assert.Throws<InvalidOperationException>(() => subjectBuilderFactory
            .WithAuthor(aboba)
            .WithName("oop")
            .WithLab(labWithScoresNotValidToCounstructSujectFrom)
            .Build());
    }
}