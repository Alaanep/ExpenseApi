﻿using System;
using System.Diagnostics;
namespace BlazorSwordDamage
{
    
    public class SwordDamage
    {
        public const int BASE_DAMAGE = 3;
        public const int FLAME_DAMAGE = 2;

        public int Roll;
        public decimal MagicMultiplier = 1m;
        public int FlamingDamage = 0;
        public int Damage;

        public SwordDamage()
        {
            Debug.WriteLine("Created an instance of swordDamage");
        }

        public void CalculateDamage()
        {
            Damage = (int)(Roll * MagicMultiplier) + BASE_DAMAGE + FlamingDamage;
            Debug.WriteLine($"CalculateDamage finished: {Damage} (roll: {Roll})");
        }

        public void SetMagic(bool isMagic)
        {
            if (isMagic)
            {
                MagicMultiplier = 1.75m;
            }else
            {
                MagicMultiplier = 1m;
            }
            CalculateDamage();
            Debug.WriteLine($"SetMagic finished: {Damage} (roll: {Roll})");
        }

        public void SetFlaming(bool isFlaming)
        {
            CalculateDamage();
            if (isFlaming)
            {
                Damage += FLAME_DAMAGE;
            }
            Debug.WriteLine($"SetFlaming finished: {Damage} (roll: {Roll})");
        }

        
    }
}
