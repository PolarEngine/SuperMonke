using BepInEx;
using HarmonyLib;
using Photon.Pun;
using System.Reflection;
namespace SuperMonkee
{
    [BepInPlugin("com.polar.SuperMonke","SuperMonke","1.0.1")]
    public class Mod : BaseUnityPlugin
    {
        public static bool IsAllowed()
        {
            return PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED");
        }

        private void Start()
        {
            new Harmony("com.polar.SuperMonke").PatchAll(assembly:Assembly.GetExecutingAssembly());
        }
    }
}
