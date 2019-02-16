
using System;
using Turbo.Plugins.Default;
using SharpDX.DirectInput;
using System.Windows.Forms;
using Turbo.Plugins.Jack.TextToSpeech;
using Turbo.Plugins.Jack.Items;
// using SharpDX;
// using SharpDX.Direct2D1;
// using System.Collections.Generic;
// using System.Globalization;
// using System.Linq;


namespace Turbo.Plugins._SR.Root
{

    public class SR_CustomizerPlugin : BasePlugin, ICustomizer
    {

        public SR_CustomizerPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

			// load order
			Order = 90000; // higher makes plugin load last to override other plugins, giving this precedence.


			// Change TH volume.

			// TH volume is now independent of the game.

			// 3 VolumeModes: AutoMaster, AutoMasterAndEffects, Constant.
			// AutoMaster volume: (IngameMasterVolume / 100) * VolumeMultiplier
			// AutoMasterAndEffects volume: (IngameMasterVolume / 100) * (IngameEffectsVolume / 100) * VolumeMultiplier
			// Constant volume: 0 = no sound; 100 = max sound.

			// used when Mode is AutoMaster or AutoMasterAndEffects:
			// Hud.Sound.VolumeMultiplier = 25.0;	// default 1.0

			// used when Mode is Constant:
			Hud.Sound.VolumeMode = VolumeMode.Constant;
			Hud.Sound.ConstantVolume = 100;	// default is 100.
        }


        // "Customize" methods are automatically executed after every plugin is loaded.
        // So these methods can use Hud.GetPlugin<class> to access the plugin instances' public properties (like decorators, Enabled flag, parameters, etc)
        // Make sure you test the return value against null!

