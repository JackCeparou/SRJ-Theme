
// added
using System.Linq;
using Turbo.Plugins.Default;

// namespace Turbo.Plugins.Default
namespace Turbo.Plugins._SR.Actors
{

    public class SR_ClickableChestGizmoPlugin: BasePlugin, ICustomizer, IInGameWorldPainter
	{

        public WorldDecoratorCollection Decorator { get; set; }
        public bool PaintOnlyWhenHarringtonWaistguardIsActive { get; set; }

		public SR_ClickableChestGizmoPlugin()
		{
            Enabled = true;
            PaintOnlyWhenHarringtonWaistguardIsActive = false; //activate only if Harrington Waistguard belt is equipped
		}

        public void Customize()
        {
			// disable DEFAULT
			Hud.TogglePlugin<ClickableChestGizmoPlugin>(false);
		}

        public override void Load(IController hud)
        {
            base.Load(hud);

            Decorator = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(200, 230, 230, 0, 2),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 2),
                    Radius = 4.5f,
                    ShapePainter = new CrossShapePainter(Hud),
                },
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
			
			// disable if Harrington belt buff is not active
			if (PaintOnlyWhenHarringtonWaistguardIsActive && !Hud.Game.Me.Powers.BuffIsActive(318881, 0)) return;
			
			// change DEFAULT as below
			// var actors = Hud.Game.Actors.Where(x => x.DisplayOnOverlay && x.GizmoType == GizmoType.Chest);

			// exclude rack, deadbody and chest actors  (should i include GizmoType.BreakableChest ?)
			var actors = Hud.Game.Actors.Where(x => x.DisplayOnOverlay && (x.GizmoType == GizmoType.Chest) && (x.SnoActor.Kind != ActorKind.WeaponRack) && (x.SnoActor.Kind != ActorKind.ArmorRack) && (x.SnoActor.Kind != ActorKind.DeadBody) && (x.GizmoType != GizmoType.LoreChest) && (x.SnoActor.Kind != ActorKind.ChestNormal) && (x.SnoActor.Kind != ActorKind.Chest) );
			
            foreach (var actor in actors)
			{
                Decorator.Paint(layer, actor, actor.FloorCoordinate, null);
			}
		}

    }

}