using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Priorities;
using Itmo.ObjectOrientedProgramming.Lab3.Users;
using Xunit;

namespace Lab3.Tests;

public class ReceiveUnreadMessageTest
{
    [Fact]
    public void ReceiveMessageAsUnread()
    {
        // arrange
        var user = new User("Aboba");
        var message = new Message("body", "message", Priority.Low);

        // act
        user.Receive(message);

        // assert
        Assert.Equal(user.UnreadMessages.First(), message);
    }
}