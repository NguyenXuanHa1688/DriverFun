using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDropPoint : MonoBehaviour
{
    [SerializeField] Transform[] pos;
    [SerializeField] GameObject dropPrefab;
    public bool dropExist = true;
    public bool firstDrop = false;
    private GameObject spawnDrop;
    void Update(){
        if(firstDrop == true){
            StartCoroutine(SpawnDrops());
        } 
    }
    IEnumerator SpawnDrops(){
        while(true){
            yield return new WaitForSeconds(2);
            if(dropExist == false){
                spawnDrop = Instantiate(dropPrefab);
                spawnDrop.transform.position = pos[Random.Range(0, pos.Length)].position;
                dropExist = true;
            }        
        }
    }
}
