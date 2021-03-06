using UnityEngine;
using HarmonyLib;
using UnityEngine.UI;
namespace CENoIntroVideoMod.Patches
{
    [HarmonyPatch(typeof(IntroVideo))]
    [HarmonyPatch("Update")]
    static class Patch_RemoveIntro
    {
        public static void Prefix(IntroVideo __instance)
        {
            if (__instance.startDone == 0 && __instance.manageContent.appInitializationDone > 0)
            {
                __instance.startDone = 1;
                Button component = __instance.transform.parent.Find("CloseIntroVideoButton").gameObject.GetComponent<Button>();
                component.onClick.Invoke();
            }
        }
    }
}