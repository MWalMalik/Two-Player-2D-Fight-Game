using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECCameraBoundary : MonoBehaviour
{
    [SerializeField]
    GameObject model;

    [SerializeField]
    float timeOffset; // how long it takes camera to reach player

    [SerializeField]
    Vector2 posOffset; // away from the wall

    [SerializeField]
    float topLimit;
    [SerializeField]
    float bottomLimit;
    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;

    private Vector3 velocity;
    private Vector3 startPos;
    private Vector3 endPos;

    void Start()
    {
    }

    void Update()
    {
        startPos = transform.position;
        endPos = model.transform.position;
        endPos.x += posOffset.x;
        endPos.y = 0;
        endPos.z = -10;

        transform.position = Vector3.SmoothDamp(startPos, endPos, ref velocity, timeOffset);

        transform.position = new Vector3 (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
        );
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit)); // horizontal top line
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(rightLimit, bottomLimit)); // horizontal bottom line
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(leftLimit, bottomLimit)); // vertical left line
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit)); // vertical right line
    }
}