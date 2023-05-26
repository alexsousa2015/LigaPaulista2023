using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Globalization;

namespace LigaPaulista.Core.SDK.Utils
{
    public class CarregarObjetos
    {

        public object CarregaObjeto(Type tp, System.Object[] ObjArray)
        {
            object Object = Activator.CreateInstance(tp);

            try
            {
                foreach (System.Reflection.PropertyInfo itemObject in Object.GetType().GetProperties())
                {
                    if (itemObject.Name != "ExtensionData")
                    {
                        if ((itemObject.PropertyType).Name == "List`1")
                        {
                            List<object> ListValue = new List<object>();

                            Type tTemp = itemObject.PropertyType.GetGenericArguments()[0];

                            object valueMax = ((System.Collections.Generic.Dictionary<string, object>)(ObjArray[0])).ToList().Find(c => c.Key == itemObject.Name).Value;
                            ListValue.Add(valueMax);

                            itemObject.SetValue(Object, CarregaObjetoList(tTemp, ListValue.ToArray()), null);
                        }

                        if ((((System.Collections.Generic.Dictionary<string, object>)(ObjArray[0])).ToList().Where(c => c.Key == itemObject.Name).Count() > 0) &&
                            (((System.Collections.Generic.Dictionary<string, object>)(ObjArray[0])).ToList().Find(c => c.Key == itemObject.Name).Value != null))
                        {
                            if ((itemObject.PropertyType).Name == "Nullable`1")
                            {
                                var nullType = Nullable.GetUnderlyingType(itemObject.PropertyType);
                                var value = Convert.ChangeType(((System.Collections.Generic.Dictionary<string, object>)(ObjArray[0])).ToList().Find(c => c.Key == itemObject.Name).Value, nullType, CultureInfo.InvariantCulture.NumberFormat);

                                itemObject.SetValue(Object, value, null);
                            }
                            else
                            {
                                object value = null;

                                if ((itemObject.PropertyType).Name == "Int32")
                                    value = Convert.ChangeType(((System.Collections.Generic.Dictionary<string, object>)(ObjArray[0])).ToList().Find(c => c.Key == itemObject.Name).Value, TypeCode.Int32);
                                else if ((itemObject.PropertyType).Name == "Decimal")
                                    value = Convert.ChangeType(((System.Collections.Generic.Dictionary<string, object>)(ObjArray[0])).ToList().Find(c => c.Key == itemObject.Name).Value, TypeCode.Decimal);
                                else if ((itemObject.PropertyType).Name == "String")
                                    value = Convert.ChangeType(((System.Collections.Generic.Dictionary<string, object>)(ObjArray[0])).ToList().Find(c => c.Key == itemObject.Name).Value, TypeCode.String);
                                else if ((itemObject.PropertyType).Name == "DateTime")
                                    value = Convert.ChangeType(((System.Collections.Generic.Dictionary<string, object>)(ObjArray[0])).ToList().Find(c => c.Key == itemObject.Name).Value, TypeCode.DateTime);
                                else if ((itemObject.PropertyType).Name == "Boolean")
                                    value = Convert.ChangeType(((System.Collections.Generic.Dictionary<string, object>)(ObjArray[0])).ToList().Find(c => c.Key == itemObject.Name).Value, TypeCode.Boolean);
                                else if ((itemObject.PropertyType).Name == "Double")
                                    value = Convert.ChangeType(((System.Collections.Generic.Dictionary<string, object>)(ObjArray[0])).ToList().Find(c => c.Key == itemObject.Name).Value, TypeCode.Double);
                                else if ((itemObject.PropertyType).Name == "Single")
                                    value = Convert.ChangeType(((System.Collections.Generic.Dictionary<string, object>)(ObjArray[0])).ToList().Find(c => c.Key == itemObject.Name).Value, TypeCode.Single);

                                if (value != null)
                                    itemObject.SetValue(Object, value, null);
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }

            return Object;
        }

        public object CarregaObjetoList(Type tp, System.Object[] ObjArray)
        {
            object list = Activator.CreateInstance(typeof(List<>).MakeGenericType(tp));

            for (int i = 0; i < ObjArray.Count(); i++)
            {
                int? count = null;
                int? count2 = null;
                try
                {
                    count = (((System.Collections.Generic.Dictionary<string, object>)(((object[])(ObjArray[i]))[0]))).Count();
                }
                catch
                {
                    try
                    {
                        count2 = ((System.Collections.Generic.Dictionary<string, object>)ObjArray[i]).Count();
                    }
                    catch{}                    
                }

                if (count > 0)
                {
                    for (int j = 0; j < ((System.Object[])ObjArray[i]).Count(); j++)
                    {
                        List<object> ListAux = new List<object>();

                        ListAux.Add(((System.Object[])ObjArray[i])[j]);

                        ((IList)list).Add(CarregaObjeto(tp, ListAux.ToArray()));
                    }
                }
                else if (count2 > 0)
                {
                    List<object> ListAux = new List<object>();

                    ListAux.Add((System.Collections.Generic.Dictionary<string, object>)ObjArray[i]);

                    ((IList)list).Add(CarregaObjeto(tp, ListAux.ToArray()));
                }
            }

            return list;
        }
    }
}
