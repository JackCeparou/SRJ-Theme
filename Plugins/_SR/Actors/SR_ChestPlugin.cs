
using Turbo.Plugins.Default;

namespace Turbo.Plugins._SR.Actors
{

    public class SR_ChestPlugin : BasePlugin, ICustomizer
    {

        public SR_ChestPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
        }
		
        public void Customize()
        {
			
			Hud.RunOnPlugin<ChestPlugin>(plugin =>
            {
				
				// enable DEFAULT
				plugin.Enabled = true;
				
				// normal chest shape
				plugin.NormalChestDecorator = new WorldDecoratorCollection(
				
					// map shape circle
					new MapShapeDecorator(Hud)
					{
						Brush = Hud.Render.CreateBrush(220, 200, 255, 200, 1.8f),
						ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
						Radius = 6.0f,
						ShapePainter = new CircleShapePainter(Hud),
					},
					
					// ground shape x
					new GroundShapeDecorator(Hud)
					{
						Brush = Hud.Render.CreateBrush(200, 230, 230, 0, 3),
						Radius = 0.9f,
						ShapePainter = WorldStarShapePainter.NewCross(Hud),
					}
					
				);
				
				// resplendent chest shape
				plugin.ResplendentChestDecorator = new WorldDecoratorCollection(
				
					// map shape circle
					new MapShapeDecorator(Hud)
					{
						Brush = Hud.Render.CreateBrush(220, 64, 255, 64, 3.5f),
						ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
						Radius = 6.5f,
						ShapePainter = new CircleShapePainter(Hud),
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