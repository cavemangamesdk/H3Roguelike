﻿using GameV1.BehaviorTree.Base;

namespace GameV1.BehaviorTree.Decorators
{
    public class Repeater : DecoratorBase
    {
        private static int m_currentRepeats;
        private int m_numRepeats;

        public Repeater(int numRepeats)
        {
            Reset();
            m_numRepeats = numRepeats;
        }

        public override NodeStates Evaluate()
        {
            if (m_currentRepeats < m_numRepeats || m_numRepeats < 0)
            {
                Console.WriteLine($"Repeater evaluating... {m_currentRepeats}");

                Child?.Evaluate();

                m_currentRepeats++;

                State = NodeStates.Running;
                return State;
            }
            else
            {
                Reset();

                State = NodeStates.Success;  // TODO: Return Child state or Success?
                return State;
            }
        }

        public void Reset()
        {
            m_currentRepeats = 0;
        }
    }
}
