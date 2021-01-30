using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxigenBar : MonoBehaviour
{
    public float oxigen;
    public float oxigenCapcity;
    public Image fillImage;
    public Slider slider;

    public Player playerInstance;
    // Start is called before the first frame update
    void Start()
    {
        playerInstance.setRechargeOxigen(false);
        //slider = GetComponent<Slider>(); // search for the slider component and make a reference
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

        if(playerInstance.getRechregeOxigen())
        {
            ChargeOxigen();
        }
        else
        {
            UnChargeOxigen();
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



    private void UnChargeOxigen()
    {
        if (oxigen > 1)
        {
            oxigen -= Time.deltaTime;
        }
        else if (oxigen <= 1 && oxigen > 0)
        {
            oxigen -= (Time.deltaTime * 0.8f);

        }
    }

    private void ChargeOxigen()
    {
        if (oxigen < oxigenCapcity)
        {
            oxigen += Time.deltaTime;
        }
    }



}
