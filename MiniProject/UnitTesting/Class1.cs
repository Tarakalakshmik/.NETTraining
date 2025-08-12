using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using MiniProject;
namespace UnitTesting
{
    [TestFixture]
    public class User_Login
    {
        DatabaseHelper db;

        [SetUp]
        public void Setup()
        {
            db = new DatabaseHelper();
        }

        [Test]
        public void TrueUserLogin()
        {
            bool isAdmin;
            bool user = db.ValidateLogin("admin", "admin123", out isAdmin);
            ClassicAssert.AreEqual(user, true);
        }

        [Test]
        public void FalseUserLogin()
        {
            bool isAdmin;
            bool user = db.ValidateLogin("scarlet", "scarlet123", out isAdmin);
            ClassicAssert.AreNotEqual(user, true);
        }
    }
}
