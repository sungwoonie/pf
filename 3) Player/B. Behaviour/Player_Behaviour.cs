using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Player_Behaviour : SingleTon<Player_Behaviour>
    {
        [HideInInspector]public Animation_Behaviour animation_behaviour;
        [HideInInspector]public Player_Stat_Manager stat_manager;

        [HideInInspector]public State_Context state_context;
        [HideInInspector]public IState combat_state, idle_state;

        #region "Event Bus"

        private void Initialize_EventBus()
        {
            Event_Bus.Subscribe_Event(Event_Type.Stop, EventBus_Idle);
            Event_Bus.Subscribe_Event(Event_Type.Start_Running, EventBus_Idle);
            Event_Bus.Subscribe_Event(Event_Type.Start_Combat, EventBus_Combat);
        }

        private void EventBus_Idle()
        {
            state_context.Transition(idle_state);
        }

        private void EventBus_Combat()
        {
            state_context.Transition(combat_state);
        }

        #endregion

        #region "State"

        private void Initialize_State_Pattern()
        {
            state_context = new State_Context(transform);
            idle_state = GetComponent<Idle_State>();
            combat_state = GetComponent<Combat_State>();
        }

        #endregion

        protected override void Awake()
        {
            base.Awake();

            animation_behaviour = gameObject.AddComponent<Animation_Behaviour>();
            stat_manager = GetComponent<Player_Stat_Manager>();

            Initialize_State_Pattern();
            Initialize_EventBus();
        }
    }
}