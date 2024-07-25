using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    internal class Reflector
    {
        public static void SetField(Object obj, String fieldName, object value)
        {
            Type type = obj.GetType();
            FieldInfo field = type.GetField(
                fieldName,
                BindingFlags.NonPublic | BindingFlags.Instance
            );
            field.SetValue(obj, value);
        }

        public static Object GetField(Object target, String fieldName)
        {
            Type type = target.GetType();

            return type.InvokeMember(
                fieldName,
                BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                target,
                null
            );
        }
    }
}
