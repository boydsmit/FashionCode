using UnityEngine;

namespace Clothing.ClothingPresets
{
    public class RandomPresetGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject[] prefabs;
         private GameObject[] _spawnLocations;
        
        private void Start()
        {
            _spawnLocations = GameObject.FindGameObjectsWithTag("Spawn");
            SpawnPrefabs();
        }    

        private void SpawnPrefabs()
        {
            foreach (var spawnLocation in _spawnLocations)
            {
                var random = Random.Range(0, prefabs.Length);
                var spawnedPreset = Instantiate(prefabs[random], spawnLocation.transform);
                
                spawnedPreset.transform.localScale  = new Vector3(0.8f,0.8f,0.8f);
            }
        }

        public void SetChosenPreset(GameObject preset)
        {
            var clothingData = preset.GetComponent<ClothingData>();
            var presetManager = new PresetManager();
            presetManager.WriteJsonFile(clothingData.GetClothingBase(), clothingData.GetLength(), clothingData.GetColor());
        }
    }
}