// ArmorySetInfo.cs "$Revision: 901 $" "$Date: 2019-01-30 11:51:59 +0200 (ke, 30 tammi 2019) $"
using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// using Turbo.Plugins;
using Turbo.Plugins.Default;

// namespace Turbo.plugins.JarJar.DefaultUI
namespace Turbo.Plugins.User.Root

{
    class ArmorySetInfo : BasePlugin, IKeyEventHandler, IInGameTopPainter
    {
        const string left = "\u25C0";                               // black left-pointing pointer https://www.fileformat.info/info/unicode/char/25c0/index.htm
        const string left2 = "\u25C2";                              // black left-pointing small triangle https://www.fileformat.info/info/unicode/char/25c2/index.htm
        
        // Keyboard.
        public bool UseToggleLabelsKey { get; set; } = true;        // Is "ShowArmorySetNumberLabels" and "ShowArmorySetNamesLeft" toggleable.
        public Key ToggleLabelsKey { get; set; } = Key.Divide;      // Key to use toggle "ShowArmorySetNumberLabels".

        // Item borders.
        public bool EquippedBorderEnabled { get; set; } = true;     // Equipped items get light (almost invisible) border if in armory and default border if not.
        public bool StashBorderEnabled { get; set; } = true;        // Armory set items in stash get red border.
        public bool InventoryBorderEnabled { get; set; } = true;    // Armory set items in inventory get teal border.
        
        // Item labels (toggleable).
        public bool ShowArmorySetNumberLabels { get; set; } = true; // Show Armory Set number labels under items.

        // Armory Set name list in left side of the screen (toggleable).
        public bool ShowArmorySetNamesLeft { get; set; } = true;    // Show Armory Set name list on left side of the screen.

        // Armory Set name(s) in Inventory header.
        public bool ShowArmorySetNamesHeader { get; set; } = true;  // Show Armory Set names that have equipped items.
        public bool ShowOnlyMatchingArmorySetNames { get; set; } = true; // Show only matching Armory Set names.
        public bool MatchCubePowers { get; set; } = true;          // Match Cube Powers as well!

        // Armory Set name selection filter.
        public uint ArmorySetMinNameLen { get; set; } = 2;          // Armory set names shorter than this will be ignored.

        public string MatchingSetIndicator { get; set; } = left;     // Matching Armory Set indicator.
        public string MatchingPowersIndicator { get; set; } = left2; // Matching Cube powers indicator.

        public float ArmorySetHeaderRatioX { get; set; } = 0.62f;   // % X-offset for "ShowArmorySetNamesHeader".
        public float ArmorySetHeaderRatioY { get; set; } = 0.07f;   // % Y-offset baseline.

        public float ArmorySetLabelRatioX { get; set; } = 0.005f;   // % X-offset for "ShowArmorySetNamesLeft".
        public float ArmorySetLabelRatioY { get; set; } = 0.35f;    // % Y-offset.

        public IFont ArmorySetLabelFont { get; set; }
        public IFont ArmorySetNameFont { get; set; }

        public IBrush EquippedBorderBrush { get; set; }
        public IBrush StashBorderBrush { get; set; }
        public IBrush InventoryBorderBrush { get; set; }
        public IBrush NotArmorySetBorderBrush { get; set; }

        SimpleLabel labelArmorySetNamesLeft;
        StringBuilder labelTextHeader = new StringBuilder();
        StringBuilder labelTextLeft = new StringBuilder();
        int stashPage, stashTab, stashTabAbs;
        float rv;
        StringBuilder builder = new StringBuilder();
        List<int> setNumbers = new List<int>(16);
        uint requiredItemCount;
        uint[] equippedItemCount;
        bool[] isMatchingSet;
        bool[] isMatchingPowers;

        public ArmorySetInfo() { Enabled = true; }

