using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int Speed { get; set; } = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckDestroy();
    }

    private void CheckDestroy()
    {
        if (transform.position.z < -14f)
            Destroy(gameObject);
    }

    private void Move()
    {
        transform.Translate(0f, 0f, -Speed* Time.deltaTime);
}
}
