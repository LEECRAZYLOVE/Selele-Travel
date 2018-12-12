//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SeleleTravel
{
    using System;
    using System.Collections.Generic;
    public enum clienttype { Individual, Business };
    public partial class client
    {
        public string client_no { get; set; }
        public string quote_no { get; set; }
        public string clientname { get; set; }
        //public string cellphone { get; set; }
        public string address { get; set; }
        //public string emailaddress { get; set; }
        //public string telephone { get; set; }
        //public string fax { get; set; }
        public Nullable<double> paid { get; set; }
        public Nullable<double> owe { get; set; }
        public Nullable<double> broughtforward { get; set; }

        public List<Service> services;
        public ContactDetails contactdetails;
        /// <summary>
        /// The type of client. This field will be useful when searching for clients.
        /// </summary>
        public static clienttype ClientType;

        #region Static fields, properties and methods
        /// <summary>
        /// A reference to all the clients who are single individuals.
        /// This will be useful when we implement searching.
        /// </summary>
        public static List<client> clientsWhoAreIndividuals = new List<client>();
        /// <summary>
        /// A reference to all the clients who are businesses.
        /// This will be useful when we implement searching.
        /// </summary>
        public static List<client> clientsWhoAreBusinesses = new List<client>();
        #endregion
        /// <summary>
        /// Adds a new client to the database.
        /// Status : incomplete
        /// </summary>
        /// <param name="client"></param>
        public static void addNewClient(client Client)
        {
            if (SeleleTravel.client.ClientType == clienttype.Business)
                clientsWhoAreBusinesses.Add(Client);
            else clientsWhoAreIndividuals.Add(Client);

            //Add the client to the database
        }
        /// <summary>
        /// Makes a client id using the clientType variable.
        /// </summary>
        private void makeClientID()
        {
            string endOfId;
            if (ClientType == clienttype.Business)
                endOfId = clientsWhoAreBusinesses.Count + "";
            else endOfId = clientsWhoAreIndividuals.Count + "";
            while (endOfId.Length < 4)
            {
                endOfId = endOfId.PadLeft(1, '0');
            }
            client_no = clientname.Replace(" ", "_") + endOfId;
        }

        public override string ToString()
        {
            return clientname;
        }
        public client(string names, clienttype clientType)
        {
            this.clientname = names;
            ClientType = clientType;
        }
        public client(string names, clienttype clientType, string cellphoneNumber) : this(names, clientType)
        {
            contactdetails = new ContactDetails(cellphoneNumber);
        }
        public client(string names, clienttype clientType, ContactDetails contactDetails) : this(names, clientType)
        {
            contactdetails = contactDetails;
        }
    }
}