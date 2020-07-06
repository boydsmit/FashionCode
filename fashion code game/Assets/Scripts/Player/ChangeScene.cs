using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class ChangeScene : MonoBehaviour
    {
        private bool _colliding;
        [SerializeField] private int scene;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {
                _colliding = true;
            }
        }

        public void ChangeScenes()
        {
            SceneManager.LoadScene(scene);
        }
        
        private void Update()
        {
            if (_colliding && Input.GetKeyDown(KeyCode.C))
            {
                ChangeScenes();
            }
        }
    }
}
