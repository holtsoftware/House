using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;

namespace Sannel.House
{
	/// <summary>
	/// </summary>
	public class SimpleContainer
	{
		private IDictionary<Type, TypeEntry> types = new Dictionary<Type, TypeEntry>();
		private IDictionary<Type, Object> singletons = new Dictionary<Type, Object>();

		/// <summary>
		/// Initializes a new instance of the <see cref="SimpleContainer"/> class.
		/// </summary>
		public SimpleContainer()
		{
			Instance(this);
		}

		/// <summary>
		/// Registers a Singleton
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public void Singleton<T>()
			where T : class
		{
			types[typeof(T)] = new TypeEntry
			{
				CreateType = CreateType.Singleton,
				Type = typeof(T)
			};
		}

		/// <summary>
		/// Registers a Singleton
		/// </summary>
		/// <typeparam name="I"></typeparam>
		/// <typeparam name="T"></typeparam>
		public void Singleton<I, T>()
			where T : class, I
		{
			var tc = new TypeEntry
			{
				CreateType = CreateType.Singleton,
				Type = typeof(T)
			};
			types[typeof(T)] = tc;
			types[typeof(I)] = tc;
		}

		/// <summary>
		/// Registers a PerRequest type
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public void PerRequest<T>()
			where T : class
		{
			var tc = new TypeEntry
			{
				CreateType = CreateType.PerRequest,
				Type = typeof(T)
			};
			types[typeof(T)] = tc;
		}

		/// <summary>
		/// Registers a PerRequest type
		/// </summary>
		/// <typeparam name="I"></typeparam>
		/// <typeparam name="T"></typeparam>
		public void PerRequest<I, T>()
			where T : class, I
		{
			var tc = new TypeEntry
			{
				CreateType = CreateType.PerRequest,
				Type = typeof(T)
			};
			types[typeof(T)] = tc;
			types[typeof(I)] = tc;
		}

		/// <summary>
		/// Instances the specified instance.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="instance">The instance.</param>
		/// <exception cref="ArgumentNullException"></exception>
		public void Instance<T>(T instance)
			where T : class
		{
			if(instance == null)
			{
				throw new ArgumentNullException(nameof(instance));
			}
			var tc = new TypeEntry
			{
				CreateType = CreateType.Singleton,
				Type = typeof(T)
			};
			types[typeof(T)] = tc;
			singletons[typeof(T)] = instance;
		}

		/// <summary>
		/// Instances the specified instance.
		/// </summary>
		/// <typeparam name="I"></typeparam>
		/// <typeparam name="T"></typeparam>
		/// <param name="instance">The instance.</param>
		/// <exception cref="System.ArgumentNullException"></exception>
		public void Instance<I, T>(I instance)
			where T : class, I
		{
			if(instance == null)
			{
				throw new ArgumentNullException(nameof(instance));
			}
			var tc = new TypeEntry
			{
				CreateType = CreateType.Singleton,
				Type = typeof(T)
			};
			types[typeof(T)] = tc;
			types[typeof(I)] = tc;
			singletons[tc.Type] = instance;
		}

		/// <summary>
		/// Allows you to register a method to call to create the type.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="handler">The handler.</param>
		/// <exception cref="System.ArgumentNullException"></exception>
		public void Handler<T>(Func<SimpleContainer, T> handler)
			where T : class
		{
			if(handler == null)
			{
				throw new ArgumentNullException(nameof(handler));
			}
			var tc = new TypeEntry
			{
				CreateType = CreateType.Handler,
				Type = typeof(T),
				Handler = handler
			};
			types[typeof(T)] = tc;
		}

		/// <summary>
		/// Allows you to register a method to call to create the type.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="handler">The handler.</param>
		/// <exception cref="System.ArgumentNullException"></exception>
		public void Handler<I, T>(Func<SimpleContainer, T> handler)
			where T : class, I
		{
			if(handler == null)
			{
				throw new ArgumentNullException(nameof(handler));
			}
			var tc = new TypeEntry
			{
				CreateType = CreateType.Handler,
				Type = typeof(T),
				Handler = handler
			};
			types[typeof(T)] = tc;
			types[typeof(I)] = tc;
		}

		private Object createInstance(Type t)
		{
			foreach(var c in t.GetTypeInfo().DeclaredConstructors)
			{
				if (c.IsPublic)
				{
					List<Object> obj = new List<object>();
					foreach(var p in c.GetParameters())
					{
						var i = GetInstance(p.ParameterType);
						obj.Add(i);
					}

					return c.Invoke(obj.ToArray());
				}
			}
			throw new TypeLoadException($"Unable to find constructor for type {t.FullName}");
		}

		/// <summary>
		/// Gets the instance of the <typeparamref name="T"/>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public T GetInstance<T>()
		{
			return (T)GetInstance(typeof(T));
		}

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		public Object GetInstance(Type type)
		{ 
			if (types.ContainsKey(type))
			{
				var r = types[type];
				if(r.CreateType == CreateType.PerRequest)
				{
					return createInstance(r.Type);
				}
				else if(r.CreateType == CreateType.Singleton)
				{
					Object t;
					if(singletons.TryGetValue(r.Type, out t))
					{
						return t;
					}
					else
					{
						var inst = createInstance(r.Type);
						singletons[r.Type] = inst;
						return inst;
					}
				}
				else if(r.CreateType == CreateType.Handler)
				{
					return r.Handler(this);
				}
			}
			throw new TypeLoadException($"Type {type.FullName} is not registered");
		}
	}
}