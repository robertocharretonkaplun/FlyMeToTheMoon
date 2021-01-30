using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool RechargeOxigen;
    private bool Win;
    private bool Loose;

    // Start is called before the first frame update
    void Start()
    {
        Win = false;
        Loose = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    

    //------------------ triggers -----------------//
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dome"))
        {
            RechargeOxigen = true;
            Debug.Log(RechargeOxigen.ToString());
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dome"))
        {
            RechargeOxigen = false;
            Debug.Log(RechargeOxigen.ToString());

        }
    }


    public void setRechargeOxigen(bool yesNo) { RechargeOxigen = yesNo; }
    public bool getRechregeOxigen() { return RechargeOxigen; }

    public void Winner() { Win = true; }
    public void Looser() { Loose = true; }

}
