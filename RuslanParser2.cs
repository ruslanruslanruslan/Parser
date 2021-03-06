﻿using ParsersChe.Bot.ActionOverPage;
using ParsersChe.Bot.ActionOverPage.ContentPrepare;
using ParsersChe.Bot.ActionOverPage.ContentPrepare.Avito;
using ParsersChe.Bot.ActionOverPage.EnumsPartPage;
using ParsersChe.WebClientParser;
using System;
using System.Collections.Generic;
using AvitoRuslanParser.AvitoParser;
using ParsersChe.HelpFull;

namespace AvitoRuslanParser
{
  class RuslanParser2
  {
    private string pathImages2 = "images";
    private MySqlDB mySqlDB;
    private string ftpUsername;
    private string ftpPassword;
    public string PathImages2
    {
      get { return pathImages2; }
      set { pathImages2 = value; }
    }
    private ImageParsedCountHelper imageParsedCountHelper = null;

    public RuslanParser2(string user, string pass, string pathToProxy, MySqlDB _mySqlDB, string _ftpUsername, string _ftpPassword, ImageParsedCountHelper imageParsed)
    {
      mySqlDB = _mySqlDB;
      ftpUsername = _ftpUsername;
      ftpPassword = _ftpPassword;
      imageParsedCountHelper = imageParsed;
    }

    public Dictionary<PartsPage, IEnumerable<string>> Run(string link)
    {
      Dictionary<PartsPage, IEnumerable<string>> result = null;
      IHttpWeb webCl = new WebCl();
      var url = link;
      try
      {
        ParserPage parser = new SimpleParserPage
              (url, new List<IPrepareContent> {
                    new AvitoLoadImageDeferentSize(webCl,pathImages2, mySqlDB, ftpUsername, ftpPassword, imageParsedCountHelper)
                    { 
                    }
                           }, webCl
              );
        parser.LoadPage(url);
        parser.RunActions();
        //MySqlDB.InsertItemResource(MySqlDB.ResourceID(), link);
        // ProxyCollectionSingl.Instance.Dispose();
        result = parser.ResultsParsing;
      }
      catch (Exception)
      {
        
      }
      return result;
    }
  }
}
