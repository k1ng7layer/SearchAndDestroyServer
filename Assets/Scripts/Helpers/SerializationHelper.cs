using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Helpers
{
    public static class SerializationHelper
    {
        public static byte[] SerializeBinary<T>(T data)
        {
            var formatter = new BinaryFormatter();
            var stream = new MemoryStream();
            formatter.Serialize(stream, data);
            
            return stream.ToArray();
        }

        public static T DeserializeBinary<T>(byte[] array)
        {
            var stream = new MemoryStream(array);
            var formatter = new BinaryFormatter();
            
            return (T)formatter.Deserialize(stream);
        }
    }
}