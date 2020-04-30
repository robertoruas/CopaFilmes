using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace copa_filmes_api.Code
{
    public static class Mapeador
    {
        public static P DePara<D, P>(D origem)
        {
            P destino = (P)Activator.CreateInstance(typeof(P));
            foreach (PropertyInfo propModelo in origem.GetType().GetProperties())
            {
                PropertyInfo propertyEntity = destino.GetType().GetProperty(propModelo.Name);

                if (propertyEntity != null)
                {
                    object objectProperty = propModelo.GetValue(origem, null);
                    if (objectProperty != null)
                    {
                        Type propertyTypeIn = propertyEntity.PropertyType;
                        if (propertyEntity.PropertyType.IsGenericType && propertyTypeIn.GetGenericTypeDefinition() == typeof(Nullable<>))
                            propertyTypeIn = propertyTypeIn.GetGenericArguments()[0];

                        if (propertyTypeIn.IsEnum)
                            propertyEntity.SetValue(destino, Enum.ToObject(propertyTypeIn, Convert.ToInt32(objectProperty)), null);
                        else
                            propertyEntity.SetValue(destino, objectProperty, null);
                    }
                }
            }
            return destino;
        }

    }
}
