using ARS;
using NUnit.Framework;

namespace UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            // Setup code if needed
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
            SQL testSQL = new SQL("localhost", "airlinedb", "root", "revival2017");

            // Act
            bool result = testSQL.checkValue("customer", "first_name", user);

            // Assert
            Assert.IsTrue(!result);
        }

        [Test]
        public void ValidLogin()
        {
            // Assign
            string user = "Abraham";
            string password = "hello1234";
            SQL testSQL = new SQL("localhost", "airlinedb", "root", "revival2017");
            bool result;
            
            // Act
            if(Validator.IsValidUserName(user) && password != string.Empty) 
            {
                result = true;
            }
            else
            {
                result = false;
            }
 
            // Assert
            Assert.IsTrue(result);
        }


        [Test]
        public void InvalidLogin()
        {
            // Assign
            string user = "Nobody";
            string password = "";
            SQL testSQL = new SQL("localhost", "airlinedb", "root", "revival2017");
            bool result;

            // Act
            if (Validator.IsValidUserName(user) && password != string.Empty)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            // Assert
            Assert.IsFalse(result);
        }


    }
}