        public override void Load(IController hud)
        {
            base.Load(hud);

            equippedItemCount = new uint[Hud.Game.Me.ArmorySets.Length];
            isMatchingSet = new bool[Hud.Game.Me.ArmorySets.Length];
            isMatchingPowers = new bool[Hud.Game.Me.ArmorySets.Length];

            float x = Hud.Window.Size.Width * ArmorySetLabelRatioX;
            float y = Hud.Window.Size.Height * ArmorySetLabelRatioY;
            labelArmorySetNamesLeft = new SimpleLabel(Hud, "tahoma", 7, SharpDX.Color.PaleTurquoise).WithPosition(x, y);

            ArmorySetLabelFont = Hud.Render.CreateFont("arial", 7, 255, 192, 192, 192, true, false, 220, 32, 32, 32, true); // light grey on drak grey
            ArmorySetNameFont = Hud.Render.CreateFont("tahoma", 7, 255, 0xff, 0xd7, 0x00, false, false, true);              // gold

            EquippedBorderBrush = Hud.Render.CreateBrush(150, 238, 232, 170, -1.6f);    // pale golden rod (quite light)
            StashBorderBrush = Hud.Render.CreateBrush(150, 0, 192, 128, -1.6f);         // teal - but lighter
            InventoryBorderBrush = Hud.Render.CreateBrush(200, 255, 0, 0, -1.6f);       // red
            NotArmorySetBorderBrush = Hud.Render.CreateBrush(100, 255, 51, 0, -1.6f);   // orangish transparent
        }

        public void OnKeyEvent(IKeyEvent keyEvent)
        {
            if (UseToggleLabelsKey && keyEvent.IsPressed && keyEvent.Key == ToggleLabelsKey)
            {
                ShowArmorySetNumberLabels = !ShowArmorySetNumberLabels;
            }
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.Inventory) return;

            var uiInv = Hud.Inventory.InventoryMainUiElement;
            if (!uiInv.Visible) return;

            stashTab = Hud.Inventory.SelectedStashTabIndex;
            stashPage = Hud.Inventory.SelectedStashPageIndex;
            stashTabAbs = stashTab + stashPage * Hud.Inventory.MaxStashTabCountPerPage;

            rv = 32.0f / 600.0f * Hud.Window.Size.Height;

