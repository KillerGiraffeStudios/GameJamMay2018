using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {
    RectTransform rect;
    public int maxSize;
    public int curSize;//DELETE
	// Use this for initialization
	void Awake () {
        rect = gameObject.GetComponent<RectTransform>();
        //maxSize = 100;//getMaxSize from health/power script
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, maxSize);
        //setBackBar to +2 of max
        curSize = maxSize;
    }

    /// <summary>
    /// Sets bar to length of num
    /// </summary>
    /// <param name="num">value to set bar width to</param>
    public void setBar(float num) {
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num);
    }
}
