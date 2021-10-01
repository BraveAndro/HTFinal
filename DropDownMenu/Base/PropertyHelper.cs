using System;
using System.Linq.Expressions;
using System.Reflection;

namespace DropDownMenu.Base
{
    public static class PropertyHelper
    {
        public static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
            {
                return string.Empty;
            }

            var memberExpression = propertyExpression.Body as MemberExpression;

            if (memberExpression == null)
            {
                return string.Empty;
            }

            var property = memberExpression.Member as PropertyInfo;

            if (property == null)
            {
                return string.Empty;
            }

            return memberExpression.Member.Name;
        }

    }
}
