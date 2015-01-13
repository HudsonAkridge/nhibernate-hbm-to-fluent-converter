using System;
using JetBrains.Annotations;
using NHibernate.Cfg.MappingSchema;
using NHibernateHbmToFluent.Converter.Extensions;
using NHibernateHbmToFluent.Converter.Extensions.NHibernate;
using NHibernateHbmToFluent.Converter.Types;

namespace NHibernateHbmToFluent.Converter
{
    public class PropertyMappingType : NamedConstant<PropertyMappingType>
    {
        public static readonly PropertyMappingType Id = new PropertyMappingType(typeof(HbmId),
                                                                                "id",
                                                                                x => ((HbmId)x).GetPropertyName(),
                                                                                x => ((HbmId)x).GetColumnName(),
                                                                                      x => ((HbmId)x).GetAccess(),
                                                                                x => ((HbmId)x).GetMaxLength(),
                                                                                x => ((HbmId)x).CanBeNull(),
                                                                                x => ((HbmId)x).GetReturnType(),
                                                                                x => ((HbmId)x).IsUnique(),
                                                                                x => ((HbmId)x).GetUniqueIndex(),
                                                                                x => ((HbmId)x).GetSqlType(),
                                                                                (prefix, builder, item) => new Id(builder).Start(prefix, item));

        public static readonly PropertyMappingType Property = new PropertyMappingType(typeof(HbmProperty),
                                                                                      "property",
                                                                                      x => ((HbmProperty)x).GetPropertyName(),
                                                                                      x => ((HbmProperty)x).GetExplicitColumnName(),
                                                                                      x => ((HbmProperty)x).GetAccess(),
                                                                                      x => ((HbmProperty)x).GetMaxLength(),
                                                                                      x => ((HbmProperty)x).CanBeNull(),
                                                                                      x => ((HbmProperty)x).GetReturnType(),
                                                                                      x => ((HbmProperty)x).IsUnique(),
                                                                                      x => ((HbmProperty)x).GetUniqueIndex(),
                                                                                      x => ((HbmProperty)x).GetSqlType(),
                                                                                      (prefix, builder, item) => new Map(builder).Start(prefix, item));

        public static readonly PropertyMappingType ManyToOne = new PropertyMappingType(typeof(HbmManyToOne),
                                                                                       "many-to-one",
                                                                                       x => ((HbmManyToOne)x).GetPropertyName(),
                                                                                       x => ((HbmManyToOne)x).GetColumnName(),
                                                                                       x => ((HbmManyToOne)x).GetAccess(),
                                                                                       x => ((HbmManyToOne)x).GetMaxLength(),
                                                                                       x => ((HbmManyToOne)x).CanBeNull(),
                                                                                       x => ((HbmManyToOne)x).GetReturnType(),
                                                                                       x => ((HbmManyToOne)x).IsUnique(),
                                                                                       x =>
                                                                                       ((HbmManyToOne)x).GetUniqueIndex(),
                                                                                       x => ((HbmManyToOne)x).GetSqlType(),
                                                                                       (prefix, builder, item) => new References(builder).Start(prefix, item));

        public static readonly PropertyMappingType ManyToMany = new PropertyMappingType(typeof(HbmManyToMany),
                                                                                        "many-to-many",
                                                                                        null,
                                                                                        x =>
                                                                                        ((HbmManyToMany)x).GetColumnName(),
                                                                                        null,
                                                                                        x => null,
                                                                                        null,
                                                                                        x =>
                                                                                        ((HbmManyToMany)x).GetReturnType(),
                                                                                        null,
                                                                                        null,
                                                                                        null,
                                                                                        (prefix, builder, item) => builder.StartMethod(prefix, "?(x => x." + item.ReturnType + ")"));

        public static readonly PropertyMappingType OneToOne = new PropertyMappingType(typeof(HbmOneToOne),
                                                                                      "one-to-one",
                                                                                      null,
                                                                                      null,
                                                                                      null,
                                                                                      x => null,
                                                                                      null,
                                                                                      null,
                                                                                      null,
                                                                                      null,
                                                                                      null,
                                                                                      (prefix, builder, item) => builder.StartMethod(prefix, "?(x => x." + item.ReturnType + ")"));

        public static readonly PropertyMappingType OneToMany = new PropertyMappingType(typeof(HbmOneToMany),
                                                                                       "one-to-many",
                                                                                       null,
                                                                                       null,
                                                                                       null,
                                                                                       x => null,
                                                                                       null,
                                                                                       x => ((HbmOneToMany)x).GetReturnType(),
                                                                                       null,
                                                                                       null,
                                                                                       null,
                                                                                       (prefix, builder, item) => builder.StartMethod(prefix, "?(x => x." + item.ReturnType + ")"));

        public static readonly PropertyMappingType Set = new PropertyMappingType(typeof(HbmSet),
                                                                                 "set",
                                                                                 x => ((HbmSet)x).GetPropertyName(),
                                                                                 x => ((HbmSet)x).GetColumnName(),
                                                                                 x => ((HbmSet)x).GetAccess(),
                                                                                 x => null,
                                                                                 x => ((HbmSet)x).CanBeNull(),
                                                                                 x => ((HbmSet)x).GetReturnType(),
                                                                                 x => ((HbmSet)x).IsUnique(),
                                                                                 x => null,
                                                                                 x => "NUMBER",
                                                                                 (prefix, builder, item) => new Set(builder).Start(prefix, item));

