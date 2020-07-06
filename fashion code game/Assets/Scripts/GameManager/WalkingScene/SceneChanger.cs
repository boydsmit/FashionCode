using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManager.WalkingScene
{
    public class SceneChanger : MonoBehaviour
    {
        [SerializeField] private GameObject uiObject;
        [SerializeField] private string sceneName;
        private bool _colliding;

        private void Start()
        {
            uiObject.SetActive(false);
        }
        
        private void Update()
        {
            if (_colliding && Input.GetKeyDown(KeyCode.C))
            {    
               SceneManager.LoadScene(sceneName);
            }
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag("Player")) return;
            
            uiObject.SetActive(true);
            _colliding = true;

            StartCoroutine(WaitForSeconds(5));
        }

        private IEnumerator WaitForSeconds(int time)
        {
            yield return new WaitForSeconds(time);
            Destroy(uiObject);
        }
    }
}
