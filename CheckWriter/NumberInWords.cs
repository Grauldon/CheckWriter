using System;
using System.Text;

namespace CheckWriter {
    public class NumberInWords {

        public decimal Number {
            get { return _number; }
            set {
                if (value < _maxNumber) {
                    _number = value;
                } else {
                    throw new Exception($"Maximum allowed number is {_maxNumber:n}.");
                }
            }
        }

        private const decimal _maxNumber = 999999999999999999;
        private decimal _number = 1;

        private StringBuilder _sb = new StringBuilder();

        string[] _ones = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        string[] _tens = { "DoNotUse", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        string[] _teens = { "DoNotUse", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        const string _hundreds = "hundred";
        string[] _powers = { "DoNotUse", "thousand", "million", "billion", "trillion" , "quadrillion" };

        public string PrintAmount() {

            var _cents = (int)((Number % 1) * 100);

            if (Number > 0.99m) {
                StringBuilder _sb = new StringBuilder(PrintWords(Number, 0));
                _sb.Append($"and {_cents:D2}/100");
                return _sb.ToString();
            } else {
                return $"Zero and {_cents:D2}/100";
            }

        }

        private string PrintWords(decimal num, int level) {

            if (num >= 1000) {
                PrintWords(num / 1000, level + 1);
            }

            int _number = (int)num;
            int _thousand = Math.DivRem(_number, 1000, out int _thousandRemainder);
            int _hundred = Math.DivRem(_thousandRemainder, 100, out int _hundredRemainder);
            int _ten = Math.DivRem(_hundredRemainder, 10, out int _one);

            if (_hundred > 0) {
                _sb.Append($"{FirstLetter(_ones[_hundred])} {NumberInWords._hundreds} ");
            }

            if (_ten != 0) {
                if (_ten > 1) {
                    _sb.Append($"{FirstLetter(_tens[_ten])}");

                    if (_one != 0) {
                        _sb.Append($"-{FirstLetter(_ones[_one])} ");
                    }
                } else {
                    if (_one == 0) {
                        _sb.Append($"{FirstLetter(_tens[_one])} ");
                    } else {
                        _sb.Append($"{FirstLetter(_teens[_one])} ");
                    }
                }
            } else if (_one != 0) {
                _sb.Append($"{FirstLetter(_ones[_one])} ");
            }

            if (level > 0) {
                _sb.Append($"{_powers[level]} ");
            } 

            return _sb.ToString();
        }

        private string FirstLetter(string word) {

            if (_sb.Length == 0) {
                return word.Substring(0, 1).ToUpper() + word.Substring(1);
            }

            return word;
        }
    }
}
