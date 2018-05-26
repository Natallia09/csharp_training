﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {

        private string userallphones;
        private string userallemails;

        public ContactData(string userlastname, string userfirstname)
        {
            Userfirstname = userfirstname;
            Userlastname = userlastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
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
            return "lastname=" + Userlastname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (Userlastname.CompareTo(other.Userlastname) == 0)
            {
                return Userfirstname.CompareTo(other.Userfirstname);
            }
            return Userlastname.CompareTo(other.Userlastname);
        }

        public string Userfirstname { get; set; }

        public string Usermiddlename { get; set; }

        public string Userlastname { get; set; }

        public string Usernickname { get; set; }

        public string Usertitle { get; set; }

        public string Usercompany { get; set; }

        public string Useraddress { get; set; }

        public string Userhome { get; set; }

        public string Usermobile { get; set; }

        public string Userwork { get; set; }

        public string Userfax { get; set; }

        public string Useremail { get; set; }

        public string Useremail2 { get; set; }

        public string Useremail3 { get; set; }

        public string Userhomepage { get; set; }

        public string Userbyear { get; set; }

        public string Userayear { get; set; }

        public string Useraddress2 { get; set; }

        public string Userphone2 { get; set; }

        public string Usernotes { get; set; }

        public string Id { get; set; }

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
    }
}