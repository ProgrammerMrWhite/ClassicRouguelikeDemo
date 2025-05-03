using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using ClassicRoguelikeCourse.entities;
using IComponent = ClassicRoguelikeCourse.components.IComponent;

public partial class Character : Node2D, IEntity
{
    protected List<IComponent> _components = new();

    public virtual void Initialize()
    {
        var children = GetChildren();
        foreach (var child in children)
        {
            if (child is IComponent)
            {
                var component = child as IComponent;
                component.Initialize();
                _components.Add(component);
            }
        }
    }

    public virtual void Run()
    {
        foreach (var component in _components)
        {
            component.Run();
        }
    }
}