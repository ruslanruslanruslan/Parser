﻿using ParsersChe.Bot.ActionOverPage.ContentPrepape;
using ParsersChe.Bot.ActionOverPage.EnumsPartPage;
using ParsersChe.Bot.ContentPrepape.Avito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ParsersChe.Bot.ContentPrepape.Phone
{
  public  class AvitoTypePhone : WebClientBot, IPrepareContent
    {
        public KeyValuePair<ActionOverPage.EnumsPartPage.PartsPage, IEnumerable<string>> RunActions(string content, string url, HtmlAgilityPack.HtmlDocument doc)
        {
            Doc = doc;
            var result = GetData();
            if (result != null)
            {
                return new KeyValuePair<PartsPage, IEnumerable<string>>(PartsPage.PhoneType, new List<string> { result });
            }
            else
            {
                return new KeyValuePair<PartsPage, IEnumerable<string>>(PartsPage.PhoneType, null);
            }
        }

        public string GetData() 
        {
            return AvitoHelpFulMethod.GetFirstParam(Doc);
        }

    }
}
