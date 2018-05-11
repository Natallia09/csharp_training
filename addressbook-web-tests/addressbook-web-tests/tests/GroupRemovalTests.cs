using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            int index = 0;

            applicationManager.Navigator.GoToGroupsPage();

            if (!applicationManager.Auth.IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")))
            {
                GroupData group = new GroupData("G_new");
                group.Header = "H_new";
                group.Footer = "F_new";

                applicationManager.Groups.Create(group);
            }

            applicationManager.Groups.Remove(1);
        }
    }
}
