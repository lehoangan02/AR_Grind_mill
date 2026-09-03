using System.Collections.Generic;
using UnityEngine;

namespace AR_Grind_mill.Dialogue.Data
{
    /// <summary>
    /// One NPC's full dialogue tree. Holds the entry node plus a flat list of every
    /// node in the graph. The flat list drives the custom inspector and lets
    /// <see cref="Validate"/> flag orphan (unreachable) nodes.
    /// </summary>
    [CreateAssetMenu(fileName = "DialogueGraph", menuName = "AR_Grind_mill/Dialogue/Graph")]
    public class DialogueGraph : ScriptableObject
    {
        [Header("Identity")]
        [Tooltip("NPC this graph belongs to (e.g. 'Mr. Six', 'Mrs. Four').")]
        public string characterName;

        [Header("Graph Structure")]
        [Tooltip("First node presented when the player talks to this NPC.")]
        public DialogueNode entryNode;

        [Tooltip("Every node in the graph. The custom inspector uses this for navigation; " +
                 "Validate() also checks that every node is reachable from entryNode.")]
        public List<DialogueNode> nodes = new List<DialogueNode>();

        [Header("Validation")]
        [Tooltip("Treat this graph as a flat pool of nodes instead of a connected tree. " +
                 "When true, Validate() / OnValidate() will NOT flag nodes as unreachable " +
                 "from entryNode. Use this when the runtime swaps entryNode at delivery " +
                 "time (e.g. quest events that inject specific lines) rather than walking " +
                 "the graph via choices. Other checks (null refs, terminal sanity) still " +
                 "run.")]
        public bool isNodePool;

        /// <summary>
        /// Returns the entry node, or null if none is assigned.
        /// </summary>
        public DialogueNode GetEntry()
        {
            return entryNode;
        }

        /// <summary>
        /// Inspects the graph and fills <paramref name="errors"/> with human-readable
        /// problems (missing entry, null refs, orphans, broken terminals). Returns true
        /// when the graph passes all checks.
        /// </summary>
        public bool Validate(out List<string> errors)
        {
            errors = new List<string>();

            if (entryNode == null)
            {
                errors.Add($"[{name}] entryNode is not assigned. Set the starting node before authoring.");
            }

            if (nodes == null)
            {
                errors.Add($"[{name}] nodes list is null. Re-create the asset.");
                return errors.Count == 0;
            }

            // 1. Null references inside the nodes list.
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i] == null)
                {
                    errors.Add($"[{name}] nodes[{i}] is a missing reference.");
                }
            }

            // 2. Reachable set: BFS from entryNode. Skipped when isNodePool.
            HashSet<DialogueNode> reachable = new HashSet<DialogueNode>();
            if (!isNodePool)
            {
                foreach (DialogueNode n in WalkGraph())
                {
                    if (n != null)
                    {
                        reachable.Add(n);
                    }
                }
            }

            // 3. Orphan nodes: listed but never reachable. Skipped when isNodePool.
            if (!isNodePool)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    DialogueNode node = nodes[i];
                    if (node == null) continue;
                    if (!reachable.Contains(node))
                    {
                        errors.Add($"[{name}] nodes[{i}] ('{node.name}') is unreachable from entryNode.");
                    }
                }
            }

            // 4. Terminal sanity: a node flagged terminal shouldn't have live outgoing choices.
            for (int i = 0; i < nodes.Count; i++)
            {
                DialogueNode node = nodes[i];
                if (node == null) continue;
                if (!node.IsTerminal()) continue;

                List<DialogueChoice> nodeChoices = node.choices;
                if (nodeChoices == null) continue;

                for (int c = 0; c < nodeChoices.Count; c++)
                {
                    DialogueNode next = nodeChoices[c].nextNode;
                    if (next != null)
                    {
                        errors.Add($"[{name}] Node '{node.name}' is terminal but choice[{c}] points at '{next.name}'.");
                    }
                }
            }

            return errors.Count == 0;
        }

        /// <summary>
        /// Breadth-first walk from <see cref="entryNode"/>. Yields each reachable node
        /// at most once. Used by <see cref="Validate"/>.
        /// </summary>
        private IEnumerable<DialogueNode> WalkGraph()
        {
            if (entryNode == null) yield break;

            HashSet<DialogueNode> visited = new HashSet<DialogueNode>();
            Queue<DialogueNode> queue = new Queue<DialogueNode>();
            queue.Enqueue(entryNode);

            while (queue.Count > 0)
            {
                DialogueNode current = queue.Dequeue();
                if (current == null) continue;
                if (!visited.Add(current)) continue;

                yield return current;

                List<DialogueChoice> currentChoices = current.choices;
                if (currentChoices == null) continue;

                for (int i = 0; i < currentChoices.Count; i++)
                {
                    DialogueNode next = currentChoices[i].nextNode;
                    if (next != null && !visited.Contains(next))
                    {
                        queue.Enqueue(next);
                    }
                }
            }
        }

        private void OnValidate()
        {
            if (nodes == null)
            {
                nodes = new List<DialogueNode>();
            }

            if (entryNode == null)
            {
                Debug.LogWarning($"[DialogueGraph] '{name}' has no entryNode assigned.", this);
                return;
            }

            List<string> errors;
            if (!Validate(out errors))
            {
                for (int i = 0; i < errors.Count; i++)
                {
                    Debug.LogWarning($"[DialogueGraph] {errors[i]}", this);
                }
            }
        }
    }
}
