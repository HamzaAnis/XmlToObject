using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

[Serializable]

public class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}


class Program
{
    static void Main(string[] args)
    {
        Employee emp = new Employee();
        emp.FirstName = "Code";
        emp.LastName = "Handbook";

        string xml = GetXMLFromObject(emp);
        Console.WriteLine(xml);

        System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\test.txt");
        file.WriteLine(lines);

        file.Close();
        Console.ReadLine();
    }
    public static string GetXMLFromObject(object o)
    {
        StringWriter sw = new StringWriter();
        XmlTextWriter tw = null;
        try
        {
            XmlSerializer serializer = new XmlSerializer(o.GetType());
            tw = new XmlTextWriter(sw);
            serializer.Serialize(tw, o);
        }
        catch (Exception ex)
        {
            //Handle Exception Code
        }
        finally
        {
            sw.Close();
            if (tw != null)
            {
                tw.Close();
            }
        }
        return sw.ToString();
    }


    public static Object ObjectToXML(string xml, Type objectType)
    {
        StringReader strReader = null;
        XmlSerializer serializer = null;
        XmlTextReader xmlReader = null;
        Object obj = null;
        try
        {
            strReader = new StringReader(xml);
            serializer = new XmlSerializer(objectType);
            xmlReader = new XmlTextReader(strReader);
            obj = serializer.Deserialize(xmlReader);
        }
        catch (Exception exp)
        {
            //Handle Exception Code
        }
        finally
        {
            if (xmlReader != null)
            {
                xmlReader.Close();
            }
            if (strReader != null)
            {
                strReader.Close();
            }
        }
        return obj;
    }

}

