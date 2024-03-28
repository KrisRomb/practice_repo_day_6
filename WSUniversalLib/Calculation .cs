using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSUniversalLib
{
    public class Calculation
    {
        public int GetQuantityForProduct(int productType,int materialType,int count,float width,float length)
        {
            if (productType <= 3 && productType > 0 
                && width > 0 && length > 0 
                && materialType <= 2 && materialType >0 
                && count >= 1)
            {
                var area = width * length;
                double productFactor = 0;
                double faultFactor;
                double quantity;
                if (materialType == 1)
                {
                    faultFactor = 0.003;
                }
                else
                {
                    faultFactor = 0.012;
                }
                switch (productType)
                {
                    case 1:
                        productFactor = 1.1;
                        break;
                    case 2:
                        productFactor = 2.5;
                        break;
                    case 3:
                        productFactor = 8.43;
                        break;
                }
                quantity = (area * count * productFactor) / (1 - 0.003);
                return Convert.ToInt32(Math.Ceiling(quantity));
            }
            else
            {
                return -1;
            }
        }
    }
}