        public void Customize()
        {


			// ============================================
			// 				|| MY EDITS ||
			// ============================================




			// ############################################
			// 	Customize Theme |		DEFAULT
			// ############################################


            // INVENTORY //


            Hud.RunOnPlugin<InventoryAndStashPlugin>(plugin =>
            {
                // disable  Sell_darkening / gray slots
                plugin.NotGoodDisplayEnabled = false;

				// disable  Keep_corner / green corner  (using custom "pickit_sc_70.ini" to show CUBED status)
                plugin.LooksGoodDisplayEnabled = false;

				// enable  Force_sell_corner / red corner  (using custom "pickit_sc_70.ini" to show CUBED status)
                plugin.DefinitelyBadDisplayEnabled = true;

				// enable  can-be-cubed rotating icon: rotating=cubable, static=already cubed
                plugin.CanCubedEnabled = true;


				//// copied from JACK config / edited

                //// ancient rank font
                plugin.AncientRankFont = Hud.Render.CreateFont("verdana", 9.0f, 255, 227, 153, 25, true, false, 255, 0, 0, 0, true);
                plugin.PrimalRankFont = Hud.Render.CreateFont("verdana", 9.0f, 255, 255, 64, 64, true, false, 220, 0, 0, 0, true);

				//// gem rank font
                plugin.SocketedLegendaryGemRankFont = Hud.Render.CreateFont("verdana", 6.5f, 255, 240, 240, 64, true, false, 200, 0, 0, 0, true);

                //// change darken brush to a lighter one
                //// inventoryAndStashPlugin.DarkenBrush = Hud.Render.CreateBrush(120, 38, 38, 38, 0);
            });

			// ---------------------------------------------


            // MAP REVEAL //


			Hud.SceneReveal.MinimapEnabled = true;		// bool
			Hud.SceneReveal.MinimapOpacity = 120;		// float, 13

			Hud.SceneReveal.MapEnabled = true;			// bool
			Hud.SceneReveal.MapOpacity = 150;			// float, 25

			Hud.SceneReveal.MinimapClip = true;			// bool, disable minimap clipping (small area right of minimap will always clip regardless of this value)
			Hud.SceneReveal.DisplaySceneBorder = false;	// bool


			// ---------------------------------------------


			// BUFFS //


			// disable	buff list @ player top
			// Hud.TogglePlugin<PlayerTopBuffListPlugin>(false);

			// disable	buff list @ player bottom
			// Hud.TogglePlugin<PlayerBottomBuffListPlugin>(false);

			// disable	Cheat Death buff icons @ skill bar
			// Hud.TogglePlugin<CheatDeathBuffFeederPlugin>(false);

			// disable	Cheat Death buff icons @ right side of mini map.
			// Hud.TogglePlugin<MiniMapRightBuffListPlugin>(false);

			// disable	Shrine and Pylon buff icons @ left side of mini map.
			// Hud.TogglePlugin<MiniMapLeftBuffListPlugin>(false);

			// disable	CoE buff bar
			// Hud.TogglePlugin<ConventionOfElementsBuffListPlugin>(false);

			// ---------------------------------------------


			// LABELS //


			// disable  Attributes labels above skills
			// Hud.TogglePlugin<AttributeLabelListPlugin>(false);

			// disable  DPS labels and damage hover info and CD overlay over skills
			// Hud.TogglePlugin<OriginalSkillBarPlugin>(false);

			// disable  DPS labels and damage hover info over skills (keep CD overlay)
			// Hud.RunOnPlugin<OriginalSkillBarPlugin>(plugin => plugin.SkillPainter.EnableSkillDpsBar = false);

            // disable	Multiplayer label for DPS dealt to monsters @ player portrait
			// Hud.TogglePlugin<PortraitBottomStatsPlugin>(false);

			// disable	Damage bonus bar deco (elemental bar under hp globe)
			// Hud.TogglePlugin<DamageBonusPlugin>(false);

			// customize  Damage bonus bar deco
			Hud.RunOnPlugin<DamageBonusPlugin>(plugin =>
			{
                plugin.HolyDecorator.BackgroundBrush = Hud.Render.CreateBrush(180, 190, 100, 0, 0); // (180, 190, 117, 0, 0)
                plugin.EliteDecorator.BackgroundBrush = Hud.Render.CreateBrush(180, 200, 80, 200, 0); // (180, 255, 148, 20, 0)
                plugin.ShowInTown = true; // default = true
                plugin.ShowOutOfTown = true; // default = false
			});

			// ---------------------------------------------


			// CLICKABLES //


			// disable	Weapon racks decos
			// Hud.TogglePlugin<RackPlugin>(false);

			// disable	Dead bodies decos
			// Hud.TogglePlugin<DeadBodyPlugin>(false);

			// disable	All clickable gizmos decos
			// Hud.TogglePlugin<ClickableChestGizmoPlugin>(false);

			// ---------------------------------------------


			// MONSTERS //


			// disable	All normal monsters decos
			// Hud.TogglePlugin<StandardMonsterPlugin>(false);

			// disable	All dangerous monsters decos
			// Hud.TogglePlugin<DangerousMonsterPlugin>(false);

			// disable  All elite skill decos
            // Hud.TogglePlugin<EliteMonsterSkillPlugin>(false);

			// disable  All elite affix labels
            // Hud.TogglePlugin<EliteMonsterAffixPlugin>(false);

            // disable  Arcane affix label
            // Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.Arcane);

            // change  Desecrator elite affix text
            // Hud.GetPlugin<EliteMonsterAffixPlugin>().CustomAffixNames.Add(MonsterAffix.Desecrator, "DES");

			// customize  SHIELDING affix // add as custom, remove as weak
			Hud.RunOnPlugin<EliteMonsterAffixPlugin>(plugin =>
            {
                plugin.AffixDecorators[MonsterAffix.Shielding] = new WorldDecoratorCollection(
                    new GroundLabelDecorator(Hud)
                    {
                        BorderBrush = Hud.Render.CreateBrush(128, 0, 0, 0, 2),
                        TextFont = Hud.Render.CreateFont("tahoma", 5f, 255, 0, 255, 0, true, false, false),
                        BackgroundBrush = Hud.Render.CreateBrush(255, 120, 0, 120, 0),
                    });
            });

			// ---------------------------------------------


			// MISC //


			// enable  Multiplayer Exp Range (Strength in Numbers)
            Hud.TogglePlugin<MultiplayerExperienceRangePlugin>(true);

			// disable	Exp-Paragon stats label @ top
			Hud.TogglePlugin<TopExperienceStatistics>(false);

			// disable  Paragon Screen capture
			Hud.TogglePlugin<ParagonCapturePlugin>(false);

			// disable  Notify At Rift Percentage alert (using custom one: disabled atm)
			Hud.TogglePlugin<NotifyAtRiftPercentagePlugin>(false);

			// customize  Near Monster Progression Range
			Hud.RunOnPlugin<RiftPlugin>(plugin => plugin.NearMonsterProgressionRange = 50);


			// disable	Latency numbers @ Resource globe
			// Hud.TogglePlugin<NetworkLatencyPlugin>(false);

            // disable	Game clock and server IP numbers @ top of minimap
            // Hud.TogglePlugin<GameInfoPlugin>(false);

            // disable	Pickup range transparent circle around player
            // Hud.TogglePlugin<PickupRangePlugin>(false);

            // disable	Skill ranges in town
            // Hud.TogglePlugin<SkillRangeHelperPlugin>(false);

			// ---------------------------------------------


			// SPEECH //


			// customize  TTS ItemsPlugin speech (DEFAULT)

			Hud.RunOnPlugin<ItemsPlugin>(plugin =>
            {
	            plugin.Enabled = true;

				plugin.EnableSpeakLegendary = false;
				plugin.EnableSpeakAncient = false;
				plugin.EnableSpeakPrimal = false;
				plugin.EnableSpeakSet = false;
				plugin.EnableSpeakAncientSet = false;
				plugin.EnableSpeakPrimalSet = false;

				plugin.EnableCustomSpeak = false;

				// Ex: 437485	x1_Diamond_10	Flawless Royal Diamond
				// plugin.CustomSpeakTable.Add(Hud.Sno.SnoItems.x1_Diamond_09, "Royal Daa daa daa");


				// Ramaladni's Gift:
				// 1844495708	Consumable_Add_Sockets_1
				// 403611		Consumable_Add_Sockets
				// 405649		Consumable_Add_Sockets_flippy

				// Ramaladni's Gift
				// plugin.CustomSpeakTable.Add(Hud.Sno.SnoItems.Consumable_Add_Sockets, "OMAGAD a gift!");
                // plugin.CustomSpeakTable.Add(Hud.Sno.SnoItems.Consumable_Add_Sockets_1, "OMAGAD giftsss!");
				// plugin.CustomSpeakTable.Add(Hud.Inventory.GetSnoItem(1844495708), "da da da nuclear!");
				// plugin.CustomSpeakTable.Add(Hud.Inventory.GetSnoItem(403611), "nuclear launch detected!");
				// plugin.CustomSpeakTable.Add(Hud.Inventory.GetSnoItem(405649), "nuclear launch detected!");
            });




			// ############################################
			//	Customize Plugins |		JACK Ceparou
			// ############################################


			// DoorsPlugin
			Hud.RunOnPlugin<Jack.Actors.DoorsPlugin>(plugin =>
			{
				// disable debug
				plugin.DebugEnabled = true;
				// change TOGGLE key to "Ctrl+K". Parameters: (enabled, Key value, Ctrl, Alt, Shift)
				plugin.ToggleKeyEvent = Hud.Input.CreateKeyEvent(true, Key.K, true, false, false);
			});

			// ---------------------------------------------


			// DisplayActorsPlugin
			Hud.RunOnPlugin<Jack.DevTool.DisplayActorsPlugin>(plugin =>
			{
				// change TOGGLE key to "Numpad Multiply" (*)
				plugin.HotKey = Keys.Multiply;
			});

			// ---------------------------------------------


			// WitchDoctor Pets
			Hud.RunOnPlugin<Jack.Actors.WitchDoctorPetsPlugin>(plugin =>
			{
				// disable
				plugin.GargantuansDecorators.ToggleDecorators<GroundShapeDecorator>(false);
				plugin.ZombiesDogsDecorators.ToggleDecorators<GroundShapeDecorator>(false);
			});

			// Necromance rPets
			Hud.RunOnPlugin<Jack.Actors.NecromancerPetsPlugin>(plugin =>
			{
				// disable
				plugin.SkeletonWarriorsDecorators.ToggleDecorators<GroundShapeDecorator>(false);
				plugin.SkeletonMagesDecorators.ToggleDecorators<GroundShapeDecorator>(false);
				plugin.SkeletonArchersDecorators.ToggleDecorators<GroundShapeDecorator>(false);

				// plugin.SkeletonArchersDecorators.ToggleDecorators<GroundShapeDecorator>(false);
				// plugin.var.warriorBrush = Hud.Render.CreateBrush(150, 0, 255, 0, 2); //(222, 0, 255, 0, 2)
			});

			// ---------------------------------------------


			// customize  Rift Info
			Hud.RunOnPlugin<Jack.RiftInfoPlugin>(plugin => plugin.ShowGreaterRiftTimer = true); // main timer
			Hud.RunOnPlugin<Jack.RiftInfoPlugin>(plugin => plugin.GreaterRiftCountdown = false); // down or up
			Hud.RunOnPlugin<Jack.RiftInfoPlugin>(plugin => plugin.ShowClosingTimer = true); // countdown from 30 when closing
			Hud.RunOnPlugin<Jack.RiftInfoPlugin>(plugin => plugin.ShowGreaterRiftCompletedTimer = true); // timer after boss is dead
			Hud.RunOnPlugin<Jack.RiftInfoPlugin>(plugin => plugin.CompletionDisplayLimit = 101); // disabled, default 90% box completion

			// ---------------------------------------------


			// add  TTS to GoblinPlugin (DEFAULT)
			Hud.GetPlugin<GoblinPlugin>().EnableSpeak = false;


			//// copied from  SoundAlertCustomizer (JACK)

			//// enable TTS GoblinPlugin (DEFAULT)
            Hud.RunOnPlugin<GoblinPlugin>(plugin =>
            {
                plugin.EnableSpeak = true; //just in case the default change
				// plugin.PortalDecorator.Add(SoundAlertFactory.Create<IActor>(Hud, (actor) => "portal"));
            });


			// NOTE:
            /* Hud.RunOnPlugin<GoblinPlugin>(plugin =>
            {
                plugin.EnableSpeak = false; //just in case the default change

				// use this for simple custom sound
				TextFunc = (actor) => "YATAAAA",

				// use this for complex custom sound
				TextFunc = (actor) => "YATAAAA " + actor.FullNameLocalized

				// use this for complex custom sound
				TextFunc = (actor) => {
				  var prefix = "nuclear launch imminent ";
				  return prefix + actor.FullNameLocalized;
				}",

                //plugin.PortalDecorator.Add(SoundAlertFactory.Create<IActor>(Hud, (actor) => "portal"));

            }); */


			//// TTS Goblin Pack
            Hud.RunOnPlugin<Jack.Monsters.GoblinSoundAlertPlugin>(plugin =>
            {
                plugin.GoblinPack.TextFunc = (monster) => "Goblin Pack";

                // plugin.DefaultGoblin = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
                // plugin.MalevolentTormentor = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
                // plugin.BloodThief = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
                // plugin.OdiousCollector = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
                // plugin.GemHoarder = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
                // plugin.Gelatinous = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
                // plugin.GildedBaron = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
                // plugin.InsufferableMiscreant = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
                // plugin.RainbowGoblin = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
                // plugin.MenageristGoblin = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
                // plugin.TreasureFiendGoblin = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
            });

			// ---------------------------------------------


			//// TTS bosses
			Hud.RunOnPlugin<StandardMonsterPlugin>(plugin =>
            {
                // plugin.BossDecorator.Add(SoundAlertFactory.Create<IActor>(Hud));
            });

			//// TTS shrines (not working)
            /* Hud.RunOnPlugin<ShrinePlugin>(plugin =>
            {
                // plugin.AllShrineDecorator.Add(SoundAlertFactory.Create<IShrine>(Hud, (shrine) => shrine.SnoActor.NameLocalized));
                // plugin.PoolOfReflectionDecorator.Add(SoundAlertFactory.Create<IShrine>(Hud, (shrine) => "pool"));
            }); */


			//// TTS dropped items
			Hud.RunOnPlugin<Jack.Items.ItemDropSoundAlertPlugin>(plugin =>
            {
                // legendaries
                plugin.Legendary = false;
                plugin.AncientLegendary = true;
                plugin.PrimalAncientLegendary = true;
                // sets
                plugin.Set = false;
                plugin.AncientSet = true;
                plugin.PrimalAncientSet = true;

                // alerts when gambling at kadala ?
                plugin.Gambled = true;

                // ancient & primals prefixes
                plugin.AncientLegendaryNamePrefix = "Ancient";
                plugin.PrimalAncientLegendaryNamePrefix = "Primal";
                plugin.AncientSetNamePrefix = "Ancient";
                plugin.PrimalAncientSetNamePrefix = "Primal";

                // Exceptions on above rules :
                // ---------------------------

                // add any item
                //plugin.ItemSnos.Add(2332226049); // health globe

                // ancients items if ancient rank == 1 is not activated
                // example for // 916911834 - Sacred Harvester
                //plugin.AncientItemSnos.Add(916911834);

                // primals items if ancient rank == 2 is not activated
                //plugin.PrimalAncientItemSnos.Add(12354689);

                // custom items names (if the item is not in one of the other list, this will do nothing)
                //plugin.ItemCustomNames.Add(2332226049, "health"); // health globe


				// customize  TTS Ramaladni's Gift

                // add any item
                plugin.ItemSnos.Add(1844495708); // 1844495708 - Ramaladni's Gift

                // custom items names (if the item is not in one of the other list, this will do nothing)
                plugin.ItemCustomNames.Add(1844495708, "Nuclear Launch Detected"); // 1844495708 - Ramaladni's Gift
            });

			// ---------------------------------------------


			// add  TTS skill CD: when skill is ready for use

			Hud.RunOnPlugin<Jack.Players.PlayerSkillCooldownSoundAlertPlugin>(plugin =>
            {
                plugin.InTown = true;

				plugin.Add(Hud.Sno.SnoPowers.DemonHunter_Vengeance);
				plugin.Add(Hud.Sno.SnoPowers.Monk_Epiphany);
				plugin.Add(Hud.Sno.SnoPowers.Wizard_Archon);

				plugin.Add(Hud.Sno.SnoPowers.WitchDoctor_SpiritWalk);
				//plugin.Add(Hud.Sno.SnoPowers.WitchDoctor_SpiritWalk, "Walk"); // custom name
                //plugin.Add(106237); // by sno
                //plugin.Add(106237, "Walk"); // by sno with custom name

                // remove entries
                //plugin.Remove(Hud.Sno.SnoPowers.WitchDoctor_SpiritWalk);
                //plugin.Remove(106237);

                // clear all
                //plugin.Clear();
            });

			// ---------------------------------------------




			// ############################################
			//	Customize Plugins |		RESU
			// ############################################


			// Ariadnes Thread Plugin

			Hud.RunOnPlugin<Resu.AriadnesThreadPlugin>(plugin =>
			{
				plugin.ThreadBetweenPlayers = true;	// Set to false to disable the thread between players.
				plugin.BannerTimeSeconds = 15;		// 30, Number of seconds you want each player's banner to stay.
			});

			// ---------------------------------------------


			// Crafters Delight Plugin

			/* Advice: For better experience with this plugin, turn off "Always Show Items Labels On Drop" in the Diablo 3 Gameplay options. */

			Hud.TogglePlugin<ChestPlugin>(true);  // enable default ChestPlugin

			Hud.RunOnPlugin<Resu.CraftersDelightPlugin>(plugin =>
            {
				// set to false; the items you don't want to see
				plugin.ShowAncientRank = true;
				plugin.SlainFarmers = true;
				plugin.DeathsBreath = true;
				plugin.VeiledCrystal = true;
				plugin.ArcaneDust = true;
				plugin.Gems = true;
				plugin.ForgottenSoul = true;
				plugin.ReusableParts = true;
				plugin.GreaterRiftKeystone = true;
				plugin.BovineBardiche = true;
				plugin.PuzzleRing = true;
				plugin.BloodShards = true;
				plugin.RamaladnisGift = true;
				plugin.Potion = true;
				plugin.InfernalMachine = true;
				plugin.Bounty = true;
				plugin.HellFire = true;
				plugin.LegendaryGems = true;
				plugin.HoradricCaches = true;
				plugin.LoreChestsDisplay = true;
				plugin.NormalChestsDisplay = false;
				plugin.ResplendentChestsDisplay = false;
				plugin.Equipped = true; // set to false to turn off "same item as equipped" drop sound drop & rendering on minimap & inventory.

				// plugin.EquippedBrush = Hud.Render.CreateBrush(200, 255, 54, 198, 2, SharpDX.Direct2D1.DashStyle.Solid, SharpDX.Direct2D1.CapStyle.Flat, SharpDX.Direct2D1.CapStyle.Flat);
				plugin.EquippedBrush = Hud.Render.CreateBrush(220, 255, 220, 150, 2, SharpDX.Direct2D1.DashStyle.Dash, SharpDX.Direct2D1.CapStyle.Flat, SharpDX.Direct2D1.CapStyle.Flat);
            });

			// ---------------------------------------------


			// Deluxe Shrine Labels Plugin

			Hud.RunOnPlugin<Resu.DeluxeShrineLabelsPlugin>(plugin =>
			{
			//Enable Healing Well Example
			plugin.ShowHealingWells = true;

			//Enable Pool of reflection Example
			plugin.ShowPoolOfReflection = true;

			// Disable displaying Healing Wells & Pools of reflection when health is under 40%
			plugin.ShowAllWhenHealthIsUnder40 = true;

			//Change Pylon Short Name Example
			// plugin.ShrineCustomNamesShort[ShrineType.BanditShrine] = "**BANDIT**";

			//Change Pylon Minimap Name Example
			// plugin.ShrineCustomNames[ShrineType.BanditShrine] = "OMG A BANDIT SHRINE";

			//Change Pylon Minimap Decorator Example
			//CreateMapDecorators(Font Size, Saturation(0-255), Red(0-255), Green(0-255), Blue(0-255), Radius Offset)
			// plugin.ShrineDecorators[ShrineType.BanditShrine] = plugin.CreateMapDecorators(8,255,255,0,0,5);

			//Change Pylon Ground Label Decorator Example
			//CreateGroundLabelDecorators(Font Size, Saturation(0-255), Red(0-255), Green(0-255), Blue(0-255), Bg Saturation(0-255), Bg Red(0-255), Bg Green(0-255), Bg Blue(0-255) )
			// plugin.ShrineShortDecorators[ShrineType.BanditShrine] = plugin.CreateGroundLabelDecorators(8,255,255,0,0,255,0,0,0);
			});

			// ---------------------------------------------


			// Danger Plugin

			Hud.RunOnPlugin<Resu.DangerPlugin>(plugin =>
			{
				// set to false; the items you don't want to see
				plugin.BloodSprings = false;
				plugin.DemonicForge = true;
				plugin.ShockTower = true;
				plugin.Desecrator = false;
				plugin.Thunderstorm = false;
				plugin.Plagued = false;
				plugin.Molten = false;
				plugin.ArcaneEnchanted = false;
				plugin.PoisonEnchanted = false;
				plugin.GasCloud = true; // (Ghom)
				plugin.SandWaspProjectile = true;
				plugin.MorluSpellcasterMeteorPending = true;
				plugin.DemonMine = false;
				plugin.PoisonDeath = true;
				plugin.MoltenExplosion = false;
				plugin.Orbiter = false;
				plugin.BloodStar = true;
				plugin.ArrowProjectile = true;
				plugin.BogFamilyProjectile = true;
				plugin.bloodGolemProjectile = true;
				plugin.MoleMutantProjectile = true;
				plugin.IcePorcupineProjectile = true;
				plugin.GrotesqueExplosion = true;
				plugin.BetrayedPoisonCloud = true;

				plugin.FastMummyDecorator = new WorldDecoratorCollection(
					new GroundCircleDecorator(Hud) {
                    // Brush = Hud.Render.CreateBrush(128, 255, 255, 255, 3, SharpDX.Direct2D1.DashStyle.Dash),
                    Brush = Hud.Render.CreateBrush(100, 0, 220, 50, 3, SharpDX.Direct2D1.DashStyle.Dash),
                    Radius = 9,
				});
			});

			// direct edit

			// MoveWarningDecorator
			// MoveWarningDecorator.Paint(layer, actor, actor.FloorCoordinate, "Moveth!");
			// MoveWarningDecorator.Paint(layer, actor, actor.FloorCoordinate, "Move !!");

			// ProjectileDecorator
			// ProjectileDecorator.Paint(layer, actor, actor.FloorCoordinate, "O");
			// ProjectileDecorator.Paint(layer, actor, actor.FloorCoordinate, "\u25BE"); // small triangle


			// ---------------------------------------------


			// Diadra's First Gem Plugin

			Hud.RunOnPlugin<Resu.DiadrasFirstGemPlugin>(plugin =>
            {
				plugin.Enabled = true;		// default true
				plugin.ElitesnBossOnly = false;		// default false
				plugin.BossOnly = false;	// default false
				plugin.offsetX = 10;		// default 0
				plugin.offsetY = 20;		// default 0

				plugin.StrickenStackDecorator = new TopLabelDecorator(Hud) {
					// TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 0, 0, 0, true, false, 250, 255, 255, 255, true),
					TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 0, 0, 0, true, false, 250, 255, 255, 255, true),
				};

				plugin.StrickenPercentDecorator = new TopLabelDecorator(Hud) {
					// TextFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 255, false, false, 250, 0, 0, 0, true),
					TextFont = Hud.Render.CreateFont("Helvetica", 7, 255, 0, 255, 255, false, false, 250, 0, 0, 0, true),
				};
            });

