using OrchardCore.Security.Permissions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrchardCore.Commerce;

public class Permissions : IPermissionProvider
{
    public static readonly Permission ManageCommerceSettings = new("ManageCommerceSettings", "Manage Commerce Settings");
    public static readonly Permission ManageStripeApiSettings = new("ManageStripeApiSettings", "Manage Stripe API Settings");
    public static readonly Permission ManageRegionSettings = new("ManageRegionSettings", "Manage Region Settings");
    public static readonly Permission Checkout = new("Checkout", "Ability to checkout");

    public Task<IEnumerable<Permission>> GetPermissionsAsync() =>
        Task.FromResult<IEnumerable<Permission>>(new[] { ManageCommerceSettings, ManageStripeApiSettings, Checkout, ManageRegionSettings });

    public IEnumerable<PermissionStereotype> GetDefaultStereotypes() =>
        new[]
        {
            new PermissionStereotype
            {
                Name = "Administrator",
                Permissions = new[] { ManageCommerceSettings, ManageStripeApiSettings, Checkout, ManageRegionSettings },
            },
        };
}
