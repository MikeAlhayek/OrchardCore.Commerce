using OrchardCore.Commerce.Abstractions.Abstractions;
using OrchardCore.Commerce.MoneyDataType;
using System;
using System.Collections.Generic;

namespace OrchardCore.Commerce.Abstractions.Models;

public class OrderLineItem
{
    public int Quantity { get; set; }
    public string ProductSku { get; set; }
    public string FullSku { get; set; }
    public Amount UnitPrice { get; set; }
    public Amount LinePrice { get; set; }
    public string ContentItemVersion { get; set; }
    public ISet<IProductAttributeValue> Attributes { get; }
    public IDictionary<string, IDictionary<string, string>> SelectedAttributes { get; } =
        new Dictionary<string, IDictionary<string, string>>();

    // These are necessary.
#pragma warning disable S107 // Methods should not have too many parameters
    public OrderLineItem(
        int quantity,
        string productSku,
        string fullSku,
        Amount unitPrice,
        Amount linePrice,
        string contentItemVersion,
        IEnumerable<IProductAttributeValue> attributes = null,
        IDictionary<string, IDictionary<string, string>> selectedAttributes = null)
#pragma warning restore S107 // Methods should not have too many parameters
    {
        ArgumentNullException.ThrowIfNull(productSku);
        ArgumentOutOfRangeException.ThrowIfNegative(quantity);

        Quantity = quantity;
        ProductSku = productSku;
        FullSku = fullSku;
        UnitPrice = unitPrice;
        LinePrice = linePrice;
        ContentItemVersion = contentItemVersion;
        Attributes = attributes is null
            ? []
            : new HashSet<IProductAttributeValue>(attributes);
        SelectedAttributes.AddRange(selectedAttributes);
    }
}
