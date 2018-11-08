
using CurrencyTrader.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyTrader
{
    public class AdjustTradeDataProvider : ITradeDataProvider

    {
        private readonly String url;
        ITradeDataProvider urlProvider;

        public AdjustTradeDataProvider(String url)
        {
            this.url = url;
            urlProvider = new UrlTradeDataProvider(url);
        }
        public IEnumerable<string> GetTradeData()
        {
            IEnumerable<string> tradeTxt;
            //new list of trades with the new changes
            List<string> newTradeTxt = new List<string>();

            tradeTxt = urlProvider.GetTradeData();

            // Insert code to change GBP to EUR
            foreach(string line in tradeTxt)
            {
                
                newTradeTxt.Add(line.Replace("GBP", "EUR"));
            } 

            return newTradeTxt;
        }
    }
}
