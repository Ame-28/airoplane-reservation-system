using ARS;

namespace UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void ValidateUserName()
        {
            // Assign 
            string userName = "Abraham";
            
            // Act
            bool result = Validator.IsValidUserName(userName);

            // Assert
            Assert.IsTrue(result);

        }

        [Test]
        public void ValidateEmail()
        {
            // Assign 
            string email = "joasdm@gmail.com";
            
            // Act
            bool result = Validator.IsValidEmail(email);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void UserInDatabase()
        {
            // Assign
            string user = "Abraham";
            SQL testSQL = new SQL("localhost","airlinedb", "root", "revival2017");

            // Act
            bool result = testSQL.checkValue("customer", "first_name", user);

            // Assert
            Assert.IsTrue(!result);
        }

        [Test]
        public void 
    }
}