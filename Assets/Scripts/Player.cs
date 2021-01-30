using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool RechargeOxigen;

    // Start is called before the first frame update
    void Start()
    {
        
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
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dome"))
        {
            RechargeOxigen = false;
        }
    }


    public void setRechargeOxigen(bool yesNo) { RechargeOxigen = yesNo; }
    public bool getRechregeOxigen() { return RechargeOxigen; }
}
