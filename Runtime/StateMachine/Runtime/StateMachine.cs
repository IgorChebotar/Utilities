using SimpleMan.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace SimpleMan.StateMechine
{
    public sealed class StateMachine<TContext>
    {
        //------FIELDS
        public readonly Dictionary<Type, BaseState<TContext>> states;
        public readonly float tickRate = 0;




        //------PROPERTIES
        public bool PrintLogs { get; set; }
        public TContext Context { get; private set; }
        public BaseState<TContext> CurrentState { get; private set; }





        //------METHODS
        public StateMachine(TContext context, params BaseState<TContext>[] states)
        {
            Context = context;

            this.states = new Dictionary<Type, BaseState<TContext>>(states.Length);
            foreach (var state in states)
            {
                this.states.Add(state.GetType(), state);
            }

            TickAsync();
        }

        public StateMachine(TContext context, float tickRate, params BaseState<TContext>[] states)
        {
            Context = context;
            this.tickRate = tickRate.ClampPositive();

            this.states = new Dictionary<Type, BaseState<TContext>>(states.Length);
            foreach (var state in states)
            {
                this.states.Add(state.GetType(), state);
            }

            TickAsync();
        }

        public void SwitchState<TState>() where TState : State<TContext>
        {
            CurrentState?.Stop();
            BaseState<TContext> previousState = CurrentState;


            TState newState = GetState<TState>();
            CurrentState = newState;


            PrintStateChangedLog(previousState, newState);
            newState.Start();
        }

        public void SwitchState<TState, T0>(T0 arg0) where TState : StateOneParam<TContext, T0>
        {
            CurrentState?.Stop();
            BaseState<TContext> previousState = CurrentState;


            TState newState = GetState<TState>();
            CurrentState = newState;


            PrintStateChangedLog(previousState, newState);
            newState.Start(arg0);
        }

        public void SwitchState<TState, T0, T1>(T0 arg0, T1 arg1) where TState : StateTwoParams<TContext, T0, T1>
        {
            CurrentState?.Stop();
            BaseState<TContext> previousState = CurrentState;


            TState newState = GetState<TState>();
            CurrentState = newState;


            PrintStateChangedLog(previousState, newState);
            newState.Start(arg0, arg1);
        }

        public void SwitchState<TState, T0, T1, T3>(T0 arg0, T1 arg1, T3 arg3) where TState : StateThreeParams<TContext, T0, T1, T3>
        {
            CurrentState?.Stop();
            BaseState<TContext> previousState = CurrentState;


            TState newState = GetState<TState>();
            CurrentState = newState;


            PrintStateChangedLog(previousState, newState);
            newState.Start(arg0, arg1, arg3);
        }

        private async void TickAsync()
        {
            while (true)
            {
                if (!Application.isPlaying)
                    break;

                if (tickRate == 0)
                    await Task.Yield();

                else
                    await Task.Delay((int)(tickRate * 1000));

                CurrentState?.Tick();
            }
        }

        private TState GetState<TState>() where TState : BaseState<TContext>
        {
            if(!states.ContainsKey(typeof(TState)))
            {
                throw new System.ArgumentException(
                    $"This state machine doesn't contains the '{typeof(TState).Name}' state");
            }
            return states[typeof(TState)] as TState;
        }

        private void PrintStateChangedLog(BaseState<TContext> previousState, BaseState<TContext> currentState)
        {
            if (!PrintLogs)
                return;

            string GetStateName(BaseState<TContext> state)
            {
                return state == null ? "None" : state.GetType().Name;
            }
            Debug.Log($"<b>{typeof(TContext).Name}</b>: State changed from '<b>{GetStateName(previousState)}</b>' to '<b>{GetStateName(currentState)}</b>'");
        }
    }
}