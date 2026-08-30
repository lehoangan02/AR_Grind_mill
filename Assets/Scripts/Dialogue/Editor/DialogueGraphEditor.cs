#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AR_Grind_mill.Dialogue.Data.Editor
{
    /// <summary>
    /// Custom inspector for <see cref="DialogueGraph"/>. Provides:
    /// - one-click Validate with inline error report,
    /// - one-click Create Node that prompts for an asset path and appends it to the graph,
    /// - a quick-jump foldout listing every node with a Ping button.
    /// All field edits go through <see cref="SerializedObject"/> so Undo works natively.
    /// </summary>
    [CustomEditor(typeof(DialogueGraph))]
    public class DialogueGraphEditor : UnityEditor.Editor
    {
        private const string NodesPropName = "nodes";

        private bool _nodesFoldout = true;
        private List<string> _validationErrors;

        public override void OnInspectorGUI()
        {
            DialogueGraph graph = (DialogueGraph)target;
            serializedObject.Update();

            // ---- Action bar ------------------------------------------------
            EditorGUILayout.Space();
            using (new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("Validate", GUILayout.Height(24)))
                {
                    RunValidation();
                }

                if (GUILayout.Button("Create Node", GUILayout.Height(24)))
                {
                    CreateAndAddNode(graph, serializedObject);
                }
            }

            // ---- Validation report ---------------------------------------
            DrawValidationReport();

            EditorGUILayout.Space();

            // ---- Default serialized fields --------------------------------
            // Draw everything except the script reference so designers can edit
            // characterName / entryNode / nodes via standard fields (Undo works).
            DrawPropertiesExcluding(serializedObject, "m_Script");

            EditorGUILayout.Space();

            // ---- Quick-jump node list -------------------------------------
            DrawNodesFoldout(graph);

            serializedObject.ApplyModifiedProperties();
        }

        private void RunValidation()
        {
            DialogueGraph graph = (DialogueGraph)target;
            List<string> errors;
            graph.Validate(out errors);
            _validationErrors = errors ?? new List<string>();
        }

        private void DrawValidationReport()
        {
            if (_validationErrors == null) return;

            if (_validationErrors.Count == 0)
            {
                EditorGUILayout.HelpBox("Graph is valid.", MessageType.Info);
                return;
            }

            EditorGUILayout.HelpBox(
                $"{_validationErrors.Count} issue(s) found in '{target.name}':",
                MessageType.Warning);

            for (int i = 0; i < _validationErrors.Count; i++)
            {
                EditorGUILayout.HelpBox(_validationErrors[i], MessageType.Warning);
            }
        }

        private void DrawNodesFoldout(DialogueGraph graph)
        {
            int count = graph.nodes != null ? graph.nodes.Count : 0;
            _nodesFoldout = EditorGUILayout.Foldout(_nodesFoldout, $"Nodes ({count})", true);
            if (!_nodesFoldout) return;

            EditorGUI.indentLevel++;

            if (graph.nodes == null || graph.nodes.Count == 0)
            {
                EditorGUILayout.LabelField("No nodes assigned. Use 'Create Node' to add one.");
                EditorGUI.indentLevel--;
                return;
            }

            for (int i = 0; i < graph.nodes.Count; i++)
            {
                DialogueNode node = graph.nodes[i];

                using (new EditorGUILayout.HorizontalScope(EditorStyles.helpBox))
                {
                    if (node == null)
                    {
                        EditorGUILayout.LabelField($"[{i}] <missing reference>");
                        if (GUILayout.Button("Ping", GUILayout.Width(50)))
                        {
                            // Nothing to ping — null asset reference.
                            EditorUtility.Beep();
                        }
                    }
                    else
                    {
                        string preview = BuildPreview(node);
                        int choiceCount = node.choices != null ? node.choices.Count : 0;
                        string terminalTag = node.IsTerminal() ? "  [terminal]" : string.Empty;
                        string label =
                            $"[{i}] {node.name} \u2014 \u201C{preview}\u201D \u2014 {choiceCount} choice(s){terminalTag}";

                        EditorGUILayout.LabelField(label);

                        if (GUILayout.Button("Ping", GUILayout.Width(50)))
                        {
                            EditorGUIUtility.PingObject(node);
                        }
                    }
                }
            }

            EditorGUI.indentLevel--;
        }

        private static string BuildPreview(DialogueNode node)
        {
            string text = node.line.text;
            if (string.IsNullOrEmpty(text))
            {
                return "<no text>";
            }

            // Single-line, length-clamped for a tidy foldout row.
            text = text.Replace('\n', ' ').Replace('\r', ' ');
            if (text.Length > 60)
            {
                text = text.Substring(0, 60) + "\u2026";
            }
            return text;
        }

        private void CreateAndAddNode(DialogueGraph graph, SerializedObject so)
        {
            string path = EditorUtility.SaveFilePanelInProject(
                "Create Dialogue Node",
                "NewDialogueNode",
                "asset",
                "Choose where to save the new DialogueNode asset.");

            if (string.IsNullOrEmpty(path))
            {
                return; // user cancelled
            }

            // Create the asset on disk.
            DialogueNode newNode = ScriptableObject.CreateInstance<DialogueNode>();
            AssetDatabase.CreateAsset(newNode, path);
            AssetDatabase.SaveAssets();
            AssetDatabase.ImportAsset(path);

            // Append through SerializedProperty so Undo + dirty-tracking behave correctly.
            SerializedProperty nodesProp = so.FindProperty(NodesPropName);
            if (nodesProp == null)
            {
                Debug.LogError($"[DialogueGraphEditor] SerializedProperty '{NodesPropName}' not found on '{graph.name}'.");
                return;
            }

            so.Update();
            nodesProp.arraySize = nodesProp.arraySize + 1;
            SerializedProperty element = nodesProp.GetArrayElementAtIndex(nodesProp.arraySize - 1);
            element.objectReferenceValue = newNode;

            // If the graph has no entry yet, auto-promote the new node to entry.
            SerializedProperty entryProp = so.FindProperty("entryNode");
            if (entryProp != null && entryProp.objectReferenceValue == null)
            {
                entryProp.objectReferenceValue = newNode;
            }

            so.ApplyModifiedProperties();

            // Highlight the newly created asset so designers can find it immediately.
            EditorGUIUtility.PingObject(newNode);
            Selection.activeObject = newNode;
        }
    }
}
#endif
