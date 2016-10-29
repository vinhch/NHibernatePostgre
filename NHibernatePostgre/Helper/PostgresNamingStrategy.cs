using NHibernate.Cfg;

namespace NHibernatePostgre.Helper
{
    internal class PostgresNamingStrategy : INamingStrategy
    {
        private readonly INamingStrategy _defaultNamingStrategy;

        public PostgresNamingStrategy(INamingStrategy defaultNamingStrategy = null)
        {
            _defaultNamingStrategy = defaultNamingStrategy;
        }

        public string ClassToTableName(string className)
        {
            var defaultOuput = _defaultNamingStrategy == null
                ? className
                : _defaultNamingStrategy.ClassToTableName(className);

            return DoubleQuote(defaultOuput);
        }
        public string PropertyToColumnName(string propertyName)
        {
            var defaultOuput = _defaultNamingStrategy == null
                ? propertyName
                : _defaultNamingStrategy.PropertyToColumnName(propertyName);

            return DoubleQuote(defaultOuput);
        }
        public string TableName(string tableName)
        {
            var defaultOuput = _defaultNamingStrategy == null
                ? tableName
                : _defaultNamingStrategy.TableName(tableName);

            return DoubleQuote(defaultOuput);
        }
        public string ColumnName(string columnName)
        {
            var defaultOuput = _defaultNamingStrategy == null
                ? columnName
                : _defaultNamingStrategy.ColumnName(columnName);

            return DoubleQuote(defaultOuput);
        }
        public string PropertyToTableName(string className,
                                          string propertyName)
        {
            var defaultOuput = _defaultNamingStrategy == null
                ? propertyName
                : _defaultNamingStrategy.PropertyToTableName(className, propertyName);

            return DoubleQuote(defaultOuput);
        }
        public string LogicalColumnName(string columnName,
                                        string propertyName)
        {
            if (_defaultNamingStrategy == null)
            {
                return string.IsNullOrWhiteSpace(columnName)
                    ? DoubleQuote(propertyName)
                    : DoubleQuote(columnName);
            }

            var defaultOuput = _defaultNamingStrategy.LogicalColumnName(columnName, propertyName);
            return DoubleQuote(defaultOuput);
        }
        private static string DoubleQuote(string raw)
        {
            // In some cases the identifier is single-quoted.
            // We simply remove the single quotes:
            raw = raw.Replace("`", "");

            // Trimming double-quoted if input have them.
            raw = raw.Trim('"');

            return string.Format("\"{0}\"", raw);
        }
    }
}