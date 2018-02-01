using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using WikipediaMap.DataFetch;

namespace WikipediaMap.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = p => View["index.cshtml"];

            Get["/index/{userInput}"] = p =>
                {
                    var userInput = p.userInput;
                    GetData data = new GetData(userInput);
                    var wikiOutput = data.dataFetch();

                    string newValues = data.serializeAndFormat(wikiOutput);

                    return newValues;
                };
                
        }
    }
}