using Itmo.ObjectOrientedProgramming.Lab3.Adressees;
using Itmo.ObjectOrientedProgramming.Lab3.Filters;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Priorities;
using Itmo.ObjectOrientedProgramming.Lab3.Users;
using Xunit;

namespace Lab3.Tests;

public class AdresseeUserFilterTest
{
    [Fact]
    public void MessageSentBelowImportanceLevel_ShouldBeReceivedOnce()
    {
        // arrange
        var user = new User("aboba");
        var message = new Message("body", "name", Priority.Low);
        var adresseeUserWithFilter = new Filter(new AdresseeUser(user), new List<Priority>((int)Priority.High));
        var adreseeUserWithNoFilter = new AdresseeUser(user);

        // act
        adresseeUserWithFilter.Receive(message);
        adreseeUserWithNoFilter.Receive(message);

        adreseeUserWithNoFilter.Send();
        adresseeUserWithFilter.Send();

        // assert
        Assert.Single(user.UnreadMessages);
    }
}