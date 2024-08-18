using System;
using Godot;

namespace GMTKGJ2024.Scripts;

public static class Utils
{
    public static T GetParentOfType<T>(this Node n)
    {
        Node currentNode = n;
        T targetParent = default(T);
        while (currentNode != null)
        {
            if (currentNode is T node)
            {
                targetParent = node;
                break;
            }

            currentNode = currentNode.GetParent();
        }

        if (targetParent == null)
        {
            throw new NullReferenceException($"No parent {nameof(T)} found: Please attach this script to a descendant of {nameof(T)}!");
        }

        return targetParent;
    }
}