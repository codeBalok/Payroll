using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.Services.Implementation
{
    public class TaxService : ITaxService
    {
        private decimal taxRate;
        private decimal tax;
        public decimal TaxAmount(decimal totalAmount)
        {
            if (totalAmount <= 1517)
            {
                //taxfree rate
                taxRate = .0m;
                tax = totalAmount * taxRate;
            }
            else if (totalAmount > 1517 && totalAmount <= 3084)
            {
                //basic tax rate 
                taxRate = .19m;
                //income tax
                tax = (1517 * .0m) + ((totalAmount - 1517) * taxRate);
            }
            else if (totalAmount > 3084 && totalAmount <= 7500)
            {
                //$3,572 plus 32.5c for each $1 over $37,000
                taxRate = .325m;
                tax = (1517 * .0m) + ((3084 - 1517) * .20m) + ((totalAmount - 3084) * taxRate);
                //Aussie tax rule=>
               // tax = 3572 + ((totalAmount - 3084) * taxRate);
            }
            else if (totalAmount > 7500 && totalAmount <= 15000)
            {
                taxRate = .37m;
                tax = (1517 * .0m) + ((3084 - 1517) * .20m) + ((7500 - 3084) * .327m) + 
                    ((totalAmount - 7500) * taxRate);
               // tax = 20797 + ((totalAmount - 7500) * taxRate);

            }
            else if (totalAmount > 15000)
            {
                taxRate = .45m;
                tax = (1517 * .0m) + ((3084 - 1517) * .20m) + ((7500 - 3084) * .327m) + 
                    ((15000 - 7500) * .37m) + ((totalAmount - 15000) * taxRate);
                //tax = 54097 + ((totalAmount - 15000) * taxRate);

            }
            return tax;
        }
    }
}
