
using Turbo.Plugins.Default;

namespace Turbo.Plugins._SR.BuffLists
{

    public class SR_CheatDeathBuffFeederPlugin : BasePlugin, ICustomizer
    {

        public SR_CheatDeathBuffFeederPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
        }
		
        public void Customize()
        {
			
			Hud.RunOnPlugin<CheatDeathBuffFeederPlugin>(plugin =>
            {
				
				// enable DEFAULT
				plugin.Enabled = true;
				
				// customize border
				plugin.BorderBrush = Hud.Render.CreateBrush(120, 255, 0, 0, -3);
				plugin.FillBrush = Hud.Render.CreateBrush(25, 0, 0, 0, 0);

            });
		
        }
	
    }

}