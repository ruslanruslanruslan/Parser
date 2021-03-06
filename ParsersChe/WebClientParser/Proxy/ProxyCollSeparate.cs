﻿using System;
using System.Collections.Generic;
using System.Net;

namespace ParsersChe.WebClientParser.Proxy
{
  public class ProxyCollSeparate : IDisposable
  {
    private ProxyCollection proxyColl = null;
    public IWebProxy NewProxy { get { return proxyColl.NewProxy; } }
    public IWebProxy Proxy { get { return proxyColl.Proxy; } }

    public ProxyCollSeparate(string proxyUser, string proxyPass, string proxyPath)
    {
      //ProxyCollUp proxyCollup = new ProxyCollUp(ProxyUser, ProxyPass, proxyPath, new AvitoCheckerProxy());
      //proxyCollup.MinCountProxy = 800;
      //proxyCollup.TimeCheckCrashProxy = 60000;
      //proxyColl = proxyCollup;
      proxyColl = new ProxyQueueTxt(proxyUser, proxyPass, proxyPath);
      proxyColl.ReadProxy();
    }
    public ProxyCollSeparate(string proxyPath)
    {
      proxyColl = new ProxyQueueTxt(proxyPath);
      proxyColl.ReadProxy();
    }

    public ProxyCollSeparate(string proxyPath, IList<string> list)
    {
      proxyColl = new ProxyQueueTxt(proxyPath);
      proxyColl.ReadProxy(list);
    }

    protected virtual void Dispose(bool disposing)
    {
      proxyColl.Dispose();
    }

    ~ProxyCollSeparate()
    {
      Dispose(false);
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    public void Wait()
    {
      var opColl = proxyColl as ProxyCollUp;
      if (opColl != null)
      {
        opColl.Wait();
      }
    }
  }
}
