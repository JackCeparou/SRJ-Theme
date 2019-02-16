
// added
using Turbo.Plugins.Default;

// namespace Turbo.Plugins.Default
namespace Turbo.Plugins._SR.Players
{

    public class SR_OtherPlayersPlugin : BasePlugin, ICustomizer
    {

        public SR_OtherPlayersPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
        }

        public void Customize()
        {
			
			//var grounLabelBackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0);
			var grounLabelBackgroundBrush = Hud.Render.CreateBrush(255, 20, 20, 20, 0);
			
			Hud.RunOnPlugin<OtherPlayersPlugin>(plugin =>
			{
				
				// enable DEFAULT plugin
				plugin.Enabled = true;
				
				// disable DEFAULT DH deco
				plugin.DecoratorByClass[HeroClass.DemonHunter].Decorators.Clear();
				
				// DISABLE DH Sentry map deco (DEFAULT theme)
				// plugin.SentryDecorator.Enabled = false;
				// plugin.SentryWithCustomEngineeringDecorator.Enabled = false;
				
				
				// change DH deco
				plugin.DecoratorByClass[HeroClass.DemonHunter].Add(new MapLabelDecorator(Hud)
					{
						// LabelFont = Hud.Render.CreateFont("tahoma", 6f, 255, 0, 0, 200, false, false, 128, 0, 0, 0, true),
						LabelFont = Hud.Render.CreateFont("tahoma", 6f, 255, 120, 120, 200, false, false, 128, 0, 0, 0, true),
						Up = true,
					});
				plugin.DecoratorByClass[HeroClass.DemonHunter].Add(new GroundLabelDecorator(Hud)
					{
						BackgroundBrush = grounLabelBackgroundBrush,
						BorderBrush = Hud.Render.CreateBrush(255, 0, 0, 200, 1),
						// TextFont = Hud.Render.CreateFont("tahoma", 6f, 255, 0, 0, 200, false, false, 128, 0, 0, 0, true),
						TextFont = Hud.Render.CreateFont("tahoma", 6f, 255, 120, 120, 200, true, false, 128, 0, 0, 0, true),
					});
			
			
			});

        }
    }
}