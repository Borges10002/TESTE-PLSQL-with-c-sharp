using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Questao2
{
    public class Api
    {

        public static Jogos getTotalScoredGoalsTime1(string teamName, int year, int pagina)
        {
            string accessToken = "";
            Stream stream = null;
            StreamReader streamReader;

            Dictionary<String, String> tokens = new Dictionary<string, string>();

            string url = string.Format(string.Format("https://jsonmock.hackerrank.com/api/football_matches?year={0}&team1={1}&page={2}", year, teamName, pagina));

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            stream = response.GetResponseStream();
            streamReader = new StreamReader(stream, Encoding.UTF8);

            string jsonResult = streamReader.ReadToEnd();

            Jogos res = Newtonsoft.Json.JsonConvert.DeserializeObject<Jogos>(jsonResult);

            return res;
        }

        public static Jogos getTotalScoredGoalsTime2(string teamName, int year, int pagina)
        {
            string accessToken = "";
            Stream stream = null;
            StreamReader streamReader;

            Dictionary<String, String> tokens = new Dictionary<string, string>();

            string url = string.Format(string.Format("https://jsonmock.hackerrank.com/api/football_matches?year={0}&team2={1}&page={2}", year, teamName, pagina));

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            stream = response.GetResponseStream();
            streamReader = new StreamReader(stream, Encoding.UTF8);

            string jsonResult = streamReader.ReadToEnd();

            Jogos res = Newtonsoft.Json.JsonConvert.DeserializeObject<Jogos>(jsonResult);

            return res;
        }

    }
}
