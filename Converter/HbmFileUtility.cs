using System;
using System.IO;
using System.Text;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Util;

namespace NHibernateHbmToFluent.Converter
{
    public static class HbmFileUtility
    {
        public const string NHibernateFileExtension = ".hbm.xml";

        public static void LoadFile(string nhibernateFilePath, string mapDirectory, string nameSpace)
        {
            var parser = new MappingDocumentParser();
            HbmMapping mapping;

            try
            {
                using (FileStream stream = File.OpenRead(nhibernateFilePath))
                {
                    mapping = parser.Parse(stream);
                }
            }
            catch (Exception)
            {
                Console.WriteLine(nhibernateFilePath);
                throw;
            }

            if (mapping.Items.Length <= 0)
            {
                throw new ParserException("NHibernate file has NO data: " + nhibernateFilePath);
            }

            foreach (var item in mapping.Items)
            {

                var classInfo = new MappedClassInfo((HbmClass)item, nhibernateFilePath);

                var classNameAndNamespace = classInfo.ClassName;
                var dotLoc = classNameAndNamespace.LastIndexOf('.');
                var className = classNameAndNamespace;
                if (dotLoc != -1)
                {
                    className = className.Substring(dotLoc + 1);
                }
                var classMapName = className + "Map";
                var result = MappingConverter.Convert(classMapName, classInfo, nameSpace);
                File.WriteAllText(Path.Combine(mapDirectory, classMapName + ".cs"), result);
            }
        }

        public static MappedClassInfo LoadFromString(string hbmData)
        {
            var parser = new MappingDocumentParser();
            var stream = new MemoryStream(Encoding.ASCII.GetBytes(hbmData));
            var mapping = parser.Parse(stream);

            if (mapping.Items.Length != 1)
            {
                throw new ParserException("NO data in: " + hbmData);
            }

            MappedClassInfo classInfo = new MappedClassInfo((HbmClass)mapping.Items[0], "from text");
            return classInfo;
        }
    }
}