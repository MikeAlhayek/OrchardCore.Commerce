using Money.Abstractions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Money;

internal static class KnownCurrencyTable
{
    private static readonly object _lockObject = new();

    internal static IDictionary<string, ICurrency> CurrencyTable { get; private set; }

    internal static void EnsureCurrencyTable()
    {
        if (CurrencyTable == null) InitCurrencyCodeTable();
    }

    private sealed class CurrencyEqualityComparer : IEqualityComparer<ICurrency>
    {
        public bool Equals(ICurrency left, ICurrency right) =>
            (left is null && right is null) ||
            StringComparer.OrdinalIgnoreCase.Equals(left?.CurrencyIsoCode, right?.CurrencyIsoCode);

        public int GetHashCode(ICurrency obj) => StringComparer.OrdinalIgnoreCase.GetHashCode(obj.CurrencyIsoCode);
    }

    private static void InitCurrencyCodeTable()
    {
        static bool IsValid(CultureInfo cultureInfo) =>
            !cultureInfo.IsNeutralCulture &&
            !cultureInfo.EnglishName.StartsWith("Unknown Locale", StringComparison.Ordinal) &&
            !cultureInfo.EnglishName.StartsWith("Invariant Language", StringComparison.Ordinal);

        lock (_lockObject)
        {
            CurrencyTable = CultureInfo.GetCultures(CultureTypes.AllCultures)
                .Where(IsValid)
                .Select(c => new Currency(c))
                .Cast<ICurrency>()
                .Distinct(new CurrencyEqualityComparer())
                .ToDictionary(k => k.CurrencyIsoCode, e => e);

            CurrencyTable.Add("BTC", new Currency("BitCoin", "BitCoin", "₿", "BTC", 8));
            CurrencyTable.Add("---", Currency.UnspecifiedCurrency);
        }
    }

    internal static ICurrency FromIsoCode(string isoCode)
    {
        EnsureCurrencyTable();
        return CurrencyTable[isoCode];
    }
}
