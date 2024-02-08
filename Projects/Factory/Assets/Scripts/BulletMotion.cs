using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StellarGames
{
    public class BulletMotion : MonoBehaviour
    {
        [SerializeField] private float Speed = 5.0f;

        void Update()
        {
            var pos = this.transform.position;
            pos += this.Speed * Time.deltaTime * this.transform.right;
            this.transform.position = pos;
        }
    }
}