namespace DoctorAPI.core;
using System;

[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
public class PathWay : Attribute
{
    public string XmlFilePath { get; }

    public PathWay(string xmlFilePath)
    {
        XmlFilePath = xmlFilePath;
    }
}