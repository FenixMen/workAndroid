using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Calendar : MonoBehaviour
{

    public Text year;
    public Text month;
    public Text day;
    public Text valueEggs;
    public Text messageFromServer;
    public Text messageError;
    public string date;
    public GameObject Panel;
    public GameObject Loading;
    public GameObject DateCalendar;
    public InputField inputYear;
    public InputField inputMonth;
    public InputField inputDay;
    public InputField inputEggs;


    public void ButtonUserDate()
    {
        Debug.Log("userDate start");
        if (year.text == "" || month.text == "" || day.text == "")
        {
            messageError.text = "Заполните все поля";
            Debug.Log("Зашли в условие");
        }
        else
        {
            messageError.text = "";
            date = year.text + "-" + month.text + "-" + day.text;
            Panel.SetActive(true);
        }
    }

    public void ButtonEggsValue()
    {
        messageError.text = "";
        int test;
        if (valueEggs.text == "")
        {
            messageError.text = "Не может быть пустым";
        }
        else {
                if(int.TryParse(valueEggs.text, out test))
                {
                            if (test > 0)
                            {
                                Loading.SetActive(true);
                                StartCoroutine(addEggs());
                            }
                            else
                            {
                                messageError.text = "Не может быть отрицательным";
                            }
                }
                else
                {
                    messageError.text = "Должно быть число";
                }
        }
    }



    public void GetValue()
    {

    }

    private void addNewEggs()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void closeCalendar()
    {
        inputYear.text = "";
        inputMonth.text = "";
        inputDay.text = "";
        inputEggs.text = "";
        DateCalendar.SetActive(false);
    }


    [System.Serializable]
    public struct PostStruct
    {
        public string message;
        //public string eggs;
        //public string range;
        public string user;
    }


    public IEnumerator addEggs()
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
            formdata.AddField("value", valueEggs.text);
            formdata.AddField("date", date);

            UnityWebRequest request = UnityWebRequest.Post("http://mychicken.site/include/api/eggs.php", formdata);
            //yield return new WaitForSeconds(3);
            yield return request.SendWebRequest();
            Debug.Log("Ответ сервера - " + request.downloadHandler.text);

            PostStruct postFromServer = JsonUtility.FromJson<PostStruct>(request.downloadHandler.text);

            Debug.Log(postFromServer.message);

            messageFromServer.text = postFromServer.message;
            
            Loading.SetActive(false);
            Panel.SetActive(false);
            //eggs.text = postFromServer.eggs;
            //range.text = "за " + postFromServer.range + " дней";
        }
    }




    public IEnumerator ubdateEggs()
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
            formdata.AddField("value", valueEggs.text);
            formdata.AddField("date", date);

            UnityWebRequest request = UnityWebRequest.Post("http://mychicken.site/include/api/eggs.php", formdata);
            //yield return new WaitForSeconds(3);
            yield return request.SendWebRequest();
            Debug.Log("Ответ сервера - " + request.downloadHandler.text);

            PostStruct postFromServer = JsonUtility.FromJson<PostStruct>(request.downloadHandler.text);

            Debug.Log(postFromServer.message);

            messageFromServer.text = postFromServer.message;
            Loading.SetActive(false);
            Panel.SetActive(false);
            //eggs.text = postFromServer.eggs;
            //range.text = "за " + postFromServer.range + " дней";
        }
    }
}
