﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using ModTool;

namespace ModTool
{

    /// <summary>
    /// Example mod manager. This menu displays all mods and lets you enable/disable them.
    /// </summary>
    public class ModMenu : MonoBehaviour
    {
        public ModManager modManager;

        public Dictionary<Mod, ModItem> modItems;

        /// <summary>
        /// The content panel where the menu items will be parented
        /// </summary>
        public Transform menuContentPanel;

        /// <summary>
        /// The prefab for the mod menu item
        /// </summary>
        public ModItem modItemPrefab;

        /// <summary>
        /// Button that will start loading enabled mods
        /// </summary>
        public Button loadButton;

        /// <summary>
        /// Are the enabled mods loaded?
        /// </summary>
        public bool isLoaded;

        public virtual void Start()
        {
            modItems = new Dictionary<Mod, ModItem>();

            modManager = ModManager.instance;

            modManager.refreshInterval = 2;

            foreach (Mod mod in modManager.mods)
                OnModFound(mod);

            modManager.ModFound += OnModFound;
            modManager.ModRemoved += OnModRemoved;
            modManager.ModLoaded += OnModLoaded;
            modManager.ModUnloaded += OnModUnloaded;

            Application.runInBackground = true;
        }

        public virtual void OnModFound(Mod mod)
        {
            ModItem modItem = Instantiate(modItemPrefab);
            modItem.Initialize(mod, menuContentPanel);
            modItem.SetToggleInteractable(!isLoaded);
            modItems.Add(mod, modItem);
        }

        public virtual void OnModRemoved(Mod mod)
        {
            ModItem modItem;

            if (modItems.TryGetValue(mod, out modItem))
            {
                modItems.Remove(mod);
                Destroy(modItem.gameObject);
            }
        }

        public virtual void SetTogglesInteractable(bool interactable)
        {
            foreach (ModItem item in modItems.Values)
            {
                item.SetToggleInteractable(interactable);
            }
        }

        /// <summary>
        /// Toggle load or unload all mods.
        /// </summary>
        public virtual void LoadButton()
        {
            if (isLoaded)
            {
                Unload();
            }
            else
            {
                Load();
            }
        }

        public virtual void Load()
        {
            //load mods
            foreach (Mod mod in modItems.Keys)
            {
                if (mod.isEnabled)
                    mod.LoadAsync();
            }

            SetTogglesInteractable(false);

            loadButton.GetComponentInChildren<Text>().text = "U N L O A D";

            isLoaded = true;
        }

        public virtual void Unload()
        {
            //unload all mods - this will unload their scenes and destroy all their instantiated objects as well
            foreach (Mod mod in modItems.Keys)
            {
                mod.Unload();
            }

            SetTogglesInteractable(true);

            loadButton.GetComponentInChildren<Text>().text = "L O A D";

            isLoaded = false;
        }

        public virtual void OnModLoaded(Mod mod)
        {
            Debug.Log("Loaded Mod: " + mod.name);

            //load first scene when a mod is loaded
            ModScene scene = mod.scenes.FirstOrDefault();
            if (scene != null)
                scene.LoadAsync();
        }

        public virtual void OnModUnloaded(Mod mod)
        {
            Debug.Log("Unloaded Mod: " + mod.name);
        }
    }

}