using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission_9_conmansp.Models
{
    public interface ICheckoutRepository
    {
        IQueryable<Checkout> Checkouts { get; }

        public void SaveCheckout(Checkout checkout);
    }
}
