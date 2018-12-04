using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleleTravel.Classes
{
    public class Quote
    {
        public string quote_no;
        public double amount;
        public string typeOfService;
        public DateTime timeQuoted;
        public string consultant_no;
        public static int totalQuotes = 0;
      
        public Quote(double amount, string typeOfService, string consultant_no)
        {
            this.amount = amount;
            this.typeOfService = typeOfService;
            this.consultant_no = consultant_no;
            makeQuote_no();
        }
        /// <summary>
        /// It generates a new quote number
        /// </summary>
        private void makeQuote_no()
        {
            timeQuoted = DateTime.Now; // Assignes the timeQuoted to the current time
            string _totalQts = totalQuotes.ToString(); // assigns the static value to the string
            while (_totalQts.Length < 6)
            {
                // It adds a zero once to the left of the current string
                _totalQts = _totalQts.PadLeft(1, '0');
            }
            // generates the quote number using the time and string generated above
            quote_no = $"{timeQuoted}{_totalQts}";
        }

        public override string ToString()
        {
            return base.ToString();

        }

    }
}
