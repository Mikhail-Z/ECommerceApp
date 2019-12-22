using ECommerceApp.DomainModel;
using ECommerceApp.Services;
using System;
using System.Collections.Generic;

namespace ECommerceApp
{
	class Program
	{
		static void Main(string[] args)
		{
			Customer customer = new Customer(
				"Петр", 
				"Петров", 
				null, 
				Sex.Male, 
				"+7 999 999 99 99", 
				"mike@xample.com", 
				"12345678");
			Author GregorHopp = new Author("Грегор", "ХопBo");
			Author BobbiWolf = new Author("Бобби", "Вульф");
			ISet<Author> authors = new HashSet<Author>() { GregorHopp, BobbiWolf };
			
			PublishingHouse williamsPublishing = new PublishingHouse("Вильямс");
			
			ProductCategory bookProductCategory = new ProductCategory("Книги", null);
			ProductCategory nonFictionProductCategory = 
				new ProductCategory("Нехудожественная литература", bookProductCategory);
			ProductCategory computerTechnologiesProductCategory =
				new ProductCategory("Компьютерные технологии", nonFictionProductCategory);
			
			Book book = new Book(
				"Шаблоны интеграции корпоративных приложений", authors, 
				williamsPublishing, Language.Russian, BookType.Paper, 
				BookCoverType.HardBack, 672,
				@"В данной книге исследуются стратегии интеграции корпоративных приложений с помощью 
механизмов обмена сообщениями. Авторы рассматривают шаблоны проектирования и приводят практические 
примеры интеграции приложений, демонстрирующие преимущества обмена сообщениями и эффективность решений, 
создаваемых на основе этой технологии. Каждый шаблон сопровождается описанием некоторой задачи 
проектирования, обсуждением исходных условий и представлением элегантного, сбалансированного решения. 
Авторы подчеркивают как преимущества, так и недостатки обмена сообщениями, 
а также дают практические советы по написанию кода подключения приложения к системе обмена сообщениями, 
маршрутизации сообщений и мониторинга состояния системы.Книга ориентирована на разработчиков программного 
обеспечения и системных интеграторов, использующих различные технологии и продукты для обмена сообщениями, 
такие как Java Message Service (JMS), Microsoft Message Queuing (MSMQ), IBM WebSphere MQ, 
Microsoft BizTalk, TIBCO, WebMethods, SeeBeyond, Vitria и др.", "978-5-907144-45-3",
				2019, new decimal(2829), DateTime.Now,
				computerTechnologiesProductCategory, true);
			Cart cart = new Cart(customer);
			cart.Add(book);
			cart.Add(book);
			var deliveryPoint = new DeliveryPoint("г. Рязань, ул. Новоселов, д. 49");
			var deliveryCost = DeliveryService.CalculateDeliveryCost(customer, cart.Products, deliveryPoint);
			Delivery delivery = new Delivery(
				deliveryPoint,
				deliveryCost,
				new DateTime(2019, 11, 26), 
				DeliveryType.PointOfIssue);
			Order order = new Order(cart, PaymentType.Cash, delivery);
			customer.UpdatePersonalData("Иван", "Иванов", Sex.Male, null);
			Payment payment = new Payment(order);
			//Через некоторое время после успешного взаимодействия со сторонними сервисами по оплате
			order.OrderStage = OrderStage.SuccessfullyMade;
			order.OrderStage = OrderStage.Packaging;
			order.OrderStage = OrderStage.DeliveredToDeliveryPoint;
			order.OrderStage = OrderStage.ReadyForDelivery;
			order.OrderStage = OrderStage.Issued;
		}
	}
}
