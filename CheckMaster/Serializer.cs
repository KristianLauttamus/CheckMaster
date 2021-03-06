﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CheckMaster
{
    class Serializer
    {
        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializableObject"></param>
        /// <param name="fileName"></param>
        public static void SerializeObject<T>(T serializableObject, string fileName, bool append = false)
        {
            using (Stream stream = File.Open(fileName, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, serializableObject);
            }
        }


        /// <summary>
        /// Deserializes file to an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filestream"></param>
        /// <returns></returns>
        public static T DeSerializeObject<T>(FileStream filestream)
        {
            using (Stream stream = filestream)
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }
    }
}
