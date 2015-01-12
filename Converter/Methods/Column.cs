using FluentNHibernate.Mapping;

namespace NHibernateHbmToFluent.Converter.Methods
{
	public class Column : ICommonMapMethod
	{
		private readonly CodeFileBuilder _builder;

		public Column(CodeFileBuilder builder)
		{
			_builder = builder;
		}

		public void Add(MappedPropertyInfo item)
		{
			if (item.PropertyMappingType == PropertyMappingType.Component ||
			    item.PropertyMappingType == PropertyMappingType.Property ||
			    item.PropertyMappingType == PropertyMappingType.Set ||
			    item.PropertyMappingType == PropertyMappingType.Bag)
			{
				return;
			}
			if (item.ExplicitColumnName != null)
			{
				_builder.AddLine(string.Format(".{0}(\"{1}\")", FluentNHibernateNames.Column, item.ExplicitColumnName));
			}
		}

		public static class FluentNHibernateNames
		{
			public static string Column
			{
				get { return ReflectionUtility.GetMethodName((IdentityPart ip) => ip.Column(null)); }
			}
		}
	}
}