using Microsoft.AspNetCore.Components;
using Ricardo.Models;

namespace Ricardo.Technical.Test.Pages.Components
{
    public partial class BasketItems
    {
	    [CascadingParameter] private Basket Basket { get; set; } = default!;
    }
}
