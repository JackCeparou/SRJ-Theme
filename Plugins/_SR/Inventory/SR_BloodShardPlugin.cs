
using System.Globalization;
using Turbo.Plugins.Default;

namespace Turbo.Plugins._SR.Inventory
{

    public class SR_BloodShardPlugin : BasePlugin, ICustomizer
    {

        public SR_BloodShardPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
        }
		
        public void Customize()
        {
			
			Hud.RunOnPlugin<BloodShardPlugin>(plugin =>
            {
				
				// enable BloodShardPlugin (DEFAULT)
				plugin.Enabled = true;
				
				
				// red deco
				plugin.RedDecorator = new TopLabelDecorator(Hud)
				{
					TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 100, 100, true, false, 255, 0, 0, 0, true),
					// BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
					// BackgroundTexture2 = Hud.Texture.BackgroundTextureOrange,
					BackgroundTexture1 = Hud.Texture.BackgroundTextureOrange,
					BackgroundTexture2 = Hud.Texture.ButtonTextureGray,
					BackgroundTextureOpacity1 = 0.8f,
					BackgroundTextureOpacity2 = 0.8f,
					TextFunc = () => Hud.Game.Me.Materials.BloodShard.ToString("D", CultureInfo.InvariantCulture),
					HintFunc = () => "amount of blood shards"
				};
				
				// yellow deco
				plugin.YellowDecorator = new TopLabelDecorator(Hud)
				{
					TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 200, 205, 50, true, false, 255, 0, 0, 0, true),
					// BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
					// BackgroundTexture2 = Hud.Texture.BackgroundTextureOrange,
					BackgroundTexture1 = Hud.Texture.BackgroundTextureOrange,
					BackgroundTexture2 = Hud.Texture.ButtonTextureGray,
					BackgroundTextureOpacity1 = 0.8f,
					BackgroundTextureOpacity2 = 0.8f,
					TextFunc = () => Hud.Game.Me.Materials.BloodShard.ToString("D", CultureInfo.InvariantCulture),
					HintFunc = () => "amount of blood shards"
				};

				// green deco
				plugin.GreenDecorator = new TopLabelDecorator(Hud)
				{
					TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 100, 130, 100, true, false, 255, 0, 0, 0, true),
					// BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
					// BackgroundTexture2 = Hud.Texture.BackgroundTextureOrange,
					BackgroundTexture1 = Hud.Texture.BackgroundTextureOrange,
					BackgroundTexture2 = Hud.Texture.ButtonTextureGray,
					BackgroundTextureOpacity1 = 0.8f,
					BackgroundTextureOpacity2 = 0.8f,
					TextFunc = () => Hud.Game.Me.Materials.BloodShard.ToString("D", CultureInfo.InvariantCulture),
					HintFunc = () => "amount of blood shards"
				};

            });
		
        }
	
    }

}