			// ---------------------------------------------


			// Craft Count Plugin

			// direct edit

			// TextFunc = () => craftCount.ToString("N0") + " owneth",
			// TextFunc = () => craftCount.ToString("N0") + " owned",




			// ############################################
			//	Customize Plugins |		OTHER
			// ############################################


			// 434409	a4_Heaven_Shrine_TreasureGoblin	Bandit Shrine
			// 455256	p43_AD_Shrine_TreasureGoblin	Bandit Shrine
			// 269349	Shrine_TreasureGoblin	Bandit Shrine
			// 340736	X1_graveRobber_B_ScoundrelEvent	Thieves Guild Bandit



			// Shrine Alert Plugin TTS (Darkblader24)

			// disable  plugin
			// Hud.TogglePlugin<User.Actors.ShrineAlertPlugin>(false);

			// customize alerts
			Hud.RunOnPlugin<User.Actors.ShrineAlertPlugin>(plugin =>
			{
				// Shrine Alerts Examples
				// null = use localized name for that shrine
				// "" 	= no TTS for that shrine
				plugin.UseCustomNames = true;
				plugin.ShrineCustomNames[ShrineType.BlessedShrine] = "";
				plugin.ShrineCustomNames[ShrineType.EnlightenedShrine] = "";
				plugin.ShrineCustomNames[ShrineType.FortuneShrine] = "";
				plugin.ShrineCustomNames[ShrineType.FrenziedShrine] = "";
				plugin.ShrineCustomNames[ShrineType.EmpoweredShrine] = null;
				plugin.ShrineCustomNames[ShrineType.FleetingShrine] = "";
				plugin.ShrineCustomNames[ShrineType.PowerPylon] = null;
				plugin.ShrineCustomNames[ShrineType.ConduitPylon] = "Condouwit Pylon";
				plugin.ShrineCustomNames[ShrineType.ChannelingPylon] = null;
				plugin.ShrineCustomNames[ShrineType.ShieldPylon] = null;
				plugin.ShrineCustomNames[ShrineType.SpeedPylon] = null;
				// Bandeeetoos, Jeeraunimo, Leeeroi Jejejeeenkens, Construct Additional Pylons, Yippeee kai yh yeay
				plugin.ShrineCustomNames[ShrineType.BanditShrine] = "Leeeroi Jejejeeenkens";
				plugin.ShrineCustomNames[ShrineType.PoolOfReflection] = "";
				plugin.ShrineCustomNames[ShrineType.HealingWell] = "";
			});

