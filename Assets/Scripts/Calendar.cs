using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calendar : MonoBehaviour
{

    public Text year;
    public Text month;
    public Text day;
    public Text messageError;
    public string date;



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
            Debug.Log(date);
        }
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
}
