using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPosition : MonoBehaviour
{
    public Transform targetPosition;
    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = targetPosition.position;

    }

    // Update is called once per frame
    void Update()
    {
        //float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, step);

    }
}
