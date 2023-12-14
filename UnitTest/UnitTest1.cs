using ARS;
using NUnit.Framework;
using NUnit.Framework.Internal;

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
            if (password == string.Empty )
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
        public void CreatedLogger()
        {
            // Assign
            ARS.Logger logger = new ARS.Logger("testLog.txt");
            bool result;

            // Act
            logger.initLog();
            result = true;
            
            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void AddedToDB()
        {
            // Assign
            Dictionary<string, object> customerDetails = new Dictionary<string, object>();

            customerDetails.Add("first_name", "Mark");
            customerDetails.Add("last_name", "Mylod");
            customerDetails.Add("email", "mm123@gmail.com");
            customerDetails.Add("date_of_birth", "2023-04-01"); // Replace with the actual date
            bool result;
            SQL testSQL = new SQL("localhost", "airlinedb", "root", "revival2017");

            // Act
            testSQL.insertValues("customer", customerDetails);
            result = testSQL.checkValue("customer", "email", "mm123@gmail.com");

            // Assert
            Assert.IsFalse(result);
        }
    }
}
