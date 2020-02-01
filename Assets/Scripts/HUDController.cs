using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Timer").GetComponent<Text>().text = "0:00";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
