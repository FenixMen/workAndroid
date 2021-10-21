using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Eggs : MonoBehaviour
{
    public Text user;
    public Text eggs;
 


    [System.Serializable]
    public struct PostStruct
    {
        public string message;
        public string eggs;
        public string range;
        public string date;
    }

    private IEnumerator allEggs(string value, string date)
    {
        string function = "add_eggs";
        //Debug.Log("SendRequest start");
        //string user_key = this.userId;
        if (!(SessionDate.userId == null) && !(user.text == null))
        {
            WWWForm formdata = new WWWForm();
            formdata.AddField("user", user.text);
            formdata.AddField("user_key", SessionDate.userId);
            formdata.AddField("function", function);
            formdata.AddField("value", value);
            formdata.AddField("date", date);

            UnityWebRequest request = UnityWebRequest.Post("http://mychicken.site/include/api/eggs.php", formdata);
            //yield return new WaitForSeconds(3);
            yield return request.SendWebRequest();
            Debug.Log("����� ������� - " + request.downloadHandler.text);

            //PostStruct postFromServer = JsonUtility.FromJson<PostStruct>(request.downloadHandler.text);

            //Debug.Log(postFromServer.message);

            //Message.text = postFromServer.message;
            //eggs.text = postFromServer.eggs;
            //range.text = "�� " + postFromServer.range + " ����";
        }


    

}


















// Start is called before the first frame update
void Start()
    {
        user.text = SessionDate.user;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
