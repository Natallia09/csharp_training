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

            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();

            applicationManager.Groups.Modify(0, newData);

            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}