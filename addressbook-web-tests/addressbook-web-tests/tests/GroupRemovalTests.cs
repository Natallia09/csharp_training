using System;
using System.Collections.Generic;
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

            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();

            applicationManager.Groups.Remove(0);

            Assert.AreEqual(oldGroups.Count - 1, applicationManager.Groups.GetGroupCount());

            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
