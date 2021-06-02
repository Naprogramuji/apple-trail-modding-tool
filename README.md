# Apple Trail Modding Tool
## Setup
1. Install Unity 2021.1.9f1
2. Import package "Apple Trail Modding Package.package"
3. Feel free to modify game
4. You can find up-to-date original C# gaming scripts in "Gaming Scripts Source Code" folder.
## Tips for scripts modding
* Create your own classes in first place
* When necessary, override core method
* When overriding of core methods, provide this change as standalone utility mod for another mod developers and it's source code
* Describe all your mod changes include changes in core scripts
* When you are not able to modify something, feel free to contact us for providing of support for this changes
## Third Party Assets
### [ModdingTool](https://assetstore.unity.com/packages/tools/integration/modtool-75580)
Modding Tool
### [Lean Localization](https://assetstore.unity.com/packages/tools/localization/lean-localization-28504)
Localization Tool
## GameObjects Hierarchy
* Camera [GameObject]
    * Transform [Component]
    * Camera [Component]
    * Audio Listener [Component]
*  Canvas [GameObject]
    * Rect Transform [Component]
    * Canvas [Component]
    * Canvas Scaler [Component]
    * Graphic Raycaster [Component]
    * Game [GameObject]
        * Rect Transform [Component]
        * Buttons [GameObject]
            * Rect Transform [Component]
            * Map [GameObject]
                * Rect Transform [Component]
                * Canvas Renderer [Component]
                * Image [Component]
                * Button [Component]
                * Text [GameObject]
                    * Rect Transform [Component]
                    * Canvas Renderer [Component]
                    * TextMeshPro - Text (UI) [Component]
    * Map [GameObject]
## License
This work is licensed under [Attribution-NonCommercial-ShareAlike 4.0 International](http://creativecommons.org/licenses/by-nc-sa/4.0/).