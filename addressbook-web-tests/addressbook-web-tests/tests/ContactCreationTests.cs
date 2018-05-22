using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("ULN_new", "UFN_new");


            List<ContactData> oldContacts = applicationManager.Contacts.GetContactList();

            applicationManager.Contacts.Create(contact);
            applicationManager.Navigator.GoToContactsPage();

            Assert.AreEqual(oldContacts.Count + 1, applicationManager.Contacts.GetContactCount());

            List<ContactData> newContacts = applicationManager.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");

            List<ContactData> oldContacts = applicationManager.Contacts.GetContactList();

            applicationManager.Contacts.Create(contact);
            applicationManager.Navigator.GoToContactsPage();

            Assert.AreEqual(oldContacts.Count + 1, applicationManager.Contacts.GetContactCount());

            List<ContactData> newContacts = applicationManager.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}