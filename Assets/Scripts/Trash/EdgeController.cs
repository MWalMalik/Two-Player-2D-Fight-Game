using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeController : MonoBehaviour
{
    public GameObject MC;
    public GameObject EC;

    private float MCPos;
    private float ECPos;

    void Start()
    {
        MCPos = MC.transform.position.x;
        ECPos = EC.transform.position.x;
        Vector2[] colliderPoints;
        colliderPoints = GetComponent<EdgeCollider2D>().points;
        colliderPoints[0] = new Vector2(-9, 5f);
        colliderPoints[1] = new Vector2(-9, -3.44031f);
        colliderPoints[2] = new Vector2(9, -3.44031f);
        colliderPoints[3] = new Vector2(9, 5f);
        GetComponent<EdgeCollider2D>().points = colliderPoints;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Mathf.Abs(MC.transform.position.x) + Mathf.Abs(EC.transform.position.x));
        // if (Mathf.Abs(MC.transform.position.x) + Mathf.Abs(EC.transform.position.x) > 16.8f) {
        //     if(MC.transform.position.x<EC.transform.position.x) {
        //         pointX = Mathf.Abs(MC.transform.position.x);
        //     }
        //     else {
        //         pointX = Mathf.Abs(EC.transform.position.x);
        //     }
        //     Vector2[] colliderPoints;
        //     colliderPoints = GetComponent<EdgeCollider2D>().points;
        //     colliderPoints[0] = new Vector2(-pointX, 5f);
        //     colliderPoints[1] = new Vector2(-pointX, -3.44031f);
        //     colliderPoints[2] = new Vector2(pointX, -3.44031f);
        //     colliderPoints[3] = new Vector2(pointX, 5f);
        //     GetComponent<EdgeCollider2D>().points = colliderPoints;
        // }
        //Debug.Log(Distance(MC, EC));
        //Debug.Log(Vector3.Distance(MC.transform.position, EC.transform.position));
        

        //if (MCPos != MC.transform.position.x) {
            Debug.Log(Mathf.Abs(MC.transform.position.x - EC.transform.position.x));

            if (MC.transform.position.x >= -8.5 && MC.transform.position.x <=18.5) { // MC is on Center
                if (Mathf.Abs(MC.transform.position.x - EC.transform.position.x) < 10.5f) {
                    if (MC.transform.position.x < EC.transform.position.x) {
                        Vector2[] colliderPoints;
                        colliderPoints = GetComponent<EdgeCollider2D>().points;
                        colliderPoints[0] = new Vector2(-9-(MCPos-MC.transform.position.x), 5f);
                        colliderPoints[1] = new Vector2(-9-(MCPos-MC.transform.position.x), -3.44031f);
                        //colliderPoints[2] = new Vector2(9+(MC.transform.position.x-MCPos), -3.44031f);
                        //colliderPoints[3] = new Vector2(9+(MC.transform.position.x-MCPos), 5f);
                        GetComponent<EdgeCollider2D>().points = colliderPoints;
                    }

                    if (MC.transform.position.x > EC.transform.position.x) {
                        Vector2[] colliderPoints;
                        colliderPoints = GetComponent<EdgeCollider2D>().points;
                        //colliderPoints[0] = new Vector2(-9-(MCPos-MC.transform.position.x), 5f);
                        //colliderPoints[1] = new Vector2(-9-(MCPos-MC.transform.position.x), -3.44031f);
                        colliderPoints[2] = new Vector2(9+(MC.transform.position.x-MCPos), -3.44031f);
                        colliderPoints[3] = new Vector2(9+(MC.transform.position.x-MCPos), 5f);
                        GetComponent<EdgeCollider2D>().points = colliderPoints;
                    }
                }

            //     if (MC.transform.position.x > MCPos && Mathf.Abs(MC.transform.position.x - EC.transform.position.x) < 10.5f) { // moving to right
            //         Vector2[] colliderPoints;
            //         colliderPoints = GetComponent<EdgeCollider2D>().points;
            //         //colliderPoints[0] = new Vector2(-9+(MC.transform.position.x-MCPos), 5f);
            //         //colliderPoints[1] = new Vector2(-9+(MC.transform.position.x-MCPos), -3.44031f);
            //         colliderPoints[2] = new Vector2(9+(MC.transform.position.x-MCPos), -3.44031f);
            //         colliderPoints[3] = new Vector2(9+(MC.transform.position.x-MCPos), 5f);
            //         GetComponent<EdgeCollider2D>().points = colliderPoints;
            //     }

            // if (MC.transform.position.x < MCPos && Mathf.Abs(MC.transform.position.x - EC.transform.position.x) < 10.5f) { // moving to left
            //         Vector2[] colliderPoints;
            //         colliderPoints = GetComponent<EdgeCollider2D>().points;
            //         colliderPoints[0] = new Vector2(-9-(MCPos-MC.transform.position.x), 5f);
            //         colliderPoints[1] = new Vector2(-9-(MCPos-MC.transform.position.x), -3.44031f);
            //         //colliderPoints[2] = new Vector2(9-(MCPos-MC.transform.position.x), -3.44031f);
            //         //colliderPoints[3] = new Vector2(9-(MCPos-MC.transform.position.x), 5f);
            //         GetComponent<EdgeCollider2D>().points = colliderPoints;
            //     }
            }

            // if (MC.transform.position.x > EC.transform.position.x) { // MC RIGHT EC LEFT
            //     if (MC.transform.position.x > MCPos && Mathf.Abs(MC.transform.position.x - EC.transform.position.x) < 6f) { // moving to right
            //         Vector2[] colliderPoints;
            //         colliderPoints = GetComponent<EdgeCollider2D>().points;
            //         //colliderPoints[0] = new Vector2(-9+(MC.transform.position.x-MCPos), 5f);
            //         //colliderPoints[1] = new Vector2(-9+(MC.transform.position.x-MCPos), -3.44031f);
            //         colliderPoints[2] = new Vector2(9+(MC.transform.position.x-MCPos), -3.44031f);
            //         colliderPoints[3] = new Vector2(9+(MC.transform.position.x-MCPos), 5f);
            //         GetComponent<EdgeCollider2D>().points = colliderPoints;
            //     }

            // if (MC.transform.position.x < MCPos && Mathf.Abs(MC.transform.position.x - EC.transform.position.x) < 6f) { // moving to left
            //         Vector2[] colliderPoints;
            //         colliderPoints = GetComponent<EdgeCollider2D>().points;
            //         colliderPoints[0] = new Vector2(-9-(MCPos-MC.transform.position.x), 5f);
            //         colliderPoints[1] = new Vector2(-9-(MCPos-MC.transform.position.x), -3.44031f);
            //         //colliderPoints[2] = new Vector2(9-(MCPos-MC.transform.position.x), -3.44031f);
            //         //colliderPoints[3] = new Vector2(9-(MCPos-MC.transform.position.x), 5f);
            //         GetComponent<EdgeCollider2D>().points = colliderPoints;
            //     }
            // }
            
        //}
    }

    private float Distance(GameObject MC, GameObject EC) {
        float Distance = 0f;

        if (MC.transform.position.x >= 0 && EC.transform.position.x >= 0) {
            Distance = Mathf.Abs(MC.transform.position.x - EC.transform.position.x);
        }

        if (MC.transform.position.x <= 0 && EC.transform.position.x <= 0) {
            Distance = Mathf.Abs(MC.transform.position.x - EC.transform.position.x);
        }

        if (MC.transform.position.x >= 0 && EC.transform.position.x <= 0) {
            Distance = (MC.transform.position.x + Mathf.Abs(EC.transform.position.x));
        }

        if (MC.transform.position.x <= 0 && EC.transform.position.x >= 0) {
            Distance = (Mathf.Abs(MC.transform.position.x) + EC.transform.position.x);
        }

        return Distance;
    }
}

// Max distance can be 17