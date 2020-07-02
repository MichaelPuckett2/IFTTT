using IFTTT.Constants;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IFTTT.Models
{
    public class PropertyExpression<T> : TypeExpression<T>
    {
        private static IEnumerable<PropertyInfo> propertyInfos;

        public PropertyExpression(object obj, string propertyName, EqualityOperator equalityOperator, T value)
        {
            Owner = obj;
            PropertyName = propertyName;
            EqualityOperator = equalityOperator;
            ExpressionA = (T)PropertyInfos.FirstOrDefault(x => x.Name == PropertyName)?.GetValue(Owner);
            ExpressionB = value;
        }

        private IEnumerable<PropertyInfo> PropertyInfos
        {
            get
            {
                if (propertyInfos == null) propertyInfos = Owner.GetType().GetProperties().ToList();
                return propertyInfos;
            }
        }

        public object Owner { get; set; }
        public string PropertyName { get; set; }
    }
}