            // Reset data.
            requiredItemCount = 13;
            Array.Clear(equippedItemCount, 0, equippedItemCount.Length);
            Array.Clear(isMatchingSet, 0, isMatchingSet.Length);
            Array.Clear(isMatchingPowers, 0, isMatchingPowers.Length);
            // Checked all items.
            var items = Hud.Game.Items.Where(x => x.Location != ItemLocation.Merchant && x.Location != ItemLocation.Floor);
            foreach (var item in items)
            {
                if (item.Location == ItemLocation.Stash)
                {
                    var tabIndex = item.InventoryY / 10;
                    if (tabIndex != stashTabAbs) continue;
                }
                if ((item.InventoryX < 0) || (item.InventoryY < 0)) continue;

                var rect = Hud.Inventory.GetItemRect(item);
                if (rect == System.Drawing.RectangleF.Empty) continue;
                if (item.Location == ItemLocation.Stash || item.Location == ItemLocation.Inventory)
                {
                    if (item.Unidentified ||
                        item.SnoItem.Kind == ItemKind.gem ||
                        item.SnoItem.Kind == ItemKind.uberstuff ||
                        item.SnoItem.Kind == ItemKind.potion ||
                        item.SnoItem.MainGroupCode == "gems_unique" ||
                        item.SnoItem.MainGroupCode == "riftkeystone" ||
                        item.SnoItem.MainGroupCode == "healthpotions" ||
                        item.SnoItem.MainGroupCode == "consumable" ||
                        item.SnoItem.MainGroupCode == "horadriccache")
                    {
                        continue;
                    }
                }
                checkForArmorySet(item, rect);
            }
            // All items checked.
            if (ShowArmorySetNamesLeft || ShowArmorySetNamesHeader)
            {
                var stash = Hud.Inventory.StashMainUiElement;
                labelTextHeader.Clear();
                labelTextLeft.Clear();
                for (int i = 0; i < Hud.Game.Me.ArmorySets.Length; ++i)
                {
                    var armorySet = Hud.Game.Me.ArmorySets[i];
                    if (armorySet != null && armorySet.Name.Length >= ArmorySetMinNameLen)
                    {
                        int index = armorySet.Index + 1;
                        // Inventory header.
                        if (ShowArmorySetNamesHeader && equippedItemCount[i] > 0)
                        {
                            if (isMatchingSet[i] || !ShowOnlyMatchingArmorySetNames)
                            {
                                labelTextHeader.AppendFormat("{0:00}", index).Append(' ').Append(armorySet.Name).AppendFormat(" ({0})", equippedItemCount[i]);
                                if (isMatchingSet[i])
                                {
                                    if (!string.IsNullOrWhiteSpace(MatchingSetIndicator))
                                    {
                                        labelTextHeader.Append(' ').Append(MatchingSetIndicator);
                                        if (isMatchingPowers[i] && !string.IsNullOrWhiteSpace(MatchingPowersIndicator))
                                        {
                                            labelTextHeader.Append(MatchingPowersIndicator);
                                        }
                                    }
                                }
                                labelTextHeader.AppendLine();
                            }
                        }
                        if (!stash.Visible)
                        {
                            // Left side Armory Set list.
                            if (ShowArmorySetNamesLeft && ShowArmorySetNumberLabels)    // Controlled by toggle as well.
                            {
                                labelTextLeft.AppendFormat("{0:00}", index).Append(' ').Append(armorySet.Name).AppendFormat(" ({0})", formatEquippedItemCount(equippedItemCount[i]));
                                if (isMatchingSet[i])
                                {
                                    if (!string.IsNullOrWhiteSpace(MatchingSetIndicator))
                                    {
                                        labelTextLeft.Append(' ').Append(MatchingSetIndicator);
                                        if (isMatchingPowers[i] && !string.IsNullOrWhiteSpace(MatchingPowersIndicator))
                                        {
                                            labelTextLeft.Append(MatchingPowersIndicator);
                                        }
                                    }
                                }
                                labelTextLeft.AppendLine();
                            }
                        }
                    }
                }
                if (labelTextHeader.Length > 0)
                {
                    // Vertically centered from "ArmorySetHeaderRatioY".
                    var layout = ArmorySetNameFont.GetTextLayout(labelTextHeader.ToString());
                    var x = uiInv.Rectangle.Left + (uiInv.Rectangle.Width * ArmorySetHeaderRatioX);
                    var y = uiInv.Rectangle.Top + (uiInv.Rectangle.Height * ArmorySetHeaderRatioY) - (layout.Metrics.Height / 2f);
                    if (y < uiInv.Rectangle.Top) y = uiInv.Rectangle.Top;
                    ArmorySetNameFont.DrawText(layout, x, y);
                }
                if (labelTextLeft.Length > 0)
                {
                    labelArmorySetNamesLeft.PaintLeft(labelTextLeft.ToString());
                }
            }
        }

        string formatEquippedItemCount(uint count)
        {
            return count == 0 ? "-" : count.ToString();
        }

