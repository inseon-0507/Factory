using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StellarGames
{
    public class WaterBalloonMaker : MonoBehaviour, IFactorySpell
    {
        [SerializeField] private GameObject balloonPrefab;
        [SerializeField] private GameObject waterParticlesPrefab;
        private List<GameObject> balloons = new List<GameObject>();
        private List<float> spawnTimes = new List<float>();

        public GameObject Make()
        {
            GameObject balloon = Instantiate(balloonPrefab, transform.position, Quaternion.identity);
            balloons.Add(balloon);
            spawnTimes.Add(Time.time);
            Rigidbody rb = balloon.GetComponent<Rigidbody>();
            if (rb != null)
            {
                float minForce = 8f;
                float maxForce = 12f;
                float forceMagnitude = Random.Range(minForce, maxForce);
                rb.AddForce(transform.forward * forceMagnitude, ForceMode.Impulse);
            }
            return balloon;
        }

        public void Update()
        {
            for (int i = balloons.Count - 1; i >= 0; i--)
            {
                GameObject balloon = balloons[i];
                float spawnTime = spawnTimes[i];
                if (balloon != null)
                {
                    if (Time.time - spawnTime >= 1.2f)
                    {
                        Explode(balloon.transform.position);
                        balloons.RemoveAt(i);
                        spawnTimes.RemoveAt(i);
                    }
                }
                else
                {
                    balloons.RemoveAt(i);
                    spawnTimes.RemoveAt(i);
                }
            }
        }

        private void Explode(Vector3 position)
        {
            Instantiate(waterParticlesPrefab, position, Quaternion.identity);
        }
    }
}
