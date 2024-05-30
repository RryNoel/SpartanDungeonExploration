using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;
    public Transform desPos;
    public float speed;

    private void Start()
    {
        transform.position = startPos.position;
        desPos = endPos;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, desPos.position, Time.deltaTime * speed);

        if (Vector3.Distance(transform.position, desPos.position) <= 0.05f)
        {
            if (desPos == endPos) desPos = startPos;
            else desPos = endPos;
        }
    }
}
