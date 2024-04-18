using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace HiddenStats
{// Token: 0x02000007 RID: 7
    public static class GUI
    {
        // Token: 0x0600001B RID: 27 RVA: 0x00002EB4 File Offset: 0x000010B4
        public static bool Toggle()
        {
            bool flag = !GUI.GUIRoot.gameObject.activeSelf;
            GUI.GUIRoot.gameObject.SetActive(flag);
            return flag;
        }

        // Token: 0x0600001C RID: 28 RVA: 0x00002EEB File Offset: 0x000010EB
        public static void SetVisible(bool visible)
        {
            GUI.GUIRoot.gameObject.SetActive(visible);
        }

        // Token: 0x0600001D RID: 29 RVA: 0x00002F00 File Offset: 0x00001100
        public static void Init()
        {
            GUI.GUIController = new GameObject("GUIController").transform;
            UnityEngine.Object.DontDestroyOnLoad(GUI.GUIController.gameObject);
            GUI.CreateCanvas();
            GUI.GUIRoot = GUI.m_canvas.transform;
            GUI.GUIRoot.SetParent(GUI.GUIController);
        }

        // Token: 0x0600001E RID: 30 RVA: 0x00002F58 File Offset: 0x00001158
        public static void CreateCanvas()
        {
            GameObject gameObject = new GameObject("Canvas");
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
            GUI.m_canvas = gameObject.AddComponent<Canvas>();
            GUI.m_canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            GUI.m_canvas.sortingOrder = 100000;
            gameObject.AddComponent<CanvasScaler>();
            gameObject.AddComponent<GraphicRaycaster>();
        }

        // Token: 0x0600001F RID: 31 RVA: 0x00002FB0 File Offset: 0x000011B0
        public static Text CreateText(Transform parent, Vector2 offset, string text, TextAnchor anchor = TextAnchor.MiddleCenter, int font_size = 20)
        {
            GameObject gameObject = new GameObject("Text");
            gameObject.transform.SetParent((parent != null) ? parent : GUI.GUIRoot);
            RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
            rectTransform.SetTextAnchor(anchor);
            rectTransform.anchoredPosition = offset;
            Text text2 = gameObject.AddComponent<Text>();
            text2.horizontalOverflow = HorizontalWrapMode.Overflow;
            text2.verticalOverflow = VerticalWrapMode.Overflow;
            text2.alignment = anchor;
            text2.text = text;
            text2.font = ResourceManager.LoadAssetBundle("shared_auto_001").LoadAsset<Font>("04B_03__");
            text2.fontSize = font_size;
            text2.color = Color.grey;
            return text2;
        }

        // Token: 0x06000020 RID: 32 RVA: 0x00003059 File Offset: 0x00001259
        public static void SetTextAnchor(this RectTransform r, TextAnchor anchor)
        {
            r.anchorMin = GUI.AnchorMap[anchor];
            r.anchorMax = GUI.AnchorMap[anchor];
            r.pivot = GUI.AnchorMap[anchor];
        }

        // Token: 0x04000011 RID: 17
        public static Font font;

        // Token: 0x04000012 RID: 18
        public static Transform GUIRoot;

        // Token: 0x04000013 RID: 19
        public static Transform GUIController;

        // Token: 0x04000014 RID: 20
        private static Canvas m_canvas;

        // Token: 0x04000015 RID: 21
        public static readonly Dictionary<TextAnchor, Vector2> AnchorMap = new Dictionary<TextAnchor, Vector2>
        {
            {
                TextAnchor.LowerLeft,
                new Vector2(0f, 0f)
            },
            {
                TextAnchor.LowerCenter,
                new Vector2(0.5f, 0f)
            },
            {
                TextAnchor.LowerRight,
                new Vector2(1f, 0f)
            },
            {
                TextAnchor.MiddleLeft,
                new Vector2(0f, 0.5f)
            },
            {
                TextAnchor.MiddleCenter,
                new Vector2(0.5f, 0.5f)
            },
            {
                TextAnchor.MiddleRight,
                new Vector2(1f, 0.5f)
            },
            {
                TextAnchor.UpperLeft,
                new Vector2(0f, 1f)
            },
            {
                TextAnchor.UpperCenter,
                new Vector2(0.5f, 1f)
            },
            {
                TextAnchor.UpperRight,
                new Vector2(1f, 1f)
            }
        };

        // Token: 0x04000016 RID: 22
        private static Color defaultTextColor = new Color(1f, 1f, 1f, 0.5f);
    }
}