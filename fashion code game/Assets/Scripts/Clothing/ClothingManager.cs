using UnityEngine;

namespace Clothing
{
    public class ClothingManager : MonoBehaviour
    {
        private GameObject _clothing;
        [SerializeField] private Sprite[] sprite;

        public void ChangeSleeve(string sleeveLength)
        {
            _clothing =  GameObject.FindWithTag("Clothing");
            switch (sleeveLength)
            {
                case "long":
                    _clothing.GetComponent<SpriteRenderer>().sprite = sprite[0];
                    break;
                
                case "short":
                    _clothing.GetComponent<SpriteRenderer>().sprite = sprite[1];
                    break;
            }
        }
    }
}