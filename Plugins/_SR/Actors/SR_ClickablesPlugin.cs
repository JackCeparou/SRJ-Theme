
// added

using System.Collections.Generic;
using System.Linq;
using Turbo.Plugins.Default;

// namespace Turbo.Plugins.Default
﻿namespace Turbo.Plugins._SR.Actors
{

    public class SR_ClickablesPlugin : BasePlugin, IInGameWorldPainter
    {

		public HashSet<ActorSnoEnum> ClickablesIds { get; set; }
        public WorldDecoratorCollection ClickablesDecorators { get; set; }

        public SR_ClickablesPlugin()
        {
            Enabled = true;

			/// mark miscellaneous CLICKABLES/BREAKABLES/DESTRUCTIBLES on ground:

			/*
			>>	Town:
			130400 Player_Shared_Stash	Stash SharedStash

			>>	Greed Vault:
			391765	p1_Tgoblin_Vase_A						/ 392606	p1_Tgoblin_Vase_C
			390498	p1_Tgoblin_Gold_Pile_A					/ 386274	p1_Tgoblin_Gold_Pile_C

			>>	Rainbow Land (Staff Whimsyshire / Goblin Whimsydale):
			210418	a1dun_Random_Present_A	Lovely Present
			457390	a1dun_Random_Present_A_goblin
			210422	a1dun_random_pot_of_gold_A	Pot O` Gold
			457174	a1dun_random_pot_of_gold_A_goblin
			212491	a1dun_Random_Cloud	Happy Cloud
			457424	a1dun_Random_Cloud_goblin
			211861	Pinata	Pinata
			457175	Pinata_goblin
			211965	a1dun_Random_Mushroom_Cluster_A	Mushrooms
			211959	a1dun_Random_Mushroom_Cluster_B	Mushrooms
			211851	a1dun_Random_Mushroom_Cluster_C	Mushrooms
			457660	a1dun_Random_Mushroom_Cluster_A_goblin
			457662	a1dun_Random_Mushroom_Cluster_B_goblin
			457661	a1dun_Random_Mushroom_Cluster_C_goblin

			>> Other:
			437895	p4_Ruins_Frost_KanaiCube_Altar Chest

			*/

            ClickablesIds = new HashSet<ActorSnoEnum>((new List<uint> {
                130400,
                391765, 392606, 390498, 386274,
                210418, 457390, 210422, 457174, 212491, 457424, 211861, 457175, 211965, 211959, 211851, 457660, 457662, 457661,
                437895
            }).Select(x => (ActorSnoEnum)x));
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            ClickablesDecorators = new WorldDecoratorCollection(

                new GroundShapeDecorator(hud)
                {
                    ShapePainter = WorldStarShapePainter.NewCross(Hud),
                    Radius = 1.0f,
                    Brush = Hud.Render.CreateBrush(150, 255, 0, 255, 2.5f),
                },
                new GroundCircleDecorator(hud)
                {
                    Radius = 1.5f,
                    Brush = Hud.Render.CreateBrush(150, 255, 0, 255, 3.5f),
                },
                new MapShapeDecorator(hud)
                {
					// ShapePainter = new TriangleShapePainter(hud),
                    ShapePainter = new CrossShapePainter(hud),
                    Radius = 5f,
                    Brush = Hud.Render.CreateBrush(220, 255, 0, 255, 1.5f),
                },
                new MapShapeDecorator(hud)
                {
                    ShapePainter = new CircleShapePainter(hud),
                    Radius = 5f,
                    Brush = Hud.Render.CreateBrush(220, 255, 0, 255, 1),
                }
            );

            // foreach (var mapShapeDecorator in ClickablesDecorators.GetDecorators<MapShapeDecorator>())
            // {
                // mapShapeDecorator.Enabled = false;
            // }
        }

        public void PaintWorld(WorldLayer layer)
        {
            // if (Hud.Render.UiHidden) return;
            // if (Hud.Game.IsInTown) return;
            // if (Hud.Game.Me.HeroClassDefinition.HeroClass != HeroClass.WitchDoctor) return;

            var Clickables = Hud.Game.Actors.Where(x => x.DisplayOnOverlay && ClickablesIds.Contains(x.SnoActor.Sno));

            foreach (var Clickable in Clickables)
            {
				// do not show ground label if out of view (will need to add a ground label in decorators to use this toggle)
				// ClickablesDecorators.ToggleDecorators<GroundLabelDecorator>(!actor.IsOnScreen);
                ClickablesDecorators.Paint(layer, Clickable, Clickable.FloorCoordinate, null);
            }

			// should I include all BreakableChest Gizmos?
            /* var BreakableChests = Hud.Game.Actors.Where(x => x.DisplayOnOverlay && (x.GizmoType == GizmoType.BreakableChest));
			foreach (var BreakableChest in BreakableChests)
            {
                ClickablesDecorators.Paint(layer, BreakableChest, BreakableChest.FloorCoordinate, null);
            } */

        }
    }
}