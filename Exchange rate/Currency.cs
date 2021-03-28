using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_rate
{
    public class ExchangeRate
    {
        public string ccy { get; set; }
        public string base_ccy { get; set; }
        public string buy { get; set; }
        public string sale { get; set; }

        public override string ToString()
        {
            return $"{ccy} --> {base_ccy}| buy - {buy} -- sale - {sale}";
        }

        public double GetCurrencySale()
        {
            return double.Parse(this.sale.Replace('.',','));
        }

        public double GetCurrencyBuy()
        {
            return double.Parse(this.buy.Replace('.', ','));
        }
    }
}
