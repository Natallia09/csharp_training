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
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            int index = 0;

            applicationManager.Navigator.GoToContactsPage();

            if (!applicationManager.Auth.IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")))
            {
                ContactData contact = new ContactData("UFN_new", "ULN_new");

                applicationManager.Contacts.Create(contact);
            }

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];

            applicationManager.Contacts.Remove(toBeRemoved);

            Assert.AreEqual(oldContacts.Count - 1, applicationManager.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
               Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
