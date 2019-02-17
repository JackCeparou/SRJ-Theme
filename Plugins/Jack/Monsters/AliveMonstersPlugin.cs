
// adaptation of StormReaver v6 xml theme

﻿namespace Turbo.Plugins.Jack.Monsters
{
    using Turbo.Plugins.Default;

    public class AliveMonsterPlugin : BasePlugin, IInGameWorldPainter
    {
        public WorldDecoratorCollection Decorator { get; set; }

        public AliveMonsterPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            // mark all alive mobs with shapes below feet / mix and match
			
            Decorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud) //yellow circle
                {
                    Brush = Hud.Render.CreateBrush(255, 255, 255, 0, 1.5f),
                    Radius = 0.2f,
                },
                new GroundCircleDecorator(Hud) //red dot
                {
                    Brush = Hud.Render.CreateBrush(255, 255, 0, 0, 1f),
                    Radius = 0.1f,
                },
                new GroundShapeDecorator(Hud) //green diamond
                {
                   Enabled = false,
                   Brush = Hud.Render.CreateBrush(200, 255, 255, 10, 4f),
                   Radius = 0.2f,
                   ShapePainter = WorldStarShapePainter.NewCross(Hud),
                },
                new GroundShapeDecorator(Hud) //tiny green x
                {
                    Enabled = false,
                    Brush = Hud.Render.CreateBrush(200, 0, 255, 0, 1.2f),
                    Radius = 0.2f,
                    ShapePainter = WorldStarShapePainter.NewCross(Hud),
                }
            );
        }

        public void PaintWorld(WorldLayer layer)
        {
            var monsters = Hud.Game.AliveMonsters;

            foreach (var monster in monsters)
            {
                Decorator.Paint(layer, monster, monster.FloorCoordinate, string.Empty);
            }
        }
    }
}