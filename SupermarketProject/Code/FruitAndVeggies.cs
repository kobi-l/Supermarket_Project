using SupermarketProject;

namespace SupemarketProject
{
    public class FruitAndVeggies : ProductAbstract
    {
        public double PoundsTotal { get; set; }
        public FruitAndVeggies(string productName, decimal productPrice, double poundsTotal = 1)
        {
            ProductName = productName;
            ProductPrice = productPrice;
            PoundsTotal = poundsTotal;
            ProductQuantity = 1;
        }

        public override decimal GetProductTotalPrice() => (decimal)PoundsTotal * ProductPrice;

        public override void QuantityUpdate(double newQuantity)
        {
            PoundsTotal += newQuantity;
        }

        public override double GetQuantity()
        {
            return PoundsTotal;
        }

        public override string GenerateItemLine() => $"{ProductName,-16}"
            + $"{PoundsTotal,5}lb" + $"{ProductPrice,12:C}";

        public override decimal GetProductTax() => .0M;
    }
}
