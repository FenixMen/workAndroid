using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssEggs : MonoBehaviour
{
    public Text user;


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
