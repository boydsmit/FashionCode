using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clothing
{
    public class ClothingManager : MonoBehaviour
    {
        private GameObject _clothing;
        [SerializeField] private GameObject[] clothingPrefab;
        [SerializeField] private GameObject particlePrefab;
        private bool _timer;

        public void ChangeSleeve(string sleeveLength)
        {
            _clothing =  GameObject.FindWithTag("Clothing");
            var position = _clothing.transform.position;

            switch (sleeveLength)
            {
                case "long":
                    Instantiate(clothingPrefab[0], new Vector3(position.x,position.y,position.z), Quaternion.identity);
                    Destroy(_clothing);
                    //_clothing.GetComponent<SpriteRenderer>().sprite = clothingPrefab[0];
                    break;
                
                case "short":
                   
                    Instantiate(clothingPrefab[1], new Vector3(position.x,position.y,position.z),Quaternion.identity);
                    Destroy(_clothing);
                    //_clothing.GetComponent<SpriteRenderer>().sprite = clothingPrefab[1];
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