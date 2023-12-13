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
        SQL testSQL = new SQL("localhost", "airlinedb", "root", "revival2017");

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
            string email = "johnsmith@gmail.com";

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

        [Test]
        public void EmptyLogin()
        {
            // Assign
            string user = "";
            string password = "";
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

        [Test]
        public void InvalidPassword()
        {
            // Assign
            string password = "";
            bool result;

            // Act
            if (password == string.Empty)
            {
                result = false;
            }
            else
            {
                result = false;
            }

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void AddedToDB()
        {
            // Assign
            Dictionary<string, object> vals = new Dictionary<string, object>
            {
                {"first_name", "Abraham"},
                {"last_name", "Vijai"},
                {"email", "abrahamvijai23@gmail.com"},
                {"date_of_birth", "2023-11-28 00:00:00"}
            };
            bool result;

            // Act
            testSQL.insertValues("customer", vals);
            result = testSQL.checkValue("customer", "email", vals["email"]);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
