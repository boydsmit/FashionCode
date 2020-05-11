using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpriteGenerator : MonoBehaviour
{
    //public Sprite Shirt_Short_Sleeves;
    [SerializeField] 
    private GameObject[] prefabs;

    private int randomPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        randomPrefab = Random.Range(0, 13);
       
        Instantiate(prefabs[randomPrefab],transform.position,  Quaternion.Euler(new Vector3(-90, 0, 0)));
        
        
      //  SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
      //  gameObject.GetComponent<SpriteRenderer>().color = new Color( Random.value, Random.value, Random.value, 1.0f );
        
      //  spriteRenderer.sprite = Shirt_Short_Sleeves;
        
    }

    // Update is called once per frame
    void Update () 
    {
        
        
        {
            // pick a random color
            
       
            // apply it on current object's material
            
            
        }
  
         
    }
}
