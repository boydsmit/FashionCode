using UnityEngine;

namespace Clothing.ClothingPresets
{
    public class RandomPresetGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject[] clothingPrefabs;
        [SerializeField] private GameObject[] patternsPrefabs;
        private GameObject[] _spawnLocations;

        private readonly string[] _colorDictionary = 
            {"#D9221C", "#B365E5", "#4F42F5", "#61F6FF", "#7DEA3D", "#FFEA45", "#FF61A2", "#FFA61E"};
        
        
        private void Start()
        { 
            SpawnPrefabs();
        }    

        private void SpawnPrefabs()
        {
            _spawnLocations = GameObject.FindGameObjectsWithTag("Spawn");
            foreach (var spawnLocation in _spawnLocations)
            {
                var randomPrefab = Random.Range(0, clothingPrefabs.Length);
                var randomClothingColor = Random.Range(0, _colorDictionary.Length);
                var randomPatternColor = Random.Range(0, _colorDictionary.Length);
                var randomPattern = Random.Range(0, patternsPrefabs.Length + 1);
                ColorUtility.TryParseHtmlString(_colorDictionary[randomClothingColor], out var clothingColor);
                ColorUtility.TryParseHtmlString(_colorDictionary[randomPatternColor], out var patternColor);
                
                var spawnedPreset = Instantiate(clothingPrefabs[randomPrefab], spawnLocation.transform);
                if (patternsPrefabs.Length - randomPattern > 0 )
                {
                    var instantiatedPattern = Instantiate(patternsPrefabs[randomPattern], spawnedPreset.transform);
                    instantiatedPattern.GetComponent<SpriteRenderer>().color = patternColor;
                    instantiatedPattern.GetComponent<SpriteRenderer>().sortingOrder = 5;
                }

                spawnedPreset.GetComponent<SpriteRenderer>().color = clothingColor;
                spawnedPreset.GetComponent<SpriteRenderer>().sortingOrder = 3;
                spawnedPreset.transform.localScale  = new Vector3(0.7f,0.7f,0.7f);
            }
        }

        public void SetChosenPreset(GameObject spawnPoint)
        {    
            var presetManager = new PresetManager();
            
            var clothing= spawnPoint.transform.GetChild(0);
            var clothingName = clothing.name.Split('_');
            var color = ColorUtility.ToHtmlStringRGB(clothing.GetComponent<SpriteRenderer>().color);
            
            var pattern = clothing.transform.GetChild(0);
            var patternName = "null";
            var patternColor = "null";
            
            if (pattern != null)
            {
                patternName = pattern.name.Split('_')[1].Replace("(Clone)", "");
                patternColor = ColorUtility.ToHtmlStringRGB(pattern.GetComponent<SpriteRenderer>().color);
            }
            
            presetManager.WriteJsonFile(clothingName[0], clothingName[1], color, patternName, patternColor);
        }    
    }
}