        void checkForArmorySet(IItem item, System.Drawing.RectangleF rect)
        {
            setNumbers.Clear();
            var player = Hud.Game.Me;
            for (int i = 0; i < player.ArmorySets.Length; ++i)
            {
                var armorySet = player.ArmorySets[i];
                if (armorySet != null && armorySet.Name.Length >= ArmorySetMinNameLen)
                {
                    if (armorySet.ContainsItem(item))
                    {
                        setNumbers.Add(armorySet.Index + 1);
                        if (item.Location >= ItemLocation.Head && item.Location <= ItemLocation.Neck)
                        {
                            equippedItemCount[i] += 1;
                            if (item.Location == ItemLocation.LeftHand && item.SnoItem.MainGroupCode == "2h" && requiredItemCount == 13)
                            {
                                requiredItemCount = 12;     // Left hand is empty!
                            }
                            if (equippedItemCount[i] == requiredItemCount)
                            {
                                // Save matching armory set.
                                isMatchingSet[i] = true;
                                isMatchingPowers[i] = MatchCubePowers ? hasSameCubePowers(player, armorySet) : false;
                            }
                        }
                    }
                }
            }
            if (setNumbers.Count == 0)
            {
                if (EquippedBorderEnabled && !(item.Location == ItemLocation.Stash || item.Location == ItemLocation.Inventory))
                {
                    NotArmorySetBorderBrush.DrawRectangle(rect.X, rect.Y, rect.Width, rect.Height);
                }
                return;
            }
            if (item.Location == ItemLocation.Stash)
            {
                if (StashBorderEnabled) StashBorderBrush.DrawRectangle(rect.X, rect.Y, rect.Width, rect.Height);
            }
            else if (item.Location == ItemLocation.Inventory)
            {
                if (InventoryBorderEnabled) InventoryBorderBrush.DrawRectangle(rect.X, rect.Y, rect.Width, rect.Height);
            }
            else
            {
                if (EquippedBorderEnabled) EquippedBorderBrush.DrawRectangle(rect.X, rect.Y, rect.Width, rect.Height);
            }
            if (ShowArmorySetNumberLabels)
            {
                builder.Length = 0;
                builder.Append('#');
                int endIndex = setNumbers.Count - 1;
                int current = 0;
                try
                {
                    while (current <= endIndex)
                    {
                        int first = current;
                        int last = current + 1;
                        int delta = 1;
                        if (last <= endIndex && (setNumbers[last] - setNumbers[first]) == delta)
                        {
                            while (last + 1 <= endIndex && (setNumbers[last + 1] - setNumbers[first]) == delta + 1)
                            {
                                last += 1;
                                delta += 1;
                            }
                            builder.Append(setNumbers[first])
                                .Append(delta == 1 ? ',' : '-')
                                .Append(setNumbers[last]).Append(',');
                            current = last + 1;
                        }
                        else
                        {
                            builder.Append(setNumbers[first]).Append(',');
                            current += 1;
                        }
                    }
                    builder.Length -= 1;
                }
                catch (Exception ex)
                {
                    Hud.Debug("Error " + ex.ToString());
                    builder.Append("E:").Append(setNumbers.Count);
                }
                bool upper = item.Location == ItemLocation.Stash || item.Location == ItemLocation.Inventory;
                var font = ArmorySetLabelFont;
                var text = builder.ToString();
                var textLayout = font.GetTextLayout(text);
                var x = upper ? rect.Left + rv / 15.0f : rect.Right - textLayout.Metrics.Width - rv / 15.0f;
                var y = upper ? rect.Top + rv / 35.0f : rect.Bottom - 2 * (rv / 35.0f);
                font.DrawText(textLayout, x, y);
            }
        }

        bool hasSameCubePowers(IPlayer player, IPlayerArmorySet set)
        {
            return isEqual(player.CubeSnoItem1, set.CubeSnoItem1)
                && isEqual(player.CubeSnoItem2, set.CubeSnoItem2)
                && isEqual(player.CubeSnoItem3, set.CubeSnoItem3);
        }

        bool isEqual(ISnoItem left, ISnoItem right)
        {
            if (left != null && right != null)
            {
                return left.Sno == right.Sno;
            }
            if (left == null && right == null) return true;
            return false;
        }

        class SimpleLabel
        {
            public IFont TextFont;
            public float X;
            public float Y;

            public SimpleLabel(IController hud, string fontFamily, float size, SharpDX.Color textColor, bool bold = false)
                :
                this(hud.Render.CreateFont(fontFamily, size, textColor.A, textColor.R, textColor.G, textColor.B, bold, false, true))
            { }

            public SimpleLabel(IFont font)
            {
                TextFont = font;
            }

            public SimpleLabel WithPosition(float x, float y)
            {
                this.X = x;
                this.Y = y;
                return this;
            }

            public SharpDX.DirectWrite.TextMetrics GetTextMetrics(string text)
            {
                return TextFont.GetTextLayout(text).Metrics;
            }

            public float PaintLeft(string text)
            {
                return PaintLeft(X, Y, text);
            }
            public float PaintLeft(float x, float y, string text)
            {
                var layout = TextFont.GetTextLayout(text);
                TextFont.DrawText(layout, x, y);
                return layout.Metrics.Height;
            }

            public float PaintRight(string text)
            {
                return PaintRight(X, Y, text);
            }
            public float PaintRight(float x, float y, string text)
            {
                var layout = TextFont.GetTextLayout(text);
                TextFont.DrawText(layout, x - layout.Metrics.Width, y - layout.Metrics.Height);
                return layout.Metrics.Height;
            }
        }
    }
}