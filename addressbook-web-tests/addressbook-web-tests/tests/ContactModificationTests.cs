using System;
using System.Text;
using System.Collections.Generic;
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
                ContactData contact = new ContactData("ULN_new", "UFN_new");

                applicationManager.Contacts.Create(contact);
            }

            ContactData newData = new ContactData("ULN_modify", "UFN_modify");

            List<ContactData> oldContacts = applicationManager.Contacts.GetContactList();

            applicationManager.Contacts.Modify(0, newData);

            Assert.AreEqual(oldContacts.Count, applicationManager.Contacts.GetContactCount());

            List<ContactData> newContacts = applicationManager.Contacts.GetContactList();
            oldContacts[0].Userfirstname = newData.Userfirstname;
            oldContacts[0].Userlastname = newData.Userlastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
