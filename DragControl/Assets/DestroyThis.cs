using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThis : MonoBehaviour
{
    
    public GameObject destroyEffect;
    
    public float hp;
    


    
    // Update is called once per frame
    void EarlyUpdate()
    {
        if(hp <= 0 )
        {
            //Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        if (hp <= 0)
        {
            //Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
