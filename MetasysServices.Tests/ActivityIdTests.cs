using NUnit.Framework;
using System;

namespace JohnsonControls.Metasys.BasicServices;

[TestFixture]
public class ActivityIdTests
{
    // Mainly just making sure we never get a Null exception due to the default constructor
    // This was really addressed by the fact that I switched ActivityId to be a record,
    // changed the language in csproj to 12 and provided a default constructor that ensures
    // we default to empty string
    [Test]
    public void DefaultInstanceNeverThrows()
    {
        // Arrange
        var id = new ActivityId();

        // Assertions
        Assert.That(id.ToString(), Is.EqualTo(""));
        Assert.That((string)id, Is.EqualTo(""));
        Assert.That(id == "", Is.True);
        Assert.That(id.GetHashCode(), Is.EqualTo(id.ToString().GetHashCode()));
    }


    // Basically make sure conversions to/from string are correct
    [TestCase("")]
    [TestCase("54efad4c-0fb7-59b4-9b6f-e385fd7e5b9e")]
    [TestCase("Happy Data 😃")]
    public void StringConversions(string inputString)
    {
        // Act
        ActivityId activityId = inputString;

        // Assert
        Assert.That(activityId, Is.EqualTo(inputString));
        Assert.That(activityId, Is.EqualTo(new ActivityId(inputString)));
        Assert.That(inputString, Is.EqualTo(activityId));
        Assert.That(inputString, Is.EqualTo(activityId.ToString()));
        Assert.That(activityId == inputString, Is.True);
        Assert.That(activityId != inputString, Is.False);
        Assert.That(activityId != "78f5c3ca-46e1-5f93-b06e-5711677bf933", Is.True);
    }

    [TestCase("54efad4c-0fb7-59b4-9b6f-e385fd7e5b9e")]
    public void GuidConversions(string inputString)
    {
        // Act
        var guid = new Guid(inputString);
        ActivityId activityId = guid;

        // Assert
        Assert.That(activityId, Is.EqualTo(guid));
        Assert.That(activityId, Is.EqualTo(new ActivityId(inputString)));
        Assert.That(guid, Is.EqualTo(activityId));
    }
}
