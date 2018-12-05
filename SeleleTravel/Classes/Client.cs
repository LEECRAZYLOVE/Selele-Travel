using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleleTravel
{
    enum ClientType { Individual, Business };
    class Client
    {
        /// <summary>
        /// The names of the individual or Business.
        /// </summary>
        public string names;
        /// <summary>
        /// The contact details in arranged in array in the order:
        /// cellphone (index 0), telephone (index 1), email (index 2), fax (index 3).
        /// </summary>
        public ContactDetails contactDetails;
        /// <summary>
        /// A unique identifier of the client.
        /// </summary>
        public string clientID;
        /// <summary>
        /// This is where the client is situated.
        /// </summary>
        public string location;
        public List<Service> services;
        /// <summary>
        /// The type of client. This field will be useful when searching for clients.
        /// </summary>
        public ClientType clientType;

        #region Static fields, properties and methods
        /// <summary>
        /// A reference to all the clients who are single individuals.
        /// This will be useful when we implement searching.
        /// </summary>
        public static List<Client> clientsWhoAreIndividuals = new List<Client>();
        /// <summary>
        /// A reference to all the clients who are businesses.
        /// This will be useful when we implement searching.
        /// </summary>
        public static List<Client> clientsWhoAreBusinesses = new List<Client>();
        #endregion
        /// <summary>
        /// Adds a new client to the database.
        /// Status : incomplete
        /// </summary>
        /// <param name="client"></param>
        public static void addNewClient(Client client)
        {
            if (client.clientType == ClientType.Business)
                clientsWhoAreBusinesses.Add(client);
            else clientsWhoAreIndividuals.Add(client);

            //Add the client to the database
        }
        /// <summary>
        /// Makes a client id using the clientType variable.
        /// </summary>
        private void makeClientID()
        {
            string endOfId;
            if (clientType == ClientType.Business)
                endOfId = clientsWhoAreBusinesses.Count() + "";
            else endOfId = clientsWhoAreIndividuals.Count() + "";
            while (endOfId.Length < 4)
            {
                endOfId = endOfId.PadLeft(1, '0');
            }
            clientID = names.Replace(" ", "_") + endOfId;
        }

        public override string ToString()
        {
            return names;
        }
        public Client(string names, ClientType clientType)
        {
            this.names = names;
            this.clientType = clientType;
        }
        public Client(string names, ClientType clientType, string cellphoneNumber) : this(names, clientType)
        {
            contactDetails = new ContactDetails(cellphoneNumber);
        }
        public Client(string names, ClientType clientType, ContactDetails contactDetails) : this (names, clientType)
        {
            this.contactDetails = contactDetails;
        }
    }
}