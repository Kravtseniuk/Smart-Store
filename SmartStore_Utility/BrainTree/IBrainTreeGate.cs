using Braintree;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStore_Utility.BrainTree
{
    public interface IBrainTreeGate
    {
        IBraintreeGateway CreateGateway();
        IBraintreeGateway GetGateway();
    }
}