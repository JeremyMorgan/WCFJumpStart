using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Zza.Client.ZzaServices;

namespace Zza.Client
{
	class ZzaProxy : ClientBase<IZzaService>, IZzaService
	{
		public ZzaProxy(){ }

		public ZzaProxy(string endpointName) : base(endpointName)
		{
			//
		}

		public ZzaProxy(Binding binding, string address) : base(binding, new EndpointAddress(address))
		{
		}

		public System.Collections.ObjectModel.ObservableCollection<Entities.Product> GetProducts()
		{
			return Channel.GetProducts();
		}

		public Task<System.Collections.ObjectModel.ObservableCollection<Entities.Product>> GetProductsAsync()
		{
			return Channel.GetProductsAsync();
		}

		public System.Collections.ObjectModel.ObservableCollection<Entities.Customer> GetCustomers()
		{
			return Channel.GetCustomers();
		}

		public Task<System.Collections.ObjectModel.ObservableCollection<Entities.Customer>> GetCustomersAsync()
		{
			return Channel.GetCustomersAsync();
		}

		public void SubmitOrder(Entities.Order order)
		{
			Channel.SubmitOrder(order);
		}

		public Task SubmitOrderAsync(Entities.Order order)
		{
			return Channel.SubmitOrderAsync(order);
		}
	}
}
