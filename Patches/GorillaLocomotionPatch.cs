using HarmonyLib;
using UnityEngine;

namespace SuperMonkee.Patches
{
    [HarmonyPatch(typeof(GorillaTagger), "Start")]
    public class GorillaLocomotionPatch
    {
        private static void Prefix()
        {
            new GameObject("SuperMonke").AddComponent<SuperPhysics>();
        }
    }
}
