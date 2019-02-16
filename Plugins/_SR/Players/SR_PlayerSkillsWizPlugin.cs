// adaptation of StormReaver v6 xml theme

using System;

namespace Turbo.Plugins._SR.Players
{
    using SharpDX.Direct2D1;
    using System.Collections.Generic;
    using Turbo.Plugins.Default;

    public class SR_PlayerSkillsWizPlugin : BasePlugin, ICustomizer, IInGameWorldPainter
    {
        public WorldDecoratorCollection HydraDecorator { get; set; }
        public WorldDecoratorCollection BlackHoleDecorator { get; set; }
        public WorldDecoratorCollection BlackHoleAllDeco { get; set; }
        public WorldDecoratorCollection BlackHoleSmDeco { get; set; }
        public WorldDecoratorCollection MeteorDecorator { get; set; }
        public WorldDecoratorCollection MeteorMsDeco { get; set; }
        public WorldDecoratorCollection MeteorMiDeco { get; set; }
        public WorldDecoratorCollection BlizzardDecorator { get; set; }
        public WorldDecoratorCollection BlizzardUsDeco { get; set; }
        public WorldDecoratorCollection BlizzardApDeco { get; set; }
        public WorldDecoratorCollection EnergyTwisterDecorator { get; set; }
        public WorldDecoratorCollection EnergyTwisterDeco2 { get; set; }
        public WorldDecoratorCollection EnergyTwisterRSMTDeco { get; set; }
        public WorldDecoratorCollection TeleportFrDeco { get; set; }

        public SR_PlayerSkillsWizPlugin()
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

            InitMapping();

            //  WIZ: Female: 6526  |  Male: 6544

            /* **************************
					  WIZ SKILLS
			***************************** */

            // Hydra

