using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {
    RectTransform rect;
    Image image;
    Color baseColor;
    public int maxSize;
    public int curSize;//DELETE
	// Use this for initialization
	void Awake () {
        rect = gameObject.GetComponent<RectTransform>();
        image = GetComponent<Image>();
        baseColor = image.color;
        //maxSize = 100;//getMaxSize from health/power script
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, maxSize);
        //setBackBar to +2 of max
        curSize = maxSize;
    }

    /// <summary>
    /// Sets bar to length of num
    /// </summary>
    /// <param name="percent">value to set bar width to</param>
    public void setBar(float percent) {
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, maxSize * percent);
    }

    public void lockBar(){
        image.color = Color.white;
    }
    public void unlockBar(){
        image.color = baseColor;
    }
}
