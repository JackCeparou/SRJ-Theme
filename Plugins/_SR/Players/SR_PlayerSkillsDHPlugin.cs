
// adaptation of StormReaver v6 xml theme

namespace Turbo.Plugins._SR.Players
{
    using SharpDX.Direct2D1;
    using System.Collections.Generic;
    using System.Linq;
    using Turbo.Plugins.Default;

    public class SR_PlayerSkillsDHPlugin : BasePlugin, ICustomizer, IInGameWorldPainter
    {

        public WorldDecoratorCollection SentryDecorator { get; set; }
        public WorldDecoratorCollection SentryCeDeco { get; set; }
        public WorldDecoratorCollection SentryPolarDeco { get; set; }
        public WorldDecoratorCollection SentryGuardianDeco { get; set; }
        public WorldDecoratorCollection MfdVodDeco { get; set; }
        public WorldDecoratorCollection RoVShadeDeco { get; set; }
        public WorldDecoratorCollection RoVDarkCloudDeco { get; set; }
        public WorldDecoratorCollection RoVAnathemaDeco { get; set; }
        public WorldDecoratorCollection RoVFlyingStrikeDeco { get; set; }
        public WorldDecoratorCollection RoVStampedeDeco { get; set; }
        public WorldDecoratorCollection GrenadeDecorator { get; set; }
        public WorldDecoratorCollection GrenadeCGDeco { get; set; }


        public SR_PlayerSkillsDHPlugin()
        {
            Enabled = true;
        }


        public void Customize()
        {

			Hud.RunOnPlugin<PlayerSkillPlugin>(plugin =>
			{
				// disable DEFAULT
				plugin.Enabled = false;

				// DISABLE DH Sentry map deco (DEFAULT theme)
				/* plugin.SentryDecorator.Enabled = false;
				plugin.SentryWithCustomEngineeringDecorator.Enabled = false; */

			});

        }


