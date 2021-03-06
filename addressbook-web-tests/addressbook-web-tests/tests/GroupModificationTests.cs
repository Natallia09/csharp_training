﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
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

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];

            applicationManager.Groups.Modify(oldData, newData);

            Assert.AreEqual(oldGroups.Count, applicationManager.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}