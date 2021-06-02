using UnityEngine;
using UnityEngine.UI;
using ModTool;

namespace ModTool
{
    public class ModItem : MonoBehaviour
    {

        public Text modName;
        public Text modType;

        public Toggle toggle;

        public Mod mod;

        /// <summary>
        /// Initialze this ModItem with a Mod and ModMenu.
        /// </summary>
        /// <param name="mod"></param>
        /// <param name="modMenu"></param>
        public virtual void Initialize(Mod mod, Transform menuContentPanel)
        {
            this.mod = mod;

            transform.SetParent(menuContentPanel);

            modName.text = mod.name;
            modType.text = mod.contentType.ToString();

            toggle.isOn = mod.isEnabled;

            toggle.onValueChanged.AddListener(value => Toggle(value));
        }

        /// <summary>
        /// Toggle whether the mod should be loaded
        /// </summary>
        public virtual void Toggle(bool isEnabled)
        {
            mod.isEnabled = isEnabled;
        }

        /// <summary>
        /// Enable or disable this ModItem's toggle.
        /// </summary>
        /// <param name="interactable"></param>
        public virtual void SetToggleInteractable(bool interactable)
        {
            toggle.interactable = interactable;
        }
    }

}