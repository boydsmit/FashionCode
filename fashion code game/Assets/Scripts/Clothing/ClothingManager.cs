using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clothing
{
    public class ClothingManager : MonoBehaviour
    {
        private GameObject _clothing;
        [SerializeField] private Sprite[] sprite;
        [SerializeField] private GameObject particlePrefab;
        private bool _timer;

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

        private void Update()
        {
            var activeParticles = GameObject.FindGameObjectsWithTag("Particle");
            if (_timer && activeParticles.Length > 0)
            {
                foreach (var particle in activeParticles)
                {
                    var particleSys = particle.GetComponent<ParticleSystem>();
                    if (particleSys.isPlaying)
                    {
                        particleSys.Stop();
                    }
                }
            }
        }


        public void PlayParticleOnClick()
        {
            _timer = false;
            var particles = GameObject.FindGameObjectsWithTag("Particle");
            var clothingPosition = GameObject.FindWithTag("Clothing").transform.position;
            if (particles != null && particles.Length > 0)
            {
                foreach (var particle in particles)
                {
                    particle.GetComponent<ParticleSystem>().Play();
                }
                
            }
            else
            {
                Instantiate(particlePrefab, clothingPosition, Quaternion.Euler(new Vector2(0, 0)));
            }
            
            StartCoroutine(ParticleTimer());
        }
    
        private IEnumerator ParticleTimer()
        {
            yield return new WaitForSeconds (0.5f);
            _timer = true;
        }
    }
}