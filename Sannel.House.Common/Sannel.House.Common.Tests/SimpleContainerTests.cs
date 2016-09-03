using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sannel.House.Common;

namespace Sannel.House.Common.Tests
{
	[TestClass]
	public class SimpleContainerTests
	{
		[TestMethod]
		public void SingletonTest()
		{
			SimpleContainer sc = new SimpleContainer();
			sc.Singleton<Test1>();
			var result = sc.GetInstance<Test1>();
			Assert.IsNotNull(result);

			var result2 = sc.GetInstance<Test1>();
			Assert.IsNotNull(result2);
			Assert.AreEqual(result, result2);

			sc.Singleton<ITest2, Test2>();
			var result3 = sc.GetInstance<ITest2>();
			Assert.IsNotNull(result3);
			Assert.IsInstanceOfType(result3, typeof(ITest2));
			Assert.IsInstanceOfType(result3, typeof(Test2));
			Assert.AreNotEqual(result2, result3);

			var result4 = sc.GetInstance<Test2>();
			Assert.IsNotNull(result4);
			Assert.IsInstanceOfType(result4, typeof(ITest2));
			Assert.IsInstanceOfType(result4, typeof(Test2));
			Assert.AreEqual(result3, result4);



			sc.Singleton<ITest4, Test4>();
			ITest4 result5;
			bool thrown = false;
			try
			{
				result5 = sc.GetInstance<ITest4>();
			}
			catch (TypeLoadException)
			{
				thrown = true;
			}

			Assert.IsTrue(thrown);
			sc.Singleton<ITest3, Test3>();

			result5 = sc.GetInstance<ITest4>();

			Assert.IsNotNull(result5);
			Assert.IsInstanceOfType(result5, typeof(ITest4));
			Assert.IsInstanceOfType(result5, typeof(Test4));
			Assert.IsNotNull(result5.Test3);
			Assert.IsInstanceOfType(result5.Test3, typeof(ITest3));
			Assert.IsInstanceOfType(result5.Test3, typeof(Test3));
		}

		[TestMethod]
		public void PerRequestTest()
		{
			SimpleContainer sc = new SimpleContainer();
			sc.PerRequest<Test1>();
			var result1 = sc.GetInstance<Test1>();
			Assert.IsNotNull(result1);

			var result1a = sc.GetInstance<Test1>();
			Assert.IsNotNull(result1a);
			Assert.AreNotEqual(result1, result1a);

			bool thrown = false;
			try
			{
				var result2 = sc.GetInstance<Test2>();
			}
			catch(TypeLoadException)
			{
				thrown = true;
			}
			Assert.IsTrue(thrown);


			sc.PerRequest<ITest3, Test3>();
			var result3 = sc.GetInstance<ITest3>();
			Assert.IsNotNull(result3);
			Assert.IsInstanceOfType(result3, typeof(ITest3));
			Assert.IsInstanceOfType(result3, typeof(Test3));

			var result4 = sc.GetInstance<Test3>();
			Assert.IsNotNull(result4);
			Assert.IsInstanceOfType(result4, typeof(ITest3));
			Assert.IsInstanceOfType(result4, typeof(Test3));

			sc.PerRequest<ITest4, Test4>();
			var result5 = sc.GetInstance<ITest4>();
			Assert.IsNotNull(result5);
			Assert.IsInstanceOfType(result5, typeof(ITest4));
			Assert.IsInstanceOfType(result5, typeof(Test4));
			Assert.IsNotNull(result5.Test3);
			Assert.IsInstanceOfType(result5.Test3, typeof(ITest3));
			Assert.IsInstanceOfType(result5.Test3, typeof(Test3));

		}

		[TestMethod]
		public void InstanceTest()
		{
			SimpleContainer sc = new SimpleContainer();
			ITest1 ti = new Test1();
			sc.Instance<ITest1, Test1>(ti);
			var result = sc.GetInstance<ITest1>();
			Assert.AreEqual(result, ti);
			var result2 = sc.GetInstance<Test1>();
			Assert.AreEqual(result2, ti);

			Test2 t2 = new Test2();
			sc.Instance(t2);
			var result3 = sc.GetInstance<Test2>();
			Assert.AreEqual(result3, t2);

			Test3 t3 = new Tests.Test3();
			sc.Instance<ITest3>(t3);
			var result4 = sc.GetInstance<ITest3>();
			Assert.AreEqual(result4, t3);
		}

		[TestMethod]
		public void HandlerTest()
		{
			SimpleContainer sc = new SimpleContainer();
			ITest1 t1 = null;
			sc.Handler<ITest1>((i) =>
			{
				Assert.AreEqual(sc, i);
				t1 = new Test1();
				return t1;
			});

			var result1 = sc.GetInstance<ITest1>();
			Assert.IsNotNull(t1);
			Assert.IsNotNull(result1);
			Assert.AreEqual(t1, result1);

			Test2 t2 = null;
			sc.Handler<ITest2, Test2>(i =>
			{
				Assert.AreEqual(sc, i);
				t2 = new Test2();
				return t2;
			});

			var result2 = sc.GetInstance<ITest2>();
			Assert.IsNotNull(t2);
			Assert.IsNotNull(result2);
			Assert.AreEqual(t2, result2);

			result2 = sc.GetInstance<Test2>();
			Assert.IsNotNull(result2);
			Assert.AreEqual(t2, result2);
		}
	}
}
