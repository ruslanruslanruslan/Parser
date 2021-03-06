﻿using ParsersChe.Bot.ActionOverPage.ContentPrepare;
using ParsersChe.Bot.ActionOverPage.EnumsPartPage;
using System.Collections.Generic;

namespace ParsersChe.Bot.ContentPrepape.Avito
{
  public class AvitoTypeProduct : WebClientBot, IPrepareContent
  {
    public KeyValuePair<PartsPage, IEnumerable<string>> RunActions(string content, string url, HtmlAgilityPack.HtmlDocument doc)
    {
      Doc = doc;
      var result = GetData();
      if (result != null)
        return new KeyValuePair<PartsPage, IEnumerable<string>>(PartsPage.ProductType, new List<string> { result });
      else
        return new KeyValuePair<PartsPage, IEnumerable<string>>(PartsPage.ProductType, null);
    }

    public string GetData()
    {
      return AvitoHelpFulMethod.GetFirstParam(Doc);
    }
  }
}
