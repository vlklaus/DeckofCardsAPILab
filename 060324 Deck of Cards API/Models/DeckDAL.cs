using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Serialization;

namespace _060324_Deck_of_Cards_API.Models
{
    public class DeckDAL
    {
        public static DeckModel GetDeck() 
        {

            string url = "https://deckofcardsapi.com/api/deck/at9j3ma2gcro/draw/?count=5";

            // request
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //JSON - extract JSON out of response
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            // install Newtonsoft.json
            DeckModel result = JsonConvert.DeserializeObject<DeckModel>(JSON); //c# model of api model
            return result;
        }

        public static DeckModel Shuffle() 
        {

            string url = "https://deckofcardsapi.com/api/deck/at9j3ma2gcro/shuffle/";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            DeckModel result = JsonConvert.DeserializeObject<DeckModel>(JSON); //c# model of api model
            return result;
        }
    }
}
