
using Turbo.Plugins.Default;

namespace Turbo.Plugins._SR.Items
{

    public class SR_ItemsPlugin : BasePlugin, ICustomizer
    {

        public SR_ItemsPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
        }

        public void Customize()
        {
		
			// add ground circles under progressions spheres //Jack
			
			Hud.RunOnPlugin<GlobePlugin>(plugin =>
            {
                plugin.RiftOrbDecorator.Add(new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(150, 50, 225, 225, 0),
                    Radius = 0.9f
                });
				plugin.RiftOrbDecorator.Add(new GroundCircleDecorator(Hud)
                {
					Brush = Hud.Render.CreateBrush(200, 240, 120, 240, 3),
                    Radius = 1.3f
                });
            });
			
			
			// ---------------------------------------------
			
			
			// add ground circle under death breaths //Jack
			
			Hud.RunOnPlugin<ItemsPlugin>(plugin =>
            {
                plugin.DeathsBreathDecorator.Add(new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(250, 255, 0, 225, 4),
                    Radius = 1.0f
                });
            });
			
			
			// ---------------------------------------------
			
			
			// Add map labels for dropped legendary and set items //Prrovoss
			
			Hud.RunOnPlugin<ItemsPlugin>(plugin =>
            {
                plugin.LegendaryDecorator.Decorators.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6, 255, 235, 120, 0, false, false, false),
                    RadiusOffset = 14,
                    Up = true,
                });

                plugin.AncientDecorator.Decorators.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6, 255, 235, 120, 0, true, false, false),
                    RadiusOffset = 14,
                    Up = true,
                });

				plugin.PrimalDecorator.Decorators.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7, 255, 240, 20, 0, true, false, false),
                    RadiusOffset = 14,
                    Up = true,
                });
				
                plugin.SetDecorator.Decorators.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6, 255, 0, 170, 0, false, false, false),
                    RadiusOffset = 14,
                    Up = true,
                });

                plugin.AncientSetDecorator.Decorators.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6, 255, 0, 170, 0, true, false, false),
                    RadiusOffset = 14,
                    Up = true,
                });

                plugin.PrimalSetDecorator.Decorators.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7, 255, 240, 20, 0, true, false, false),
                    RadiusOffset = 14,
                    Up = true,
                });
				
            });
			
			// ---------------------------------------------
			
			

        }
    }
}