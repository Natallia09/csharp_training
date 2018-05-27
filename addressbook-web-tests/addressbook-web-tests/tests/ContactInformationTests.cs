using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformationHomePage()
        {
            ContactData fromTable = applicationManager.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = applicationManager.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);

            Assert.AreEqual(fromTable.Userallphones, fromForm.Userallphones);
            Assert.AreEqual(fromTable.Userallemails, fromForm.Userallemails);
        }

        [Test]
        public void TestContactInformationDetailsPage()
        {
            ContactData fromDetails = applicationManager.Contacts.GetContactInformationFromDetails(0);
            ContactData fromForm = applicationManager.Contacts.GetContactInformationFromEditForm(0);


            Assert.AreEqual(fromDetails, fromForm);

            Assert.AreEqual(fromDetails.AllDetails, fromForm.AllDetails);

        }

    }
}
