using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FoodMemory.SharedKernel.Aggregate
{
    public sealed class MetadataContainer : Metadata
    {
        public MetadataContainer()
        {
            CreatedTime = DateTime.Now;
        }

        public void Serializable<TEvent>(TEvent @event)
        {
            var formatter = new BinaryFormatter();
            var rems = new MemoryStream();
            formatter.Serialize(rems, @event);
            Data = rems.GetBuffer();
        }


        public TEvent Deserialize<TEvent>()
        {
            if (Data.Length == 0) return default(TEvent);
            var ms = new MemoryStream(Data) { Position = 0 };
            var formatter = new BinaryFormatter();
            var obj = formatter.Deserialize(ms);
            ms.Close();
            return (TEvent)obj;

        }
    }
}
