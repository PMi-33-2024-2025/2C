using _2C.BusinessLogic.Services;
using _2C.DataAccess;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2C.BusinessLogic.Tests
{
	[TestFixture]
	public class ProductServiceTests
	{
		private IProductService service;
		[SetUp]
		public void SetUp()
		{
			service = new ProductService(new Mock<_2CDbContext>().Object);

		}
	}
}
