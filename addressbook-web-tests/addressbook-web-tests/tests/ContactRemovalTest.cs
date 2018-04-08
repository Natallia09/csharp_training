using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            applicationManager.Navigator.GoToHomePage();
            applicationManager.Auth.Login(new AccountData("admin", "secret"));
            applicationManager.Navigator.GoToContactsPage();
            applicationManager.Contacts.SelectContact(1);
            applicationManager.Contacts.RemoveContact();
            applicationManager.Contacts.ReturnsToContactsPage();
        }
    }
}
