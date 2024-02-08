﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arcanum
{
    public enum Spells { Typhoon, BlackHole, Bullet}

    [RequireComponent(typeof(BlackHoleMaker))]
    [RequireComponent(typeof(TyphoonMaker))]
    [RequireComponent(typeof(BulletMaker))]
    public class SpellFactory : MonoBehaviour
    {
        public void BuildSpell(Spells type)
        {
            if(Spells.BlackHole == type)
            {
                var blackHole = this.GetComponent<BlackHoleMaker>().Make();
                blackHole.transform.position = this.transform.position;
            }
            else if (Spells.Typhoon == type)
            {
                var typhoon = this.GetComponent<TyphoonMaker>().Make();
                typhoon.transform.position = this.transform.position;
            }
            else if (Spells.Bullet == type)
            {
                var bullet = this.GetComponent<BulletMaker>().Make();
                bullet.transform.position = this.transform.position;
            }
        }

        public void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {
                this.BuildSpell(Spells.BlackHole);
            }
            else if(Input.GetButtonDown("Fire1"))
            {
                this.BuildSpell(Spells.Typhoon);
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                this.BuildSpell(Spells.Bullet);
            }
         }

    }

}
