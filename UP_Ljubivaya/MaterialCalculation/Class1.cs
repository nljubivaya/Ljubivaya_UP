namespace MaterialCalculation
{
    public class Class1
    {
        public int MaterialCalculator(int productId, int materialId, int kolProd, float width, float length)
        {
            if (kolProd <= 0 || width <= 0 || length <= 0)
            {
                return -1; 
            }
            double koeff = 0;
            double defect = 0;
            switch (productId)
            {
                case 1:
                    koeff = 4.34;
                    if (materialId == 1)
                    {
                        defect = 0.001;
                    }
                    else if (materialId == 2)
                    {
                        defect = 0.0095;
                    }
                    else if (materialId == 3)
                    {
                        defect = 0.0028;
                    }
                    else if (materialId == 4)
                    {
                        defect = 0.0055;
                    }
                    else if (materialId == 5)
                    {
                        defect = 0.0034;
                    }
                    break;
                case 2:
                    koeff = 2.35;
                    if (materialId == 1)
                    {
                        defect = 0.001;
                    }
                    else if (materialId == 2)
                    {
                        defect = 0.0095;
                    }
                    else if (materialId == 3)
                    {
                        defect = 0.0028;
                    }
                    else if (materialId == 4)
                    {
                        defect = 0.0055;
                    }
                    else if (materialId == 5)
                    {
                        defect = 0.0034;
                    }
                    break;
                case 3:
                    koeff = 1.5;
                    if (materialId == 1)
                    {
                        defect = 0.001;
                    }
                    else if (materialId == 2)
                    {
                        defect = 0.0095;
                    }
                    else if (materialId == 3)
                    {
                        defect = 0.0028;
                    }
                    else if (materialId == 4)
                    {
                        defect = 0.0055;
                    }
                    else if (materialId == 5)
                    {
                        defect = 0.0034;
                    }
                    break;
                case 4:
                    koeff = 5.15;
                    if (materialId == 1)
                    {
                        defect = 0.001;
                    }
                    else if (materialId == 2)
                    {
                        defect = 0.0095;
                    }
                    else if (materialId == 3)
                    {
                        defect = 0.0028;
                    }
                    else if (materialId == 4)
                    {
                        defect = 0.0055;
                    }
                    else if (materialId == 5)
                    {
                        defect = 0.0034;
                    }
                    break;
                default:
                    return -1; 
            }

            double allKolvoMaterial = (width * length * koeff * kolProd);
            double MaterialWithDefect = allKolvoMaterial + (allKolvoMaterial * defect);
            return Convert.ToInt32(Math.Ceiling(MaterialWithDefect));
        }

    }
}
