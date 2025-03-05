using Itmo.ObjectOrientedProgramming.Lab3.Adressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Priorities;
using Itmo.ObjectOrientedProgramming.Lab3.Users;
using Lab3.Tests.Mocks;
using Xunit;

namespace Lab3.Tests;

public class AdresseeLoggingTest
{
    [Fact]
    public void ShouldLogMessageWhenMessageIsReceived()
    {
        // arrange
        var user = new User("Aboba");
        var message = new Message("body", "message", Priority.Low);
        var adresseeLogger = new LoggerMock(new AdresseeUser(user));
        const string expectedLogString =
            $"Received:\n\tBody:body\nName:message\nPriority:Low\n\tWith result: Success";

        // act
        adresseeLogger.Receive(message);

        // assert
        Assert.Equal(expectedLogString, adresseeLogger.LoggedMessage);
    }
}