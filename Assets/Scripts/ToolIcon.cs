using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ToolIcon : MonoBehaviour
{
    public HUDController HUD;
    public Sprite Icon;
    public Tools Tool;
    // Start is called before the first frame update
    void Update()
    {
        if (Icon != null) {
            this.gameObject.transform.Find("ToolIcon").GetComponent<Image>().sprite = Icon;
        }
    }

    public void SetActiveTool() {
        HUD.SetActiveTool(this.Tool);
    }
}
