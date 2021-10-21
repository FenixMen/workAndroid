using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{

    




    private void Start()
    {
    }

    public void Update()
    {

        //выходим по нажатию назад
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }

    public string url = "http://mychicken.site/include/api/autorize.php";
    public Text Message;
    //public static string User;
    //public string UserId;
    public Text loginFromUser;
    public Text passwordFromUser;
    public InputField EnterLogin;
    public InputField EnterPassword;


    [System.Serializable]
    public struct PostStruct
    {
        public string message;
        public string user;
        public string userId;

    }
 

        void InrutClear()
    {
        EnterLogin.text = "";
        EnterPassword.text = "";
    }

        public void login()
        {
            if (EnterLogin.text == "" || EnterPassword.text == "")
            {
                Message.text = "Поле не может быть пустым";
                InrutClear();
        }
            else
            {
                loginFromUser.text = EnterLogin.text;
                passwordFromUser.text = EnterPassword.text;
                StartCoroutine(SendRequest());
                //Debug.Log(loginFromUser.text);
            }


        }

        public void ButtonToServer()
        {
            login();

        }
        private void ifLogin()
        {
            SceneManager.LoadScene(1);
        }

        private IEnumerator SendRequest()
        {
            WWWForm formdata = new WWWForm();
            formdata.AddField("login", loginFromUser.text);
            formdata.AddField("password", EnterPassword.text);
            UnityWebRequest request = UnityWebRequest.Post(url, formdata);
            //yield return new WaitForSeconds(3);
            yield return request.SendWebRequest();
            //Debug.Log("Ответ сервера - " + request.downloadHandler.text);
            PostStruct postFromServer = JsonUtility.FromJson<PostStruct>(request.downloadHandler.text);

            //Debug.Log(postFromServer.user);
            Message.text = postFromServer.message;
            if (Message.text == "true")
            {
                SessionDate.user = postFromServer.user;
                SessionDate.userId = postFromServer.userId;
                ifLogin();
            }
            else InrutClear();
        // Debug.Log("answer2 = " + postFromServer.answer2);

    }

 
        
    




















    //IEnumerator что бы можно было получить ответ от сервера (нужено подключить System.Collections;)  позволяет использовать yield - ожидание
    /* private IEnumerator SendPHP()
     {
         WWWForm form = new WWWForm();
         form.AddField("Message", "Запрос из программы");

         using (UnityWebRequest www = UnityWebRequest.Post("http://mychicken.site/test/test.php", form))
         {
             yield return www.SendWebRequest();

             if (www.result != UnityWebRequest.Result.Success)
             {
                 Debug.Log(www.error);

             }
             else
             {
                 if (www.isDone)
                 {
                     //www.GetType();
                    // FromServer = JsonUtility.FromJson<Game>(www.downloadHandler.text);
                     // MoneyTxt.text = JsonUtility.ToJson(playerInstance, true);
                     Debug.Log("Ответ сервера - " + www.downloadHandler);
                     //AnswerList answerList = new AnswerList();
                    // answerList = JsonUtility.FromJson<AnswerList>(www.downloadHandler.text);
                     //return answerList;
                     // var answer = JsonUtility.FromJson<T>(www.downloadHandler.text);
                 }
             }
         }
     }*/

}






