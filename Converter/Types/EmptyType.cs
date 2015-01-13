using NHibernateHbmToFluent.Converter.Extensions;

namespace NHibernateHbmToFluent.Converter.Types
{
    public class EmptyType : IMapStart
    {
        private readonly CodeFileBuilder _builder;

        public EmptyType(CodeFileBuilder builder)
        {
            _builder = builder;
        }

        public void Start(string prefix, MappedPropertyInfo item)
        {
            _builder.StartMethod(string.Empty, string.Empty);
        }
    }
}