﻿using System;
using System.Collections.Generic;
using System.Net;

namespace ParsersChe.WebClientParser.Proxy
{
  abstract public class ProxyCollection : IDisposable
  {
    public abstract IWebProxy NewProxy { get; }
    public IWebProxy Proxy { get; protected set; }
    protected NetworkCredential credential;
    protected IWebProxy webProxy;
    protected string path;

    public ProxyCollection(string login, string password, string path)
      : this(path)
    {
      if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
        credential = new NetworkCredential(login, password);

    }
    public ProxyCollection(string path)
    {
      this.path = path;
    }

    public abstract void ReadProxy();
    public abstract void ReadProxy(IList<string> proxyList);

    public abstract void WriteProxy();

    protected virtual void Dispose(bool disposing)
    {
      WriteProxy();
    }

    ~ProxyCollection()
    {
      Dispose(false);
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }


  }
}
