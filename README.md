# Apple Trail Modding Tool
## Setup
1. Install Unity 2021.1.10f1
2. Import package "Apple Trail Modding Package.package"
3. Feel free to modify game
4. You can find up-to-date original C# gaming scripts in "Gaming Scripts Source Code" folder.
## Tips for scripts modding
* Create your own classes in first place
* When necessary, override core method
* When overriding of core methods, provide this change as standalone utility mod for another mod developers and it's source code
* Describe all your mod changes include changes in core scripts
* Create pull request for your core scripts fixes and improvements (Nobody is perfect. Lot of core scripts was written in hurry so we can provide more stuff for you. Your changes can help improve stability, security and extensibility of this game and your modding utilites can become part of core game.)
* When you are not able to modify something, feel free to contact us for providing of support for this changes
## Modding Tutorials
### Textures
See “Texture Change” example in “Tutorials” folder
## Creating of the Mod
1. Open Apple Trail Modding Tool
2. Create new scene
3. Feel free to modify game using tutorials below
4. [More info about modding tool](https://hellomeow.net/modtool/documentation/html/96083abe-78cf-43e9-a3f6-59c4e717b7e7.htm)
## Third Party Assets
### [ModdingTool](https://assetstore.unity.com/packages/tools/integration/modtool-75580)
Modding Tool
### [Lean Localization](https://assetstore.unity.com/packages/tools/localization/lean-localization-28504)
Localization Tool
## GameObjects Hierarchy
* Camera [GameObject]
    * Camera [Component]
    * Audio Listener [Component]
* Systems [GameObject]
    * Events [GameObject]
        * Event System [Component]
        * Standalone Input Module [Component]
        * Events [Component - AppleTrail.Events]
    * Localization [GameObject]
        * Lean Localization [Component - Lean Localization]
        * English [GameObject]
            * Lean Language [Component - Lean Localization]
        * Czech [GameObject]
            * Lean Language [Component - Lean Localization]
        * English CSV [GameObject]
            * Lean Language CSV [Component - Lean Localization]
        * Czech CSV [GameObject]
            * Lean Language CSV [Component - Lean Localization]
    * World [GameObject]
        * World [Component - AppleTrail.World]
        * Factions [GameObject]
            * Britain [GameObject]
                * Faction [Component - AppleTrail.Faction]
            * France [GameObject]
                * Faction [Component - AppleTrail.Faction]
            * Spain [GameObject]
                * Faction [Component - AppleTrail.Faction]
            * Netherlands [GameObject]
                * Faction [Component - AppleTrail.Faction]
        * Colonies [GameObject]
            * Roanoke (North Carolina) [GameObject]
                * Colony [Component - AppleTrail.Colony]
            * Jamestown (Virginia) [GameObject]
                * Colony [Component - AppleTrail.Colony]
        * Persons [GameObject]
            * Ralph Lane [GameObject]
                * Person [Component - AppleTrail.Person]
            * John White [GameObject]
                * Person [Component - AppleTrail.Person]
            * Elizabeth I [GameObject]
                * Person [Component - AppleTrail.Person]
            * Edward Maria Wingfield [GameObject]
                * Person [Component - AppleTrail.Person]
*  Canvas [GameObject]
    * Rect Transform [Component]
    * Canvas [Component]
    * Canvas Scaler [Component]
    * Graphic Raycaster [Component]
    * Main Menu [GameObject]
        * Rect Transform [Component]
        * Buttons [GameObject]
            * Rect Transform [Component]
            * Continue [GameObject]
                * Rect Transform [Component]
                * Canvas Renderer [Component]
                * Image [Component]
                * Button [Component]
            * New [GameObject]
                * Rect Transform [Component]
                * Canvas Renderer [Component]
                * Image [Component]
                * Button [Component - OnClick = AppleTrail.Events.NewTrail()]
            * Load [GameObject]
                * Rect Transform [Component]
                * Canvas Renderer [Component]
                * Image [Component]
                * Button [Component]
            * Settings [GameObject]
                * Rect Transform [Component]
                * Canvas Renderer [Component]
                * Image [Component]
                * Button [Component]
            * Exit [GameObject]
                * Rect Transform [Component]
                * Canvas Renderer [Component]
                * Image [Component]
                * Button [Component - OnClick = AppleTrail.Events.ExitGame()]
    * New Trail [GameObject]
        * Rect Transform [Component]
        * Year [GameObject]
            * Rect Transform [Component]
            * Label [GameObject]
                * Rect Transform [Component]
                * Canvas Renderer [Component]
                * TextMeshPro - Text (UI) [Component]
            * Slider [GameObject]
                * Rect Transform [Component]
                * Slider [Component]
                * Background [GameObject]
                    * Rect Transform [Component]
                    * Canvas Renderer [Component]
                    * Image [Component]
                * Fill Area [GameObject]
                    * Rect Transform [Component]
                    * Fill [GameObject]
                        * Rect Transform [Component]
                        * Canvas Renderer [Component]
                        * Image [Component]
                * Handle Slide Area [GameObject]
                    * Rect Transform [Component]
                    * Handle [GameObject]
                        * Rect Transform [Component]
                        * Canvas Renderer [Component]
                        * Image [Component]
                * Number [GameObject]
                    * Rect Transform [Component]
                    * Canvas Renderer [Component]
                    * TextMeshPro - Text (UI) [Component]
        * Start [GameObject]
            * Rect Transform [Component]
            * Canvas Renderer [Component]
            * Image [Component]
            * Button [Component]
            * Text [GameObject]
                * Rect Transform [Component]
                * Canvas Renderer [Component]
                * TextMeshPro - Text (UI) [Component]
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
        * Rect Transform [Component]
            * Background [GameObject]
                * Rect Transform [Component]
                * Canvas Renderer [Component]
                * Image [Component]
            * Blank Map [GameObject]
                * Rect Transform [Component]
                * Canvas Renderer [Component]
                * Image [Component]
            * Close Button [GameObject]
                * Rect Transform [Component]
                * Canvas Renderer [Component]
                * Image [Component]
                * Button [Component - OnClick = AppleTrail.Events.CloseMap()]
    * Mod Menu [GameObject]
        * Rect Transform [Component]
        * Mod Menu [Component - AppleTrail.ModTools]
        * Background [GameObject]
            * Rect Transform [Component]
            * Canvas Renderer [Component]
            * Image [Component]
        * Menu [GameObject]
            * Rect Transform [Component]
            * Canvas Renderer [Component]
            * Image [Component]
            * Scroll View [GameObject]
                * Rect Transform [Component]
                * Scroll Rect [Component]
                * Canvas Renderer [Component]
                * Image [Component]
                * Viewport [GameObject]
                    * Rect Transform [Component]
                    * Mask [Component]
                    * Canvas Renderer [Component]
                    * Image [Component]
                    * Context [GameObject]
                        * Rect Transform [Component]
                        * Content Size Fitter [Component]
                        * Vertical Layout Group [Component]
            * Mods Text [GameObject]
                * Rect Transform [Component]
                * Canvas Renderer [Component]
                * Text [Component]
            * Load Button [GameObject]
                * Rect Transform [Component]
                * Canvas Renderer [Component]
                * Image [Component]
                * Button [Component - OnClick = AppleTrail.ModMenu.LoadButton()]
                * Text [GameObject]
                    * Rect Transform [Component]
                    * Canvas Renderer [Component]
                    * Text [Component]
* Test
Object for internal testing. Can be used for mods testing. Don’t use this object for the final mod version.
## Exporting of the Mod
1. Tools -> ModTool -> Export Mod
2. Export to “Apple Trail/Mods” folder
3. You need to install Unity support for all platforms you selected when before export
4. [More info about exporting of mod](https://hellomeow.net/modtool/documentation/html/bc47d09d-b0b6-490a-af4b-7f0cb43b84b9.htm)
## License
This work is licensed under [Attribution-NonCommercial-ShareAlike 4.0 International](http://creativecommons.org/licenses/by-nc-sa/4.0/).