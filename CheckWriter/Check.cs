using System;
using System.Collections.Generic;
using System.Text;

namespace CheckWriter {
    public class Check {

        #region Properties
        public string Name { get; set; } = "John A. Doe";
        public string Address { get; set; } = "123 Somewhere St\nACity, AState 12345";
        public string Phone { get; set; } = "(555) 555-1212";

        public static int Number { get; set; } = 2893;

        public string Payee {
            get { return _payee; }
            set {
                if (value.Length < 50) {
                    _payee = value;
                } else {
                    _payee = value.Substring(0, 50);
                }
            }
        }

        public decimal Amount {
            get { return _amount; }
            set {
                _amount = value;
                WrittenAmount = converter.PrintAmount();
            }
        }

        public string WrittenAmount { get; set; } = null;

        public string BankName { get; set; } = "Bank of America";
        public string BankNumber { get; set; } = "(888) 555-1212";
        public string BankURL { get; set; } = "www.bankofamerica.com";
        #endregion

        private string _payee = null;
        private decimal _amount = 0;
        NumberInWords converter = null;

        #region Ctors
        public Check() {
            converter = new NumberInWords();
        }

        public Check(string name, decimal amount) {
            Payee = name;
            converter = new NumberInWords() { Number = amount };
            Amount = amount;
        }

        public Check(string name, decimal amount, int number) {
            Payee = name;
            converter = new NumberInWords() { Number = amount };
            Amount = amount;
            Number = number;
        }
        #endregion

        public override string ToString() {

            int width = Console.WindowWidth / 2;

            StringBuilder _sb = new StringBuilder(new string('*', width) + "\n");

            int size = width - Name.Length - Number.ToString().Length - 2;              // 2 spaces after the check number
            string spaces = new string(' ', size);
            _sb.AppendLine($"{Name}{spaces}{Number++}");

            _sb.AppendLine($"{Address}");

            size = width - Phone.Length - 17;                                           // Date = 10 spaces + 3 spaces after date
            spaces = new string(' ', size);
            _sb.AppendLine($"{Phone}{spaces}{DateTime.Today.ToString("d")}\n");
            _sb.AppendLine("Pay to the");

            size = width - Payee.Length - $"{Amount:C}".Length - 14;                    //order of = 8 + 3 spaces before/after + 3 spaces after Amount
            spaces = new string(' ', size);
            _sb.AppendLine($"  order of {Payee}{spaces}{Amount:C}\n");

            size = width - WrittenAmount.Length - 13;                                   // Dollars = 7 + 2 spaces before/after dashes + 4 spaces after dollars
            string dashes = new string('-', size);
            _sb.AppendLine($"{WrittenAmount} {dashes} Dollars\n");

            _sb.AppendLine($"{BankName}");
            _sb.AppendLine($"{BankNumber}");
            _sb.AppendLine($"{BankURL}\n");

            _sb.Append($"For {new string('_', 20)}");
            _sb.Append($"{new string(' ', 10)}");
            _sb.AppendLine($"{new string('_', width - 36)}\n");                         // Diff of beginning of line + 2 spaces after signature line

            _sb.AppendLine(new string('*', width));
            return _sb.ToString();
        }
    }
}
