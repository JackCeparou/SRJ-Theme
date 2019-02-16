// adaptation of StormReaver v6 xml theme

using System;

namespace Turbo.Plugins._SR.Players
{
    using SharpDX.Direct2D1;
    using System.Collections.Generic;
    using Turbo.Plugins.Default;

    public class SR_PlayerSkillsWDPlugin : BasePlugin, ICustomizer, IInGameWorldPainter
    {
        public WorldDecoratorCollection PiranhasDecorator { get; set; }
        public WorldDecoratorCollection PiranhasZombieDeco { get; set; }
        public WorldDecoratorCollection PiranhasPiranhadoDeco { get; set; }
        public WorldDecoratorCollection PiranhasWomDeco { get; set; }
        public WorldDecoratorCollection BigBadVoodooDecorator { get; set; }
        public WorldDecoratorCollection BigBadVoodooJdDeco { get; set; }
        public WorldDecoratorCollection BigBadVoodooGLDeco { get; set; }
        public WorldDecoratorCollection SpiritWalkDecorator { get; set; }
        public WorldDecoratorCollection SpiritWalkJauntDeco { get; set; }
        public WorldDecoratorCollection FetishArmyDecorator { get; set; }
        public WorldDecoratorCollection FetishSycophantsDecorator { get; set; }
        public WorldDecoratorCollection HorrifyDecorator { get; set; }
        public WorldDecoratorCollection HorrifyFodDeco { get; set; }
        public WorldDecoratorCollection AcidCloudDecorator { get; set; }
        public WorldDecoratorCollection AcidCloudArDeco1 { get; set; }
        public WorldDecoratorCollection AcidCloudArDeco2 { get; set; }
        public WorldDecoratorCollection AcidCloudSbDeco { get; set; }
        public WorldDecoratorCollection GraspOfTheDeadDecorator { get; set; }
        public WorldDecoratorCollection WallOfDeathDecorator { get; set; }
        public WorldDecoratorCollection WallOfDeathNrDeco { get; set; }
        public WorldDecoratorCollection WallOfDeathSbdDeco { get; set; }
        public WorldDecoratorCollection WallOfDeathRopDeco { get; set; }
        public WorldDecoratorCollection WallOfDeathCwsDeco { get; set; }
        public WorldDecoratorCollection WallOfDeathWozDeco { get; set; }
        public WorldDecoratorCollection WallOfDeathFwDeco { get; set; }

        public SR_PlayerSkillsWDPlugin()
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

            //  WD: Female: 6481  |  Male: 6485

            /* **************************
					  WD SKILLS
			***************************** */

            // Piranhas

