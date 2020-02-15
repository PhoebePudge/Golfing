using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour : MonoBehaviour
{
    [SerializeField] private Player character;
    [SerializeField] int l1;
    [SerializeField] int r1;
    [SerializeField] int l2;
    [SerializeField] int r2;
    #region enviroment
    [SerializeField] private Folliage[] terrain;
    [SerializeField] private List <GameObject> terrainArray;
    #endregion
    void Start(){
        character.Start();
        createFolliage();
        
    }
    
    void Update(){
        character.Update();
    }
    private void OnDrawGizmos(){
        character.onDrawGizmos();
    }
    [System.Serializable] struct Folliage{
        [SerializeField] public GameObject prefab;
        [SerializeField] public float percentageChance;
    }
    private void createFolliage(){
        GameObject parent = Instantiate(new GameObject());
        parent.name = "Enviroment";
        for (int x = l1; x < l2; x++){
            for (int y = r1; y < r2; y++){
                int index = Random.Range(0, terrain.Length);
                if (terrain[index].percentageChance > Random.Range(0, 100)){
                    GameObject gm = Instantiate(terrain[index].prefab);
                    gm.transform.position = new Vector3(x,0,y);
                    gm.transform.parent = parent.transform;
                    gm.AddComponent<BoxCollider>().isTrigger = true;
                    gm.AddComponent<EnviromentAnimation>();
                    terrainArray.Add(gm);
                }
            }
        }
    }
}
