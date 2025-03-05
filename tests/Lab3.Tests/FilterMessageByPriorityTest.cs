using Itmo.ObjectOrientedProgramming.Lab3.Adressees;
using Itmo.ObjectOrientedProgramming.Lab3.Filters;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Priorities;
using Lab3.Tests.Mocks;
using Xunit;

namespace Lab3.Tests;

public class FilterMessageByPriorityTest
{
    [Fact]
    public void ReceiveMessageWithPriorityWhichNotAcceptedByFilter()
    {
        // arrange
        var user = new UserMock("Aboba");
        var message = new Message("body", "message", Priority.Low);
        var adressee = new Filter(new AdresseeUser(user), new List<Priority>((int)Priority.High));

        // act
        adressee.Receive(message);
        adressee.Send();

        // assert
        Assert.Null(user.Message);
    }
}