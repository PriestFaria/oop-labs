using Itmo.ObjectOrientedProgramming.Lab1;
using Itmo.ObjectOrientedProgramming.Lab1.Segment;
using Xunit;
using DefaultSegment = Itmo.ObjectOrientedProgramming.Lab1.Segment.DefaultSegment;

namespace Lab1.Tests;

public class RouteTest
{
    [Fact]
    public void FirstTest()
    {
        var train = new Train(30, 15000, 3);
        var segments = new List<ISegment>([new PowerSegment(1200, 300), new DefaultSegment(1200)]);
        var route = new Route(segments, 120);
        route.Simulate(train);
        Assert.True(route.Success);
    }

    [Fact]
    public void SecondTest()
    {
        var train = new Train(30, 1500, 3);
        var segments = new List<ISegment>([new PowerSegment(1200, 300),
            new DefaultSegment(1200)]);
        var route = new Route(segments, 119);
        route.Simulate(train);
        Assert.False(route.Success);
    }

    [Fact]
    public void ThirdTest()
    {
        var train = new Train(30, 1500, 3);
        var segments = new List<ISegment>([new PowerSegment(1200, 300),
            new DefaultSegment(141),
            new Station(431, 120),
            new DefaultSegment(330)]);
        var route = new Route(segments, 120);
        route.Simulate(train);
        Assert.True(route.Success);
    }

    [Fact]
    public void FourthTest()
    {
        var train = new Train(30, 1500, 3);
        var segments = new List<ISegment>([new PowerSegment(1200, 300),
            new DefaultSegment(141),
            new Station(431, 10),
            new DefaultSegment(330)]);
        var route = new Route(segments, 1999000);
        route.Simulate(train);
        Assert.False(route.Success);
    }

    [Fact]
    public void FifthTest()
    {
        var train = new Train(30, 1500, 3);
        var segments = new List<ISegment>([new PowerSegment(1200, 300),
            new Station(431, 1200),
            new DefaultSegment(330)]);
        var route = new Route(segments, 119);
        route.Simulate(train);
        Assert.False(route.Success);
    }

    [Fact]
    public void SixthTest()
    {
        var train = new Train(30, 1500, 3);
        var segments = new List<ISegment>([new PowerSegment(1200, 300),
            new DefaultSegment(4000),
            new PowerSegment(-200, 300),
            new Station(431, 100),
            new DefaultSegment(330),
            new PowerSegment(1200, 300),
            new DefaultSegment(14321),
            new PowerSegment(-1000, 300),
        ]);
        var route = new Route(segments, 120);
        route.Simulate(train);
        Assert.True(route.Success);
    }

    [Fact]
    public void SeventhTest()
    {
        var train = new Train(30, 1500, 3);
        var segments = new List<ISegment>([
            new DefaultSegment(4000),
        ]);
        var route = new Route(segments, 120);
        route.Simulate(train);
        Assert.False(route.Success);
    }

    [Fact]
    public void EighthTest()
    {
        var train = new Train(30, 4000, 1);
        var segments = new List<ISegment>([new PowerSegment(30, 100),
            new PowerSegment(-60, 100)]);
        var route = new Route(segments, 10000);
        route.Simulate(train);
        Assert.False(route.Success);
    }
}