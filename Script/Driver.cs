using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] ParticleSystem dust;
    [SerializeField] float moveSpeed;
    [SerializeField] float steerSpeed;
    [SerializeField] float slowSpeed;
    [SerializeField] float moveSpeedBoost;
    [SerializeField] SpawnCargo sCargo;
    [SerializeField] SpawnDropPoint sDrop;
    [SerializeField] CountDownTimer timerText;
    private string CARGO_TAG = "Cargo";
    private string DROP_TAG = "Drop";
    private string SPEED_TAG = "SpeedBoost";
    private string OBJECT_TAG = "Object";
    private string LAKE_TAG = "Lake";
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
        if(collision.gameObject.CompareTag(OBJECT_TAG)){
            moveSpeed = slowSpeed;
            dust.Stop();
        }
    }

    void OnTriggerEnter2D(Collider2D trigger) {
        if(trigger.gameObject.CompareTag(CARGO_TAG)){
            sDrop.dropExist = false;
            sDrop.firstDrop = true;
        } 
        if(trigger.gameObject.CompareTag(DROP_TAG)){
            sCargo.cargoExist = false;
            sDrop.dropExist = true;
            timerText.currentTime = 10f;
        } 
        if(trigger.gameObject.CompareTag(SPEED_TAG)){
            moveSpeed = moveSpeedBoost;
            dust.Play();
        }
        if(trigger.gameObject.CompareTag(LAKE_TAG)){
            Destroy(gameObject);
        }
    }
}
