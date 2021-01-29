using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxigenBar : MonoBehaviour
{
    public float oxigen;
    public float oxigenCapcity;
    public Image fillImage;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>(); // search for the slider component and make a reference
    }

    // Update is called once per frame
    void Update()
    {

        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }
        if (slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }
        if (oxigen > 1)
        {
            oxigen -= Time.deltaTime;
        }
        else if (oxigen <= 1)
        {
            oxigen -= (Time.deltaTime * 0.8f);
        }
        
        float fillvalue = oxigen / oxigenCapcity;
        slider.value = fillvalue;

        if(fillvalue <= slider.maxValue / 3)
        {
            //fillImage.color = Color.white; //set a color
        }
        else if (fillvalue > slider.maxValue / 3)
        {
            //fillImage.color = Color.white; //set a color
        }
            
    }

}
