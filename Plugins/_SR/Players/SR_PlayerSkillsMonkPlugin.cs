// adaptation of StormReaver v6 xml theme

namespace Turbo.Plugins._SR.Players
{
    using SharpDX.Direct2D1;
    using Turbo.Plugins.Default;

    public class SR_PlayerSkillsMonkPlugin : BasePlugin, ICustomizer, IInGameWorldPainter
    {
        public WorldDecoratorCollection InnerSanctuaryDecorator { get; set; }
        public WorldDecoratorCollection InnerSanctuarySgDeco { get; set; }
        public WorldDecoratorCollection SunwukoDecoyDecorator { get; set; }
        public WorldDecoratorCollection CycloneStrikeDecorator { get; set; }
        public WorldDecoratorCollection CycloneStrikeImpDeco { get; set; }
        public WorldDecoratorCollection SweepingWindDecorator { get; set; }
        public WorldDecoratorCollection SweepingWindFsDeco { get; set; }

        public SR_PlayerSkillsMonkPlugin()
        {
            Enabled = true;
        }

        public void Customize()
        {
            /* Hud.RunOnPlugin<PlayerSkillPlugin>(plugin =>
			{
				// disable DEFAULT
				plugin.Enabled = false;
			}); */
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            //  MONK: Female: 4717  |  Male: 4721

            /* **************************
					  MONK SKILLS
			***************************** */

            // Inner Sanctuary

            // All runes EXCEPT Sanctified Ground (13y? or 11y? 6s)
            InnerSanctuaryDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(200, 240, 240, 100, 8, DashStyle.Dash),
                    Radius = 13, //11
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 6,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 100, 255, 150, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 6,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(100, 190, 117, 0, 0),
                    Radius = 35,
                });
            // Sanctified Ground, rune (13y? or 11y? 8s) ??
            InnerSanctuarySgDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(200, 240, 240, 100, 8, DashStyle.Dash),
                    Radius = 13, //11
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 8,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 100, 255, 150, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 8,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(100, 190, 117, 0, 0),
                    Radius = 35,
                });

            // Sunwuko Set

            // Exploding Decoy (0.5s)
            SunwukoDecoyDecorator = new WorldDecoratorCollection(
                 new GroundLabelDecorator(Hud) // offset_z="-3"
                {
                     CountDownFrom = 1, // cannot use float/decimal
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 255, 20, 150, true, false, 128, 0, 0, 0, true),
                 },
                 new GroundTimerDecorator(Hud) // offset_z="-3"
                {
                     CountDownFrom = 0.5f,
                     BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                     BackgroundBrushFill = Hud.Render.CreateBrush(220, 190, 150, 0, 0),
                     Radius = 15,
                 });

            // Cyclone Strike

            // All runes EXCEPT Implosion (24y)
            CycloneStrikeDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(150, 220, 220, 0, 0.5f),
                    Radius = 24,
                });
            // Implosion rune (34y)
            CycloneStrikeImpDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(150, 220, 220, 0, 0.5f),
                    Radius = 34,
                });

            // Sweeping Wind

            // All runes EXCEPT Firestorm (10y)
            SweepingWindDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(180, 250, 200, 0, 0.5f, DashStyle.Dash),
                    Radius = 10,
                });
            // Firestorm rune (14y)
            SweepingWindFsDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(180, 250, 200, 0, 0.5f, DashStyle.Dash),
                    Radius = 14,
                });
        }

        public void PaintWorld(WorldLayer layer)
        {
            var actors = Hud.Game.Actors;
            foreach (var actor in actors)
            {
                /* ---  Skills where "summoned_by_me" works  --- */

                // if (actor.SummonerAcdDynamicId == Hud.Game.Me.SummonerId) // summoned_by_me
                // {
                // switch (actor.SnoActor.Sno)
                // {
                // Empty switch block //

                // }
                // }

                /* ---  Skills where "summoned_by_me" does not work  --- */

                switch (actor.SnoActor.Sno)
                {
                    // Inner Sanctuary
                    // All runes EXCEPT Sanctified Ground (13y? or 11y? 6s)
                    case ActorSnoEnum._x1_monk_innersanctuaryrune_forbidden_proxy/*320136*/: // // X1_Monk_innerSanctuaryRune_forbidden_proxy
                    case ActorSnoEnum._x1_monk_innersanctuaryrune_intervene_proxy/*319583*/: // // X1_Monk_innerSanctuaryRune_intervene_proxy
                    case ActorSnoEnum._x1_monk_innersanctuary_proxy/*319337*/: // // X1_Monk_innerSanctuary_proxy
                    case ActorSnoEnum._x1_monk_innersanctuaryrune_healing_proxy/*320135*/: // // X1_Monk_innerSanctuaryRune_healing_proxy
                    case ActorSnoEnum._x1_monk_innersanctuaryrune_protect_proxy/*319776*/: // // X1_Monk_innerSanctuaryRune_protect_proxy
                        InnerSanctuaryDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                        break;

                    case ActorSnoEnum._monk_innersanctuaryrune_duration_proxy/*149848*/: // Sanctified Ground, rune ?? // Monk_innerSanctuaryRune_duration_proxy
                        InnerSanctuarySgDeco.Paint(layer, actor, actor.FloorCoordinate, null);
                        break;

                    // Sunwuko Set Exploding Decoy ?
                    case ActorSnoEnum._p2_monk_female_lethaldecoy_cold/*426083*/:    //p2_Monk_Female_lethalDecoy_cold
                    case ActorSnoEnum._p2_monk_female_lethaldecoy_fire/*426074*/:    //p2_Monk_Female_lethalDecoy_fire
                    case ActorSnoEnum._p2_monk_female_lethaldecoy_lightning/*426095*/:    //p2_Monk_Female_lethalDecoy_lightning
                    case ActorSnoEnum._p2_monk_female_lethaldecoy_phys/*426110*/:    //p2_Monk_Female_lethalDecoy_phys
                    case ActorSnoEnum._p2_monk_male_lethaldecoy_cold/*426092*/:    //p2_Monk_Male_LethalDecoy_cold
                                                     // case 426091:	//p2_Monk_Male_lethalDecoy_cold_model
                    case ActorSnoEnum._p2_monk_male_lethaldecoy_fire/*141773*/:    //p2_Monk_Male_lethalDecoy_fire
                                                     // case 426081:	//p2_Monk_Male_lethalDecoy_fire_model
                    case ActorSnoEnum._p2_monk_male_lethaldecoy_lightning/*426107*/:    //p2_Monk_Male_LethalDecoy_lightning
                                                     // case 426106:	//p2_Monk_Male_lethalDecoy_lightning_model
                    case ActorSnoEnum._p2_monk_male_lethaldecoy_phys/*426121*/:    //p2_Monk_Male_LethalDecoy_phys
                                                     // case 426123:	//p2_Monk_Male_lethalDecoy_phys_model
                    case ActorSnoEnum._x1_monk_female_decoy/*363236*/:    // x1_Monk_Female_Decoy // old
                    case ActorSnoEnum._x1_monk_male_decoy/*363237*/:    // x1_Monk_Male_Decoy // old
                        SunwukoDecoyDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                        break;

                    // Draw circles around Monk player //////////////////////

                    case ActorSnoEnum._monk_female/*4717*/: // Female
                    case ActorSnoEnum._monk_male/*4721*/: // Male
                        {
                            // Cyclone Strike
                            // 223473 // Cyclone Strike SNO
                            var Skill_CS = Hud.Game.Me.Powers.UsedMonkPowers.CycloneStrike;
                            if (Hud.Game.IsInTown) return; // only out of town
                            if (Skill_CS != null)
                            {
                                if (Skill_CS.Rune == 1) // Implosion rune (34y)
                                {
                                    CycloneStrikeImpDeco.Paint(layer, actor, actor.FloorCoordinate, null);
                                }
                                else // All runes EXCEPT Implosion (24y)
                                {
                                    CycloneStrikeDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                                }
                            }

                            // Sweeping Wind
                            // 96090 // Sweeping Wind SNO
                            var Skill_SW = Hud.Game.Me.Powers.UsedMonkPowers.SweepingWind;
                            if (Hud.Game.IsInTown) return; // only out of town
                            if (Skill_SW != null)
                            {
                                if (Skill_SW.Rune == 1) // Firestorm rune (14y)
                                {
                                    SweepingWindFsDeco.Paint(layer, actor, actor.FloorCoordinate, null);
                                }
                                else // All runes EXCEPT Firestorm (10y)
                                {
                                    SweepingWindDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                                }
                            }
                        }
                        break;
                }
            }
        }
    }
}