        public override void Load(IController hud)
        {
            base.Load(hud);


			//  DH: Female: 74706  |  Male: 75207


			/* **************************
					  DH SKILLS
			***************************** */


            // DH Sentry

            // without Custom Engineering passive
            SentryDecorator = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(220, 0, 170, 170, 2),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    ShapePainter = new TriangleShapePainter(Hud),
                    Radius = 5f,
                },
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(150, 0, 150, 255, 2, DashStyle.Dash),
                    Radius = 1.9f,
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 30,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 220, 255, 255, 255, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud) // value_format can be 'dyn', 'F0', 'F1'
                {
                    CountDownFrom = 30,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(160, 240, 148, 32, 0),
                    Radius = 20,
                });

            // with Custom Engineering passive
            SentryCeDeco = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(220, 0, 170, 170, 2),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    ShapePainter = new TriangleShapePainter(Hud),
                    Radius = 5f,
                },
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(150, 0, 150, 255, 2, DashStyle.Dash),
                    Radius = 1.9f,
                },
                new GroundLabelDecorator(Hud) // offset_z="-3.0" use_bottom="1"
                {
                    CountDownFrom = 60,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 220, 255, 255, 255, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud) //offset_z="3" use_bottom="1"
                {
                    CountDownFrom = 60,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(160, 240, 148, 32, 0),
                    Radius = 20,
                });

            // Polar Station, rune 3
            SentryPolarDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(80, 0, 150, 255, 1.2f),
                    Radius = 16f,
                });

            // Guardian Turret, rune 4
            SentryGuardianDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(80, 0, 150, 255, 1.2f),
                    Radius = 18f,
                });


            // Marked For Death

            // Valley of Death, rune 2
            MfdVodDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(100, 0, 255, 255, 1.0f, DashStyle.Dash),
                    Radius = 15f,
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 15,
                    TextFont = Hud.Render.CreateFont("tahoma", 7.5f, 255, 255, 255, 0, true, false, 255, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 15,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(120, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(120, 255, 0, 255, 0),
                    Radius = 16,
                });


            // Rain of Vengeance

            // No rune | Shade, rune 0 (30y?, 5s)
            RoVShadeDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(100, 255, 255, 0, 1.0f, DashStyle.Dash),
                    Radius = 30f,
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 5,
                    TextFont = Hud.Render.CreateFont("tahoma", 9f, 255, 255, 255, 0, true, false, 255, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 5,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(120, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(120, 255, 0, 255, 0),
                    Radius = 20,
                });

            // Dark Cloud, rune 1 (10y?, 8s)
            RoVDarkCloudDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(180, 255, 255, 0, 1.0f, DashStyle.Dash),
                    Radius = 10f,
                });

            // Anathema, rune 2 (15y?, 2s)
            RoVAnathemaDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(100, 255, 255, 0, 1.0f, DashStyle.Dash),
                    Radius = 15f,
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 2,
                    TextFont = Hud.Render.CreateFont("tahoma", 7.5f, 255, 255, 255, 0, true, false, 255, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 2,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(120, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(120, 255, 0, 255, 0),
                    Radius = 16f,
                });

            // Flying Strike, rune 3 (11y?, 4s | 8y, 2s freeze)
            RoVFlyingStrikeDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(100, 255, 255, 0, 1.0f, DashStyle.Dash),
                    Radius = 11f,
                });

            // Stampede, rune 4 (15y?, 3s | 8y knockback)
            RoVStampedeDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(100, 255, 255, 0, 1.0f, DashStyle.Dash),
                    Radius = 15f,
                });


            // Grenade

            // All runes EXCEPT Cluster Grenades (6y)
            GrenadeDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(40, 255, 255, 0, 1.0f, DashStyle.Dash),
                    Radius = 6f,
                });
            // Cluster Grenades, rune 1 (9y)
            GrenadeCGDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(40, 255, 255, 0, 1.0f, DashStyle.Dash),
                    Radius = 9f,
                });

        }


        public void PaintWorld(WorldLayer layer)
        {
            var actors = Hud.Game.Actors;
            foreach (var actor in actors)
            {

                /* ---  Skills where "summoned_by_me" works  --- */

                if (actor.SummonerAcdDynamicId == Hud.Game.Me.SummonerId) // summoned_by_me
                {
                    // TODO: fix this by using enum values
                    switch (actor.SnoActor.Sno)
                    {

                        // Sentry
                        case ActorSnoEnum._dh_sentry/*141402*/: // No rune // DH_sentry
                        case ActorSnoEnum._dh_sentry_tether/*168815*/: // Chain of Torment, rune 0 // DH_sentry_tether
                        case ActorSnoEnum._dh_sentry_addsduration/*150024*/: // Impaling Bolt, rune 1 // DH_sentry_addsDuration
                        case ActorSnoEnum._dh_sentry_addsmissiles/*150025*/: // Spitfire Turret, rune 2 // DH_sentry_addsMissiles
                            if (!Hud.Game.Me.Powers.BuffIsActive(208610, 0)) // without Custom Engineering passive
                            {
                                SentryCeDeco.Paint(layer, actor, actor.FloorCoordinate, null);
                            }
                            else // with Custom Engineering passive
                            {
                                SentryCeDeco.Paint(layer, actor, actor.FloorCoordinate, null);
                            }
                            break;

                        case ActorSnoEnum._dh_sentry_addsheals/*150026*/: // Polar Station, rune 3 // DH_sentry_addsHeals
                            SentryPolarDeco.Paint(layer, actor, actor.FloorCoordinate, null);
                            if (!Hud.Game.Me.Powers.BuffIsActive(208610, 0)) // without Custom Engineering passive
                            {
                                SentryDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                            }
                            else // with Custom Engineering passive
                            {
                                SentryCeDeco.Paint(layer, actor, actor.FloorCoordinate, null);
                            }
                            break;

                        case ActorSnoEnum._dh_sentry_addsshield/*150027*/: // Guardian Turret, rune 4 // DH_sentry_addsShield
                            SentryGuardianDeco.Paint(layer, actor, actor.FloorCoordinate, null);
                            if (!Hud.Game.Me.Powers.BuffIsActive(208610, 0)) // without Custom Engineering passive
                            {
                                SentryDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                            }
                            else // with Custom Engineering passive
                            {
                                SentryCeDeco.Paint(layer, actor, actor.FloorCoordinate, null);
                            }
                            break;

                    }
                }


                /* ---  Skills where "summoned_by_me" does not work  --- */
                switch (actor.SnoActor.Sno)
                {

                    // Marked For Death
                    case ActorSnoEnum._dh_markedfordeath_proxyactor/*230674*/: // Valley of Death, rune 2 // DH_MarkedForDeath_proxyActor
                        MfdVodDeco.Paint(layer, actor, actor.FloorCoordinate, null);
                    break;


                    // Rain of Vengeance
                    case ActorSnoEnum._demonhunter_rainofarrows/*131701*/: // No rune // DemonHunter_RainOfArrows
                    case ActorSnoEnum._demonhunter_rainofarrows_alabaster_discipline/*151842*/: // Shade, rune 0 // DemonHunter_RainOfArrows_alabaster_discipline
                        RoVShadeDeco.Paint(layer, actor, actor.FloorCoordinate, null);
                    break;

                    case ActorSnoEnum._demonhunter_rainofarrows_indigo_buff/*153029*/: // Dark Cloud, rune 1 // DemonHunter_RainOfArrows_indigo_buff
                        RoVDarkCloudDeco.Paint(layer, actor, actor.FloorCoordinate, null);
                    break;

                    // case 154292: // Anathema, Rune 2 // DH_rainOfArrows_projectile_grenades (grenade explosion + sky source)
                    case ActorSnoEnum._dh_rainofarrows_grenade_launcher/*155276*/: // Anathema, Rune 2 // DH_rainOfArrows_grenade_launcher
                        RoVAnathemaDeco.Paint(layer, actor, actor.FloorCoordinate, null);
                    break;

                    case ActorSnoEnum._demonhunter_rainofarrows_kamikaze/*200561*/: // Flying Strike, rune 3 // DemonHunter_RainOfArrows_kamikaze
                        RoVFlyingStrikeDeco.Paint(layer, actor, actor.FloorCoordinate, null);
                    break;

                    case ActorSnoEnum._x1_dh_rainofarrows_flyercrash_projectile/*370495*/: // Stampede, rune 4 // x1_DH_rainOfArrows_flyerCrash_projectile
                        RoVStampedeDeco.Paint(layer, actor, actor.FloorCoordinate, null);
                    break;


                    // Grenade
                    case ActorSnoEnum._demonhunter_grenade_projectile/*88244*/: // All Grenades launch projectile (except Cold Grenade) // DemonHunter_Grenade_Projectile
                    case ActorSnoEnum._p1_demonhunter_grenade_projectile_cold/*428572*/: // Cold Grenade launch projectile // p1_DemonHunter_Grenade_Projectile_cold
                    case ActorSnoEnum._grenadeproxy_norune/*154027*/: // No rune // GrenadeProxy_NoRune
                    case ActorSnoEnum._grenadeproxy_crimson_aoe/*154076*/: // Cold Grenade, rune 0 // GrenadeProxy_Crimson_AOE
                    case ActorSnoEnum._grenadeproxy_indigo/*154028*/: // Cluster Grenades, rune 1 // GrenadeProxy_Indigo
                    // case ActorSnoEnum./*154027*/: // Grenade Cache, rune 2 (shared with No rune) // GrenadeProxy_NoRune
                    case ActorSnoEnum._grenadeproxy_golden/*154046*/: // Tinkerer, rune 3 // GrenadeProxy_Golden
                    case ActorSnoEnum._grenadeproxy_alabaster/*154043*/: // Stun Grenade, rune 4 // GrenadeProxy_Alabaster
						{
							var skill = Hud.Game.Me.Powers.UsedDemonHunterPowers.Grenades;
							if (skill != null)
							{
								if (skill.Rune == 1) // with Cluster Grenades rune
								{
									GrenadeCGDeco.Paint(layer, actor, actor.FloorCoordinate, null);
								}
								else // Without Cluster Grenades rune
								{
									GrenadeDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
								}
							}
						}
						break;


                }
            }
        }

    }
}