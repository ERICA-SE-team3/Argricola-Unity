using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public float speed = 1f;
    public float amplitude = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetHover();
    }

    public void SetHover()
    {
        float y = Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(transform.position.x, transform.position.y + y, transform.position.z);
    }
}
