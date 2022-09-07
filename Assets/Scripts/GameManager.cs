using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameObject Camera;
    private static GameObject MC;
    private static GameObject EC;

    void Start()
    {
        Camera = GameObject.Find("Camera");
        EC = GameObject.Find("MC");
        MC = GameObject.Find("EC");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Mathf.Abs(MC.transform.position.x - EC.transform.position.x));
    }

    public static void MCCameraBoundary() {
        if (Mathf.Abs(MC.transform.position.x - EC.transform.position.x) < 17) {
            Camera.GetComponent<MCCameraBoundary>().enabled = true;
            Camera.GetComponent<ECCameraBoundary>().enabled = true;
        } else {
            Camera.GetComponent<MCCameraBoundary>().enabled = true;
            Camera.GetComponent<ECCameraBoundary>().enabled = false;
        }
    }

    public static void ECCameraBoundary() {
        if (Mathf.Abs(MC.transform.position.x - EC.transform.position.x) < 17) {
            Camera.GetComponent<MCCameraBoundary>().enabled = true;
            Camera.GetComponent<ECCameraBoundary>().enabled = true;
        } else {
            Camera.GetComponent<MCCameraBoundary>().enabled = false;
            Camera.GetComponent<ECCameraBoundary>().enabled = true;
        }
    }

    public static void CameraState(KeyCode KeyArg) {
        // Movement - Left:
        if (KeyArg == KeyCode.A || KeyArg == KeyCode.D) {
            MCCameraBoundary();
        }
        
        else if (KeyArg == KeyCode.Keypad4 || KeyArg == KeyCode.Keypad6) {
            ECCameraBoundary();
        }

        else {
            return;
        }
    }

    public static void Attack(KeyCode KeyArg) {
        if (Mathf.Abs(MC.transform.position.x - EC.transform.position.x) < 0.91f && 
        ((MC.transform.localScale.x>0 && EC.transform.localScale.x<0) || (MC.transform.localScale.x<0 && EC.transform.localScale.x>0)) &&
        (!MC.GetComponent<Animator>().GetBool("Crouch") &&  !EC.GetComponent<Animator>().GetBool("Crouch"))) { // using distance to calculate attack space, using local scale to make sure players are inront each other, using animator to makre sure attack does not happen during crouch moment
            if (KeyArg == KeyCode.Space) {
                ScoreManager.MCAttack();
                //Debug.Log("MC Attack");
            }

            else if (KeyArg == KeyCode.KeypadEnter) {
                ScoreManager.ECAttack();
                //Debug.Log("EC Attack");
                // Health.MCHealth -= 0.05f;
                // Debug.Log(Health.MCHealth);
            }
            
            else {
                return;
            }
        }
    }
}