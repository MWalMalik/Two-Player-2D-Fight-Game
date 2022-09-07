using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private GameObject Camera;
    public float parallaxEffect;
    private float length;
    private float startPos;

    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("Camera");
        startPos = transform.position.x;
        length = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = Camera.transform.position.x * (1-parallaxEffect);
        float distance = Camera.transform.position.x * parallaxEffect;

        float desiredXPos = startPos + distance;
        
        transform.position = new Vector2(desiredXPos, transform.position.y);

        if (temp > startPos + length) {
            startPos += length;
        } else if (temp > startPos - length) {
            startPos -= length;
        }
    }
}