using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;

namespace Zza.Services
{
	[ServiceBehavior (InstanceContextMode = InstanceContextMode.PerCall)]
	public class ZzaService : IZzaService, IDisposable
	{
		readonly ZzaDbContext _Context = new ZzaDbContext();

		public List<Entities.Product> GetProducts()
		{
			return _Context.Products.ToList();
		}

		public List<Entities.Customer> GetCustomers()
		{
			return _Context.Customers.ToList();
		}

		[OperationBehavior(TransactionScopeRequired = true)]
		public void SubmitOrder(Entities.Order order)
		{
			_Context.Orders.Add(order);
			order.OrderItems.ForEach(oi => _Context.OrderItems.Add(oi));
			_Context.SaveChanges();
		}

		public void Dispose()
		{
			_Context.Dispose();
		}
	}
}
