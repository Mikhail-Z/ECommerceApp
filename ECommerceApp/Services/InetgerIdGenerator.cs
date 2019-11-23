using System.Threading;

namespace ECommerceApp.Services
{
	public static class LongIdGenerator
	{
		private static int _id;

		public static long Increment()
		{
			return Interlocked.Increment(ref _id);
		}
	}
}
