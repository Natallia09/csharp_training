using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            int index = 0;

            applicationManager.Navigator.GoToContactsPage();

            if (!applicationManager.Auth.IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")))
            {
                ContactData contact = new ContactData("UFN_new", "ULN_new");

                applicationManager.Contacts.Create(contact);
            }

            ContactData newData = new ContactData("UFN_modify", "ULN_modify");

            applicationManager.Contacts.Modify(1, newData);
        }
    }
}
