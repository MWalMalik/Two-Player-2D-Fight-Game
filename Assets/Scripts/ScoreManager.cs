using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MCAttack() {
        Health.ECHealth -= 0.05f;
        Debug.Log(Health.ECHealth);
    }

    private void ECAttack() {
        Health.MCHealth -= 0.05f;
        Debug.Log(Health.MCHealth);
    }
}
