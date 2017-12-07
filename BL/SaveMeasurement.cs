using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BL
{
    public class SaveMeasurement
    {
        public byte[]
            ConvertToBinary(
                List<double> BPList) //Konverterer blodtrykket til et bytearray, så det kan gemmes i databsen
        {
            var binformatter = new BinaryFormatter();
            var mstream = new MemoryStream();

            binformatter.Serialize(mstream, BPList);

            return mstream.ToArray();
        }
    }
}