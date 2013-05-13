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

        public Recorder(bool useBinary = true)
        {
            if (useBinary) formatter = new BinaryFormatter();
            else formatter = new SoapFormatter();
            stream = null;
        }

        public void WriteStream(string fileName){
            stream = File.Open(fileName, FileMode.Append);
        }

        public void ReadStream(string fileName)
        {
            stream = File.Open(fileName, FileMode.Open);
        }

        public void CloseStream(){
            stream.Close();
        }

        public void writeObj(object obj)
        {
            try
            {
                formatter.Serialize(stream, obj);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.GetType().Name);
                Console.WriteLine("{0}", ex.Message);
            }
        }

        public object readObj()
        {
            object o = null;
            try
            {                
                o = formatter.Deserialize(stream);
            }
            catch 
            {
                // Here may the end of file.
            }
            return o;
        }
    }
}