			// ---------------------------------------------


			//  Monsters Count Plugin  @ below minimap (glq)

			/* NOTE:  This plugin helps you know more about the Monsters Count, RiftProgress (Timevalue), and Debuff
			Left CTRL(You can set it in your custom code) can toggle the statistics of a specified number of yard and the maximum number of yard (120)
			When the TotalRP is Enough to reach 100%, the font color becomes orange
			When the TrashRP is Enough to reach 100%, the font color becomes red  */

			// disable  plugin
			// Hud.TogglePlugin<User.Monsters.MonstersCountPlugin>(false);

			Hud.RunOnPlugin<User.Monsters.MonstersCountPlugin>(plugin =>
			{
				plugin.ToggleKeyEvent = Hud.Input.CreateKeyEvent(true, Key.LeftControl, true, false, false); // Toggle the base range and maximum range
				plugin.ShowCircle = true; // Draw a circle on minimap
				plugin.BaseYard = 120; // Basic range of Statistics (40 is default)
				plugin.MaxYard = 120; // The maximum range of Statistics (120 is maximum)
				plugin.ShowMonstersCount = true;
				plugin.ShowTotalProgression = true;
				plugin.ShowTrashProgression = true;
				plugin.ShowEliteProgression = true;
				plugin.ShowRareMinionProgression = true;
				plugin.ShowRiftGlobeProgression = true;
				plugin.ShowTime = true; // Progress to time value
				plugin.ShowHauntedCount = false;
				plugin.ShowLlocustCount = false;
				plugin.ShowPalmedCount = false;
                plugin.baseMapShapeDecorator.Brush = Hud.Render.CreateBrush(70, 180, 147, 109, 1); // (150, 180, 147, 109, 1)
                plugin.maxMapShapeDecorator.Brush = Hud.Render.CreateBrush(70, 180, 147, 109, 1); // (150, 180, 147, 109, 1)
			});

