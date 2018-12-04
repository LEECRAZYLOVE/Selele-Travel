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

        private void makeQuote_no()
        {
            timeQuoted = DateTime.Now;
            string _totalQts = totalQuotes.ToString();
            while (_totalQts.Length < 6)
            {
                _totalQts = _totalQts.PadLeft(1, '0');
            }
            quote_no = $"{timeQuoted}{_totalQts}";
        }

    }
}
