using NHibernateHbmToFluent.Converter.Extensions;

namespace NHibernateHbmToFluent.Converter.Types
{
    public class Unknown : IMapStart
    {
        private readonly CodeFileBuilder _builder;

        public Unknown(CodeFileBuilder builder)
        {
            _builder = builder;
        }

        public void Start(string prefix, MappedPropertyInfo item)
        {
            _builder.StartMethod(prefix, string.Format("Unknown(x => x.{0},)", item.Name));
        }
    }
}