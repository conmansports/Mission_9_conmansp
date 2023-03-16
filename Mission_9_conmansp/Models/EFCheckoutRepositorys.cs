using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission_9_conmansp.Models
{
    public class EFCheckoutRepositorys : ICheckoutRepository
    {
        private BookstoreContext context;
        public EFCheckoutRepositorys (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Checkout> Checkouts => context.Checkouts.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveCheckout(Checkout checkout)
        {
            context.AttachRange(checkout.Lines.Select(x => x.Book));

            if (checkout.CheckoutId == 0)
            {
                context.Checkouts.Add(checkout);
            }

            context.SaveChanges();
        }
    }
}
