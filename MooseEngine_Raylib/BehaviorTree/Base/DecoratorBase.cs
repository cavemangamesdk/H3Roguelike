﻿using MooseEngine.BehaviorTree.Interfaces;

namespace MooseEngine.BehaviorTree.Base
{
    public abstract class DecoratorBase : NodeBase, IDecorator
    {
        public INode? Child { get; set; }

        public DecoratorBase() : base() { }

        public DecoratorBase(INode node) : base()
        {
            node.Root = Root;
            node.Parent = this;
            Child = node;
        }

        public override INode Add(INode node)
        {
            node.Root = Root;
            node.Parent = this;
            Child = node;

            return this;
        }

        public override string ToString()
        {
            return base.ToString() + $" Child: {Child}";
        }
    }
}