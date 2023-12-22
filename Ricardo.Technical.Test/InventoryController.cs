using Microsoft.AspNetCore.Mvc;
using Ricardo.Plugins.Inventory.Interfaces;

namespace Ricardo.Technical.Test
{
	[ApiController]
	public class InventoryController : Controller
	{
		private readonly IInventoryServices _inventory;
		public InventoryController(IInventoryServices inventory)
		{
			_inventory = inventory;
		}
		[HttpGet("GetItems")]
		public IActionResult Get()
		{
			return Ok(_inventory.AllStock());
		}
	}
}
