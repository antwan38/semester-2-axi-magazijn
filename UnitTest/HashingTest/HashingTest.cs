using DataAccessLayer;
using LogicLayer;
using NUnit.Framework;

namespace UnitTest.HashingTest
{
    [TestFixture]
    public class HashingTest
    {
        [Test, Category("HashingTest")]
        public void Hash()
        {
            //arrange
            string Password = "12345";
            string Email = "bradleydenouden@ziggo.nl";

            Hashing hashing = new Hashing();

            //act
            var hash = hashing.HashPassword(password: Password, mail: Email);

            //assert
            Assert.Pass();
        }

        [Test, Category("HashingTest")]
        public void Verify()
        {
            //arrange
            Hashing hashing = new Hashing();
            string Password = "12345";
            string Email = "123@gmail.com";
            string hash =
                "$argon2i$v=19$m=65536,t=3,p=4$HtOoL1gq1gqSDMqhNeixgg$wE6nzb7c7rONeuzaBWjqWMBMQ8nxrkMOGUZ745IF2js";
            
            //act
            bool verify = hashing.VerifyPassword(hash, Password, Email);

            //assert
            if (verify)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }
        
        [Test, Category("HashingTest")]
        public void VerifyFail()
        {
            //arrange
            Hashing hashing = new Hashing();
            string Password = "hallo";
            string Email = "123@gmail.com";
            string hash =
                "$argon2i$v=19$m=65536,t=3,p=4$HtOoL1gq1gqSDMqhNeixgg$wE6nzb7c7rONeuzaBWjqWMBMQ8nxrkMOGUZ745IF2js";
            
            //act
            bool verify = hashing.VerifyPassword(hash, Password, Email);

            //assert
            if (verify)
            {
                Assert.Fail();
            }
            Assert.Pass();
        }
    }
}