            // All runes EXCEPT Waves of Mutilation (15y)
            PiranhasDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(100, 255, 255, 255, 1f, DashStyle.Dash),
                    Radius = 15,
                });
            // Zombie Piranhas, rune 1 / leap attack (40y)
            PiranhasZombieDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(60, 255, 255, 255, 1.2f, DashStyle.Dash),
                    Radius = 40,
                });
            // Piranhado, rune 2 / pull-in effect every 2s, working properly? (30y)
            PiranhasPiranhadoDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(60, 255, 255, 255, 1.2f, DashStyle.Dash),
                    Radius = 30,
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 4,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 255, 255, 0, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 4,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(150, 255, 0, 255, 0),
                    Radius = 20,
                });
            // Wave of Mutilation, rune 3 / wave 30y, forward rush 30y?, effective radius 18y? (30y)
            PiranhasWomDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(100, 255, 255, 255, 1f, DashStyle.Dash),
                    Radius = 18,
                });

            // Big Bad Voodoo

            // Without Jungle Drums, rune 1
            BigBadVoodooDecorator = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(200, 0, 255, 150, 2.5f),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    ShapePainter = new TriangleShapePainter(Hud),
                    Radius = 5,
                },
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(100, 255, 255, 255, 1f),
                    Radius = 33,
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 20,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 255, 255, 255, true, false, 220, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 20,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(160, 100, 200, 100, 0),
                    Radius = 20,
                });
            // With Jungle Drums, rune 1
            BigBadVoodooJdDeco = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(200, 0, 255, 150, 2.5f),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    ShapePainter = new TriangleShapePainter(Hud),
                    Radius = 5,
                },
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(100, 255, 255, 255, 1f),
                    Radius = 33,
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 30,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 255, 255, 255, true, false, 220, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 30,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(160, 100, 200, 100, 0),
                    Radius = 20,
                });
            // B.B.V. Ground Label
            BigBadVoodooGLDeco = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 255, 255, 255, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 0, 0, 0, true, false, 80, 0, 255, 0, false),
                    BorderBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 1.5f),
                });

            // Spirit Walk

            // without Jaunt, rune 1
            SpiritWalkDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 2,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 150, 255, 150, true, false, 150, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 2,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(200, 255, 150, 255, 0),
                    Radius = 20,
                });
            // with Jaunt, rune 1
            SpiritWalkJauntDeco = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 3,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 150, 255, 150, true, false, 150, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 3,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(200, 255, 150, 255, 0),
                    Radius = 20,
                });

            // Fetish Army

            // Al runes
            FetishArmyDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 20,
                    TextFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 255, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 20,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(80, 255, 255, 255, 0),
                    Radius = 12,
                });

            // Fetish Sycophants

            // Al runes
            FetishSycophantsDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 60,
                    TextFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 255, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 60,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(80, 255, 255, 255, 0),
                    Radius = 12,
                });

            // Horrify

            // add ground circle to WD actor ON-ACTIVATING Horrify (self only?)
            // All runes EXCEPT Face of Death (18y)
            HorrifyDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 100, 0, 255, 2f),
                    Radius = 18,
                    //RadiusTransformator = new StandardPingRadiusTransformator(Hud, 800),
                });
            // Face of Death, rune 1 (24y)
            HorrifyFodDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 100, 0, 255, 2f),
                    Radius = 24,
                    //RadiusTransformator = new StandardPingRadiusTransformator(Hud, 800),
                });

            // Acid Cloud

            // All runes EXCEPT Acid Rain & Slow Burn (12y)
            AcidCloudDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(100, 0, 255, 0, 1.2f),
                    Radius = 12,
                });
            // Acid Rain, rune 1: Main (24y)
            AcidCloudArDeco1 = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(80, 0, 255, 0, 1.4f),
                    Radius = 24,
                });
            // Acid Rain, rune 1: 3 pools (24y)
            AcidCloudArDeco2 = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(60, 0, 255, 0, 0.5f),
                    Radius = 24,
                });
            // Slow Burn, rune 3: Main & 3 pools (12y)
            AcidCloudSbDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(60, 0, 255, 0, 0.5f),
                    Radius = 12,
                });

            // Grasp of the Dead

            // All Runes (15y, 8s)
            GraspOfTheDeadDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(100, 255, 255, 255, 1.5f, DashStyle.Dash),
                    Radius = 15,
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 8,
                    TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 255, 0, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 8,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(120, 0, 255, 255, 0),
                    Radius = 16,
                });

            // Wall of Death

            // No Rune | Communing with Spirits, rune 2 | Wall of Zombies, rune 3 (6s)
            WallOfDeathDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 6,
                    TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 255, 0, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 6,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(120, 0, 255, 255, 0),
                    Radius = 16,
                });
            // No Rune (18y, not 28y)
            WallOfDeathNrDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(80, 255, 255, 255, 0.5f, DashStyle.Dash),
                    Radius = 18,
                });
            // Surrounded by Death, rune 0 (15y?, 5s)
            WallOfDeathSbdDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(80, 255, 255, 255, 0.5f, DashStyle.Dash),
                    Radius = 15,
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 5,
                    TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 255, 0, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 5,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(120, 0, 255, 255, 0),
                    Radius = 16,
                });
            // Ring of Poison, rune 1 (20y?, 5s)
            WallOfDeathRopDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(100, 255, 255, 255, 0.8f, DashStyle.Dash),
                    Radius = 20,
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 5,
                    TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 255, 0, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 5,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(120, 0, 255, 255, 0),
                    Radius = 16,
                });
            // Communing with Spirits, rune 2 (20y?)
            WallOfDeathCwsDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(80, 255, 255, 255, 0.8f, DashStyle.Dash),
                    Radius = 20,
                });
            // Wall of Zombies, rune 3 (25y?, not 50y)
            WallOfDeathWozDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(80, 255, 255, 255, 0.5f, DashStyle.Dash),
                    Radius = 25,
                });
            // Fire Wall, rune 4 (28y?, 8s, not 40y)
            WallOfDeathFwDeco = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(80, 255, 255, 255, 0.5f, DashStyle.Dash),
                    Radius = 28,
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 8,
                    TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 255, 0, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 8,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(120, 0, 255, 255, 0),
                    Radius = 16,
                });
        }

        private Dictionary<ActorSnoEnum, Action<WorldLayer, IActor>> _snoMapping;
        private Dictionary<ActorSnoEnum, Action<WorldLayer, IActor>> _summonedByMeSnoMapping;

        private void InitMapping()
        {
            _summonedByMeSnoMapping = new Dictionary<ActorSnoEnum, Action<WorldLayer, IActor>>()
            {
                // Big Bad Voodoo
                {(ActorSnoEnum) 117574, BigBadVoodooPaint}, // No rune // Witchdoctor_BigBadVoodoo_fetish
                {(ActorSnoEnum) 182271, BigBadVoodooPaint}, // Slam Dance, rune 0 // Witchdoctor_BigBadVoodoo_fetish_red
                //{ (ActorSnoEnum)117574, BigBadVoodooPaint }, // Jungle Drums, rune 1, shared with No rune // Witchdoctor_BigBadVoodoo_fetish
                {(ActorSnoEnum) 182283, BigBadVoodooPaint}, // Ghost Trance, rune 2 // Witchdoctor_BigBadVoodoo_fetish_yellow
                {(ActorSnoEnum) 182276, BigBadVoodooPaint}, // Rain Dance, rune 3 // Witchdoctor_BigBadVoodoo_fetish_blue
                {(ActorSnoEnum) 182278, BigBadVoodooPaint}, // Boogie Man, rune 4 // Witchdoctor_BigBadVoodoo_fetish_purple

                // Spirit Walk
                {(ActorSnoEnum) 106584, SpiritWalkPaint}, // Witchdoctor_spiritWalk_Dummy actor
                {(ActorSnoEnum) 107705, SpiritWalkPaint}, // Witchdoctor_spiritWalk_Dummy_female actor
                // Severance, rune 0 | Jaunt, rune 1 | Umbral Shock, rune 2 | Honored Guest, rune 3 | Healing Journey, rune 4

                // Fetish Army
                {(ActorSnoEnum) 87189, FetishArmyPaint}, // No rune // Fetish_Melee_A	Fetish Army
                {(ActorSnoEnum) 89934, FetishArmyPaint}, // Fetish Ambush, rune 0 // Fetish_Skeleton_A
                //{ (ActorSnoEnum)87189, FetishArmyPaint }, // Legion of Daggers, rune 1, shared with No rune // Fetish_Melee_A	Fetish Army
                {(ActorSnoEnum) 409656, FetishArmyPaint}, // Tiki Torchers, rune 2 // Fetish_Melee_fire
                {(ActorSnoEnum) 90072, FetishArmyPaint}, // Tiki Torchers, rune 2 // Fetish_doubleStack_Shaman_A
                //{ (ActorSnoEnum)87189, FetishArmyPaint }, // Devoted Following, rune 3, shared with No rune // Fetish_Melee_A	Fetish Army
                {(ActorSnoEnum) 410238, FetishArmyPaint}, // Head Hunters, rune 4 // Fetish_Melee_poison
                {(ActorSnoEnum) 89933, FetishArmyPaint}, // Head Hunters, rune 4 // Fetish_Ranged_A	Fetish Army

                // Fetish Sycophants
                {
                    (ActorSnoEnum) 409590, (layer, actor) =>
                    {
                        // Fetish_Melee_Sycophants // both spawned by WD FS Passive & Belt of Transcendence
                        if (!Hud.Game.Me.Powers.BuffIsActive(318778, 0)
                        ) // without Zunimassa buff which makes them permanent
                        {
                            FetishSycophantsDecorator.Paint(layer, actor, actor.FloorCoordinate.Offset(0, 0, 1f), null);
                        }
                    }
                },
            };

            _snoMapping = new Dictionary<ActorSnoEnum, Action<WorldLayer, IActor>>()
            {
                // Piranhas
                { (ActorSnoEnum)348308, PiranhasPaint }, // No rune // x1_WD_piranha_proxy
                { (ActorSnoEnum)356987, PiranhasPaint }, // Bogadile, rune 0 // x1_WD_piranha_gator
                { (ActorSnoEnum)358653, PiranhasPaint }, // Frozen Piranhas, rune 4 // x1_WD_piranha_cold_proxy
                { (ActorSnoEnum)358018, // Zombie Piranhas, rune 1 // x1_WD_piranha_flying
                    (layer, actor) =>
                    {
                        PiranhasPaint(layer, actor);
                        PiranhasZombieDeco.Paint(layer, actor, actor.FloorCoordinate, null);
                    } },
                { (ActorSnoEnum)357846,  // Piranhado, rune 2 // x1_WD_piranha_tornado
                    (layer, actor) =>
                    {
                        PiranhasPaint(layer, actor);
                        PiranhasPiranhadoDeco.Paint(layer, actor, actor.FloorCoordinate, null);
                    } },
                { (ActorSnoEnum)357569, // Wave of Mutilation, rune 3 // x1_WD_piranha_wave_projectile
                    (layer, actor) => { PiranhasWomDeco.Paint(layer, actor, actor.FloorCoordinate, null); } },

                // Acid Cloud
                { (ActorSnoEnum)61398, AcidCloudPaint }, // No rune: WD_AcidCloud
                { (ActorSnoEnum)121919, AcidCloudPaint }, // Corpse Bomb, rune 0 // WD_AcidCloudRune_damage
                { (ActorSnoEnum)123587, AcidCloudPaint }, // Lob Blob Bomb, rune 2, main // WD_AcidCloudRune_slimes
                { (ActorSnoEnum)121595, AcidCloudPaint }, // Lob Blob Bomb, rune 2, blob // WD_acidCloudRune_slime
                { (ActorSnoEnum)121920, AcidCloudPaint }, // Slow Burn, rune 3, main // WD_AcidCloudRune_disease
                                                          // Kiss of Death, rune 4: frontal cone, no actor
                { (ActorSnoEnum)122281, // Acid Rain, rune 1, main // WD_AcidCloudRune_splash
                    (layer, actor) => { AcidCloudArDeco1.Paint(layer, actor, actor.FloorCoordinate, null); } },
                { (ActorSnoEnum)6509, // Acid Rain, rune 1, 3 pools // Wizard_AcidCloud_pool
                    (layer, actor) => { AcidCloudArDeco1.Paint(layer, actor, actor.FloorCoordinate, null); } },
                { (ActorSnoEnum)121904, // Slow Burn, rune 3, 3 pools // WD_AcidCloudRune_disease_pools
                    (layer, actor) => { AcidCloudArDeco1.Paint(layer, actor, actor.FloorCoordinate, null); } },

                // Horrify  --- (not working > only 2 runes give a buff) !!!
                { (ActorSnoEnum)6481, HorrifyPaint }, // WD Female actor
                { (ActorSnoEnum)6485, HorrifyPaint }, // WD Male actor

                // Grasp of the Dead
                { (ActorSnoEnum)69308, GraspOfTheDeadPaint }, // No rune // Witchdoctor_GraspoftheDead_proxyActor
                { (ActorSnoEnum)105953, GraspOfTheDeadPaint }, // Groping Eels, rune 0 // Witchdoctor_GraspoftheDead_crimsonRune
                // { (ActorSnoEnum)69308, GraspOfTheDeadPaint }, // Rain of Corpses, rune 1, shared with No rune
                { (ActorSnoEnum)105956, GraspOfTheDeadPaint }, // Unbreakable Grasp, rune 2 // Witchdoctor_GraspoftheDead_obsidianRune
                { (ActorSnoEnum)105957, GraspOfTheDeadPaint }, // Desperate Grasp, rune 3 // Witchdoctor_GraspoftheDead_goldenRune
                { (ActorSnoEnum)105958, GraspOfTheDeadPaint }, // Death is Life, rune 4 // Witchdoctor_GraspoftheDead_alabasterRune
                //{ (ActorSnoEnum)105955, GraspOfTheDeadPaint }, // Witchdoctor_GraspoftheDead_indigoRune (?? not found)

                // Wall of Death
                { (ActorSnoEnum)131202,  // No rune // WD_wallOfZombies_emitter
                    (layer, actor) =>
                    {
                        WallOfDeathDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                        WallOfDeathNrDeco.Paint(layer, actor, actor.FloorCoordinate, null);
                    } },
                { (ActorSnoEnum)182574, // Surrounded by Death, rune 0 // WD_wallOfZombies_emitter_slow
                    (layer, actor) =>
                    {
                        WallOfDeathSbdDeco.Paint(layer, actor, actor.FloorCoordinate, null);
                    } },
                { (ActorSnoEnum)439698, // Ring of Poison, rune 1 // WD_wallOfDeath_poison_emitter
                    (layer, actor) =>
                    {
                        WallOfDeathRopDeco.Paint(layer, actor, actor.FloorCoordinate, null);
                    } },
                { (ActorSnoEnum)441081, // Communing with Spirits, rune 2 // WD_wallOfDeath_spectral_emitter
                    (layer, actor) =>
                    {
                        WallOfDeathDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                        WallOfDeathCwsDeco.Paint(layer, actor, actor.FloorCoordinate, null);
                    } },
                { (ActorSnoEnum)135016, // Wall of Zombies, rune 3 // WD_wallOfZombies_emitter_wide
                    (layer, actor) =>
                    {
                        WallOfDeathDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                        WallOfDeathWozDeco.Paint(layer, actor, actor.FloorCoordinate, null);
                    } },
                { (ActorSnoEnum)440520, // Fire Wall, rune 4 // WD_wallOfDeath_fire_proxy
                    (layer, actor) =>
                    {
                        WallOfDeathFwDeco.Paint(layer, actor, actor.FloorCoordinate, null);
                    } },
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

        private void GraspOfTheDeadPaint(WorldLayer layer, IActor actor)
        {
            GraspOfTheDeadDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
        }

        private void HorrifyPaint(WorldLayer layer, IActor actor)
        {
            //if (Hud.Game.Me.Powers.BuffIsActive(67668, 0)) // with Horrify buff
            if (Hud.Game.Me.Powers.BuffIsActive(67668)) // with Horrify buff
            {
                var skill = Hud.Game.Me.Powers.UsedWitchDoctorPowers.Horrify;
                if (skill != null)
                {
                    if (skill.Rune == 1) // with Face of Death, rune 1
                    {
                        HorrifyFodDeco.Paint(layer, actor, actor.FloorCoordinate, null);
                    }
                    else // All runes EXCEPT Face of Death
                    {
                        HorrifyDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                    }
                }
            }
        }

        private void AcidCloudPaint(WorldLayer layer, IActor actor)
        {
            AcidCloudDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
        }

        private void PiranhasPaint(WorldLayer layer, IActor actor)
        {
            PiranhasDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
        }

        private void FetishArmyPaint(WorldLayer layer, IActor actor)
        {
            if (!Hud.Game.Me.Powers.BuffIsActive(318778, 0)) // without Zunimassa buff which makes them permanent
            {
                FetishArmyDecorator.Paint(layer, actor, actor.FloorCoordinate.Offset(0, 0, 1f), null);
            }
        }

        private void SpiritWalkPaint(WorldLayer layer, IActor actor)
        {
            var skill = Hud.Game.Me.Powers.UsedWitchDoctorPowers.SpiritWalk;
            if (skill != null)
            {
                if (skill.Rune == 1) // with Jaunt rune
                {
                    SpiritWalkJauntDeco.Paint(layer, actor, actor.FloorCoordinate, null);
                }
                else // Without Jaunt rune
                {
                    SpiritWalkDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                }
            }
        }

        private void BigBadVoodooPaint(WorldLayer layer, IActor actor)
        {
            var skill = Hud.Game.Me.Powers.UsedWitchDoctorPowers.BigBadVoodoo;
            if (skill != null)
            {
                if (skill.Rune == 1) // with Jungle Drums rune
                {
                    BigBadVoodooJdDeco.Paint(layer, actor, actor.FloorCoordinate, null);
                    BigBadVoodooGLDeco.Paint(layer, actor, actor.FloorCoordinate.Offset(0, 0, -2.7f), "B.B.V.");
                }
                else // Without Jungle Drums rune
                {
                    BigBadVoodooDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                    BigBadVoodooGLDeco.Paint(layer, actor, actor.FloorCoordinate.Offset(0, 0, -2.7f), "B.B.V.");
                }
            }
        }
    }
}