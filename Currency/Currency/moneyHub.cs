using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Currency
{
    public static class DB
    {
        public static HashSet<Money> Money = new HashSet<Money>()
        {
            new Money("Dolar", 5.76m),
            new Money("EURO", 6.47m),
            new Money("Ruble", 0.087m),
            new Money("Yuan", 0.81m),
            new Money("Sterlin", 7.07m)
        };
    }

    public class moneyHub : Hub
    {
        public IEnumerable<Money> GetAll()
        {
            Money item1 = new Money();
            Money item2 = new Money("Riyal", 0.8m);
            return DB.Money.ToList();
        }

        public void PressValueToAllClients(Guid id, decimal value)
        {
            Money money = DB.Money.Where(x => x.ID == id).FirstOrDefault();
            money.Value = value;

            Clients.Others.newValue(money);
        }
    }
}