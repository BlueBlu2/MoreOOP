using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodEx
{
    class Active : IAccountState
    {
        private Action OnUnFreeze { get; }

        public Active(Action onUnFreeze)
        {
            this.OnUnFreeze = onUnFreeze;
        }
        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }
        public IAccountState Withdraw(Action subtractFromBalance)
        {
            subtractFromBalance();
            return this;
        }
        public IAccountState Freeze() => new Frozen(this.OnUnFreeze);

        public IAccountState HolderVerified() => this;

        public IAccountState Close() => new Closed();
    }
}
