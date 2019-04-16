using Calculator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calculator.Data
{
    public interface ICalculatorDatabase
    {
        Task<List<CalculatorItem>> GetAll();

        Task<int> Insert(CalculatorItem item);

        Task<int> Delete(CalculatorItem item);

        Task<int> DeleteAll();
    }
}