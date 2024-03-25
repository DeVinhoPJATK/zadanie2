using LegacyApp;

namespace LegacyAppTests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_Should_Return_False_When_Missing_FirstName()
    {
        //Arrange
        var service = new UserService();
        
        //Act
        var res = service.AddUser(null, null, "kowalski@wp.pl", new DateTime(1980, 1, 1), 1);
        
        //Assert
        Assert.False(res);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_Email_Has_Wrong_Format()
    {
        //Arrange
        var service = new UserService();
        
        //Act
        var res = service.AddUser("John", "Smith", "kowalskiwpl", new DateTime(1980, 1, 1), 1);
        
        //Assert
        Assert.False(res);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_Age_Below_21()
    {
        //Arrange
        var service = new UserService();
        
        //Act
        var res = service.AddUser("John", "Smith", "kowalski@wp.pl", new DateTime(2010, 1, 1), 1);
        
        //Assert
        Assert.False(res);
    }

    [Fact]
    public void AddUser_Should_Throw_Exception_When_ClientId_NotExists()
    {
        //Arrange
        var service = new UserService();

        //Act & Assert
        Assert.Throws<ArgumentException>(() =>
            service.AddUser("John", "Smith", "kowalski@wp.pl", new DateTime(1998, 12, 9), 978));
    }
}