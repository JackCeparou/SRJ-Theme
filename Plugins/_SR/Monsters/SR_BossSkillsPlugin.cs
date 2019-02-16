
// adaptation of StormReaver v6 xml theme
// This is Jack's BossSkillsPlugin.cs, with streamlined comments

namespace Turbo.Plugins._SR.Monsters
{
    using SharpDX.Direct2D1;
    using System.Collections.Generic;
    using System.Linq;
    using Turbo.Plugins.Default;

    public class SR_BossSkillsPlugin : BasePlugin, IInGameWorldPainter
    {
        public Dictionary<ActorSnoEnum, WorldDecoratorCollection> SnoMapping { get; set; }

        ////private GroundLabelDecorator debugDecorator;

        public SR_BossSkillsPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            SnoMapping = new Dictionary<ActorSnoEnum, WorldDecoratorCollection>();


		/* **********************************
				RIFT GUARDIAN  Skills
		************************************* */


            /* add ground circle & timer to RG Tornado / Energy Twister   (Saxtris / Sand Shaper)
            139741	ZoltunKulle_EnergyTwister	Energy Twister */
            SnoMapping.Add((ActorSnoEnum)139741, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 10,
                    Brush = Hud.Render.CreateBrush(160, 255, 50, 50, 2, DashStyle.Dash)
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 30,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 255, 200, 200, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 30,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(230, 255, 200, 200, 0),
                    Radius = 30,
                }));

            /* add ground circle to RG AOE DOT Poison 10y   (The Choker)
            360046	X1_Unique_Monster_Generic_AOE_DOT_Poison_10foot */
            SnoMapping.Add((ActorSnoEnum)360046, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 10,
                    Brush = Hud.Render.CreateBrush(160, 255, 50, 50, 2, DashStyle.Dash)
                }));

			/* add ground circle to RG AOE DOT Poison 20y   (The Choker)
            363358	X1_Unique_Monster_Generic_AOE_DOT_Poison_20foot */
            SnoMapping.Add((ActorSnoEnum)363358, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 20,
                    Brush = Hud.Render.CreateBrush(160, 255, 50, 50, 2, DashStyle.Dash)
                }));

			/* add ground circle & timer to RG Fire Pentagram / Impact, AOE DOT Fire   (Agnidox / Man Carver)
            159163	g_monster_projectile_fire_impact
            359693	X1_Unique_Monster_Generic_AOE_DOT_Fire_10foot */
            SnoMapping.Add((ActorSnoEnum)159163, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 11.5f,
                    Brush = Hud.Render.CreateBrush(120, 255, 255, 255, 5, DashStyle.Dash)
                }));
            SnoMapping.Add((ActorSnoEnum)359693, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 11.5f,
                    Brush = Hud.Render.CreateBrush(120, 255, 255, 255, 5, DashStyle.Dash)
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 15,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 255, 200, 200, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 15,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(230, 255, 255, 255, 0),
                    Radius = 30,
                }));

			/* add ground circle & timer to RG Dangerous skills   (Perendi / Stonesinger / Voracity)
            Falling Rocks:
				368453	x1_LR_Boss_MalletDemon_FallingRocks
				374732	x1_Pand_Cellar_FallingRock
				3026	a2dun_Zolt_Random_FallingRocks_C
            Meteor Strike:
				378237	X1_LR_Boss_AsteroidRain
            Gas Cloud:
				93837	Gluttony_gasCloud_proxy */
            var rgDangerousSkillDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 20,
                    Brush = Hud.Render.CreateBrush(160, 255, 50, 50, 2, DashStyle.Dash)
                });
            SnoMapping.Add((ActorSnoEnum)368453, rgDangerousSkillDecorator);
            SnoMapping.Add((ActorSnoEnum)374732, rgDangerousSkillDecorator);
            SnoMapping.Add((ActorSnoEnum)3026, rgDangerousSkillDecorator);
            SnoMapping.Add((ActorSnoEnum)378237, rgDangerousSkillDecorator);
            SnoMapping.Add((ActorSnoEnum)93837, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 75,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 255, 200, 200, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 75,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(230, 255, 50, 50, 0),
                    Radius = 30,
                }));

			/* add ground circle to RG Ice Circles 12y?   (Rime)
            359703	X1_Unique_Monster_Generic_AOE_DOT_Cold_10foot */
            SnoMapping.Add((ActorSnoEnum)359703, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 12,
                    Brush = Hud.Render.CreateBrush(100, 150, 150, 150, 2, DashStyle.Dash)
                }));

            /* add ground circle to RG Ice Circles 22y?   (Rime)
            363356	X1_Unique_Monster_Generic_AOE_DOT_Cold_20foot */
            SnoMapping.Add((ActorSnoEnum)363356, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 22,
                    Brush = Hud.Render.CreateBrush(100, 150, 150, 150, 2, DashStyle.Dash)
                }));

            // add ground circle to RG Ice Projectile   (Rime)
            // 377087	X1_Unique_Monster_Generic_Projectile_Cold
            SnoMapping.Add((ActorSnoEnum)377087, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 3,
                    Brush = Hud.Render.CreateBrush(100, 150, 150, 150, 2, DashStyle.Dash)
                }));

			/* add ground circle to Morlu Incinerator Meteor: Pending, Impact, AOE DOT Fire   (including RG Ember)
			found in to _SR_MonsterSkillsPlugin */


            //credits to SeaDragon
			/* Geyser ground circle & timer	/ duration=3, radius=15   (Tethrys)
			315366	x1_Adria_Geyser
			315362	x1_Adria_Geyser_Pending
			337092	x1_Adria_homingProjectile_impact */
            SnoMapping.Add((ActorSnoEnum)315366, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 15,
                    Brush = Hud.Render.CreateBrush(200, 255, 150, 255, 2, DashStyle.Dash)
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 3,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 255, 200, 200, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 3,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(230, 255, 150, 255, 0),
                    Radius = 30,
                }));

            //credits to SeaDragon
			/* Sandmonster Turret ground circle & timer	/ duration=20, radius=-1   (Stonesinger)
			434201	P4_LR_Boss_Sandmonster_Turret */
            SnoMapping.Add((ActorSnoEnum)434201, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = -1,
                    Brush = Hud.Render.CreateBrush(200, 255, 150, 255, 2, DashStyle.Dash)
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 20,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 255, 200, 200, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 20,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(230, 255, 150, 255, 0),
                    Radius = 30,
                }));

            //credits to SeaDragon
			/* Hamelin Rat Swarm ground circle / duration=60?, radius=7.5   (Hamelin)
			427170	p4_RatKing_RatBallMonster	Rat Swarm */
            SnoMapping.Add((ActorSnoEnum)427170, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 7.5f,
                    Brush = Hud.Render.CreateBrush(200, 255, 150, 255, 2, DashStyle.Dash)
                }
                /* ,
                new GroundLabelDecorator(Hud)
                {
                   CountDownFrom = 3,
                   TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 255, 200, 200, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                   CountDownFrom = 3,
                   BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                   BackgroundBrushFill = Hud.Render.CreateBrush(230, 255, 150, 255, 0),
                   Radius = 30,
                } */
                ));


		/* **********************************
					BOSS  Skills
		************************************* */


            /* add ground circle to Ring of Fire   (Diablo)
            226350	Diablo_ringofFire_damageArea */
            SnoMapping.Add((ActorSnoEnum)226350, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 15,
                    Brush = Hud.Render.CreateBrush(160, 255, 50, 50, 3, DashStyle.Dash)
                }));

            /* add ground circle to Punish Projectile   (Maghda / Uber Maghda)
            166686	Maghda_Punish_projectile
            278340	UberMaghda_Punish_projectile  */
            SnoMapping.Add((ActorSnoEnum)166686, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 3,
                    Brush = Hud.Render.CreateBrush(160, 255, 50, 50, 2, DashStyle.Dash)
                }));
            SnoMapping.Add((ActorSnoEnum)278340, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 3,
                    Brush = Hud.Render.CreateBrush(160, 255, 50, 50, 2, DashStyle.Dash)
                }));

            /* add ground circle & timer to Slow-Time Bubble   (Zoltun Kulle)
            185924	zoltunKulle_slowTime_bubble */
            SnoMapping.Add((ActorSnoEnum)185924, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 20,
                    Brush = Hud.Render.CreateBrush(160, 255, 50, 255, 2, DashStyle.Dash)
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 16,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 255, 200, 200, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 16,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(230, 255, 50, 50, 0),
                    Radius = 30,
                }));

            /* add ground circle to Adria skills   (Adria)

			Adria Arcane Pool
            360738	X1_Adria_arcanePool
			292507	x1_Adria_Arena_FloorPanel_Active
			292508	x1_Adria_Arena_FloorPanel_Telegraph */
            var adriaArcanePool = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 6,
                    Brush = Hud.Render.CreateBrush(180, 255, 50, 255, 2, DashStyle.Dash)
                });
            SnoMapping.Add((ActorSnoEnum)360738, adriaArcanePool);
            SnoMapping.Add((ActorSnoEnum)292507, adriaArcanePool);
            SnoMapping.Add((ActorSnoEnum)292508, adriaArcanePool);

            /* Adria Blood Pool
			358404	X1_Adria_blood_large */
            SnoMapping.Add((ActorSnoEnum)358404, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 12,
                    Brush = Hud.Render.CreateBrush(200, 255, 0, 150, 1, DashStyle.Dash)
                }));

			/* Adria Blood Drops
			363873	x1_Adria_cauldron_spawn_Projectile
			338889	x1_Adria_bouncingProjectile */
            SnoMapping.Add((ActorSnoEnum)363873, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 2,
                    Brush = Hud.Render.CreateBrush(200, 255, 150, 255, 2, DashStyle.Dash)
                }));
            SnoMapping.Add((ActorSnoEnum)338889, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 2,
                    Brush = Hud.Render.CreateBrush(200, 255, 150, 255, 2, DashStyle.Dash)
                }));


		/* **********************************
				KEY WARDEN  Skills
		************************************* */


            /* Xah'Rith the Keywarden, ACT3 / Rain of Corpses, pending   (Xah'Rith)
            260762	Uber_Morlu_GroundBomb_Pending */
            SnoMapping.Add((ActorSnoEnum)260762, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 12,
                    Brush = Hud.Render.CreateBrush(220, 255, 50, 255, 2, DashStyle.Dash)
                }));

            /* Xah'Rith the Keywarden, ACT3 / Rain of Corpses, impact   (Xah'Rith)
            260761	Uber_Morlu_FrozenZombie_proxyActor */
            SnoMapping.Add((ActorSnoEnum)260761, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 12,
                    Brush = Hud.Render.CreateBrush(220, 255, 50, 100, 2, DashStyle.Dash)
                }));

			/* Xah'Rith the Keywarden, ACT3 / Rain of Corpses, DOT   (Xah'Rith)
            260812	Unique_Monster_IceTrail */
            SnoMapping.Add((ActorSnoEnum)260812, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 12,
                    Brush = Hud.Render.CreateBrush(220, 255, 0, 0, 2, DashStyle.Dash)
                }));


			/* debugDecorator = new GroundLabelDecorator(Hud)
            {
               TextFont = Hud.Render.CreateFont("tahoma", 12, 255, 255, 255, 255, false, false, true),
               BorderBrush = Hud.Render.CreateBrush(180, 255, 50, 255, 2, DashStyle.Dash),
            }; */

        }


        public void PaintWorld(WorldLayer layer)
        {
            var monsterSkills = Hud.Game.Actors.Where(a => SnoMapping.ContainsKey(a.SnoActor.Sno));
            foreach (var skill in monsterSkills)
            {
                SnoMapping[skill.SnoActor.Sno].Paint(layer, skill, skill.FloorCoordinate, string.Empty);
            }

            //foreach (var actor in Hud.Game.Actors)
			/* {
               debugDecorator.Paint(actor, actor.FloorCoordinate, actor.SnoActor.Sno.ToString());
            } */

        }

    }
}