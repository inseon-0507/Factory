using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arcanum
{
    public class BulletMaker : MonoBehaviour, IFactorySpell
    {
        [SerializeField] private GameObject prefab;

        public GameObject Make()
        {
            GameObject newGameObject = Instantiate(this.prefab, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform);
            newGameObject.transform.rotation = Quaternion.Euler(90f, 0f, 90f);
            return newGameObject;
        }
    }
}
