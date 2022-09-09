﻿using MooseEngine.Core;
using MooseEngine.BehaviorTree.Actions;
using MooseEngine.BehaviorTree.Composites;
using MooseEngine.BehaviorTree.Decorators;
using MooseEngine.BehaviorTree.Interfaces;
using MooseEngine.Interfaces;

namespace MooseEngine.BehaviorTree
{
    public static class BehaviorTreeFactory
    {
        public static IBehaviorTree BehaviorTree(IEntity entity)
        {
            return new BTree(entity);
        }

        public static IBehaviorTree BehaviorTree(IEntity entity, INode rootNode)
        {
            return new BTree(entity, rootNode);
        }

        public static IAction Action(Actions.Delegate @delegate)
        {
            return new ActionDelegate(@delegate);
        }

        public static IAction Action(Command command)
        {
            return new ActionCommand(command);
        }

        public static IDecorator Breakpoint(string message)
        {
            return new Breakpoint(message);
        }

        public static IDecorator Breakpoint(INode node, string message)
        {
            return new Breakpoint(node, message);
        }

        public static IDecorator Delay(int numDelays)
        {
            return new Delay(numDelays);
        }

        public static IDecorator Delay(INode node, int numDelays)
        {
            return new Delay(node, numDelays);
        }

        public static IDecorator Inverter()
        {
            return new Inverter();
        }

        public static IDecorator Inverter(INode node)
        {
            return new Inverter(node);
        }

        public static IDecorator Limiter(int numRepeats)
        {
            return new Limiter(numRepeats);
        }

        public static IDecorator Limiter(INode node, int numRepeats)
        {
            return new Limiter(node, numRepeats);
        }

        public static IDecorator Repeater(int numRepeats)
        {
            return new Repeater(numRepeats);
        }

        public static IDecorator Repeater(INode node, int numRepeats)
        {
            return new Repeater(node, numRepeats);
        }

        public static IComposite Selector()
        {
            return new Selector();
        }

        public static IComposite Selector(params INode[] nodes)
        {
            return new Selector(nodes);
        }

        public static IComposite Sequence()
        {
            return new Sequence();
        }

        public static IComposite Sequence(params INode[] nodes)
        {
            return new Sequence(nodes);
        }

        public static IComposite Serializer()
        {
            return new Serializer();
        }

        public static IComposite Serializer(params INode[] nodes)
        {
            return new Serializer(nodes);
        }
    }
}