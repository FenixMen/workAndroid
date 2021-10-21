using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class FirstPage : MonoBehaviour
{

    public Text user;
    //public Text userId;
    //public Text Message;
    public Text eggs;
    public Text range;
    //public Text userId;

    public void ExitButton()
    {
        SessionDate.Exit();
    }

    // Start is called before the first frame update
    void Start()
    {
        user.text = SessionDate.user;
       // userId.text = SessionDate.userId;
        //SessionDate.allEggs();
        StartCoroutine(allEggs());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [System.Serializable]
    public struct PostStruct
    {
        public string message;
        public string eggs;
        public string range;
        public string date;
    }

    public void ButtonAddChages()
    {
        SceneManager.LoadScene(2);
    }




    private IEnumerator allEggs()
    {
        string function = "get_all_eggs";
        //Debug.Log("SendRequest start");
        //string user_key = this.userId;
            if (!(SessionDate.userId == null) && !(user.text == null))
            {
                WWWForm formdata = new WWWForm();
                formdata.AddField("user", user.text);
                formdata.AddField("user_key", SessionDate.userId);
                formdata.AddField("function", function);
                UnityWebRequest request = UnityWebRequest.Post("http://mychicken.site/include/api/eggs.php", formdata);
                //yield return new WaitForSeconds(3);
                yield return request.SendWebRequest();
                Debug.Log("Ответ сервера - " + request.downloadHandler.text);

                PostStruct postFromServer = JsonUtility.FromJson<PostStruct>(request.downloadHandler.text);

                //Debug.Log(postFromServer.message);

                //Message.text = postFromServer.message;
                eggs.text = postFromServer.eggs;
                range.text = "за " + postFromServer.range + " дней";
            }
        

    }

}
