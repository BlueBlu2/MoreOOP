using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadEx
{
    class Account
    {
        public decimal Balance { get; private set; }
        private  bool IsVerified { get; set; }
        private  bool IsClosed { get; set; }
        private bool IsFrozen { get; set; }
        private Action OnUnFreeze { get; }

        public Account(Action onUnFreeze)
        {
            this.OnUnFreeze = onUnFreeze;
        }
        public void Deposit(decimal amount)
        {
            if (this.IsClosed)
                return; //or do something
            if (this.IsFrozen)
            {
                this.IsFrozen = false;
                this.OnUnFreeze();
            }
            //Deposit money
            this.Balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            if (!this.IsVerified)
                return; //or do something
            if (this.IsClosed)
                return; //or do something
            if (this.IsFrozen)
            {
                this.IsFrozen = false;
                this.OnUnFreeze();
            }
            //withdraw money
            this.Balance -= amount;
        }

        public void HolderVerified()
        {
            this.IsVerified = true;
        }
        public void Close ()
        {
            this.IsClosed = true;
        }

        public void Freeze()
        {
            if (this.IsClosed)
                return; //Account Mustn't be closed
            if (!this.IsVerified)
                return; //Account must be verified
            this.IsFrozen = true;
        }
    }
}
