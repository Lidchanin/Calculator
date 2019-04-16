using System;
using SQLite;

namespace Calculator.Models
{
    public class CalculatorItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Expression { get; set; }

        public string Result { get; set; }

        public DateTime CalculationTime { get; set; }
    }
}