        public static readonly PropertyMappingType Bag = new PropertyMappingType(typeof(HbmBag),
                                                                                 "bag",
                                                                                 x => ((HbmBag)x).GetPropertyName(),
                                                                                 x => ((HbmBag)x).GetColumnName(),
                                                                                      x => ((HbmBag)x).GetAccess(),
                                                                                 x => null,
                                                                                 x => ((HbmBag)x).CanBeNull(),
                                                                                 x => ((HbmBag)x).GetReturnType(),
                                                                                 x => ((HbmBag)x).IsUnique(),
                                                                                 x => null,
                                                                                 x => "NUMBER",
                                                                                 (prefix, builder, item) => new Bag(builder).Start(prefix, item));

        public static readonly PropertyMappingType Component = new PropertyMappingType(typeof(HbmComponent),
                                                                                       "component",
                                                                                       x =>
                                                                                       ((HbmComponent)x).GetPropertyName(),
                                                                                       null,
                                                                                       null,
                                                                                       x => null,
                                                                                       x => null,
                                                                                       x => ((HbmComponent)x).GetReturnType(),
                                                                                       x => null,
                                                                                       x => null,
                                                                                       null,
                                                                                       (prefix, builder, item) => new Component(builder).Start(prefix, item));

        public Type HbmType { get; private set; }
        public string XmlTagName { get; private set; }
        public Func<object, string> GetPropertyName { get; private set; }
        public Func<object, string> GetAccess { get; private set; }
        public Func<object, string> GetExplicitColumnName { get; private set; }
        public Func<object, int?> GetMaxLength { get; private set; }
        public Func<object, bool?> GetNullability { get; private set; }
        public Func<object, string> GetReturnType { get; private set; }
        public Func<object, bool?> GetIsUnique { get; private set; }
        public Func<object, string> GetUniqueIndex { get; private set; }
        public Func<object, string> GetColumnType { get; private set; }
        public Action<string, CodeFileBuilder, MappedPropertyInfo> StartMethod { get; set; }

        private PropertyMappingType(Type hbmType, string xmlTagName, Func<object, string> getPropertyName,
                                    Func<object, string> getExplicitColumnName, Func<object, string> getAccess, Func<object, int?> getMaxLength,
                                    Func<object, bool?> getNullability, Func<object, string> getReturnType,
                                    Func<object, bool?> getIsUnique, Func<object, string> getUniqueIndex,
                                    Func<object, string> getColumnType, Action<string, CodeFileBuilder, MappedPropertyInfo> startMethod)
        {
            HbmType = hbmType;
            XmlTagName = xmlTagName;
            GetPropertyName = getPropertyName;
            GetExplicitColumnName = getExplicitColumnName;
            GetAccess = getAccess;
            GetMaxLength = getMaxLength;
            GetNullability = getNullability;
            GetReturnType = getReturnType;
            GetIsUnique = getIsUnique;
            GetUniqueIndex = getUniqueIndex;
            GetColumnType = getColumnType;
            StartMethod = startMethod;
            Add(xmlTagName.ToLower(), this);
            Add(hbmType.Name.ToLower(), this);
        }

        [NotNull]
        public static PropertyMappingType GetByXmlTagName(string typeName)
        {
            var propertyMappingType = Get(typeName.ToLower());
            return propertyMappingType ?? BuildUnknownType(typeName);
        }

        public static PropertyMappingType GetByHbmTypeName(string hbmTypeName)
        {
            var propertyMappingType = Get(hbmTypeName.ToLower());
            return propertyMappingType ?? BuildUnknownType(hbmTypeName);
        }

        private static PropertyMappingType BuildUnknownType(string typeName)
        {
            return new PropertyMappingType(typeof(HbmComponent),
                typeName,
                x =>
                {
                    var name = "UnknownProp";
                    try
                    {
                        var methodInfo = x.GetType().GetMethod("GetPropertyName");
                        if (methodInfo != null)
                        {
                            name = methodInfo.Invoke(x, null).ToString();
                        }
                    }
                    catch (Exception)
                    {
                        //Intentionally suppress
                    }
                    return name;
                },
                x => "?",
                x => "?",
                x => int.MinValue,
                x => null,
                x => "?",
                x => null,
                x => "?",
                x => "?",
                (prefix, builder, item) => new Unknown(builder).Start(typeName, item));
        }

        private static PropertyMappingType BuildEmptyType(string typeName)
        {
            return new PropertyMappingType(typeof(HbmComponent),
                typeName,
                x => string.Empty,
                x => string.Empty,
                x => string.Empty,
                x => int.MinValue,
                x => null,
                x => string.Empty,
                x => null,
                x => string.Empty,
                x => string.Empty,
                (prefix, builder, item) => new EmptyType(builder).Start(typeName, item));
        }
    }
}