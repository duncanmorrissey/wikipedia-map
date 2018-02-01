using System;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Collections.Generic;

namespace WikipediaMap.DataFetch
{
    public class GetData
    {
        public string URL = "https://en.wikipedia.org/w/api.php?action=query&prop=linkshere&lhlimit=10&format=json&indexpageids&titles=";
        public string pageid;

        public GetData(string input)
        {
            //format URL for api call from what user inputs
            Regex rgx = new Regex("/[^/w/s]/");
            input = rgx.Replace(input, "");
            Regex space = new Regex("/s");
            input = space.Replace(input, "%20");
            URL += input;
        }

        public string dataFetch()
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(URL);
            using(HttpWebResponse response = (HttpWebResponse)myRequest.GetResponse())
            {
                string ResponseText;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    ResponseText = reader.ReadToEnd();
                    return ResponseText;
                }
            }
        }

        public string serializeAndFormat(string ResponseText)
        {
            JObject json = JObject.Parse(ResponseText);

            List<String> wikiJson = new List<String>(); ;//return value

            //get pageid for user entered word
            var indexPageIDJson = json["query"]["pageids"];

            foreach(var indexPageID in indexPageIDJson) { pageid = (string)indexPageID; }//only one value ever, TODO refactor with linq

            //verify the wikipedia page exists
            if (pageid == "-1")
            {
                return JsonConvert.SerializeObject("bad_path");
            }

            //get titles of all pages that link to entered word
            var titlesJson = from t in json["query"]["pages"][pageid]["linkshere"]
                             select (string)t["title"];

            foreach (var item in titlesJson)
            {
                wikiJson.Add(item);
            }

            return JsonConvert.SerializeObject(wikiJson);
        }
    }

}