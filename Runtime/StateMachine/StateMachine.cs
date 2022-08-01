using SimpleMan.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;


namespace SimpleMan.StateMachine
{
    /// <summary>
    /// Supports to handle and switch the states. 
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public sealed class StateMachine<TContext>
    {
        //------FIELDS
        private readonly StateData<TContext>[] _stateDatas;




        //------PROPERTIES
        /// <summary>
        /// Should state machine print logs on state changing?
        /// </summary>
        public bool PrintLogs { get; set; } = true;

        /// <summary>
        /// Owner of the current state machine
        /// </summary>
        public TContext Context { get; private set; }
        public IReadOnlyList<State<TContext>> States
        {
            get
            {
                List<State<TContext>> result = new List<State<TContext>>(_stateDatas.Length);
                for (int i = 0; i < _stateDatas.Length; i++)
                {
                    result.Add(_stateDatas[i].state);
                }

                return result;
            }
        }
        public int CurrentStateIndex { get; private set; }
        public int PreviousStateIndex { get; private set; }
        public State<TContext> CurrentState
        {
            get => CurrentStateIndex == -1 ? null : _stateDatas[CurrentStateIndex].state;
        }
        public State<TContext> PreviousState
        {
            get => PreviousStateIndex == -1 ? null : _stateDatas[PreviousStateIndex].state;
        }





        //------CONSTRUCTORS
        public StateMachine(TContext context, params State<TContext>[] states)
        {
            Context = context;
            _stateDatas = new StateData<TContext>[states.Length];

            states = states.NullCheck(
                "Null referenced state detected. Check arguments, that " +
                "you gave into the state machine's constructor").ToArray();

            for (int i = 0; i < states.Length; i++)
            {
                _stateDatas[i] = new StateData<TContext>(states[i], 0);
                states[i].Context = context;
                states[i].MachineOwner = this;
            }
        }

        public StateMachine(TContext context, params StateData<TContext>[] datas)
        {
            Context = context;

            for (int i = 0; i < datas.Length; i++)
            {
                if(datas[i].state == null)
                {
                    throw new System.NullReferenceException(
                        "Null referenced state detected. Check arguments, that " +
                        "you gave into the state machine's constructor");
                }

                datas[i].state.Context = context;
                datas[i].state.MachineOwner = this;
            }

            _stateDatas = datas;
            StartTickAsync();
        }





        //------METHODS
        /// <summary>
        /// Automatically stop current state and start new one
        /// </summary>
        /// <param name="id">Indexes (ID's) of states you can gen from 'States' list</param>
        /// <exception cref="System.IndexOutOfRangeException"></exception>
        public void SwitchState(int id)
        {
            if (id < 0 || id >= _stateDatas.Length)
            {
                throw new System.IndexOutOfRangeException(
                    $"<b>{Context.ToString()}:</b> State ID should be in valid range. State at index " +
                    $"'{id}' not exist");
            }

            PreviousStateIndex = CurrentStateIndex;
            CurrentStateIndex = id;

            PreviousState?.Stop();
            CurrentState?.Start();

            if (PrintLogs)
            {
                string contextName = Context == null ? "Independent state machine" : Context.ToString();
                Debug.Log($"<b>{contextName}:</b> switched state from '{PreviousState}' to '{CurrentState}'");
            }
        }

        /// <summary>
        /// Automatically stop current state and start new one
        /// </summary>
        /// <typeparam name="TState"></typeparam>
        /// <exception cref="System.NullReferenceException">If state of given type not exist on the states list</exception>
        public void SwitchState<TState>() where TState : State<TContext>
        {
            int id = -1;
            for (int i = 0; i < _stateDatas.Length; i++)
            {
                if(_stateDatas[i].state is TState)
                {
                    id = i;
                    break;
                }
            }

            if(id == -1)
            {
                throw new System.NullReferenceException(
                    $"<b>{Context.ToString()}:</b> state of type '{typeof(TState)}' " +
                    $"not exist. You can check added states with '{nameof(States)}' property");
            }

            SwitchState(id);
        }

        private async void StartTickAsync()
        {
            while (true)
            {
                if (!Application.isPlaying)
                    break;

                CurrentState?.Tick();

                StateData<TContext> currentStateData = _stateDatas[CurrentStateIndex];
                if(currentStateData.tickRate <= 0)
                {
                    await Task.Yield();
                }
                else
                {
                    await Task.Delay((int)(currentStateData.tickRate * 1000));
                }   
            }
        }
    }
}