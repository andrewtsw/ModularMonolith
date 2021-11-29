using System;

namespace TCO.SNT.Common.Esf
{
    public abstract class SessionId
    {
        protected SessionId(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
            Value = value;
        }

        public string Value { get; private set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is SessionId other)
            {
                return other.Value == Value;
            }
            return false;
        }

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value;
    }
}
