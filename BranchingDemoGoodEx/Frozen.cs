using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodEx
{
    class Frozen : IAccountState
    {
        private Action OnUnFreeze { get; }

        public Frozen(Action onUnFreeze)
        {
            this.OnUnFreeze = onUnFreeze;
        }
        public IAccountState Deposit(Action addToBalance)
        {
            this.OnUnFreeze();
            addToBalance();
            return new Active(this.OnUnFreeze);
        }

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            this.OnUnFreeze();
            subtractFromBalance();
            return new Active(this.OnUnFreeze);
        }
        public IAccountState Freeze() => this;
        public IAccountState HolderVerified() => this;

        public IAccountState Close() => new Closed();

    }
}