			// ---------------------------------------------


			//  Monster Rift Progression Plugin (glq)

			/* NOTE:  This plugin will help you know the progress values for each monster */

			// disable  plugin
			// Hud.TogglePlugin<User.Monsters.MonsterRiftProgressionPlugin>(false);

			// Hud.RunOnPlugin<User.Monsters.MonsterRiftProgressionPlugin>(plugin =>
			// {
				// plugin.ToggleKeyEvent = Hud.Input.CreateKeyEvent(true, Key.F9, false, false, false); // Toggle display or no displaymaximum range
				// plugin.DisplayLimit = 0.5; // Minimum limit Progression display // 0.5% default
				// plugin.DyingEnable = true; // The dying monster is shown red
				// plugin.DyingLimit= 15; // The percentage below the health value is dying
				// plugin.OnlyMultiplayerEnable = true; // Dying for red function is effective only in multiplayer games
			// });

			// ---------------------------------------------


			// Skeletal Mage Singularity Essence Plugin (BM)

            Hud.RunOnPlugin<User.Actors.SkeletalMageSingularityEssencePlugin>(plugin =>
            {
				//To disable the plugin in town: change to false
				plugin.ShowInTown = true;

				//Value of your Reaper's Wraps: Health globes restore 25-30% of your primary resource
				plugin.ReapersWrapsResourceRestore = 30;

				//Default position is under the feet of the player
				//plugin.XPos = Hud.Window.Size.Width * 0.5f;	// 0.5f
				plugin.YPos = Hud.Window.Size.Height * 0.51f; // 0.5f, lower value = move to top of screen.
            });

