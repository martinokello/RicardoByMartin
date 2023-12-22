﻿using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Ricardo.Models;

namespace Ricardo.Technical.Test.Pages
{
	public partial class Browse
	{
		private readonly List<ToastMessage> _messages = new();
		private IEnumerable<Item> _stock = new List<Item>();
		[Inject] private HttpClient HttpClient { get; set; } = default!;

		protected override async Task OnInitializedAsync()
		{
			var response = await HttpClient.GetAsync("GetItems");
			var data = await response.Content.ReadAsStringAsync();
			_stock = JsonConvert.DeserializeObject<List<Item>>(data)!;
			await base.OnInitializedAsync();
		}

		public void ItemAdded(Item item)
		{
			_messages.Add(new ToastMessage(ToastType.Success, $"{item.Name} added to basket." ));
		}

	}
}
