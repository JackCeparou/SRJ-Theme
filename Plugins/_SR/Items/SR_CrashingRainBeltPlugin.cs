
// by StormReaver

namespace Turbo.Plugins._SR.Items
{
    using SharpDX.Direct2D1;
    using System.Collections.Generic;
    using System.Linq;
    using Turbo.Plugins.Default;

    public class SR_CrashingRainBeltPlugin : BasePlugin, IInGameWorldPainter
    {

        public WorldDecoratorCollection CrashingRainPluginDecorator { get; set; }


        public SR_CrashingRainBeltPlugin()
        {
            Enabled = true;
        }


        public void Customize()
        {

			Hud.RunOnPlugin<PlayerSkillPlugin>(plugin =>
			{
				// disable DEFAULT
				plugin.Enabled = false;

			});

        }


        public override void Load(IController hud)
        {
            base.Load(hud);


            // Crashing Rain belt, effect radius // data from forums

            CrashingRainPluginDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(220, 220, 50, 50, 10f, DashStyle.Dash),
                    Radius = 15,
                });

        }


		// 1069972158 - Crashing Rain // ISnoItem P2_Unique_Belt_01
		// 200808	DemonHunter_RainOfArrows_crash_land		Invalid
		// 359554	power: ItemPassive_Unique_Ring_709_x1
		// 370496	x1_DH_rainOfArrows_flyerCrash_groundRoll
		// 370495	x1_DH_rainOfArrows_flyerCrash_projectile


        public void PaintWorld(WorldLayer layer)
        {
            var actors = Hud.Game.Actors;
            foreach (var actor in actors)
            {

                /* ---  Skills where "summoned_by_me" works  --- */

                if (actor.SummonerAcdDynamicId == Hud.Game.Me.SummonerId) // summoned_by_me
                {
                    switch (actor.SnoActor.Sno)
                    {
						case ActorSnoEnum._demonhunter_rainofarrows_crash_land /*200808*/:
							CrashingRainPluginDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
						break;
                    }
                }


                /* ---  Skills where "summoned_by_me" does not work  --- */

                // switch (actor.SnoActor.Sno)
                // {
                    // case 200808:
                        // CrashingRainPluginDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                    // break;
                // }
            }
        }


    }
}