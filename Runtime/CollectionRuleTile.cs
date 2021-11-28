using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace FF24.Variants.RuleTiles
{ 
    [CreateAssetMenu]
    public class CollectionRuleTile : RuleTile<CollectionRuleTile.CollectionNeighbor>
    {
        public class CollectionNeighbor : RuleTile.TilingRuleOutput.Neighbor
        {
            public const int CollectionAny = 3;
            public const int Collection1 = 4;
            public const int Collection2 = 5;
            public const int Collection3 = 6;
            public const int Collection4 = 7;
            public const int NotCollectionAny = -3;
            public const int NotCollection1 = -4;
            public const int NotCollection2 = -5;
            public const int NotCollection3 = -6;
            public const int NotCollection4 = -7;
        }

        [Header("collection tags")]
        public List<string> tags;
        [Header("collection tags to respond to:")]
        public List<string> connectsToCollection1 = new List<string>();
        public List<string> connectsToCollection2 = new List<string>();
        public List<string> connectsToCollection3 = new List<string>();
        public List<string> connectsToCollection4 = new List<string>();

        public override bool RuleMatch(int neighbor, TileBase other)
        {
            if (other is RuleOverrideTile)
                other = (other as RuleOverrideTile).m_InstanceTile;

            if (neighbor * neighbor > 2 * 2)
            {
                bool t = false;
                switch (neighbor)
                {
                    case CollectionNeighbor.Collection1:
                    case CollectionNeighbor.NotCollection1:
                        {
                            t = other is CollectionRuleTile
                                && ContainsAny(connectsToCollection1, (other as CollectionRuleTile).tags);
                        }
                        break;
                    case CollectionNeighbor.Collection2:
                    case CollectionNeighbor.NotCollection2:
                        {
                            t = other is CollectionRuleTile
                                && ContainsAny(connectsToCollection2, (other as CollectionRuleTile).tags);
                        }
                        break;
                    case CollectionNeighbor.Collection3:
                    case CollectionNeighbor.NotCollection3:
                        {
                            t = other is CollectionRuleTile
                                && ContainsAny(connectsToCollection3, (other as CollectionRuleTile).tags);
                        }
                        break;
                    case CollectionNeighbor.Collection4:
                    case CollectionNeighbor.NotCollection4:
                        {
                            t = other is CollectionRuleTile
                                && ContainsAny(connectsToCollection4, (other as CollectionRuleTile).tags);
                        }
                        break;
                    case CollectionNeighbor.CollectionAny:
                    case CollectionNeighbor.NotCollectionAny:
                        {
                            t = other is CollectionRuleTile
                                && (ContainsAny(connectsToCollection1, (other as CollectionRuleTile).tags) ||
                                    ContainsAny(connectsToCollection2, (other as CollectionRuleTile).tags) ||
                                    ContainsAny(connectsToCollection3, (other as CollectionRuleTile).tags) ||
                                    ContainsAny(connectsToCollection4, (other as CollectionRuleTile).tags)
                                    );
                        }
                        break;
                    default:
                        break;
                }
                if (neighbor < 0)
                {
                    return (!t);
                }
                else
                {
                    return t;
                }
            }
            else
            {
                return base.RuleMatch(neighbor, other);
            }
        }

        public static bool ContainsAny<T>(ICollection<T> list, IEnumerable<T> other)
        {
            foreach (T item in other)
            {
                if (list.Contains(item))
                {
                    return true;
                }
            }
            return false;
        }

    }

}