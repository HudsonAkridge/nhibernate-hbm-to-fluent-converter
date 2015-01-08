using FluentNHibernate.Mapping;

namespace NHibernateHbmToFluent.Converter.Methods
{
    public class Access
    {
        private readonly CodeFileBuilder _builder;

        public Access(CodeFileBuilder builder)
        {
            _builder = builder;
        }

        public void Add(MappedPropertyInfo info)
        {
            var access = info.Access;
            if (access == null) return;

            switch (access)
            {
                case "field.camelcase-underscore":
                    _builder.AddLine(string.Format(".{0}.{1}()", FluentNHibernateNames.Access, FluentNHibernateNames.FieldCamelCaseUnderscore));
                    break;
                default:
                    _builder.AddLine(string.Format(".{0}.?", FluentNHibernateNames.Access));
                    break;
            }
        }

        public static class FluentNHibernateNames
        {
            public static string Access
            {
                get { return ReflectionUtility.GetPropertyName((IdentityPart ip) => ip.Access); }
            }

            public static string FieldCamelCaseUnderscore
            {
                get { return ReflectionUtility.GetMethodName((IdentityPart ip) => ip.Access.CamelCaseField()); }
            }
        }
    }
}