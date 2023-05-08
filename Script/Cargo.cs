using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour
{
    private string PLAYER_TAG = "Player";
    private void OnTriggerExit2D(Collider2D trigger) {
        if(trigger.gameObject.CompareTag(PLAYER_TAG)){
            Destroy(gameObject);
        }
    }
}
