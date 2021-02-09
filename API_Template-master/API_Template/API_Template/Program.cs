
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using System.Web.UI.WebControls;

namespace API_Template
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://api.nobelprize.org/2.0/nobelPrizes?_ga=2.212104976.569791594.1612257338-1446810415.1612257338");
            var request = new RestRequest("/", Method.GET);
            IRestResponse response = client.Execute(request);
            String content = response.Content;
            Root menu = JsonConvert.DeserializeObject<Root>(content);
            for(int i = 0; i< menu.nobelPrizes.Count; i++)
            {
                Console.WriteLine(menu.nobelPrizes[i].laureates[0].knownName.en);
            }
        }


    }
    public class Category
    {
        public string en { get; set; }
        public string no { get; set; }
        public string se { get; set; }
    }

    public class CategoryFullName
    {
        public string en { get; set; }
        public string no { get; set; }
        public string se { get; set; }
    }

    public class Links
    {
        public string rel { get; set; }
        public string href { get; set; }
        public string action { get; set; }
        public string types { get; set; }
        public string first { get; set; }
        public string self { get; set; }
        public string next { get; set; }
        public string last { get; set; }
    }

    public class KnownName
    {
        public string en { get; set; }
    }

    public class Motivation
    {
        public string en { get; set; }
        public string se { get; set; }
        public string no { get; set; }
    }

    public class OrgName
    {
        public string en { get; set; }
        public string no { get; set; }
    }

    public class Laureate
    {
        public string id { get; set; }
        public KnownName knownName { get; set; }
        public string portion { get; set; }
        public string sortOrder { get; set; }
        public Motivation motivation { get; set; }
        public Links links { get; set; }
        public OrgName orgName { get; set; }
    }

    public class NobelPrize
    {
        public string awardYear { get; set; }
        public Category category { get; set; }
        public CategoryFullName categoryFullName { get; set; }
        public int prizeAmount { get; set; }
        public int prizeAmountAdjusted { get; set; }
        public Links links { get; set; }
        public List<Laureate> laureates { get; set; }
        public string dateAwarded { get; set; }
    }

    public class Meta
    {
        public int offset { get; set; }
        public int limit { get; set; }
        public int count { get; set; }
    }

    public class Root
    {
        public List<NobelPrize> nobelPrizes { get; set; }
        public Meta meta { get; set; }
        public Links links { get; set; }
    }
}


