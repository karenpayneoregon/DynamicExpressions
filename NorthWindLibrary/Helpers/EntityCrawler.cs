using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindLibrary.Helpers
{
    public class EntityCrawler
    {
        private IEnumerable<EntityType> _entityTypesData;

        private string[] _tableNames;
        /// <summary>
        /// Container for tables names in a Entity Framework model
        /// </summary>
        public string[] TableNames => _tableNames;

        public string EnityModelName { get; set; }
        /// <summary>
        /// Container for a single entity, columns and keys
        /// </summary>
        public List<TableInformation> TableInformation { get; set; }
        /// <summary>
        /// Assembly for Entity Framework project
        /// </summary>
        public string AssembleName { get; set; }
        /// <summary>
        /// DbContext
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// Setup for code first, EDMX will be different
        /// </summary>
        public EntityCrawler()
        {
            EnityModelName = "CodeFirstDatabaseSchema";
        }

        public EntityCrawler(string entityModelName)
        {
            EnityModelName = entityModelName;
        }
        /// <summary>
        /// Populate our list
        /// </summary>
        public void GetInformation()
        {
            var handle = Activator.CreateInstance(AssembleName, string.Concat(AssembleName, ".", TypeName));
            var EntitiesObject = (DbContext)handle.Unwrap();

            var objectContext = ((IObjectContextAdapter)EntitiesObject).ObjectContext;
            var storageMetadata = ((EntityConnection)objectContext.Connection).GetMetadataWorkspace().GetItems(DataSpace.SSpace);

            _entityTypesData = (from globalItem in storageMetadata where globalItem.BuiltInTypeKind == BuiltInTypeKind.EntityType
                select globalItem as EntityType);
           
            _tableNames = Tables();

            TableInformation = new List<TableInformation>();

            var columnNames = new List<string>();
            var keyNames = new List<string>();

            foreach (string tableName in TableNames)
            {
                columnNames = GetColumNames(tableName);
                var temp = GetColumnInformation(tableName);

                keyNames = new List<string>();

                EntityType entityType = _entityTypesData.ToList().Where(item => item.Name == tableName).FirstOrDefault();

                // get any primary keys
                var props = entityType.KeyProperties;

                if (props != null)
                {
                    foreach (EdmProperty edmProperty in props)
                    {
                        keyNames.Add(edmProperty.ToString());
                    }
                }

                TableInformation.Add(new TableInformation()
                {
                    TableName = tableName,
                    Columns = columnNames,
                    PrimaryKeyList = keyNames,
                    EntityColumnList = temp
                });

            }
        }
        /// <summary>
        /// Get all columns for table
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<string> GetColumNames(string tableName)
        {
            var columnNames = new List<string>();

            List<ReadOnlyMetadataCollection<EdmProperty>> metaData = (from entityType in _entityTypesData
                            where entityType.FullName == $"{EnityModelName}.{tableName}"
                            select entityType.DeclaredProperties).ToList();


            foreach (ReadOnlyMetadataCollection<EdmProperty> prop in metaData)
            {               
                prop.ToList().ForEach(edm => columnNames.Add(edm.Name));
            }

            return columnNames;

        }
        /// <summary>
        /// Get column details
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<EntityColumn> GetColumnInformation(string tableName)
        {
            var list = new List<EntityColumn>();

            /*
             * Checking FullName differs between code first and edmx
             * code first: CodeFirstDatabaseSchema
             * edmx: store
             */
            var metaData = (
                _entityTypesData.Where(entityType => entityType.FullName == $"{EnityModelName}.{tableName}")
                    .Select(entityTypesData => entityTypesData.DeclaredProperties)).ToList();


            EntityType entityType1 = _entityTypesData.ToList().Where(item => item.Name == tableName).FirstOrDefault();
            ReadOnlyMetadataCollection<EdmProperty> props = entityType1.KeyProperties;

            foreach (ReadOnlyMetadataCollection<EdmProperty> prop in metaData)
            {
               
                foreach (var itemEdmProperty in prop.ToList())
                {
                    bool primaryKey = false;

                    if (props != null)
                    {
                        primaryKey = props.FirstOrDefault(item => item.Name == itemEdmProperty.Name) != null;
                    }

                    list.Add(new EntityColumn()
                    {
                        Name = itemEdmProperty.Name,
                        Type = itemEdmProperty.PrimitiveType.ClrEquivalentType,
                        TypeName =  itemEdmProperty.TypeName,
                        Key = primaryKey
                    });

                }
            }

            return list;
        }

        /// <summary>
        /// Return all tables in context
        /// </summary>
        /// <returns></returns>
        string[] Tables()
        {
            return _entityTypesData
                .ToList().Where(tbl => tbl.Name != "sysdiagrams")
                .Select(item => item.Name)
                .ToList()
                .ToArray();
        }
    }


}
