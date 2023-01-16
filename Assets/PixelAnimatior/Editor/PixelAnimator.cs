using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace PixelAnimator
{
    public class PixelAnimator : EditorWindow
    {
        AnimNode movableNode = null;
        [MenuItem("Window/Pixel Animator")]
        public static void ShowWindow()
        {
            PixelAnimator wnd = GetWindow<PixelAnimator>();
            wnd.titleContent = new GUIContent("Pixel Animator");
        }
        List<AnimNode> animNodes = new List<AnimNode>();
        public void CreateGUI()
        {
            animNodes.Add(new AnimNode());
        }
        private void Update()
        {
            if (movableNode is null &&
                (Event.current.type == EventType.MouseDown) &&
                Event.current.button == 0)
            {
                foreach (var node in animNodes)
                {
                    if (node.windowRect.Contains(Event.current.mousePosition))
                    {
                        movableNode = node;
                        break;
                    }
                }
            }
            else if (movableNode is not null &&
                Event.current.type == EventType.MouseUp &&
                Event.current.button == 0)
                movableNode = null;
        }
        private void OnGUI()
        {
            renderNodes();
            if (movableNode is not null){
                movableNode.windowRect.position += Event.current.delta;
            }
            //GUI.DragWindow();
        }
        void renderNodes()
        {
            foreach(var node in animNodes)
                renderNode(node);
        }
        void renderNode(AnimNode node)
        {
            GUILayout.BeginArea(node.windowRect);
            GUI.Box(new(Vector2.zero, node.windowRect.size), "");
            node.OnGUI();
            GUILayout.EndArea();
        }
    }
}