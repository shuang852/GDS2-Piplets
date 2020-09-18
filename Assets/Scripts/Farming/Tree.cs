﻿using Player;
using UnityEngine;

namespace Farming
{
    public class Tree : InteractableObject
    {
        public bool treeDied;
        public int treeHealth;

        public override void InteractWithItem(Item item, PlayerScript player)
        {
            Debug.Log("hit");
            if (item.name == "Axe")
            {
                hit();
            }
        }

        public void hit()
        {
            Debug.Log("Hit");
            treeHealth = treeHealth - 1;
            DamageTree();
        }

        public void DamageTree()
        {
            Wood Wood = gameObject.GetComponentInChildren<Wood>();
            if (treeHealth == 2)
            {
                //changeTreeColour for now then changeTreeSprite
                Wood.WoodDrop(2);
            }
            if (treeHealth == 1)
            {
                //changeTreeColour for now then changeTreeSprite
                Wood.WoodDrop(2);
            }
            if (treeHealth == 0)
            {
                Wood.WoodDrop(1);
                Death();
            }
        }

        public void Death()
        {
            treeDied = true;
            SpriteRenderer m = GetComponent<SpriteRenderer>();
            m.enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            Wood Wood = gameObject.GetComponentInChildren<Wood>();
            Wood.woodOn();
        }
    }

}
