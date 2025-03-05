using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Priorities;
using Lab3.Tests.Mocks;
using Xunit;

namespace Lab3.Tests;

public class SendByMessengerTest
{
    [Fact]
    public void SendMessageByMessenger()
    {
        // arrange
        var messenger = new MessengerMock();
        var message = new Message("body", "name", Priority.Low);

        // act
        messenger.Receive(message);
        messenger.Show();

        // assert
        Assert.Equal(messenger.MessageShowed, "Мессенджер: " + message.Body);
    }
}