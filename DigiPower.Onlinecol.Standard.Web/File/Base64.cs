using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using System.Xml;


/// <summary>
/// 把文件和Base64字符串相互转换
/// </summary>
public class Base64
{
    /// <summary>
    /// 把任意文件转成Base64
    /// </summary>
    /// <param name="path">具体文件 D:\work\test\XmlFile\XmlFile\logo-wow.gif</param>
    /// <returns></returns>
    public string FileToXml(string path)
    {
        if (!File.Exists(path))
        {
            return "";
        }
        // 打开图片文件，利用该图片构造一个文件流
        FileStream fs = new FileStream(path, FileMode.Open);
        // 使用文件流构造一个二进制读取器将基元数据读作二进制值
        BinaryReader br = new BinaryReader(fs);
        byte[] imageBuffer = new byte[br.BaseStream.Length];
        br.Read(imageBuffer, 0, Convert.ToInt32(br.BaseStream.Length));
        string textString = System.Convert.ToBase64String(imageBuffer);
        fs.Close();
        br.Close();
        return textString;
    }
    /// <summary>　
    /// 
    /// </summary>
    /// <param name="objectData">数字对象string </param>
    /// <param name="path"> D:\work\test\XmlFile\XmlFile\logo-wow.gif"</param>
    public void XmlToFile(string objectData, string path)
    {
        try
        {
            FileStream file = new FileStream(path, FileMode.Create);

            byte[] buffer = Convert.FromBase64String(objectData);

            file.Write(buffer, 0, buffer.Length);
            file.Close();
        }
        catch{}
    }
}