using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {

        private string userallphones;
        private string userallemails;
        private string alldetails;

        public ContactData(string userlastname, string userfirstname)
        {
            Userfirstname = userfirstname;
            Userlastname = userlastname;
        }

        public ContactData() { }

        public bool Equals(ContactData other)
        {
            if (other is null)
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (Userlastname == other.Userlastname) && (Userfirstname == other.Userfirstname);
        }

        public override int GetHashCode()
        {
            return (Userlastname+Userfirstname).GetHashCode();
        }

        public override string ToString()
        {
            return "firstname" + Userfirstname + "\nlastname=" + Userlastname  + "\naddress" + Useraddress;
        }

        public int CompareTo(ContactData other)
        {
            if (other is null)
            {
                return 1;
            }

            if (Userlastname.CompareTo(other.Userlastname) == 0)
            {
                return Userfirstname.CompareTo(other.Userfirstname);
            }
            return Userlastname.CompareTo(other.Userlastname);
        }

        [Column(Name = "firstname")]
        public string Userfirstname { get; set; }

        [Column(Name = "middlename")]
        public string Usermiddlename { get; set; }

        [Column(Name = "lastname")]
        public string Userlastname { get; set; }

        [Column(Name = "nickname")]
        public string Usernickname { get; set; }

        [Column(Name = "title")]
        public string Usertitle { get; set; }

        [Column(Name = "company")]
        public string Usercompany { get; set; }

        [Column(Name = "address")]
        public string Useraddress { get; set; }

        [Column(Name = "home")]
        public string Userhome { get; set; }

        [Column(Name = "mobile")]
        public string Usermobile { get; set; }

        [Column(Name = "work")]
        public string Userwork { get; set; }

        [Column(Name = "fax")]
        public string Userfax { get; set; }

        [Column(Name = "email")]
        public string Useremail { get; set; }

        [Column(Name = "email2")]
        public string Useremail2 { get; set; }

        [Column(Name = "email3")]
        public string Useremail3 { get; set; }

        [Column(Name = "homepage")]
        public string Userhomepage { get; set; }

        [Column(Name = "byear")]
        public string Userbyear { get; set; }

        [Column(Name = "ayear")]
        public string Userayear { get; set; }

        [Column(Name = "address2")]
        public string Useraddress2 { get; set; }

        [Column(Name = "phone2")]
        public string Userphone2 { get; set; }

        [Column(Name = "notes")]
        public string Usernotes { get; set; }

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }


        public string Userallphones
        {
            get
            {
                if (userallphones != null)
                {
                    return userallphones;
                }
                else
                {
                    return (CleanUpUserPhone(Userhome) + CleanUpUserPhone(Usermobile) + CleanUpUserPhone(Userwork)).Trim();
                }
            }
            set
            {
                userallphones = value;
            }
        }

        private string CleanUpUserPhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone,"[-() ]", "") + "\r\n";
        }

        public string Userallemails
        {
            get
            {
                if (userallemails != null)
                {
                    return userallemails;
                }
                else
                {
                    return (CleanUpUserEmail(Useremail) + CleanUpUserEmail(Useremail2) + CleanUpUserEmail(Useremail3)).Trim();
                }
            }
            set
            {
                userallemails = value;
            }
        }

        private string CleanUpUserEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return Regex.Replace(email, "[-() ]", "") + "\r\n";
        }

        public string AllDetails
        {
            get
            {
                alldetails = Userlastname + " " + Userfirstname;

                if (alldetails != null)
                {
                    return alldetails;
                }
                else
                {

                    if (Useraddress != "" || Useraddress != null)
                    {
                        alldetails = alldetails + "\r\n" + Useraddress;
                    }
                    alldetails = alldetails + "\r\n";

                    if (Userhome != "" || Userhome != null)
                    {
                        alldetails = alldetails + "\r\n" + ("H: " + Userhome);
                    }

                    if (Usermobile != "" || Usermobile != null)
                    {
                        alldetails = alldetails + "\r\n" + ("M: " + Usermobile);
                    }

                    if (Userwork != "" || Userwork != null)
                    {
                        alldetails = alldetails + "\r\n" + ("W: " + Userwork);
                    }
                    alldetails = alldetails + "\r\n";

                    if (Useremail != "" || Useremail != null)
                    {
                        alldetails = alldetails + "\r\n" + Useremail;
                    }

                    if (Useremail2 != "" || Useremail2 != null)
                    { 
                        alldetails = alldetails + "\r\n" + Useremail2;
                    }

                    if (Useremail3 != "" || Useremail3 != null)
                    {
                        alldetails = alldetails + "\r\n" + Useremail3;
                    }

                }
                return alldetails;
            }
            set
            {
                alldetails = value;
            }
        }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }
    }
}