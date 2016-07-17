using System;

namespace TV.TiskarnaVosahlo.Models
{
    public class UserData
    {
        public String UserName { get; set; }

        public String Password { get; set; }

        public TV.Core.Rights.Roles Roles { get; set; }

        public string Serialize()
        {
            return _serializer.Serialize(this);
        }

        public static UserData Deserialize(string jsonDefinition)
        {
            return _serializer.Deserialize(jsonDefinition);
        }

        private static JsonSerializer<UserData> _serializer = new JsonSerializer<UserData>();
    }
}
