using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorMarket.Models.ViewModels
{
    public class MotorViewModel
    {
        public Motorsiklet Motorsiklet { get; set; }
        public IEnumerable<Main> Mains { get; set; }
        public IEnumerable<Model> Models { get; set; }
        public IEnumerable<Currency> Currencies { get; set; }

        private List<Currency> CList = new List<Currency>();
        private List<Currency> CreateList()
        {
            CList.Add(new Currency("TRL", "TRL"));
            CList.Add(new Currency("USD", "USD"));
            CList.Add(new Currency("EUR", "EUR"));
            return CList;
        }
        public MotorViewModel()
        {
            Currencies=CreateList();
        }
    }
    public class Currency
    {
        public String Id { get; set; }
        public String Name { get; set; }

        public Currency(String id, String name)
        {
            Id = id;
            Name = name;
        }
    }
}
