using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SciptState : MonoBehaviour
{
    public GameObject MC;
    public GameObject EC;
    
    void Start()
    {
    }

    void Update()
    {
        //Debug.Log(Vector3.Distance(MC.transform.position, EC.transform.position));
        //Debug.Log(Vector3.Distance(MC.transform.position, new Vector3(0,MC.transform.position.y,0)));

        //Debug.Log(new Vector3(MC.transform.position.x, MC.transform.position.y, 0) - new Vector3(0, MC.transform.position.y, 0));

        //Debug.Log(Distance(MC,0f));
        
        // if (MC.position.x ) {
        //     GetComponent<MCCameraBoundary>().enabled = true;
        //     GetComponent<ECCameraBoundary>().enabled = false;
        // } else {
        //     GetComponent<MCCameraBoundary>().enabled = true;
        //     GetComponent<ECCameraBoundary>().enabled = true;
        // }

        // if (Distance(MC,0f) < 0 && Mathf.Abs(Distance(MC,EC)) > 10.39311f) {
        //     GetComponent<MCCameraBoundary>().enabled = true;
        //     GetComponent<ECCameraBoundary>().enabled = true;
        // }
        // else {
        //     GetComponent<MCCameraBoundary>().enabled = true;
        //     GetComponent<ECCameraBoundary>().enabled = false;
        // }
    }

    private float Distance(GameObject MC, GameObject EC) {
        return Mathf.Abs(MC.transform.position.x - EC.transform.position.x);
    }
    private float Distance(GameObject MC, float number) {
        return MC.transform.position.x - number;
    }
}
