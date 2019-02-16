
using System.Globalization;
using Turbo.Plugins.Default;

namespace Turbo.Plugins._SR.Inventory
{

    public class SR_InventoryFreeSpacePlugin : BasePlugin, ICustomizer
    {

        public SR_InventoryFreeSpacePlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
        }
		
        public void Customize()
        {
			
			Hud.RunOnPlugin<InventoryFreeSpacePlugin>(plugin =>
            {
				
				// enable InventoryFreeSpacePlugin (DEFAULT)
				plugin.Enabled = true;
				
				
				// red deco
				plugin.RedDecorator = new TopLabelDecorator(Hud)
				{
					TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 100, 100, true, false, 255, 0, 0, 0, true),
					BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
					BackgroundTexture2 = Hud.Texture.BackgroundTextureOrange,
					BackgroundTextureOpacity1 = 0.8f,
					BackgroundTextureOpacity2 = 0.8f,
					TextFunc = () => (Hud.Game.Me.InventorySpaceTotal - Hud.Game.InventorySpaceUsed).ToString("D", CultureInfo.InvariantCulture),
					HintFunc = () => "free space in inventory",
				};
				
				// yellow deco
				plugin.YellowDecorator = new TopLabelDecorator(Hud)
				{
					TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 200, 205, 50, true, false, 255, 0, 0, 0, true),
					BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
					BackgroundTexture2 = Hud.Texture.BackgroundTextureOrange,
					BackgroundTextureOpacity1 = 0.8f,
					BackgroundTextureOpacity2 = 0.8f,
					TextFunc = () => (Hud.Game.Me.InventorySpaceTotal - Hud.Game.InventorySpaceUsed).ToString("D", CultureInfo.InvariantCulture),
					HintFunc = () => "free space in inventory",
				};

				// green deco
				plugin.GreenDecorator = new TopLabelDecorator(Hud)
				{
					TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 100, 130, 100, true, false, 255, 0, 0, 0, true),
					BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
					BackgroundTexture2 = Hud.Texture.BackgroundTextureOrange,
					BackgroundTextureOpacity1 = 0.8f,
					BackgroundTextureOpacity2 = 0.8f,
					TextFunc = () => (Hud.Game.Me.InventorySpaceTotal - Hud.Game.InventorySpaceUsed).ToString("D", CultureInfo.InvariantCulture),
					HintFunc = () => "free space in inventory",
				};

            });
		
        }
	
    }

}