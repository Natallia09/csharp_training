using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {

        [Test]

        public void GroupModificationTest()
        {
            int index = 0;

            applicationManager.Navigator.GoToGroupsPage();

            if (! applicationManager.Auth.IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")))
            {
                GroupData group = new GroupData("G_new");
                group.Header = "H_new";
                group.Footer = "F_new";

                applicationManager.Groups.Create(group);
            }

            GroupData newData = new GroupData("G_modify");
            newData.Header = "H_modify";
            newData.Footer = "F_modify";

            applicationManager.Groups.Modify(1, newData);
        }
    }
}