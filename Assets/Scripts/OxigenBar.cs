using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxigenBar : MonoBehaviour
{
  [SerializeField]        //Tiene que existir, eso es lo que hace el [serializedField] - es un input field
  public float oxigen;
  [SerializeField]
  public float oxigenCapcity;
  [SerializeField]
  public Image fillImage;
  [SerializeField]
  public GameObject slider;
  [SerializeField]
  public ProgressBar oxigenBar;
  [SerializeField]
  public Player playerInstance;

  // Start is called before the first frame update
  void Start()
  {
    oxigenBar.minimum = oxigenCapcity;
    oxigenBar.minimum = oxigenCapcity;
    //slider = GetComponent<Slider>(); // search for the slider component and make a reference
  }

  // Update is called once per frame
  void Update()
  {
    var sliderbar = slider.GetComponent<Slider>();

    if (sliderbar.value <= sliderbar.minValue)
    {
      fillImage.enabled = false;
    }
    if (sliderbar.value > sliderbar.minValue && !fillImage.enabled)
    {
      fillImage.enabled = true;
    }

    if (playerInstance.getRechregeOxigen())
    {
      ChargeOxigen();
    }
    else
    {
      UnChargeOxigen();
    }

    float fillvalue = oxigen / oxigenCapcity;
    sliderbar.value = fillvalue;
    oxigenBar.current = oxigen;
    if (fillvalue <= sliderbar.maxValue / 3)
    {
      //fillImage.color = Color.white; //set a color
    }
    else if (fillvalue > sliderbar.maxValue / 3)
    {
      //fillImage.color = Color.white; //set a color
    }


    if (oxigen < 0)
    {
      playerInstance.Looser();
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
