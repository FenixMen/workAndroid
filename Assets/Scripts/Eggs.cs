using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Eggs : MonoBehaviour
{
    //public Text user;
    //public Text eggs;
    public static Text messageFromServer;


    [System.Serializable]
    public struct PostStruct
    {
        public string message;
        public string eggs;
        public string range;
        public string date;
    }

    public static IEnumerator addEggs(string value, string date)
    {
        string function = "add_eggs";
        //Debug.Log("SendRequest start");
        //string user_key = this.userId;
        if (!(SessionDate.userId == null) && !(SessionDate.user == null))
        {
            WWWForm formdata = new WWWForm();
            formdata.AddField("user", SessionDate.user);
            formdata.AddField("user_key", SessionDate.userId);
            formdata.AddField("function", function);
            formdata.AddField("value", value);
            formdata.AddField("date", date);

            UnityWebRequest request = UnityWebRequest.Post("http://mychicken.site/include/api/eggs.php", formdata);
            //yield return new WaitForSeconds(3);
            yield return request.SendWebRequest();
            Debug.Log("Ответ сервера - " + request.downloadHandler.text);

            PostStruct postFromServer = JsonUtility.FromJson<PostStruct>(request.downloadHandler.text);

            //Debug.Log(postFromServer.message);

            messageFromServer.text = postFromServer.message;
            //eggs.text = postFromServer.eggs;
            //range.text = "за " + postFromServer.range + " дней";
        }


    

}


















// Start is called before the first frame update
void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
