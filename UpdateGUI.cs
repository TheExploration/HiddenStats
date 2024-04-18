using System;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using Dungeonator;

namespace HiddenStats
{
    internal class UpdateGUI : MonoBehaviour
    {
        public PlayerStats p;
        public Dungeon d;
        
       

        // Token: 0x06000019 RID: 25 RVA: 0x00002E64 File Offset: 0x00001064
        private void Update()
        {
            try
            {
                p = ETGModMainBehaviour.FindObjectOfType<PlayerStats>();
                d = ETGModMainBehaviour.FindObjectOfType<Dungeon>();




                if (p != null)
                {
                    HiddenStats.floorMagnificence.text = "Floor Magnificence: " + p.m_floorMagnificence.ToString();
                    HiddenStats.Magnificence.text = "Magnificence: " + p.m_magnificence.ToString();



                }






                HiddenStats.HeartMagnificence.text = "Heart Magnificence: " + RewardManager.AdditionalHeartTierMagnificence.ToString();

                HiddenStats.SynergyFactor.text = "Synergy Factor: " + SynergyFactorConstants.GetSynergyFactor().ToString();

                if (d != null)
                {
                    HiddenStats.generatedMagnificence.text = "Chest Magnificence: " + d.GeneratedMagnificence.ToString();
                    HiddenStats.TotalMagnificence.text = "Total Magnificence: " + (d.GeneratedMagnificence + p.Magnificence).ToString();
                }
            } catch (Exception e)
            {

            }
        }
    }
}