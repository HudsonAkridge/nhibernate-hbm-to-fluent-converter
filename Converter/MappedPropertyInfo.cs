using System;
using System.IO;

namespace NHibernateHbmToFluent.Converter
{
    public class MappedPropertyInfo
    {
        private readonly object _hbmObject;

        private int? _maxLength;
        private bool _hasMaxLength;
        private bool _hasNullability;
        private bool? _canBeNull;
        private string _returnType;
        private bool? _isUnique;
        private bool _hasIsUnique;
        private string _uniqueIndex;
        private string _columnType;

        public MappedPropertyInfo(object nhibernateObject, string fileName)
        {
            _hbmObject = nhibernateObject;
            FileName = fileName;
            var extension = Path.GetExtension(nhibernateObject.GetType().FullName);
            if (extension == null) throw new InvalidOperationException("Cannot create mapped property info for invalid type.");

            var type = extension.Substring(1);
            Type = PropertyMappingType.GetByHbmTypeName(type);

            Name = Type.GetPropertyName(_hbmObject);

            ExplicitColumnName = Type.GetExplicitColumnName(_hbmObject);
            HasExplicitColumnName = !string.IsNullOrEmpty(ExplicitColumnName);

            Access = Type.GetAccess(_hbmObject);
        }

        public T HbmObject<T>()
        {
            return (T)_hbmObject;
        }

        public string Name { get; private set; }
        public string ExplicitColumnName { get; private set; }
        public bool HasExplicitColumnName { get; private set; }
        public string Access { get; private set; }

        public int? MaxLength
        {
            get
            {
                if (_hasMaxLength) return _maxLength;
                _maxLength = Type.GetMaxLength(_hbmObject);

                _hasMaxLength = true;
                return _maxLength;
            }
        }

        public bool? CanBeNull
        {
            get
            {
                if (_hasNullability) return _canBeNull;
                _canBeNull = Type.GetNullability(_hbmObject);
                _hasNullability = true;
                return _canBeNull;
            }
        }

        public string ReturnType
        {
            get { return _returnType ?? (_returnType = Type.GetReturnType(_hbmObject)); }
        }

        public bool? IsUnique
        {
            get
            {
                if (_hasIsUnique) return _isUnique;
                _isUnique = Type.GetIsUnique(_hbmObject);
                _hasIsUnique = true;
                return _isUnique;
            }
        }

        public PropertyMappingType Type { get; private set; }

        public string SqlType
        {
            get { return _columnType ?? (_columnType = Type.GetColumnType(_hbmObject)); }
        }

        public string UniqueIndex
        {
            get { return _uniqueIndex ?? (_uniqueIndex = Type.GetUniqueIndex(_hbmObject)); }
        }

        public string FileName { get; private set; }
    }
}