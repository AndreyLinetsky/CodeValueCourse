using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ObjLinq
{
    public static class LinqExtensions
    {
        public static void CopyTo(this object sourceObj, object targetObj)
        {
            Type objType = sourceObj.GetType();
            var firstResult = sourceObj.GetType().GetProperties()
                .Join(targetObj.GetType().GetProperties(), source => new { source.PropertyType ,source.Name} , target => new {target.PropertyType,target.Name},
                    (source, target) => new
                    {
                        SourceProp = source,
                        TargetProp = target
                    }).Where(p => p.SourceProp.CanRead && p.TargetProp.CanWrite);
            foreach (var prop in firstResult)
            {
                prop.TargetProp.SetValue(targetObj, prop.SourceProp.GetValue(sourceObj, null), null);
            }
        }
    }
}