using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodEx
{
    class Account
    {
        public decimal Balance { get; private set; }
        private IAccountState State { get; set; }

        public Account(Action onUnFreeze)
        {
            this.State = new NotVerified(onUnFreeze);
        }
        public void Deposit(decimal amount)
        {
            this.State = this.State.Deposit(() =>
            {
                this.Balance += amount;
            });
        }


        public void Withdraw(decimal amount)
        {
            this.State = this.State.Withdraw(() =>
            {
                this.Balance -= amount;
            });
        }

        public void HolderVerified()
        {
            this.State = this.State.HolderVerified();
        }
        public void Close ()
        {
            this.State = this.State.Close();
        }

        public void Freeze()
        {
            this.State = this.State.Freeze();
        }
    }
}
