using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

public static class XmlHelper
{
    public static void Serialize<T>(T t, string filePath)
    {
        Stream stream = null;
        try
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
            if (stream != null)
            {
                var xz = new XmlSerializer(t.GetType());
                xz.Serialize(stream, t);
                stream.Close();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(String.Format("Serialize xml error!\nError message:{0}", ex.Message));
        }
        finally
        {
            if (stream != null)
            {
                stream.Close();
            }
        }
    }
    public static object Deserialize(Type type, string filePath)
    {
        object obj = null;
        Stream stream = null;
        try
        {
            if (filePath == null)
            {
                throw new ArgumentNullException(string.Format("\r\nClass: {0}\r\nMethod: {1}!\r\nDetail: {2}",
                   MethodBase.GetCurrentMethod().DeclaringType.Name,
                   MethodBase.GetCurrentMethod().Name,
                   "FilePath is null!"));
            }

            if (File.Exists(filePath))
            {
                stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                var xz = new XmlSerializer(type);
                obj = xz.Deserialize(stream);
                stream.Close();
            }
            else
            {
                throw new IOException(string.Format("\r\nClass: {0}\r\nMethod: {1}!\r\nDetail: {2}",
                   MethodBase.GetCurrentMethod().DeclaringType.Name,
                   MethodBase.GetCurrentMethod().Name,
                   string.Format("File:{0} is not existing!", filePath)));
            }
        }
        catch (Exception ex)
        {
            throw new Exception(String.Format("Deserialize xml:{0} error!\nError message:{1}", filePath, ex.Message));
        }
        finally
        {
            if (stream != null)
            {
                stream.Close();
            }
        }
        return obj;
    }

    public static void Serialize(IXmlSerializable ser, string filePath)
    {
        try
        {
            Stream fs = new FileStream(filePath, FileMode.Create,
                FileAccess.Write, FileShare.ReadWrite);

            if (fs != null)
            {
                XmlWriter writer = new XmlTextWriter(fs, new UTF8Encoding());

                ser.WriteXml(writer);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(String.Format(
                "Class: {0}\r\nMethod: {1}!\r\nDetail: {2}",
                MethodBase.GetCurrentMethod().DeclaringType.Name,
                MethodBase.GetCurrentMethod().Name,
                ex.Message));
        }
    }

    public static void Deserialize(IXmlSerializable ser, string filePath)
    {
        try
        {
            if (false == File.Exists(filePath))
            {
                return;
            }
            XmlReader reader = new XmlTextReader(filePath);

            ser.ReadXml(reader);
        }
        catch (Exception ex)
        {
            throw new Exception(String.Format(
                "Class: {0}\r\nMethod: {1}!\r\nDetail: {2}",
                MethodBase.GetCurrentMethod().DeclaringType.Name,
                MethodBase.GetCurrentMethod().Name,
                ex.Message));
        }
    }
}

