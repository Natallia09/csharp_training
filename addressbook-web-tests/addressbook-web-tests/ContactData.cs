using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData
    {
        private string userfirstname;
        private string usermiddlename = "";
        private string userlastname;
        private string usernickname = "";
        private string usertitle = "";
        private string usercompany = "";
        private string useraddress = "";
        private string userhome = "";
        private string usermobile = "";
        private string userwork = "";
        private string userfax = "";
        private string useremail = "";
        private string useremail2 = "";
        private string useremail3 = "";
        private string userhomepage = "";
        private string userbyear = "";
        private string userayear = "";
        private string useraddress2 = "";
        private string userphone2 = "";
        private string usernotes = "";

        public ContactData(string userfirstname, string userlastname)
        {
            this.userfirstname = userfirstname;
            this.userlastname = userlastname;
        }

        public string Userfirstname
        {
            get
            {
                return userfirstname;
            }
            set
            {
                userfirstname = value;
            }
        }

        public string Usermiddlename
        {
            get
            {
                return usermiddlename;
            }
            set
            {
                usermiddlename = value;
            }
        }

        public string Userlastname
        {
            get
            {
                return userlastname;
            }
            set
            {
                userlastname = value;
            }
        }

        public string Usernickname
        {
            get
            {
                return usernickname;
            }
            set
            {
                usernickname = value;
            }
        }

        public string Usertitle
        {
            get
            {
                return usertitle;
            }
            set
            {
                usertitle = value;
            }
        }

        public string Usercompany
        {
            get
            {
                return usercompany;
            }
            set
            {
                usercompany = value;
            }
        }

        public string Useraddress
        {
            get
            {
                return useraddress;
            }
            set
            {
                useraddress = value;
            }
        }

        public string Userhome
        {
            get
            {
                return userhome;
            }
            set
            {
                userhome = value;
            }
        }

        public string Usermobile
        {
            get
            {
                return usermobile;
            }
            set
            {
                usermobile = value;
            }
        }

        public string Userwork
        {
            get
            {
                return userwork;
            }
            set
            {
                userwork = value;
            }
        }

        public string Userfax
        {
            get
            {
                return userfax;
            }
            set
            {
                userfax = value;
            }
        }

        public string Useremail
        {
            get
            {
                return useremail;
            }
            set
            {
                useremail = value;
            }
        }

        public string Useremail2
        {
            get
            {
                return useremail2;
            }
            set
            {
                useremail2 = value;
            }
        }

        public string Useremail3
        {
            get
            {
                return useremail3;
            }
            set
            {
                useremail3 = value;
            }
        }

        public string Userhomepage
        {
            get
            {
                return userhomepage;
            }
            set
            {
                userhomepage = value;
            }
        }

        public string Userbyear
        {
            get
            {
                return userbyear;
            }
            set
            {
                userbyear = value;
            }
        }

        public string Userayear
        {
            get
            {
                return userayear;
            }
            set
            {
                userayear = value;
            }
        }

        public string Useraddress2
        {
            get
            {
                return useraddress2;
            }
            set
            {
                useraddress2 = value;
            }
        }

        public string Userphone2
        {
            get
            {
                return userphone2;
            }
            set
            {
                userphone2 = value;
            }
        }

        public string Usernotes
        {
            get
            {
                return usernotes;
            }
            set
            {
                usernotes = value;
            }
        }

    }
}