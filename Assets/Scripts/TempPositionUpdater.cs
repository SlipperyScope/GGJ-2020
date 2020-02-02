using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPositionUpdater : MonoBehaviour
{
    public HUDController HUD;
    public GameObject Player;
    public GameObject Map;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var ppos = Player.transform.position;
        var mmin = Map.GetComponent<SpriteRenderer>().bounds.min;
        var mmax = Map.GetComponent<SpriteRenderer>().bounds.max;
        HUD.UpdatePosition(
            percent(ppos.x, mmin.x, mmax.x),
            percent(ppos.y, mmin.y, mmax.y)
        );
    }

    float percent(float position, float min, float max) {
        return Mathf.Min(100, Mathf.Max(0, (position - min) / (max - min)));
    }
}
