using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Exchange_rate
{
    class Program
    {
        static Dictionary<string, double> currencySale = new Dictionary<string, double>();

        static Dictionary<string, double> currencyBuy = new Dictionary<string, double>();

        const string LINK = "https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=5";
        static void Main(string[] args)
        {
            using (WebClient client = new WebClient())
            {
                var json = client.DownloadString(LINK);
                var result = JsonConvert.DeserializeObject<List<ExchangeRate>>(json);

                Print(result);

                SetSaleCurrency(result);
                SetBuyCurrency(result);

                //BUY
                foreach (var item in result)
                {
                    Console.WriteLine(item.GetCurrencyBuy());
                }

                Console.WriteLine();
                // SALE
                foreach (var item in result)
                {
                    Console.WriteLine(item.GetCurrencySale());
                }
            }

            // SALE
            Console.WriteLine();
            Console.WriteLine("SALE");
            foreach (var item in currencySale)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }

            //BUY
            Console.WriteLine();
            Console.WriteLine("BUY");
            foreach (var item in currencyBuy)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }
        }

        static void Print(List<ExchangeRate> result)
        {
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        static void SetSaleCurrency(List<ExchangeRate> result)
        {
            try
            {
                foreach (var item in result)
                {
                    currencySale.Add(item.ccy, double.Parse(item.sale.Replace('.', ',')));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void SetBuyCurrency(List<ExchangeRate> result)
        {
            try
            {
                foreach (var item in result)
                {
                    currencyBuy.Add(item.ccy, double.Parse(item.buy.Replace('.', ',')));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
