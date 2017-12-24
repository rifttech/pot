using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Pot {
    public static class P {
        public static void Bind<T>(T mono) where T : MonoBehaviour {
            ResolveBindings(mono);
        }

        private static void ResolveBindings<T>(T mono) where T : MonoBehaviour {

            mono.With((x) => {
                   x.GetType()
                    .GetFields(FieldsFlags)
                    .ToList()
                    .FindAll(BindAttributeExists)
                    .ForEach(s => InitField(s, mono, string.Empty));
                return x;
            });
            
        }


        private const BindingFlags FieldsFlags =
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

        private const string Failover = "FAILOVER";
        private const string Regular = "REGULAR";
       

        private static bool BindAttributeExists(FieldInfo field) {
            return field.GetCustomAttributes(typeof(BindAttribute), false).Length > 0;
        }

        private static void InitField(FieldInfo field, MonoBehaviour mono, string type) {

            var component = mono.GetComponent(field.FieldType);
            if (component != null) {
                field.SetValue(mono, component);
            }
        }

        private static string IsFailover(FieldInfo fieldInfo) {
            return
            (fieldInfo.GetAttribute<BindAttribute>()
                .Failover)
                ? Failover
                : Regular;
        }

        private static T GetAttribute<T>(this FieldInfo fi) where T : Attribute {
            return
                fi.GetCustomAttributes(typeof(T), false)
                    .Cast<T>()
                    .SingleOrDefault();
        }
    }

    internal static class ExtMonad {
        public static TR With<T, TR>(this T o, Func<T, TR> f) 
            where T : class where TR : class {
            return o == null ? null : f(o);
        }

        
    }
}
