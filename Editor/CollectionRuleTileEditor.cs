using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CollectionRuleTile), true)]
[CanEditMultipleObjects]
public class CollectionRuleTileEditor : RuleTileEditor
{

    /// <summary>
    /// Draws a neighbor matching rule
    /// </summary>
    /// <param name="rect">Rect to draw on</param>
    /// <param name="position">The relative position of the arrow from the center</param>
    /// <param name="neighbor">The index to the neighbor matching criteria</param>
    public override void RuleOnGUI(Rect rect, Vector3Int position, int neighbor)
    {
        switch (neighbor)
        {
            case RuleTile.TilingRule.Neighbor.This:
                GUI.DrawTexture(rect, arrows[GetArrowIndex(position)]);
                break;
            case RuleTile.TilingRule.Neighbor.NotThis:
                GUI.DrawTexture(rect, arrows[9]);
                break;
            default:
                var style = new GUIStyle();
                style.alignment = TextAnchor.MiddleCenter;
                style.fontSize = 10;
                if(neighbor < 0)
                {
                    GUI.DrawTexture(rect, arrows[9]);
                    
                    neighbor *= -1;
                }
                if(neighbor == 3)
                    GUI.Label(rect, "A", style);
                else
                    GUI.Label(rect, (neighbor-3).ToString(), style);
                break;
        }
    }

}
