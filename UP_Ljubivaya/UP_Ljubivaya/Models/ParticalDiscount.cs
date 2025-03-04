using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP_Ljubivaya.Models
{
    public partial class Partner
    {
        public string Discount
        {
            get
            {
                int totalQuantity = PartnersProducts.Sum(product => product.Quantity ?? 0);

                if (totalQuantity < 10000)
                {
                    return "0%";
                }
                else if (totalQuantity >= 10000 && totalQuantity < 50000)
                {
                    return "5%";
                }
                else if (totalQuantity >= 50000 && totalQuantity < 300000)
                {
                    return "10%";
                }
                else 
                {
                    return "15%";
                }
            }
        }
    }

}
