using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float steerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(moveAmount, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Hit");
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Yo");
    }
}
