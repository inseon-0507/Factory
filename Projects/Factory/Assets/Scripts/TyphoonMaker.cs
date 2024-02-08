using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StellarGames
{
    public class TyphoonMaker : MonoBehaviour, IFactorySpell
    {
        [SerializeField] private GameObject prefab;

        public GameObject Make()
        {
            GameObject newGameObject = Instantiate(this.prefab, this.gameObject.transform);
            return newGameObject;
        }
    }
}