			// ---------------------------------------------


			// Armory Set Info (JarJarD3)

			Hud.RunOnPlugin<User.Root.ArmorySetInfo>(plugin =>
            {
				// Keyboard
				plugin.UseToggleLabelsKey = true;  // Is "ShowArmorySetNumberLabels" and "ShowArmorySetNamesLeft" toggleable.
				plugin.ToggleLabelsKey = Key.Divide;  // Key to use toggle "ShowArmorySetNumberLabels".

				// Item borders
				plugin.EquippedBorderEnabled = true;
				plugin.StashBorderEnabled = true;
				plugin.InventoryBorderEnabled = true;
				plugin.EquippedBorderBrush = Hud.Render.CreateBrush(180, 238, 232, 170, -1.5f);  // pale golden rod -- equipped ArmorySet.
				plugin.NotArmorySetBorderBrush = Hud.Render.CreateBrush(100, 255, 51, 0, -1.6f);  // red orange transparent -- equipped not ArmorySet.
				plugin.StashBorderBrush = Hud.Render.CreateBrush(200, 255, 0, 0, -1.5f);  // red -- ArmorySet in stash.
				plugin.InventoryBorderBrush = Hud.Render.CreateBrush(200, 255, 0, 0, -1.6f);  // red -- ArmorySet in inventory.

				// Labels & List
				plugin.ShowArmorySetNumberLabels = true;  // Show Armory Set number labels under items.
				plugin.ShowArmorySetNamesLeft = true;  // Show Armory Set name list on left side of the screen.
				plugin.ShowArmorySetNamesHeader = true;  // Show Armory Set names that have equipped items.
				plugin.ShowOnlyMatchingArmorySetNames = true;  // Show only matching Armory Set names.
				plugin.MatchCubePowers = true;  // Match Cube Powers as well!
				plugin.ArmorySetLabelFont = Hud.Render.CreateFont("calibri", 8, 255, 255, 255, 255, true, false, 220, 0, 0, 0, true);  // white on black - ArmorySet label.
				plugin.ArmorySetNameFont = Hud.Render.CreateFont("calibri", 8, 255, 0xff, 0xd7, 0x00, false, false, true);  // gold

				plugin.ArmorySetMinNameLen = 2;  // Armory set names shorter than this will be ignored.
				plugin.MatchingSetIndicator = "\u25C0";  // black left-pointing pointer
				plugin.MatchingPowersIndicator = "\u25C6";  // BLACK DIAMOND
					// "\u25C2";  // black left-pointing small triangle
					// "\u25B6";  // BLACK RIGHT-POINTING TRIANGLE
            });

			// ---------------------------------------------







        }
    }
}
