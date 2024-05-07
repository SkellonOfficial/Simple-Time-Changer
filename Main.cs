using BepInEx;
using UnityEngine;

namespace SimpleTimerChanger
{
    [BepInPlugin("org.skellon.gorillatag.timechanger", "SimpleChangerChanger", "1.0.0")]
    class Main : BaseUnityPlugin
    {
        static Rect windowRect = new Rect(0, 0, 215, 210);
        void Update()
        {
            timer2--;
            timer--;
            if (UnityInput.Current.GetKey(KeyCode.F3) && timer < 1)
            {
                ShownMainGUI = !ShownMainGUI;
                timer = 30;
            }
            if (UnityInput.Current.GetKey(KeyCode.F2) && timer2 < 1)
            {
                ColorPurple = !ColorPurple;
                timer2 = 30;
            }
            if (ColorPurple)
            {
                textColor = Color.magenta;
            }
            if (!ColorPurple)
            {
                textColor = Color.red;
            }
        }
        void OnGUI()
        {
            GUI.backgroundColor = Color.black;
            if (ShownMainGUI)
            {
                windowRect = GUILayout.Window(0, windowRect, MainGUI, "");
            }
            else
            {
                windowRect = new Rect(0, 0, 215, 210);
            }
        }
        static void MainGUI(int windowID)
        {
            GUILayout.BeginVertical();
            GUILayout.Label("Simple Time Changer", GUILayout.Width(175));
            GUILayout.EndVertical();
            GUI.skin.box.normal.textColor = textColor;
            GUI.skin.button.normal.textColor = textColor;
            GUI.skin.label.normal.textColor = textColor;
            GUI.skin.toggle.normal.textColor = textColor;
            GUI.skin.toggle.active.textColor = textColor;
            GUI.skin.button.active.textColor = textColor;
            GUI.backgroundColor = Color.black;
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Day", GUILayout.Width(150), GUILayout.Height(24)))
            {
                BetterDayNightManager.instance.SetTimeOfDay(3);
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Night", GUILayout.Width(150), GUILayout.Height(24)))
            {
                BetterDayNightManager.instance.SetTimeOfDay(0);
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Sunrise", GUILayout.Width(150), GUILayout.Height(24)))
            {
                BetterDayNightManager.instance.SetTimeOfDay(1);
            }
            GUILayout.EndHorizontal();
            GUILayout.Label("Made By Skellon", GUILayout.Width(175));
            GUILayout.EndVertical();
            GUI.DragWindow();
        }
        static bool ShownMainGUI = false;
        static bool ColorPurple = true;
        static float timer = 0;
        static float timer2 = 0;
        static Color textColor = Color.magenta;
    }
}
