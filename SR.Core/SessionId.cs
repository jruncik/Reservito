using System;
using System.Runtime.Serialization;

namespace TV.Core
{
    [DataContract]
    [Serializable]
    public sealed class SessionId
    {
        [DataMember]
        private readonly string _id;

        public SessionId(string id)
        {
            _id = id;
        }

        public static SessionId New
        {
            get { return new SessionId(Guid.NewGuid().ToString()); }
        }

        public static SessionId Empty
        {
            get { return new SessionId(Guid.Empty.ToString()); }
        }

        public bool IsEmpty
        {
            get { return _id == Guid.Empty.ToString(); }
        }

        public override bool Equals(object obj)
        {
            SessionId other = obj as SessionId;
            if (other == null)
            {
                return false;
            }

            return String.Compare(_id, other._id, true) == 0;
        }

        public override int GetHashCode()
        {
            return (_id ?? string.Empty).GetHashCode();
        }

        public override string ToString()
        {
            return _id;
        }

        public static bool operator ==(SessionId a, SessionId b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(SessionId a, SessionId b)
        {
            return !(a == b);
        }
    }
}