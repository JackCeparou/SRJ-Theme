
// added
using System.Linq;
using Turbo.Plugins.Default;

// namespace Turbo.Plugins.Default
namespace Turbo.Plugins._SR.Actors
{

    public class SR_DeadBodyPlugin : BasePlugin,  ICustomizer, IInGameWorldPainter
	{

        public WorldDecoratorCollection Decorator { get; set; }

		public SR_DeadBodyPlugin()
		{
            Enabled = true;
		}
		
        public void Customize()
        {
			// disable DEFAULT
			Hud.TogglePlugin<DeadBodyPlugin>(false);
		}
		
        public override void Load(IController hud)
        {
            base.Load(hud);

            Decorator = new WorldDecoratorCollection(
			
				// map shape x
				new MapShapeDecorator(Hud)
				{
					Brush = Hud.Render.CreateBrush(255, 230, 230, 0, 2),
					ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 2),
					Radius = 4.5f,
					ShapePainter = new CrossShapePainter(Hud),
				},
				
				// ground shape x
				new GroundShapeDecorator(Hud)
				{
					Brush = Hud.Render.CreateBrush(200, 230, 230, 0, 3),
					Radius = 0.9f,
					ShapePainter = WorldStarShapePainter.NewCross(Hud),
				}
                );
        }
		
		public void PaintWorld(WorldLayer layer)
		{
			// disable in town
			if (Hud.Game.IsInTown) return;
			
            var actors = Hud.Game.Actors.Where(x => x.DisplayOnOverlay && x.SnoActor.Kind == ActorKind.DeadBody);
            foreach (var actor in actors)
			{
                Decorator.Paint(layer, actor, actor.FloorCoordinate, null);
			}
		}

    }

}