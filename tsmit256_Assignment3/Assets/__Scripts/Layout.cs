﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layout : MonoBehaviour
{
    public PT_XMLReader xmlr; // Just like Deck, this has a PT_XMLReader
    public PT_XMLHashtable xml; // This variable is for faster xml access
    public Vector2 multiplier; // The offset of the tableau's center
                               // SlotDef references
    public List<SlotDef> slotDefs; // All the SlotDefs for Row0-Row3
    public SlotDef drawPile;
    public SlotDef discardPile;
    // This holds all of the possible names for the layers set by layerID
    public string[] sortingLayerNames = new string[] { "Row0", "Row1",
        "Row2", "Row3", "Discard", "Draw" };

    // This function is called to read in the LayoutXML.xml file
    public void ReadLayout(string xmlText)
    {
        xmlr = new PT_XMLReader();
        xmlr.Parse(xmlText);      // The XML is parsed
        xml = xmlr.xml["xml"][0]; // And xml is set as a shortcut to the XML

        // Read in the multiplier, which sets card spacing
        multiplier.x = float.Parse(xml["multiplier"][0].Att("x"));
        multiplier.y = float.Parse(xml["multiplier"][0].Att("y"));

        // Read in the slots
        SlotDef tSD;
        // slotsX is used as a shortcut to all the <slot>s
        PT_XMLHashList slotsX = xml["slot"];

        for (int i = 0; i < slotsX.Count; i++)
        {
            tSD = new SlotDef(); // Create a new SlotDef instance
            if (slotsX[i].HasAtt("type"))
            {
                // If this <slot> has a type Attribute parse it
                tSD.type = slotsX[i].Att("type");
            }
            else
            {
                // If not, set its type to "slot"; it's a card in the rows
                tSD.type = "slot";
            }
            // Various Attributes are parsed into numerical values
            tSD.x = float.Parse(slotsX[i].Att("x"));
            tSD.y = float.Parse(slotsX[i].Att("y"));
            tSD.layerID = int.Parse(slotsX[i].Att("layer"));
            // This converts the number of the layerID into a text layerName     
            tSD.layerName = sortingLayerNames[tSD.layerID];              // a

            switch (tSD.type)
            {
                // pull additional Attributes based on the type of this <slot>
                case "slot":
                    tSD.faceUp = (slotsX[i].Att("faceup") == "1");
                    tSD.id = int.Parse(slotsX[i].Att("id"));
                    if (slotsX[i].HasAtt("hiddenby"))
                    {
                        string[] hiding = slotsX[i].Att("hiddenby").Split(',');
                        foreach (string s in hiding)
                        {
                            tSD.hiddenBy.Add(int.Parse(s));
                        }
                    }
                    slotDefs.Add(tSD);
                    break;

                case "drawpile":
                    tSD.stagger.x = float.Parse(slotsX[i].Att("xstagger"));
                    drawPile = tSD;
                    break;
                case "discardpile":
                    discardPile = tSD;
                    break;
            }
        }
    }
}
