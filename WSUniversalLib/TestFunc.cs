using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSUniversalLib
{
    class TestFunc
    {
        /// <summary>
        /// Метод расчитывает количество необходимых ресурсов опредленного типа 
        /// для производства заданного кол-ва продукции опредленного типа, имеющей
        /// заданную ширину и длину
        /// </summary>
        /// <param name="productType"></param>
        /// <param name="materialType"></param>
        /// <param name="count"></param>
        /// <param name="width"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static int GetQuantityForProduct(int productType, int materialType, int count, float width, float length)
        {
            double[] matKoef = { 0, 0.997, 0.988 };
            double[] prodKoef = { 0, 1.1, 2.5, 8.43 };

            if (productType <= 0 || materialType <= 0 || count <= 0 || width <= 0 || length <= 0)
            {
                return -1;
            }

            try
            {
                int matCount = (int)Math.Ceiling(count * width * length * prodKoef[productType] / matKoef[materialType]);
                return matCount;
            }
            catch
            {
                return -1;
            }
        }
    }
}
