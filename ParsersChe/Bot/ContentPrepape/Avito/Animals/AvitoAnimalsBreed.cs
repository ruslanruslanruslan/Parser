﻿using ParsersChe.Bot.ActionOverPage.ContentPrepare;
using ParsersChe.Bot.ActionOverPage.EnumsPartPage;
using System.Collections.Generic;

namespace ParsersChe.Bot.ContentPrepape.Avito.Animals
{
  public class AvitoAnimalsBreed : WebClientBot, IPrepareContent
  {
    public KeyValuePair<PartsPage, IEnumerable<string>> RunActions(string content, string url, HtmlAgilityPack.HtmlDocument doc)
    {
      Doc = doc;
      var result = AvitoHelpFulMethod.GetFirstParam(Doc);
      if (result != null)
        return new KeyValuePair<PartsPage, IEnumerable<string>>(PartsPage.AnimalBreed, new List<string> { result });
      else
        return new KeyValuePair<PartsPage, IEnumerable<string>>(PartsPage.AnimalBreed, null);
    }
  }
}
