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
    public class ContactModificationTests : ContactTestBase
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

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldData = oldContacts[0];

            applicationManager.Contacts.Modify(oldData, newData);

            Assert.AreEqual(oldContacts.Count, applicationManager.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            oldData.Userfirstname = newData.Userfirstname;
            oldData.Userlastname = newData.Userlastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
