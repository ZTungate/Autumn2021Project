using System;
using System.Collections.Generic;
using System.Text;
using Poggus.UI.UIObjects;
using Poggus.Player;
using Poggus.PlayerInventory;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Poggus.UI
{
    class HUDHandler
    {
        bool fullHUD;
        MapUIHandler mapHandler;
        TextSprite lifeText, levelTex, rupeeAmtText, keyAmtText, bombAmtText, slotAText, slotBText, inventoryText;
        ImageUI aSlotBackground, bSlotBackground, inventoryBackground;
        List<ImageUI> heartImages;

        ILink link;
        Inventory inventory;
        public HUDHandler(ILink link, Inventory inv)
        {
            this.link = link;
            this.inventory = inv;
            this.heartImages = new List<ImageUI>();
            mapHandler = new MapUIHandler();
        }
        public void InitHUD()
        {
            this.lifeText = new TextSprite(HUDSpriteFactory.instance.hudFont, "-LIFE-", Color.Red, new Point(0,0));
        }
        public void Draw(SpriteBatch batch)
        {
            if (fullHUD)
            {

            }
            else
            {

            }
        }
    }
}
