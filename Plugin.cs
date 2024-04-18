using BepInEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using MonoMod.RuntimeDetour;
using Gungeon;
using System.Net.NetworkInformation;
using System.Reflection;
using Microsoft;

namespace HiddenStats
{
    [BepInDependency(ETGModMainBehaviour.GUID)]
    [BepInPlugin(GUID, NAME, VERSION)]
    public class HiddenStats : BaseUnityPlugin
    {
        public const string GUID = "exploration.etg.hiddenstats";
        public const string NAME = "Hidden Stats";
        public const string VERSION = "1.0.0";
        public const string TEXT_COLOR = "#00FFFF";

        public static Text floorMagnificence;
        public static Text generatedMagnificence;
        public static Text Magnificence;
        public static Text TotalMagnificence;
        public static Text HeartMagnificence;
        public static Text SynergyFactor;
        


        public static int FontSize = 34;
        public void Start()
        {
            GUI.Init();
            ETGModMainBehaviour.WaitForGameManagerStart(GMStart);
            ETGModMainBehaviour.Instance.gameObject.AddComponent<UpdateGUI>();
            
            HiddenStats.floorMagnificence = GUI.CreateText(null, new Vector2(15f, 200f), "", TextAnchor.MiddleLeft, FontSize);
            floorMagnificence.gameObject.SetActive(true);

            HiddenStats.generatedMagnificence = GUI.CreateText(null, new Vector2(15f, 160f), "", TextAnchor.MiddleLeft, FontSize);
            generatedMagnificence.gameObject.SetActive(true);

            HiddenStats.Magnificence = GUI.CreateText(null, new Vector2(15f, 120f), "", TextAnchor.MiddleLeft, FontSize);
            Magnificence.gameObject.SetActive(true);

            HiddenStats.TotalMagnificence = GUI.CreateText(null, new Vector2(15f, 80f), "", TextAnchor.MiddleLeft, FontSize);
            TotalMagnificence.gameObject.SetActive(true);

            HiddenStats.HeartMagnificence = GUI.CreateText(null, new Vector2(15f, 40f), "", TextAnchor.MiddleLeft, FontSize);
            HeartMagnificence.gameObject.SetActive(true);

            HiddenStats.SynergyFactor = GUI.CreateText(null, new Vector2(15f, 0f), "", TextAnchor.MiddleLeft, FontSize);
            SynergyFactor.gameObject.SetActive(true);


        }


        
        public void GMStart(GameManager g)
        {
            Log($"{NAME} v{VERSION} started successfully.", TEXT_COLOR);

           
        }

        public static void Log(string text, string color="FFFFFF")
        {
            ETGModConsole.Log($"<color={color}>{text}</color>");
        }
    }

}
