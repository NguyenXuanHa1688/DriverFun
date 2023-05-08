using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float steerSpeed;
    [SerializeField] SpawnCargo sCargo;
    [SerializeField] SpawnDropPoint sDrop;
    [SerializeField] CountDownTimer timerText;
    private string CARGO_TAG = "Cargo";
    private string DROP_TAG = "Drop";
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
        Debug.Log("Cargo:" + sCargo.cargoExist);
        Debug.Log("Drop:" + sDrop.dropExist);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Hit");
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
    }
}
