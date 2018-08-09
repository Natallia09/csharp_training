using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) 
            : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToContactsPage();
            GoToAddNewContactPage();
            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToContactsPage();
            ClearGroupFilter();
            SelectContact_(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public ContactHelper SelectContact_(String id)
        {
            driver.FindElement(By.Id(id)).Click();
            return this;
        }

        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public ContactHelper Modify(int index, ContactData newData)
        {
            manager.Navigator.GoToContactsPage();
            SelectContact(index);
            InitContactModification(index);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnsToContactsPage();
            return this;
        }

        public ContactHelper Modify(ContactData oldContacts, ContactData newContacts)
        {
            manager.Navigator.GoToContactsPage();
            SelectContact(oldContacts.Id);
            FillContactForm(newContacts);
            SubmitContactModification();
            ReturnsToContactsPage();
            return this;
        }

        public ContactHelper Remove(int p)
        {
            manager.Navigator.GoToContactsPage();
            SelectContact(p);
            RemoveContact();
            ReturnsToContactsPage();
            return this;
        }

        public ContactHelper Remove(ContactData contact)
        {
            manager.Navigator.GoToContactsPage();
            SelectContact(contact.Id);
            RemoveContact();
            ReturnsToContactsPage();
            return this;
        }

        public ContactHelper GoToAddNewContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Userfirstname);
            Type(By.Name("middlename"), contact.Usermiddlename);
            Type(By.Name("lastname"), contact.Userlastname);
            Type(By.Name("nickname"), contact.Usernickname);
            Type(By.Name("title"), contact.Usertitle);
            Type(By.Name("company"), contact.Usercompany);
            Type(By.Name("address"), contact.Useraddress);
            Type(By.Name("home"), contact.Userhome);
            Type(By.Name("mobile"), contact.Usermobile);
            Type(By.Name("work"), contact.Userwork);
            Type(By.Name("fax"), contact.Userfax);
            Type(By.Name("email"), contact.Useremail);
            Type(By.Name("email2"), contact.Useremail2);
            Type(By.Name("email3"), contact.Useremail3);
            Type(By.Name("homepage"), contact.Userhomepage);
            Type(By.Name("byear"), contact.Userbyear);
            Type(By.Name("ayear"), contact.Userayear);
            Type(By.Name("address2"), contact.Useraddress2);
            Type(By.Name("phone2"), contact.Userphone2);
            Type(By.Name("notes"), contact.Usernotes);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactHelper SelectContact(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])"))
                .FindElement(By.XPath("(//img[@alt='Edit'])")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        public ContactHelper ReturnsToContactsPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        public ContactHelper InitContactModification(ContactData contact)
        {
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            return this;
        }

        public ContactHelper SelectContactDetails(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToContactsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));

                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cell = element.FindElements(By.CssSelector("td"));
                    contactCache.Add(new ContactData(cell[1].Text, cell[2].Text));
                }
            }

            return new List<ContactData>(contactCache);
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.Name("entry")).Count;
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string userlastname = cells[1].Text;
            string userfirstname = cells[2].Text;
            string useraddress = cells[3].Text;
            string userallphones = cells[5].Text;
            string userallemails = cells[4].Text;

            return new ContactData(userfirstname, userlastname)
            {
                Useraddress = useraddress,
                Userallphones = userallphones,
                Userallemails = userallemails,
            };
        }

        public ContactData GetContactInformationFromDetails(int index)
        {
            manager.Navigator.GoToHomePage();
            SelectContactDetails(0);

            string[] userfirstlastname = driver.FindElement(By.CssSelector("div#content"))
            .FindElement(By.TagName("b")).Text.Split(' ');

            string userfirstname = userfirstlastname[0];
            string userlastname = userfirstlastname[1];

            string alldetails = driver.FindElement(By.CssSelector("div#content")).Text;

            return new ContactData(userfirstname, userlastname)
            {
               AllDetails = alldetails,
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(0);

            string userfirstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string userlastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string useraddress = driver.FindElement(By.Name("address")).GetAttribute("value");

            string userhome = driver.FindElement(By.Name("home")).GetAttribute("value");
            string usermobile = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string userwork = driver.FindElement(By.Name("work")).GetAttribute("value");

            string useremail = driver.FindElement(By.Name("email")).GetAttribute("value");
            string useremail2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string useremail3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(userfirstname, userlastname)
            {
                Useraddress = useraddress,
                Userhome = userhome,
                Usermobile = usermobile,
                Userwork = userwork,
                Useremail = useremail,
                Useremail2 = useremail2,
                Useremail3 = useremail3
            };
        }
    }
}

