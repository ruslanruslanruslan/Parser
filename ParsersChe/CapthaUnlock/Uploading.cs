﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

namespace AntigateUnravel
{
  public class Uploading
  {
    public byte[] UploadFiles(string address, IEnumerable<UploadFile> files, NameValueCollection values, string cookie)
    {
      var request = WebRequest.Create(address);
      request.Method = "POST";

      //  request.Headers["User-Agent"]="Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
      request.Headers["Cookie"] = cookie;
      var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x", NumberFormatInfo.InvariantInfo);
      request.ContentType = "multipart/form-data; boundary=" + boundary;
      boundary = "--" + boundary;

      using (var requestStream = request.GetRequestStream())
      {
        // Write the values
        foreach (string name in values.Keys)
        {
          var buffer = Encoding.ASCII.GetBytes(boundary + Environment.NewLine);
          requestStream.Write(buffer, 0, buffer.Length);
          buffer = Encoding.ASCII.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"{1}{1}", name, Environment.NewLine));
          requestStream.Write(buffer, 0, buffer.Length);
          buffer = Encoding.UTF8.GetBytes(values[name] + Environment.NewLine);
          requestStream.Write(buffer, 0, buffer.Length);
        }

        // Write the files
        foreach (var file in files)
        {
          var buffer = Encoding.ASCII.GetBytes(boundary + Environment.NewLine);
          requestStream.Write(buffer, 0, buffer.Length);
          buffer = Encoding.UTF8.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"{2}", file.Name, file.Filename, Environment.NewLine));
          requestStream.Write(buffer, 0, buffer.Length);
          buffer = Encoding.ASCII.GetBytes(string.Format("Content-Type: {0}{1}{1}", file.ContentType, Environment.NewLine));
          requestStream.Write(buffer, 0, buffer.Length);
          file.Stream.CopyTo(requestStream);
          buffer = Encoding.ASCII.GetBytes(Environment.NewLine);
          requestStream.Write(buffer, 0, buffer.Length);
        }

        var boundaryBuffer = Encoding.ASCII.GetBytes(boundary + "--");
        requestStream.Write(boundaryBuffer, 0, boundaryBuffer.Length);
      }

      using (var response = request.GetResponse())
      using (var responseStream = response.GetResponseStream())
      using (var stream = new MemoryStream())
      {
        responseStream.CopyTo(stream);
        return stream.ToArray();
      }

    }
    public byte[] UploadFiles(string address, IEnumerable<UploadFile> files, NameValueCollection values, CookieContainer cookie)
    {

      var request = (HttpWebRequest)WebRequest.Create(address);
      request.Method = "POST";
      request.CookieContainer = cookie;
      //  request.Headers["User-Agent"]="Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";

      var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x", NumberFormatInfo.InvariantInfo);
      request.ContentType = "multipart/form-data; boundary=" + boundary;
      boundary = "--" + boundary;

      using (var requestStream = request.GetRequestStream())
      {
        // Write the values
        foreach (string name in values.Keys)
        {
          var buffer = Encoding.ASCII.GetBytes(boundary + Environment.NewLine);
          requestStream.Write(buffer, 0, buffer.Length);
          buffer = Encoding.ASCII.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"{1}{1}", name, Environment.NewLine));
          requestStream.Write(buffer, 0, buffer.Length);
          buffer = Encoding.UTF8.GetBytes(values[name] + Environment.NewLine);
          requestStream.Write(buffer, 0, buffer.Length);
        }
        // Write the files
        foreach (var file in files)
        {
          var buffer = Encoding.ASCII.GetBytes(boundary + Environment.NewLine);
          requestStream.Write(buffer, 0, buffer.Length);
          buffer = Encoding.UTF8.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"{2}", file.Name, file.Filename, Environment.NewLine));
          requestStream.Write(buffer, 0, buffer.Length);
          buffer = Encoding.ASCII.GetBytes(string.Format("Content-Type: {0}{1}{1}", file.ContentType, Environment.NewLine));
          requestStream.Write(buffer, 0, buffer.Length);
          file.Stream.CopyTo(requestStream);
          buffer = Encoding.ASCII.GetBytes(Environment.NewLine);
          requestStream.Write(buffer, 0, buffer.Length);
        }

        var boundaryBuffer = Encoding.ASCII.GetBytes(boundary + "--");
        requestStream.Write(boundaryBuffer, 0, boundaryBuffer.Length);
      }

      using (var response = request.GetResponse())
      using (var responseStream = response.GetResponseStream())
      using (var stream = new MemoryStream())
      {
        responseStream.CopyTo(stream);
        return stream.ToArray();
      }

    }
    public string UploadValue(string address, IEnumerable<UploadFile> files, NameValueCollection values, string cookie)
    {
      var request = (HttpWebRequest)WebRequest.Create(address);
      request.Method = "POST";
      request.Accept = "text/html, application/xhtml+xml, */*";
      request.Referer = "http://www.avito.ru/profile";
      request.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
      request.Headers["Cookie"] = cookie;
      request.AllowAutoRedirect = false;
      var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x", NumberFormatInfo.InvariantInfo);
      request.ContentType = "multipart/form-data; boundary=" + boundary;
      boundary = "--" + boundary;

      using (var requestStream = request.GetRequestStream())
      {
        // Write the values
        foreach (string name in values.Keys)
        {
          var buffer = Encoding.ASCII.GetBytes(boundary + Environment.NewLine);
          requestStream.Write(buffer, 0, buffer.Length);
          buffer = Encoding.ASCII.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"{1}{1}", name, Environment.NewLine));
          requestStream.Write(buffer, 0, buffer.Length);
          buffer = Encoding.UTF8.GetBytes(values[name] + Environment.NewLine);
          requestStream.Write(buffer, 0, buffer.Length);
        }

        // Write the files
        foreach (var file in files)
        {
          var buffer = Encoding.ASCII.GetBytes(boundary + Environment.NewLine);
          requestStream.Write(buffer, 0, buffer.Length);
          buffer = Encoding.UTF8.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"{2}", file.Name, file.Filename, Environment.NewLine));
          requestStream.Write(buffer, 0, buffer.Length);
          buffer = Encoding.ASCII.GetBytes(string.Format("Content-Type: {0}{1}{1}", file.ContentType, Environment.NewLine));
          requestStream.Write(buffer, 0, buffer.Length);
          file.Stream.CopyTo(requestStream);
          buffer = Encoding.ASCII.GetBytes(Environment.NewLine);
          requestStream.Write(buffer, 0, buffer.Length);
        }

        var boundaryBuffer = Encoding.ASCII.GetBytes(boundary + "--");
        requestStream.Write(boundaryBuffer, 0, boundaryBuffer.Length);
      }

      using (var response = request.GetResponse())
      using (var responseStream = response.GetResponseStream())
      using (var stream = new MemoryStream())
      {
        responseStream.CopyTo(stream);
        return response.Headers["Set-Cookie"];
      }

    }
  }
}
