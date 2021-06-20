using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodEx
{
    class Closed : IAccountState
    {
        public IAccountState Close() => this;

        public IAccountState Deposit() => this;

        public IAccountState Freeze() => this;

        public IAccountState HolderVerified() => this;

        public IAccountState Withdraw() => this;
    }
}
