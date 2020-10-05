﻿using TMPro;
using UnityEngine;

namespace Terminal
{
    public class ProcessingItemButton : TerminalAddRemoveButton
    {
        [HideInInspector]
        public CraftingRecipe craftingRecipe;

        [SerializeField] private TextMeshProUGUI amountRequiredText;

        private void Update()
        {
            // Adds amount
            if (_adding && _delay <= 0)
            {
                if (craftingRecipe.CanCraft(PlayerInventory, _amount + 1))
                {
                    UpdateAmount(_amount += 1);
                    _delay = delayReset;
                }
            }

            // Removes amount
            if (_removing && _delay <= 0)
            {
                if (_amount > 0)
                {
                    UpdateAmount(_amount -= 1);
                    _delay = delayReset;
                }
            }

            // Timer
            if (_delay > 0)
            {
                _delay -= Time.deltaTime;
            }
        }

        public void ResetAmount()
        {
            UpdateAmount(0);
        }

        protected override void UpdateAmount(int changeAmount)
        {
            base.UpdateAmount(changeAmount);
            amountRequiredText.text = "" + craftingRecipe.Materials[0].Amount * _amount;
        }
    }
}
