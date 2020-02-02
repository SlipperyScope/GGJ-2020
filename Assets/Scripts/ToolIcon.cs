using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ToolIcon : MonoBehaviour
{
    public Sprite Icon;
    // Start is called before the first frame update
    void Update()
    {
        if (Icon != null) {
            this.gameObject.transform.Find("ToolIcon").GetComponent<Image>().sprite = Icon;
        }
    }
}
