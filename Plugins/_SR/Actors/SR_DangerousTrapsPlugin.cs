
// adaptation of StormReaver v6 xml theme

namespace Turbo.Plugins._SR.Actors
{
    using SharpDX.Direct2D1;
    using System.Collections.Generic;
    using System.Linq;
    using Turbo.Plugins.Default;
    using Turbo.Plugins.User.Root; // for custom shapes

    public class SR_DangerousTrapsPlugin : BasePlugin, IInGameWorldPainter
    {
        public Dictionary<ActorSnoEnum, WorldDecoratorCollection> SnoMapping { get; set; }
        public Dictionary<ActorSnoEnum, WorldDecoratorCollection> SnoMapping2 { get; set; }

        ////private GroundLabelDecorator debugDecorator;

        public SR_DangerousTrapsPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            SnoMapping = new Dictionary<ActorSnoEnum, WorldDecoratorCollection>();
            SnoMapping2 = new Dictionary<ActorSnoEnum, WorldDecoratorCollection>();


		/* **********************************
			    DANGEROUS TRAPS & DEVICES
		************************************* */


            /* ----------------
                    FIRE
            ------------------- */


			/* mark BIG FIRE GRATE (A1)
            108012	a1dun_leor_BigFireGrate	Deadly Fire Grate */
            SnoMapping.Add((ActorSnoEnum)108012, new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(220, 255, 0, 0, 0),
                    Radius = 4.0f,
                    ShapePainter = new CircleShapePainter(Hud),
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 333),
                },
				new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("verdana", 4, 220, 255, 0, 0, true, false, false),
                },
				new GroundShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(220, 255, 10, 10, 1.5f),
                    Radius = 25,
                    ShapePainter = WorldStarShapePainter.NewCross(Hud),
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("verdana", 7, 255, 255, 0, 0, true, false, false),
                }));


            /* mark DEMONIC FORGE (A3)
            174900	a3_Battlefield_demonic_forge	Demonic Forge
            185391	a3_crater_st_demonic_forge	Demonic Forge */
				/* var Demonic_Forge = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(180, 255, 0, 0, 0),
                    Radius = 4.0f,
                    ShapePainter = new CircleShapePainter(Hud),
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 333),
                },
				new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("verdana", 3, 180, 255, 0, 0, true, false, false),
                },
                new GroundCircleDecorator(Hud)
                {
                    Radius = 42, //45 in xml
                    Brush = Hud.Render.CreateBrush(140, 255, 10, 10, 1)
                },

				// add spinning X shape
				new GroundShapeDecorator(Hud)
                {
                    Enabled = true,
                    Brush = Hud.Render.CreateBrush(80, 255, 0, 0, 1f), //(140, 255, 10, 10, 1)
                    Radius = 42,
                    ShapePainter = WorldStarShapePainter.NewCross(Hud),
					RotationTransformator = new CircularRotationTransformator(Hud, 20), //rotation speed
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("verdana", 6, 200, 255, 0, 0, true, false, false),
                });
            SnoMapping.Add((ActorSnoEnum)174900, Demonic_Forge);
            SnoMapping.Add((ActorSnoEnum)185391, Demonic_Forge); */


            /* mark DEMON MINE (A3):
            118596	A3_Battlefield_DemonMine_C	Demon Mine
            150825	A3_Battlefield_DemonMine_C_Snow	Demon Mine */
            var Demon_Mine = new WorldDecoratorCollection(
                /* new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(180, 255, 0, 0, 0),
                    Radius = 4.0f,
                    ShapePainter = new CircleShapePainter(Hud),
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 333),
                }, */
				new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("verdana", 4, 180, 255, 0, 0, true, false, false),
                },
                new GroundCircleDecorator(Hud)
                {
                    Radius = 10,
                    Brush = Hud.Render.CreateBrush(100, 255, 10, 10, 1)
                },
				// new GroundShapeDecorator(Hud)
                // {
                    // Brush = Hud.Render.CreateBrush(130, 255, 10, 10, 1),
                    // Radius = 10,
                    // ShapePainter = WorldStarShapePainter.NewCross(Hud),
                // },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("verdana", 6, 200, 255, 0, 0, true, false, false),
                });
            SnoMapping2.Add((ActorSnoEnum)118596, Demon_Mine);
            SnoMapping2.Add((ActorSnoEnum)150825, Demon_Mine);


			/* mark FURNACE WALL (A5)
            355365	x1_Abattoir_furnaceWall	Furnace */
            SnoMapping.Add((ActorSnoEnum)355365, new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(180, 255, 0, 0, 0),
                    Radius = 4.0f,
                    ShapePainter = new CircleShapePainter(Hud),
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 333),
                },
				new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("verdana", 4, 180, 255, 0, 0, true, false, false),
                },
				new GroundShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(150, 255, 10, 10, 1.5f),
                    Radius = 25,
                    ShapePainter = WorldStarShapePainter.NewCross(Hud),
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("verdana", 7, 255, 255, 0, 0, true, false, false),
                }));


			/* mark FURNACE SPINNER (A5)
            353821	x1_Abattoir_furnaceSpinner	Furnace Vent */
            SnoMapping.Add((ActorSnoEnum)353821, new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(180, 255, 0, 0, 0),
                    Radius = 4.0f,
                    ShapePainter = new CircleShapePainter(Hud),
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 333),
                },
				new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("verdana", 4, 180, 255, 0, 0, true, false, false),
                },
				new GroundShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(150, 255, 10, 10, 1.5f),
                    Radius = 32,
                    ShapePainter = WorldStarShapePainter.NewCross(Hud),
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("verdana", 7, 255, 255, 0, 0, true, false, false),
                }));


            /* ----------------
                    KHAZRA
            ------------------- */


			/* mark KHAZRA DROPPING LOG TRAP (A1)
            78422	a2dun_Cave_Goatmen_Dropping_Log_Trap Trap */
            SnoMapping2.Add((ActorSnoEnum)78422, new WorldDecoratorCollection(
                /* new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(180, 255, 0, 0, 0),
                    Radius = 5.0f,
                    ShapePainter = new CircleShapePainter(Hud),
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 333),
                }, */
				new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("verdana", 6, 180, 255, 0, 0, true, false, false),
                },
				new GroundShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(120, 255, 10, 10, 2.5f),
                    Radius = 8,
                    ShapePainter = WorldStarShapePainter.NewCross(Hud),
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(200, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("verdana", 5, 200, 255, 0, 0, true, false, false),
                }));


			/* mark KHAZRA SPRING TRAP (A1)
            77690	trOut_TristramFields_Punji_Trap	Spring Trap	DestroySelfWhenNear */
            SnoMapping2.Add((ActorSnoEnum)77690, new WorldDecoratorCollection(
                /* new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(180, 255, 0, 0, 0),
                    Radius = 5.0f,
                    ShapePainter = new CircleShapePainter(Hud),
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 333),
                }, */
				new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("verdana", 6, 180, 255, 0, 0, true, false, false),
                },
				new GroundShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(120, 255, 10, 10, 2.0f),
                    Radius = 7,
                    ShapePainter = WorldStarShapePainter.NewCross(Hud),
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(200, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("verdana", 5, 200, 255, 0, 0, true, false, false),
                }));


            /* ----------------
                    OASIS
            ------------------- */


			/* mark OASIS POISON PLANT
            59401	caOut_Oasis_Attack_Plant	Moonseed */
            SnoMapping2.Add((ActorSnoEnum)59401, new WorldDecoratorCollection(
                /* new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(180, 255, 0, 0, 0),
                    Radius = 4.0f,
                    ShapePainter = new CircleShapePainter(Hud),
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 333),
                }, */
				new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("verdana", 4.5f, 140, 255, 0, 0, true, false, false),
                },
                new GroundCircleDecorator(Hud)
                {
                    Radius = 18,
                    Brush = Hud.Render.CreateBrush(50, 255, 10, 10, 0.3f)
                },
				/* new GroundShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(50, 255, 10, 10, 0.3f),
                    Radius = 18,
                    ShapePainter = WorldStarShapePainter.NewCross(Hud),
                }, */
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(180, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("verdana", 5.5f, 180, 255, 0, 0, true, false, false),
                }));


            /* ----------------
                BOG / MARSH
            ------------------- */


			/* mark BOG FLOOR TRAP
             237458	x1_Bog_Knockback_Trap_C_Hidden (??)
             239487	x1_Bog_Knockback_Trap_D	Bogan Trap */
            var Bog_Floor_Trap = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(180, 255, 0, 0, 0),
                    Radius = 4.0f,
                    ShapePainter = new CircleShapePainter(Hud),
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 333),
                },
				new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("verdana", 3, 180, 255, 0, 0, true, false, false),
                },
				new GroundShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(150, 255, 10, 10, 1.5f),
                    Radius = 25,
                    ShapePainter = WorldStarShapePainter.NewCross(Hud),
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("verdana", 5, 255, 255, 0, 0, true, false, false),
                });
            SnoMapping.Add((ActorSnoEnum)237458, Bog_Floor_Trap);
            SnoMapping.Add((ActorSnoEnum)239487, Bog_Floor_Trap);


			/* mark Bogan Trapper BEAR TRAP
             237062	x1_Bog_Bear_Trap
             284752	x1_Bog_Bear_Trap_projectile_lobbed */
            var Bog_Bear_Trap = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 3,
                    Brush = Hud.Render.CreateBrush(150, 255, 10, 10, 1.5f)
                },
				new GroundShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(150, 255, 10, 10, 1.5f),
                    Radius = 3,
                    ShapePainter = WorldStarShapePainter.NewCross(Hud),
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("verdana", 3, 255, 255, 0, 0, true, false, false),
                });
            SnoMapping.Add((ActorSnoEnum)237062, Bog_Bear_Trap);
            SnoMapping.Add((ActorSnoEnum)284752, Bog_Bear_Trap);


            /* ----------------
                BLOOD SPRING
            ------------------- */


			/* mark Bog/Marsh BLOOD SPRING  (SMALL)
            332924	x1_Bog_bloodSpring_small */
            SnoMapping2.Add((ActorSnoEnum)332924, new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(80, 255, 0, 0, 1.5f),
                    Radius = 6,
                    ShapePainter = new CircleShapePainter(Hud),
                    //RadiusTransformator = new StandardPingRadiusTransformator(Hud, 999),
                },
				/* new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("verdana", 3, 140, 255, 0, 0, true, false, false),
                }, */
                new GroundCircleDecorator(Hud)
                {
                    Radius = 6,
                    Brush = Hud.Render.CreateBrush(120, 255, 0, 0, 1)
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("verdana", 5, 255, 255, 0, 0, true, false, false),
                }));

			/* mark Bog/Marsh BLOOD SPRING  (MEDIUM)
            332922	x1_Bog_bloodSpring_medium */
            SnoMapping2.Add((ActorSnoEnum)332922, new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(80, 255, 0, 0, 1.5f),
                    Radius = 11,
                    ShapePainter = new CircleShapePainter(Hud),
                    //RadiusTransformator = new StandardPingRadiusTransformator(Hud, 999),
                },
				/* new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("verdana", 3, 140, 255, 0, 0, true, false, false),
                }, */
                new GroundCircleDecorator(Hud)
                {
                    Radius = 11,
                    Brush = Hud.Render.CreateBrush(120, 255, 0, 0, 1)
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("verdana", 5, 255, 255, 0, 0, true, false, false),
                }));

			/* mark Bog/Marsh BLOOD SPRING  (LARGE)
            332923	x1_Bog_bloodSpring_large */
            SnoMapping2.Add((ActorSnoEnum)332923, new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(80, 255, 0, 0, 1.5f),
                    Radius = 19,
                    ShapePainter = new CircleShapePainter(Hud),
                    //RadiusTransformator = new StandardPingRadiusTransformator(Hud, 999),
                },
				/* new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("verdana", 3, 140, 255, 0, 0, true, false, false),
                }, */
                new GroundCircleDecorator(Hud)
                {
                    Radius = 19,
                    Brush = Hud.Render.CreateBrush(120, 255, 0, 0, 1)
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("verdana", 5, 255, 255, 0, 0, true, false, false),
                }));

        }


        public void PaintWorld(WorldLayer layer)
        {

            var dangerousTraps = Hud.Game.Actors.Where(a => SnoMapping.ContainsKey(a.SnoActor.Sno));
            foreach (var dTrap in dangerousTraps)
            {
				// Decorator.ToggleDecorators<GroundLabelDecorator>(actor.IsOnScreen); // show GroundLabel if off-screen
                SnoMapping[dTrap.SnoActor.Sno].Paint(layer, dTrap, dTrap.FloorCoordinate, "!! CAUTION !!");
            }

            var dangerousTraps2 = Hud.Game.Actors.Where(a => SnoMapping2.ContainsKey(a.SnoActor.Sno));
            foreach (var dTrap2 in dangerousTraps2)
            {
				// Decorator.ToggleDecorators<GroundLabelDecorator>(!actor.IsOnScreen); // hide GroundLabel if off-screen
                SnoMapping2[dTrap2.SnoActor.Sno].Paint(layer, dTrap2, dTrap2.FloorCoordinate, "?!");
            }

            //foreach (var actor in Hud.Game.Actors)
			/* {
               debugDecorator.Paint(actor, actor.FloorCoordinate, actor.SnoActor.Sno.ToString());
            } */

        }


    }
}