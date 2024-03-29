﻿using Microsoft.AspNetCore.Mvc;
using ParkinglotApp.Data.VO;
using ParkinglotApp.Hypermedia.Constants;
using System.Text;
using System.Threading.Tasks;

namespace ParkinglotApp.Hypermedia.Enricher
{
  public class ManobraEnricher : ContentResponseEnricher<ManobraVO>
  {
    private readonly object _lock = new object();
    protected override Task EnrichModel(ManobraVO content, IUrlHelper urlHelper)
    {
      var path = "api/manobra/v1";
      string link = GetLink(content.Codigo, urlHelper, path);

      content.Links.Add(new HyperMediaLink()
      {
        Action = HttpActionVerb.GET,
        Href = link,
        Rel = RelationType.self,
        Type = ResponseTypeFormat.DefaultGet
      });
      content.Links.Add(new HyperMediaLink()
      {
        Action = HttpActionVerb.POST,
        Href = link,
        Rel = RelationType.self,
        Type = ResponseTypeFormat.DefaultPost
      });
      content.Links.Add(new HyperMediaLink()
      {
        Action = HttpActionVerb.PUT,
        Href = link,
        Rel = RelationType.self,
        Type = ResponseTypeFormat.DefaultPut
      });
      content.Links.Add(new HyperMediaLink()
      {
        Action = HttpActionVerb.DELETE,
        Href = link,
        Rel = RelationType.self,
        Type = "int"
      });
      return null;
    }

    private string GetLink(long id, IUrlHelper urlHelper, string path)
    {
      lock (_lock)
      {
        var url = new { controller = path, id = id };
        return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").ToString();
      };
    }
  }
}
