using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;

namespace WeiboCrawler
{
    class Recorder
    {
        IFormatter formatter;
        Stream stream;

        public Recorder(bool useBinary)
        {
            if (useBinary) formatter = new BinaryFormatter();
            else formatter = new SoapFormatter();
            stream = null;
        }

        public void OpenStream(string fileName){
            stream = File.Open(fileName, FileMode.Append);
        }

        public void ReadStream(string fileName)
        {
            stream = File.Open(fileName, FileMode.Open);
        }

        public void DropStream(){
            stream.Close();
        }

        public void writeObj(object obj)
        {
            if (stream == null) Console.WriteLine("S");
            if (obj == null) Console.WriteLine("O");
            formatter.Serialize(stream, obj);    
        }

        public object readObj()
        {
            return formatter.Deserialize(stream); ;
        }
    }
}
