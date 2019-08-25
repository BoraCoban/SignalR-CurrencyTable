using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Currency
{
    public class Money
    {
        public Money()
        {
            this.ID = Guid.NewGuid();
            this.Value = 0;
        }

        public Money(string name, decimal value) 
        {
            this.ID = Guid.NewGuid();
            this.Value = 0;

            this.Name = name;
            this.Value = value;
        }

        public Guid ID { get; set; }
        public string Name { get; set; }

        private decimal _value
        {
            get;
            set;
        } 
        public decimal Value
        {
            get { return _value; }
            set
            {
                LastValue = _value;
                _value = value;
            }
        }

        public decimal LastValue
        {
            get;
            set;
        }
        public decimal Change { get; set; }
    }
}