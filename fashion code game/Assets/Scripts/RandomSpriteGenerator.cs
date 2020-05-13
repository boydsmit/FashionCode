using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpriteGenerator : MonoBehaviour
{
    //public Sprite Shirt_Short_Sleeves;
    [SerializeField] 
    public GameObject[] prefabs;

    public int randomPrefab;

    // Start is called before the first frame update
    void Start()
    {
     

        Debug.Log("dit werkt niet");
        
        
        //  SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //  gameObject.GetComponent<SpriteRenderer>().color = new Color( Random.value, Random.value, Random.value, 1.0f );

        //  spriteRenderer.sprite = Shirt_Short_Sleeves;

    }

    public void CreateSprite()
    {
        randomPrefab = Random.Range(0, prefabs.Length);

        GameObject sprite = Instantiate(
            prefabs[randomPrefab], transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
        
        ChangeSpriteColor(sprite);
        
        
    }

    private void ChangeSpriteColor(GameObject sprite)
    {
        sprite.GetComponent<SpriteRenderer>().color = new Color(100f, 100f, 203f);

    }

    public void OnLoad()
    {
        
    }

    
  

    // Update is called once per frame
 



}

