using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Shared
{
    public partial class Constant
    {
        public static readonly string EmailRegex = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public static readonly char[] PhoneNumberSeparators = { '-', '/', '(', ')' };
        public static readonly string ZeroAmountWithDollarSymbol = $"${ZeroAmount}";
        public static readonly string ZeroAmount = "0.00";
        public static readonly string AdminRole = "Admin";
    }
}
