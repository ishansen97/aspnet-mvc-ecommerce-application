using ETicketsStore.Data.Base;
using ETicketsStore.Data.Services.ServiceContracts;
using ETicketsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketsStore.Data.Services
{
	public class ProducerService : EntityBaseRepository<Producer>, IProducerService
	{
		public ProducerService(AppDbContext context) : base(context)
		{
		}
	}
}
