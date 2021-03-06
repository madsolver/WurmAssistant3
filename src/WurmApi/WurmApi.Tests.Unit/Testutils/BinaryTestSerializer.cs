﻿using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AldursLab.WurmApi.Tests.Unit.Testutils
{
    public class BinaryTestSerializer<T>
    {
        public T Reserialize(T source)
        {
            var memorystream = new MemoryStream();
            var binaryformatter = new BinaryFormatter();
            binaryformatter.Serialize(memorystream, source);
            memorystream.Seek(0, SeekOrigin.Begin);
            var deserialized = binaryformatter.Deserialize(memorystream);
            return (T)deserialized;
        }
    }
}