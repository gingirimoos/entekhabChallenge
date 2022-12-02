namespace Infrastructure.Interfaces
{
    public interface IPaymnetCalculator
    {
        double CalcurlatorA(double basicSalary, double allowance);

        double CalcurlatorB(double basicSalary, double allowance);

        double CalcurlatorC(double basicSalary, double allowance);
    }
}