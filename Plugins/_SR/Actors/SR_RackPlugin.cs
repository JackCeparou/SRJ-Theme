
using Turbo.Plugins.Default;

namespace Turbo.Plugins._SR.Actors
{

    public class SR_RackPlugin : BasePlugin, ICustomizer
    {

        public SR_RackPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
        }
		
        public void Customize()
        {
			
			Hud.RunOnPlugin<RackPlugin>(plugin =>
            {
				
				// enable DEFAULT
				plugin.Enabled = true;
				
				// rack shape
				plugin.Decorator = new WorldDecoratorCollection(
				
					// map shape rectangle
					new MapShapeDecorator(Hud)
					{
						Brush = Hud.Render.CreateBrush(200, 64, 255, 64, 1.5f),
						ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
						Radius = 4.0f,
						ShapePainter = new RectangleShapePainter(Hud),
					},
					
					// ground shape x
					new GroundShapeDecorator(Hud)
					{
						Brush = Hud.Render.CreateBrush(200, 230, 230, 0, 3),
						Radius = 0.9f,
						ShapePainter = WorldStarShapePainter.NewCross(Hud),
					}
					
				);

            });
		
        }
	
    }

}