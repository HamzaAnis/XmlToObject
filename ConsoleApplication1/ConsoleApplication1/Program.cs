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
        Employee temp = new Employee();
        temp.FirstName = "Code";
        temp.LastName = "Handbook";

        Type testing = null;
        string xml = GetXMLFromObject(temp);
        Employee emp=new Employee();
        emp= (Employee) ObjectToXML(xml,typeof(Employee));

        Console.WriteLine("The name of the emp is {0}",temp.FirstName);
        Console.WriteLine("The name of the temp is {0}", emp.FirstName);

        //    Console.WriteLine(xml);

        //      System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\hamza\\1.txt");
        //        file.WriteLine(xml);

        //  file.Close();
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

