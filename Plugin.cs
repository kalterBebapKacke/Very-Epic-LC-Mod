using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using LCSoundTool;
using LCSoundTool.Utilities;
using UnityEngine;
using System;

namespace MyFirstPlugin
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]




    public class Plugin : BaseUnityPlugin



    {
        private ConfigEntry<string> configGreeting;
        private ConfigEntry<bool> configDisplayGreeting;

        internal ManualLogSource logger;

        private const string PLUGIN_GUID = "MyFirstPlugin";
        private const string PLUGIN_NAME = "My First Plugin";
        private const string PLUGIN_VERSION = "1.0.0";

        //sounds
        public AudioClip metal_pipe;
        public AudioClip amongus;

        private void Awake()
        {
            // Test code
            Logger.LogInfo("Hello, world!");

            logger = BepInEx.Logging.Logger.CreateLogSource(PLUGIN_GUID);

            logger.LogInfo($"Plugin {PLUGIN_GUID} is loaded!");
        }

        private void Start()
        {
            logger.LogInfo("Loading Sounds");
            // Referencing Sounds
            metal_pipe = getAudioFromPath(@"S:\SteamLibrary\steamapps\common\Lethal Company\dev_mod\MyFirstPlugin\Sounds\metal_pipe.mp3");
            amongus = getAudioFromPath(@"S:\SteamLibrary\steamapps\common\Lethal Company\dev_mod\MyFirstPlugin\Sounds\sus.mp3");


            //Replace vanilla Sounds
            SoundTool.ReplaceAudioClip("Scan", metal_pipe); 
            SoundTool.ReplaceAudioClip("Aluminum1", amongus); 

            logger.LogInfo("Loaded Sounds");
            logger.LogInfo(System.AppDomain.CurrentDomain.BaseDirectory);
        }

        private AudioClip getAudioFromPath(string path)
        {
            AudioClip result = Mp3Utility.LoadFromDiskToAudioClip(path);
            if (result == null)
            {
                logger.LogInfo("Sound not loaded");
            }

            return result;
        }

    }
}
