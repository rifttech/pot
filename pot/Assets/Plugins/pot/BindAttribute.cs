using System;

// ReSharper disable once CheckNamespace
namespace Pot {
    [AttributeUsage(AttributeTargets.Field)]
    public class BindAttribute : Attribute {
        private readonly bool _failover;

        public bool Failover {
            get { return _failover; }
        }

        public BindAttribute(bool failover = false, string resolver = "") {
            _failover = failover;
        }
    }
}
