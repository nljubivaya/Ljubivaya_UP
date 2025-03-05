using MaterialCalculation;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {

        private Class1 _calculator;

        [TestInitialize]
        public void Setup()
        {
            _calculator = new Class1();
        }
        //Проверяет, что метод возвращает -1, если количество продукта равно 0
        [TestMethod]
        public void Test_ZeroCount_ReturnsMinusOne()
        {
            int result = _calculator.MaterialCalculator(1, 1, 0, 2.0f, 3.0f);
            Assert.AreEqual(-1, result);
        }
        //Проверяет, что метод возвращает -1, если ширина отрицательная.
        [TestMethod]
        public void Test_NegativeWidth_ReturnsMinusOne()
        {
            int result = _calculator.MaterialCalculator(1, 1, 10, -2.0f, 3.0f);
            Assert.AreEqual(-1, result);
        }
        //Проверяет, что метод возвращает -1, если длина отрицательная
        [TestMethod]
        public void Test_NegativeLength_ReturnsMinusOne()
        {
            int result = _calculator.MaterialCalculator(1, 1, 10, 2.0f, -3.0f);
            Assert.AreEqual(-1, result);
        }
        // Проверяет, что метод возвращает -1, если идентификатор продукта неизвестен
        [TestMethod]
        public void Test_UnknownProduct_ReturnsMinusOne()
        {
            int result = _calculator.MaterialCalculator(5, 1, 10, 2.0f, 3.0f);
            Assert.AreEqual(-1, result);
        }
        //Проверяет, что метод возвращает -1, если ширина и длина равны 0
        [TestMethod]
        public void Test_ZeroWidthAndLength_ReturnsMinusOne()
        {
            int result = _calculator.MaterialCalculator(1, 1, 10, 0.0f, 0.0f);
            Assert.AreEqual(-1, result); 
        }
        //Проверяет корректный расчет для продукта 1 и материала 1
        [TestMethod]
        public void Test_CorrectInput_Product1_Material1()
        {
            int result = _calculator.MaterialCalculator(1, 1, 10, 2.0f, 3.0f);
            Assert.AreEqual(261, result); 
        }
        // Проверяет корректный расчет для продукта 3 и материала 3
        [TestMethod]
        public void Test_CorrectInput_Product3_Material3()
        {
            int result = _calculator.MaterialCalculator(3, 3, 8, 1.0f, 1.0f);
            Assert.AreEqual(13, result); 
        }
        // Проверяет корректный расчет для продукта 3 и материала 1
        [TestMethod]
        public void Test_CorrectInput_Product3_Material1()
        {
            int result = _calculator.MaterialCalculator(3, 1, 20, 0.5f, 1.0f);
            Assert.AreEqual(16, result); 
        }
        //Проверяет корректный расчет для большого количества продукта 1 и материала 1
        [TestMethod]
        public void Test_LargeQuantity()
        {
            int result = _calculator.MaterialCalculator(1, 1, 1000, 2.0f, 2.0f); 
            Assert.AreEqual(17378, result); 
        }
        //Проверяет, что метод возвращает -1, если количество продукта отрицательное
        [TestMethod]
        public void Test_NegativeQuantity()
        {
            int result = _calculator.MaterialCalculator(1, 1, -5, 2.0f, 2.0f);
            Assert.AreEqual(-1, result);
        }

        //сложные тесты
        // Проверяет метод с небольшими размерами и низкими коэффициентами.
        [TestMethod]
        public void Test_SmallValues()
        {
            int result = _calculator.MaterialCalculator(2, 3, 1, 0.01f, 0.01f);
             double expected = (0.01 * 0.01 * 2.35 * 1) + ((0.01 * 0.01 * 2.35 * 1) * 0.0028);
            Assert.AreEqual(Convert.ToInt32(Math.Ceiling(expected)), result);
        }
        // Проверяет метод с дробными значениями для коэффициентов.
        [TestMethod]
        public void Test_FractionalProductCount()
        {
            int result = _calculator.MaterialCalculator(1, 1, 1, 2.5f, 3.5f);
            double expected = (2.5 * 3.5 * 4.34 * 1) + ((2.5 * 3.5 * 4.34 * 1) * 0.001);
            Assert.AreEqual(Convert.ToInt32(Math.Ceiling(expected)), result);
        }
        // Проверяет метод с большими размерами и высоким коэффициентом.
        [TestMethod]
        public void Test_LargeDimensionsWithHighCoefficient()
        {
            int result = _calculator.MaterialCalculator(100, 200, 50, 10.0f, 10000.0f);
            double expected = (100 * 200 * 10.0 * 50) + ((100 * 200 * 10.0 * 50) * 0.0095);
            Assert.AreNotEqual(Convert.ToInt32(Math.Ceiling(expected)), result);
        }
        // Проверяет метод с валидными входными данными и высоким дефектом.
        [TestMethod]
        public void Test_ValidInputWithHighDefect()
        {
            int result = _calculator.MaterialCalculator(4, 5, 10, 5.0f, 5.0f);
            double expected = (5 * 5 * 5.15 * 10) + ((5 * 5 * 5.15 * 10) * 0.0034);
            Assert.AreEqual(Convert.ToInt32(Math.Ceiling(expected)), result);
        }
        // Проверяет метод с небольшими размерами и высоким дефектом.
        [TestMethod]
        public void Test_SmallProductCountWithHighDefect()
        {
            int result = _calculator.MaterialCalculator(1, 4, 1, 1.0f, 1.0f);
            double expected = (1 * 1 * 4.34 * 1) + ((1 * 1 * 4.34 * 1) * 0.0055);
            Assert.AreEqual(Convert.ToInt32(Math.Ceiling(expected)), result);
        }
    }
}