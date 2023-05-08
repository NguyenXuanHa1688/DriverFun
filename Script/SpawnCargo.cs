using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCargo : MonoBehaviour
{
    [SerializeField] Transform[] pos;
    [SerializeField] GameObject cargoPrefab;
    public bool cargoExist = false;
    private GameObject spawnCargo;
    void Update(){
        StartCoroutine(SpawnCargos());
    }
    IEnumerator SpawnCargos(){
        while(true){
            yield return new WaitForSeconds(2);
            if(cargoExist == false){
                spawnCargo = Instantiate(cargoPrefab);
                spawnCargo.transform.position = pos[Random.Range(0, pos.Length)].position;
                cargoExist = true;
            }        
        }
    }
}
