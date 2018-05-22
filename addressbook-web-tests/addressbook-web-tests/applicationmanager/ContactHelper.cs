using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public ContactHelper Modify(int p, ContactData newData)
        {
            manager.Navigator.GoToContactsPage();
            SelectContact(p);
            InitContactModification();
            FillContactForm(newData);
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
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper ReturnsToContactsPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.CssSelector("img[title='Edit']")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToContactsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));

            foreach (IWebElement element in elements)
            {
                IList<IWebElement> cell = element.FindElements(By.CssSelector("td"));
                contacts.Add(new ContactData(cell[1].Text, cell[2].Text));
            }
            return contacts;
        }
    }
}
