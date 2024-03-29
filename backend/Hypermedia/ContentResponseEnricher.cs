﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using ParkinglotApp.Hypermedia.Abstract;
using ParkinglotApp.Hypermedia.Utils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkinglotApp.Hypermedia
{
  public abstract class ContentResponseEnricher<T> : IResponseEnricher where T : ISupportHypermedia
  {
    public ContentResponseEnricher()
    {
    }

    public bool CanEnrich(Type contentType)
    {
      return contentType == typeof(T) || contentType == typeof(List<T>) || contentType == typeof(PagedSearchVO<T>);
    }

    bool IResponseEnricher.CanEnrich(ResultExecutingContext response)
    {
      if (response.Result is OkObjectResult okObjectResult)
      {
        return CanEnrich(okObjectResult.Value.GetType());
      }
      return false;
    }

    protected abstract Task EnrichModel(T content, IUrlHelper urlHelper);

    public async Task Enrich(ResultExecutingContext response)
    {
      var urlHelper = new UrlHelperFactory().GetUrlHelper(response);
      if (response.Result is OkObjectResult okObjectResult)
      {
        if (okObjectResult.Value is T model)
        {
          await EnrichModel(model, urlHelper);
        }
        else if (okObjectResult.Value is List<T> collection)
        {
          ConcurrentBag<T> bag = new ConcurrentBag<T>(collection);
          Parallel.ForEach(bag, (element) =>
          {
            EnrichModel(element, urlHelper);
          });
        }
        else if (okObjectResult.Value is PagedSearchVO<T> pageSearch)
        {
          Parallel.ForEach(pageSearch.List.ToList(), (element) =>
          {
            EnrichModel(element, urlHelper);
          });
        }

      }
      await Task.FromResult<object>(null);
    }
  }
}
