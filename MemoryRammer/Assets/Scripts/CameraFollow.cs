using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float levelStartPos = -12f;
    public float levelEndPos = 185f;
 

    private float smoothDampTime = 0.15f;
    private Vector3 smoothDampVelocity = Vector3.zero;

    private float camWidth, camHeight, levelMinX, levelMaxX;

    void Start()
    {
        camHeight = Camera.main.orthographicSize * 2;
        camWidth = camHeight * Camera.main.aspect;

        // float leftBoundsWidth = leftBounds.GetComponentInChildren<SpriteRenderer>().bounds.size.x / 2;
        // float rightBoundsWidth = rightBounds.GetComponentInChildren<SpriteRenderer>().bounds.size.x / 2;
        //levelMinX = leftBounds.position.x + (camWidth / 2);
        // levelMaxX = rightBounds.position.x - (camWidth / 2);
        
        ///acima é pra quando tiver um background e quiser limitar a camera pelo tamanho do background


        levelMinX = levelStartPos + (camWidth / 2);
        levelMaxX = levelEndPos - (camWidth / 2);


    }

    void FixedUpdate()
    {
        if (target)
        {
            float targetX = Mathf.Max(levelMinX, Mathf.Min(levelMaxX, target.position.x));
            float x = Mathf.SmoothDamp(transform.position.x, targetX, ref smoothDampVelocity.x, smoothDampTime);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);


        }
    }

}