            // All runes
            HydraDecorator = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(220, 255, 100, 100, 2),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    ShapePainter = new TriangleShapePainter(Hud),
                    Radius = 4f,
                },
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(150, 0, 150, 255, 2, DashStyle.Dash),
                    Radius = 1.9f,
                },
                new GroundLabelDecorator(Hud) // offset_z="-7.5"
                {
                    CountDownFrom = 15,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 220, 255, 255, 255, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud) // offset_z="3"
                {
                    CountDownFrom = 15,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(230, 255, 50, 50, 0),
                    Radius = 20,
                });

            // Black Hole

            // All runes
            BlackHoleDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 2,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 255, 200, 200, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 2,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(230, 255, 50, 50, 0),
                    Radius = 20,
                });
            // add ground circle to all runes EXCEPT Supermassive (15y)
            BlackHoleAllDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(80, 255, 100, 255, 2, DashStyle.Dash),
                    Radius = 15,
                });
            // Supermassive, rune 0 (20y)
            BlackHoleSmDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(80, 255, 255, 100, 2, DashStyle.Dash),
                    Radius = 20,
                });

            // Meteor

            // PS: also triggered by Tal Rasha 2pc Set Bonus
            // Comet, rune 2 | Star Pact, rune 3 | Thunder Crash, rune 4 (12y)
            MeteorDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(60, 50, 150, 50, 2, DashStyle.Dash),
                    Radius = 12,
                });
            //  Molten Impact, rune 0 (20y)
            MeteorMiDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(50, 50, 150, 50, 2, DashStyle.Dash),
                    Radius = 20,
                });
            // Meteor Shower, rune 1 (8y)
            MeteorMsDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(60, 50, 150, 50, 1.5f, DashStyle.Dash),
                    Radius = 8,
                });

            // Blizzard

            // No rune | Lightning Storm, rune 2 | Snowbound, rune 3 | Frozen Solid, rune 4 (12y, 6s)
            BlizzardDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(100, 0, 120, 255, 2.5f, DashStyle.Dash),
                    Radius = 12f,
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 6,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 180, 200, 255, 150, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    Enabled = true,
                    CountDownFrom = 6,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(160, 100, 255, 150, 0),
                    Radius = 20,
                });
            // Unrelenting Storm, rune 0 (12y, 8s)
            BlizzardUsDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(100, 0, 120, 255, 2.5f, DashStyle.Dash),
                    Radius = 12f,
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 8,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 180, 200, 255, 150, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    Enabled = true,
                    CountDownFrom = 8,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(160, 100, 255, 150, 0),
                    Radius = 20,
                });
            // Apocalypse, rune 1 (30y, 6s)
            BlizzardApDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(100, 0, 120, 255, 2.5f, DashStyle.Dash),
                    Radius = 30f,
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 6,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 180, 200, 255, 150, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    Enabled = true,
                    CountDownFrom = 6,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(160, 100, 255, 150, 0),
                    Radius = 20,
                });

            // Energy Twister

            // PS: Wicked Wind, rune 4: "summoned_by_me" does not work with this rune (9.5y?, 6s)
            // All rune (6s)
            EnergyTwisterDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 6,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 200, 100, 255, 150, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 6,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(140, 255, 10, 150, 0),
                    Radius = 20,
                });
            // All runes (9.5y?, not 8y?)
            EnergyTwisterDeco2 = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(80, 255, 255, 0, 2.0f, DashStyle.Dash),
                    Radius = 9.5f,
                });
            // Raging Storm, rune 1 (Merged Tornadoes) (15y)
            EnergyTwisterRSMTDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(120, 255, 255, 0, 2.5f, DashStyle.Dash),
                    Radius = 15f,
                });

            // Teleport

            // Fracture, Rune 1
            TeleportFrDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(60, 255, 255, 0, 2.5f, DashStyle.Dash),
                    Radius = 2f,
                },
                new GroundLabelDecorator(Hud) // offset_z="-1.5"
                {
                    CountDownFrom = 6,
                    TextFont = Hud.Render.CreateFont("tahoma", 7.5f, 220, 255, 255, 0, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud) // offset_z="-1.5"
                {
                    Enabled = true,
                    CountDownFrom = 6,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(150, 0, 255, 150, 0),
                    Radius = 15,
                });
        }

        private Dictionary<ActorSnoEnum, Action<WorldLayer, IActor>> _snoMapping;
        private Dictionary<ActorSnoEnum, Action<WorldLayer, IActor>> _summonedByMeSnoMapping;

        private void InitMapping()
        {
            _summonedByMeSnoMapping = new Dictionary<ActorSnoEnum, Action<WorldLayer, IActor>>()
            {
                {(ActorSnoEnum) 117574, HydraPaint },
                // Hydra
                {(ActorSnoEnum) 80745, HydraPaint }, // No rune:     80745|80757|80758 (heads x3)
                {(ActorSnoEnum) 82109, HydraPaint }, // Lightning:   81229|82109||81230
                {(ActorSnoEnum) 81515, HydraPaint }, // Arcane:      81515|81231|81232
                {(ActorSnoEnum) 325807, HydraPaint }, // Blazing:    325807|325813|325815
                {(ActorSnoEnum) 82972, HydraPaint }, // Frost:       83024|82972|83025
                {(ActorSnoEnum) 83959, HydraPaint }, // Mammoth:     83959
                // Black Hole // All runes
                {(ActorSnoEnum) 336410, BlackHolePaint },
                {(ActorSnoEnum) 341426, BlackHolePaint },
                {(ActorSnoEnum) 341411, BlackHolePaint },
                {(ActorSnoEnum) 341396, BlackHolePaint },
                {(ActorSnoEnum) 341441, BlackHolePaint },
                // Supermassive, rune 0
                {(ActorSnoEnum) 341381, BlackHoleSuperMassivePaint },
                // Energy Twister
                {(ActorSnoEnum) 6560, EnergyTwisterPaint }, // No rune // Wizard_Tornado
                {(ActorSnoEnum) 319692, EnergyTwisterPaint }, // Gale Force, rune 0 // x1_Wizard_Tornado_fire
                {(ActorSnoEnum) 323092, EnergyTwisterPaint }, // Raging Storm, rune 1 (base) // x1_Wizard_Tornado_damage
                {(ActorSnoEnum) 226648, EnergyTwisterPaint }, // Storm Chaser, rune 2 // Wizard_Tornado_obsidian
                {(ActorSnoEnum) 215324, EnergyTwisterPaint }, //  Mistral Breeze, rune 3 // Wizard_Tornado_golden
                {(ActorSnoEnum) 77333, RagingStormPaint }, // Raging Storm, rune 1 (Merged Tornadoes) // Wizard_Tornado_Big
                //Teleport
                {(ActorSnoEnum) 98010, TeleportPaint }, // Wizard_MirrorImage_Female
                {(ActorSnoEnum) 107916, TeleportPaint }, // Wizard_MirrorImage_Male
            };

            _snoMapping = new Dictionary<ActorSnoEnum, Action<WorldLayer, IActor>>()
            {
                // Meteor   (also triggered by Tal Rasha 2pc Set Bonus)
                    // No rune
                    {(ActorSnoEnum) 86790, MeteorPaint }, // Pending // TEMP_Wizard_Meteor_Pending
                    {(ActorSnoEnum) 86769, MeteorPaint }, // Impact // TEMP_Wizard_Meteor_Impact
                    {(ActorSnoEnum) 90364, MeteorPaint }, // AfterBurn // TEMP_Wizard_Meteor_afterBurn
                    // Comet, rune 2
                    {(ActorSnoEnum) 92030, MeteorPaint }, // Pending
                    {(ActorSnoEnum) 92031, MeteorPaint }, // Impact
                    {(ActorSnoEnum) 92032, MeteorPaint }, // AfterBurn
                    // Star Pact, rune 3
                    {(ActorSnoEnum) 217142, MeteorPaint }, // Pending
                    {(ActorSnoEnum) 217139, MeteorPaint }, // Impact
                    {(ActorSnoEnum) 217307, MeteorPaint }, // AfterBurn
                    // Thunder Crash, rune 4
                    {(ActorSnoEnum) 217457, MeteorPaint }, // Pending
                    {(ActorSnoEnum) 217458, MeteorPaint }, // Impact
                    {(ActorSnoEnum) 217459, MeteorPaint }, // AfterBurn
                    // Molten Impact, rune 0
                    {(ActorSnoEnum) 215853, MoltenImpactPaint }, // Pending
                    {(ActorSnoEnum) 215809, MoltenImpactPaint }, // Impact
                    {(ActorSnoEnum) 394102, MoltenImpactPaint }, // AfterBurn
                    // Meteor Shower, rune 1
                    {(ActorSnoEnum) 91440, MeteorShowerPaint }, // Pending
                    {(ActorSnoEnum) 91441, MeteorShowerPaint }, // Impact
                    // Blizzard
                    {(ActorSnoEnum) 6519, BlizzardPaint }, // No rune // Wizard_Blizzard
                    {(ActorSnoEnum) 409287, BlizzardPaint }, // Lightning Storm, rune 2 // p1_Wizard_Blizzard_lightning
                    {(ActorSnoEnum) 185662, BlizzardPaint }, // Snowbound, rune 3 // Wizard_Blizzard_reduceCost
                    {(ActorSnoEnum) 185663, BlizzardPaint }, // Frozen Solid, rune 4 // Wizard_Blizzard_addFreeze

                    {(ActorSnoEnum) 185660, BlizzardStormPaint }, // Unrelenting Storm, rune 0 // Wizard_Blizzard_addTime

                    {(ActorSnoEnum) 185661, BlizzardApocalypsePaint }, // Apocalypse, rune 1 // Wizard_Blizzard_addSize

                    // Energy Twister
                    // "summoned_by_me" does not work with this rune
                    {(ActorSnoEnum) 210804, EnergyTwister4Paint }, // Wicked Wind, rune 4 // Wizard_Tornado_Stationary
            };
        }

        public void PaintWorld(WorldLayer layer)
        {
            var actors = Hud.Game.Actors;
            foreach (var actor in actors)
            {
                /* ---  Skills where "summoned_by_me" works  --- */

                if (actor.SummonerAcdDynamicId == Hud.Game.Me.SummonerId) // summoned_by_me
                {
                    if (_summonedByMeSnoMapping.TryGetValue(actor.SnoActor.Sno, out var summonedByMeAction))
                    {
                        summonedByMeAction?.Invoke(layer, actor);
                    }
                }

                /* ---  Skills where "summoned_by_me" does not work  --- */
                if (_snoMapping.TryGetValue(actor.SnoActor.Sno, out var action))
                {
                    action?.Invoke(layer, actor);
                }
            }
        }

        private void EnergyTwister4Paint(WorldLayer layer, IActor actor)
        {
            var skill = Hud.Game.Me.Powers.UsedWizardPowers.EnergyTwister;
            if (skill != null)
            {
                EnergyTwisterDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                EnergyTwisterDeco2.Paint(layer, actor, actor.FloorCoordinate, null);
            }
        }

        private void BlizzardApocalypsePaint(WorldLayer layer, IActor actor)
        {
            BlizzardApDeco.Paint(layer, actor, actor.FloorCoordinate, null);
        }

        private void BlizzardStormPaint(WorldLayer layer, IActor actor)
        {
            BlizzardUsDeco.Paint(layer, actor, actor.FloorCoordinate, null);
        }

        private void BlizzardPaint(WorldLayer layer, IActor actor)
        {
            BlizzardDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
        }

        private void MeteorShowerPaint(WorldLayer layer, IActor actor)
        {
            MeteorMsDeco.Paint(layer, actor, actor.FloorCoordinate, null);
        }

        private void MoltenImpactPaint(WorldLayer layer, IActor actor)
        {
            MeteorMiDeco.Paint(layer, actor, actor.FloorCoordinate, null);
        }

        private void MeteorPaint(WorldLayer layer, IActor actor)
        {
            MeteorDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
        }

        private void TeleportPaint(WorldLayer layer, IActor actor)
        {
            var skill = Hud.Game.Me.Powers.UsedWizardPowers.Teleport;
            if (skill != null)
            {
                if (skill.Rune == 1) // with Fracture, Rune 1
                {
                    TeleportFrDeco.Paint(layer, actor, actor.FloorCoordinate, null);
                }
            }
        }

        private void RagingStormPaint(WorldLayer layer, IActor actor)
        {
            var skill = Hud.Game.Me.Powers.UsedWizardPowers.EnergyTwister;
            if (skill != null)
            {
                EnergyTwisterDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                EnergyTwisterRSMTDeco.Paint(layer, actor, actor.FloorCoordinate, null);
            }
        }

        private void EnergyTwisterPaint(WorldLayer layer, IActor actor)
        {
            var skill = Hud.Game.Me.Powers.UsedWizardPowers.EnergyTwister;
            if (skill != null)
            {
                EnergyTwisterDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                EnergyTwisterDeco2.Paint(layer, actor, actor.FloorCoordinate, null);
            }
        }

        private void BlackHoleSuperMassivePaint(WorldLayer layer, IActor actor)
        {
            BlackHoleDecorator.Paint(layer, actor, actor.FloorCoordinate.Offset(0, 0, 5.2f), null);
            BlackHoleSmDeco.Paint(layer, actor, actor.FloorCoordinate, null);
        }

        private void BlackHolePaint(WorldLayer layer, IActor actor)
        {
            BlackHoleDecorator.Paint(layer, actor, actor.FloorCoordinate.Offset(0, 0, 5.2f), null);
            BlackHoleAllDeco.Paint(layer, actor, actor.FloorCoordinate, null);
        }

        private void HydraPaint(WorldLayer layer, IActor actor)
        {
            HydraDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
        }
    }
}