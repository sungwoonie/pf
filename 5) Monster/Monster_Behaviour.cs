using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Monster
{
    public class Monster_Behaviour : MonoBehaviour
    {
        public Monster_Scriptable stat;
        public Animation_Behaviour animation_behaviour;
        public double current_health;

        [HideInInspector] public State_Context state_context;
        [HideInInspector] public IState run_state, die_state, combat_state;

        private void Awake()
        {
            animation_behaviour = GetComponent<Animation_Behaviour>();

            Initialize_State_Pattern();
        }

        private void OnEnable()
        {

        }

        public void Run()
        {
            Event_Bus.Publish(Event_Type.Start_Running);
            state_context.Transition(run_state);
        }

        private void Initialize_State_Pattern()
        {
            state_context = new State_Context(transform);

            run_state = GetComponent<Run_State>();
            die_state = GetComponent<Die_State>();
            combat_state = GetComponent<Combat_State>();
        }

        public void Initialize_Monster(Monster_Scriptable monster_stat)
        {
            stat = monster_stat;
            current_health = monster_stat.max_health;
        }
    }
}