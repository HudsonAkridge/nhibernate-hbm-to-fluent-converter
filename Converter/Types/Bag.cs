using NHibernate.Cfg.MappingSchema;
using NHibernateHbmToFluent.Converter.Extensions;
using NHibernateHbmToFluent.Converter.Methods;
using NHibernateHbmToFluent.Converter.Methods.Join;

namespace NHibernateHbmToFluent.Converter.Types
{
	public class Bag : IMapStart
	{
		private readonly CodeFileBuilder _builder;
		private readonly OrderBy _orderBy;
		private readonly Cascade _cascade;
		private readonly Inverse _inverse;
		private readonly Table _table;
		private readonly KeyColumn _keyColumn;
		private readonly LazyLoad _lazyLoad;
        private readonly Access _access;

		public Bag(CodeFileBuilder builder)
		{
			_builder = builder;
            _orderBy = new OrderBy(_builder);
            _cascade = new Cascade(_builder);
            _inverse = new Inverse(_builder);
            _table = new Table(_builder);
            _keyColumn = new KeyColumn(_builder);
            _lazyLoad = new LazyLoad(_builder);
            _access = new Access(_builder);
		}

		public void Start(string prefix, MappedPropertyInfo item)
		{
			HbmBag bag = item.HbmObject<HbmBag>();
			PropertyMappingType subType = new MappedPropertyInfo(bag.Item, item.FileName).Type;
			if (subType == PropertyMappingType.ManyToMany)
			{
				_builder.StartMethod(prefix, string.Format("{0}<{1}>(x => x.{2})", FluentNHibernateNames.HasManyToMany, item.ReturnType, item.Name));
			}
			else if (subType == PropertyMappingType.OneToMany)
			{
				_builder.StartMethod(prefix, string.Format("{0}<{1}>(x => x.{2})", FluentNHibernateNames.HasMany, item.ReturnType, item.Name));
			}
			else
			{
				_builder.StartMethod(prefix, "bag?(x => x" + item.Name + ")");
			}
			_builder.AddLine(string.Format(".{0}()", FluentNHibernateNames.AsBag));
			_keyColumn.Add(bag.inverse, item.ExplicitColumnName, subType);
            _access.Add(item);
            _lazyLoad.Add(bag.lazySpecified, bag.lazy);
			_table.Add(bag.table);
			_inverse.Add(bag.inverse);
			_cascade.Add(bag.cascade);
			_orderBy.Add(bag.orderby);
		}

		public static class FluentNHibernateNames
		{
			public static string HasManyToMany
			{
				get { return ReflectionUtility.GetMethodName((FakeMap f) => f.HasManyToMany<string>(x => x)); }
			}

			public static string HasMany
			{
				get { return ReflectionUtility.GetMethodName((FakeMap f) => f.HasMany<string>(x => x)); }
			}

			public static string AsBag
			{
				get { return ReflectionUtility.GetMethodName((FakeMap f) => f.HasMany<string>(x => x).AsBag()); }
			}
		}
	}
}