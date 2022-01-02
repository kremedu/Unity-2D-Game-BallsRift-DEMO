using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelterBehaviour : MonoBehaviour
{
    public GameObject camobj;
    private Vector3 offset;
    private Vector3 begOffset;
    private Vector3 melterMoveOffsetVal;
    private Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        offset.y = transform.position.y - camobj.transform.position.y;
        
    }

    // Update is called once per frame
    /*void Update()
    {
        if(camobj.transform.position.y <= lastPosition.y)
        {
            Vector3 position = transform.position;
            position.y = offset.y + camobj.transform.position.y;
            transform.position = position;   
        }
        if (camobj.transform.position.y > lastPosition.y)
        {
            offset.y = transform.position.y - camobj.transform.position.y;
        }
    }*/
    private void LateUpdate() //IDE Own Speed gets faster every X Seconds;
    {
        if (camobj.transform.position.y <= lastPosition.y)
        {
            Vector3 position = transform.position;
            position.y = offset.y + camobj.transform.position.y;
            transform.position = position;
        }
        if (camobj.transform.position.y > lastPosition.y)
        {
            offset.y = transform.position.y - (camobj.transform.position.y);
        }
        lastPosition = camobj.transform.position;
    }
}
