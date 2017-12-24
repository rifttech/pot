using System;

// ReSharper disable once CheckNamespace
namespace Pot {
    /// <summary>
    /// Bind attribute marks fields that need binding
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class BindAttribute : Attribute {
        
        private readonly bool _failover;

        public bool Failover {
            get { return _failover; }
        }

        /// <summary>
        /// Construcs BindingAttribute
        /// </summary>
        /// <param name="failover">
        /// If true pot will try to resolve problem with reference of component by yourself,
        /// otherwise you may get not initialized field.
        /// failover = true
        /// pot add component in gameobject with default state
        /// failover = false
        /// </param>
        /// <param name="resolver"> method that invokes that init component</param>
        public BindAttribute(bool failover = false, string resolver = "") {
            _failover = failover;
        }
    }
}
