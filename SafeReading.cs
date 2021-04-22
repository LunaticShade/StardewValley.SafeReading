using SafeReading;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Menus;
using StardewValley.Objects;
using System.Collections.Generic;

namespace SkillfulClothes
{

    public class SkillfulClothes : Mod
    {
        IModHelper helper;
        LocationObserver locationObserver;

        public override void Entry(IModHelper helper)
        {
            Logger.Init(this.Monitor);
            this.helper = helper;

            locationObserver = new LocationObserver(helper);

            helper.Events.GameLoop.SaveLoaded += GameLoop_SaveLoaded;
            helper.Events.GameLoop.ReturnedToTitle += GameLoop_ReturnedToTitle;
        }

        private void GameLoop_SaveLoaded(object sender, SaveLoadedEventArgs e)
        {
            if (Context.IsMultiplayer)
            {
                // make sure that we only register once
                helper.Events.GameLoop.UpdateTicked -= GameLoop_UpdateTicked;
                helper.Events.GameLoop.UpdateTicked += GameLoop_UpdateTicked;

                Logger.Debug("SafeReading mod enabled (Multiplayer detected)");
            }
        }

        private void GameLoop_ReturnedToTitle(object sender, ReturnedToTitleEventArgs e)
        {            
            helper.Events.GameLoop.UpdateTicked -= GameLoop_UpdateTicked;            
            locationObserver.Reset();
        }

        private void GameLoop_UpdateTicked(object sender, UpdateTickedEventArgs e)
        {
            if (!Context.IsWorldReady) return;
            
            locationObserver.Update();                        
        }
    }
}
