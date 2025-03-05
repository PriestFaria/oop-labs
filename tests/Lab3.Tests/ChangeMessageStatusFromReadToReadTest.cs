using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Priorities;
using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab3.Users;
using Xunit;

namespace Lab3.Tests;

public class ChangeMessageStatusFromReadToReadTest
{
    [Fact]
    public void ReceiveMessageAndMarkReadMessageAsRead()
    {
        // arrange
        var user = new User("Aboba");
        var message = new Message("body", "message", Priority.Low);

        // act
        user.Receive(message);
        user.ReadMessage(message);
        ChangeMessageStatusResult result = user.ReadMessage(message);

        // assert
        Assert.True(result is ChangeMessageStatusResult.AlreadyRead);
    }
}