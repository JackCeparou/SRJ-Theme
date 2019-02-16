
// adaptation of StormReaver v6 xml theme

namespace Turbo.Plugins._SR.Monsters
{
    using SharpDX.Direct2D1;
    using System.Collections.Generic;
    using System.Linq;
    using Turbo.Plugins.Default;

    public class SR_MonsterSkillsPlugin : BasePlugin, IInGameWorldPainter
    {
        public Dictionary<ActorSnoEnum, WorldDecoratorCollection> SnoMapping { get; set; }

        ////private GroundLabelDecorator debugDecorator;

        public SR_MonsterSkillsPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            SnoMapping = new Dictionary<ActorSnoEnum, WorldDecoratorCollection>();


		/* **********************************
				REGULAR MONSTER  Skills
		************************************* */


            /* add ground circle to giant Brute leap (A5)
            289827	x1_westmarchBrute_leap_telegraph */
            SnoMapping.Add((ActorSnoEnum)289827, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 15,
                    Brush = Hud.Render.CreateBrush(220, 255, 50, 50, 3, DashStyle.Dash)
                }));

            /* add ground circle to WoodWraith Spore Cloud Emitter (A1)
            6578	WoodWraith_sporeCloud_emitter
            4176	Generic_Proxy	Generic_Proxy */
            var WoodWraith_Spore_Emitter = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 5,
                    Brush = Hud.Render.CreateBrush(160, 255, 0, 255, 2, DashStyle.Dash)
                });
            SnoMapping.Add((ActorSnoEnum)6578, WoodWraith_Spore_Emitter);
            // SnoMapping.Add((ActorSnoEnum)4176, WoodWraith_Spore_Emitter);

			/* add ground circle to WoodWraith Spore (A1)
            5482	Spore */
            SnoMapping.Add((ActorSnoEnum)5482, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 5,
                    Brush = Hud.Render.CreateBrush(160, 255, 50, 100, 2, DashStyle.Dash)
                }));

			/* add ground circle to Morlu Incinerator Meteor: Pending, Impact, AOE DOT Fire (including RG Ember)
            159369	MorluSpellcaster_Meteor_Pending
            159368	MorluSpellcaster_Meteor_Impact
            159367	MorluSpellcaster_Meteor_afterBurn */
            var Morlu_Incinerator_Meteor = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 20,
                    Brush = Hud.Render.CreateBrush(60, 255, 255, 255, 3, DashStyle.Dash)
                });
            SnoMapping.Add((ActorSnoEnum)159369, Morlu_Incinerator_Meteor);
            SnoMapping.Add((ActorSnoEnum)159368, Morlu_Incinerator_Meteor);
            SnoMapping.Add((ActorSnoEnum)159367, Morlu_Incinerator_Meteor);

			/* add ground circle to Exploding Maggots
            254175	x1_bogBlight_Maggot_A	Maggot */
            SnoMapping.Add((ActorSnoEnum)254175, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 3,
                    Brush = Hud.Render.CreateBrush(120, 255, 255, 0, 2, DashStyle.Dash)
                }));


			/* add ground circle to trackable Projectiles #1   (0.5y radius)
            5212	SandWasp_Projectile (A2)
            312942	x1_skeletonArcher_arrow_cold (A5)
            337030	x1_BogFamily_ranged_quill_proj
            323212	x1_squigglet_projectile	(A5 Barbed Lurker, green proj)
			430430	p4_ice_porcupine_nova_projectile (A4 Ice Porcupine spike)
			187359	Generic_Proxy_normal p4_Ice_Porcupine_Nova (A4 Ice Porcupine spike nova)

			*/
            var Trackable_Projectiles1 = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 0.5f,
                    Brush = Hud.Render.CreateBrush(220, 255, 255, 0, 0)
                });
            SnoMapping.Add((ActorSnoEnum)5212, Trackable_Projectiles1);
            SnoMapping.Add((ActorSnoEnum)312942, Trackable_Projectiles1);
            SnoMapping.Add((ActorSnoEnum)337030, Trackable_Projectiles1);
            SnoMapping.Add((ActorSnoEnum)323212, Trackable_Projectiles1);
            SnoMapping.Add((ActorSnoEnum)430430, Trackable_Projectiles1);
            //SnoMapping.Add((ActorSnoEnum)187359, Trackable_Projectiles1); //conflicts with other SNOs like Wiz Electrocute

			/* add ground circle to trackable Projectiles #2   (1y radius)
            353256	x1_bloodGolem_shaman_bloodBall (A5 Flesh Shaman, fast moving proj)
            349564	x1_MoleMutant_ranged_projectile	(A5 Flesh Hurler, fast moving proj)
			*/
            var Trackable_Projectiles2 = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 1,
                    Brush = Hud.Render.CreateBrush(220, 255, 255, 0, 0)
                });
            SnoMapping.Add((ActorSnoEnum)353256, Trackable_Projectiles2);
            SnoMapping.Add((ActorSnoEnum)349564, Trackable_Projectiles2);


			/* add ground circle to trackable Projectiles #3   (2y radius)
			455408	reflectsDamage_projectile (// to include in Affix file !!!)
			*/
            var Trackable_Projectiles3 = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 1,
                    Brush = Hud.Render.CreateBrush(220, 255, 255, 0, 0)
                });
            SnoMapping.Add((ActorSnoEnum)455408, Trackable_Projectiles3);


		/* **********************************
				IRREGULAR MONSTER  Skills
		************************************* */


            /* add ground circle to Elite Mortar projectiles on landing (untrackable in-flight!)
            365810	Grenadier_Proj_mortar_inpact */
            SnoMapping.Add((ActorSnoEnum)365810, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 5,
                    Brush = Hud.Render.CreateBrush(160, 255, 50, 50, 2, DashStyle.Dash)
                }));

            /* add ground circle (off-center!) to Smoldering Construct Fire Pool (A2)
            432	skeletonMage_fire_groundPool */
            SnoMapping.Add((ActorSnoEnum)432, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 9,
                    Brush = Hud.Render.CreateBrush(160, 255, 10, 10, 2.5f, DashStyle.Dash)
                }));


		/* **********************************
				||	EXPERIMENTAL  	||
		************************************* */


            /* add ground circle to EXPERIMENTAL skills
            374883	x1_Pand_Cellar_FallingRock_Molten	Burning Debris
            374882	x1_Pand_Cellar_FallingRock_Spawner	Falling Debris */

            var Experimental_Skills = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 10,
                    Brush = Hud.Render.CreateBrush(200, 255, 0, 255, 4, DashStyle.Dash)
                });
            SnoMapping.Add((ActorSnoEnum)374883, Experimental_Skills);
            SnoMapping.Add((ActorSnoEnum)374882, Experimental_Skills);


		/* **********************************
				||	CANNOT TRACK  	||
		************************************* */


            /* NOTES:

            For the following skills, only the source can be tracked; the projectile itself is just an animation:

            ????	Exarch AOE lightning field (has no data)
            3901	D3Arrow (Skeleton Archer Act1)
            5392	SkeletonSummoner_projectile (Tomb Guardian Act1)
            4103	FallenShaman_fireball_projectile (Fallen Shaman/Prophet Act3)
            4101	fallenShaman_fireBall_impact (can track impact spot only)
            160154	demonFlyer_fireball_projectile (Winged Molok, Demonic Hellflyer Act3)
            160401	demonFlyer_fireball_impact (can track impact spot only)
            179226	MastaBlasta_Rider_projectile (Armaddon Act4)
            5370	skeletonMage_Cold_projectile (Construct Act2)
            5374	skeletonMage_Fire_projectile (Construct Act2)
            5385	skeletonMage_Poison_projectile (Construct Act2)
            4981	QuillDemonHorn_Projectile (Icy Quillback Act 3)
            158698	GoatMutant_Ranged_Spear (Goat Spearman)
            6040	TriuneSummoner_fireball_projectile (A1,A2 Dark Summoner)

            */

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