using UnityEngine;

namespace Clothing
{
    public class SpriteHandler : MonoBehaviour
    {
        [SerializeField] private GameObject[] prefabs;

        public void Start()
        {
            var randomPrefab = Random.Range(0, prefabs.Length);
            var previousObject = GameObject.FindWithTag("Clothing");

            if (previousObject != null) Destroy(previousObject);

            var instantiatedObject = Instantiate(
                prefabs[randomPrefab], transform.position, Quaternion.Euler(new Vector2(0, 0)));
            instantiatedObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
    }
}