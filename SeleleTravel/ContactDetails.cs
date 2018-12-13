using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleleTravel
{
    /// <summary>
    /// A helper class for the Client class
    /// </summary>
    public class ContactDetails
    {
        public string cellphone; //Cellphone number
        public string telephone; //Telephone number
        public string fax; //Fax number
        public string emailaddress;
        private string defaultValue = "Not Specified";
        public ContactDetails(string cellphone)
        {
            if (string.IsNullOrEmpty(cellphone.Trim()))
                this.cellphone = defaultValue;
            else this.cellphone = cellphone;

            this.telephone = defaultValue;
            this.emailaddress = defaultValue;
            this.fax = defaultValue;
        }
        public ContactDetails(string cellphone, string email) : this(cellphone)
        {
            if (string.IsNullOrEmpty(cellphone.Trim()))
                this.emailaddress = defaultValue;
            else this.emailaddress = email;

            telephone = defaultValue;
            fax = defaultValue;
        }
        public ContactDetails(string cellphone, string email, string telephone) : this (cellphone, email)
        {
            if (string.IsNullOrEmpty(cellphone.Trim()))
                this.telephone = defaultValue;
            else this.telephone = telephone;
            fax = defaultValue;
        }
        public ContactDetails(string cellphone, string email, string telephone, string fax) : this (cellphone, email, telephone)
        {
            if (string.IsNullOrEmpty(cellphone.Trim()))
                this.fax = defaultValue;
            else this.fax = fax;
        }
    }
}
