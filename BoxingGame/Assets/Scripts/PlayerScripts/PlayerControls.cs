// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using UnityEngine;
using UnityEngine.Experimental.Input;


[Serializable]
public class PlayerControls : InputActionAssetReference
{
    public PlayerControls()
    {
    }
    public PlayerControls(InputActionAsset asset)
        : base(asset)
    {
    }
    private bool m_Initialized;
    private void Initialize()
    {
        // Player 1
        m_Player1 = asset.GetActionMap("Player 1");
        m_Player1_Movement = m_Player1.GetAction("Movement");
        m_Player1_Punches = m_Player1.GetAction("Punches");
        // Player 2
        m_Player2 = asset.GetActionMap("Player 2");
        m_Player2_Movement = m_Player2.GetAction("Movement");
        m_Player2_Punches = m_Player2.GetAction("Punches");
        m_Initialized = true;
    }
    private void Uninitialize()
    {
        if (m_Player1ActionsCallbackInterface != null)
        {
            Player1.SetCallbacks(null);
        }
        m_Player1 = null;
        m_Player1_Movement = null;
        m_Player1_Punches = null;
        if (m_Player2ActionsCallbackInterface != null)
        {
            Player2.SetCallbacks(null);
        }
        m_Player2 = null;
        m_Player2_Movement = null;
        m_Player2_Punches = null;
        m_Initialized = false;
    }
    public void SetAsset(InputActionAsset newAsset)
    {
        if (newAsset == asset) return;
        var Player1Callbacks = m_Player1ActionsCallbackInterface;
        var Player2Callbacks = m_Player2ActionsCallbackInterface;
        if (m_Initialized) Uninitialize();
        asset = newAsset;
        Player1.SetCallbacks(Player1Callbacks);
        Player2.SetCallbacks(Player2Callbacks);
    }
    public override void MakePrivateCopyOfActions()
    {
        SetAsset(ScriptableObject.Instantiate(asset));
    }
    // Player 1
    private InputActionMap m_Player1;
    private IPlayer1Actions m_Player1ActionsCallbackInterface;
    private InputAction m_Player1_Movement;
    private InputAction m_Player1_Punches;
    public struct Player1Actions
    {
        private PlayerControls m_Wrapper;
        public Player1Actions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement { get { return m_Wrapper.m_Player1_Movement; } }
        public InputAction @Punches { get { return m_Wrapper.m_Player1_Punches; } }
        public InputActionMap Get() { return m_Wrapper.m_Player1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(Player1Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer1Actions instance)
        {
            if (m_Wrapper.m_Player1ActionsCallbackInterface != null)
            {
                Movement.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMovement;
                Movement.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMovement;
                Movement.cancelled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMovement;
                Punches.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnPunches;
                Punches.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnPunches;
                Punches.cancelled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnPunches;
            }
            m_Wrapper.m_Player1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                Movement.started += instance.OnMovement;
                Movement.performed += instance.OnMovement;
                Movement.cancelled += instance.OnMovement;
                Punches.started += instance.OnPunches;
                Punches.performed += instance.OnPunches;
                Punches.cancelled += instance.OnPunches;
            }
        }
    }
    public Player1Actions @Player1
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new Player1Actions(this);
        }
    }
    // Player 2
    private InputActionMap m_Player2;
    private IPlayer2Actions m_Player2ActionsCallbackInterface;
    private InputAction m_Player2_Movement;
    private InputAction m_Player2_Punches;
    public struct Player2Actions
    {
        private PlayerControls m_Wrapper;
        public Player2Actions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement { get { return m_Wrapper.m_Player2_Movement; } }
        public InputAction @Punches { get { return m_Wrapper.m_Player2_Punches; } }
        public InputActionMap Get() { return m_Wrapper.m_Player2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(Player2Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer2Actions instance)
        {
            if (m_Wrapper.m_Player2ActionsCallbackInterface != null)
            {
                Movement.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMovement;
                Movement.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMovement;
                Movement.cancelled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMovement;
                Punches.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnPunches;
                Punches.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnPunches;
                Punches.cancelled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnPunches;
            }
            m_Wrapper.m_Player2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                Movement.started += instance.OnMovement;
                Movement.performed += instance.OnMovement;
                Movement.cancelled += instance.OnMovement;
                Punches.started += instance.OnPunches;
                Punches.performed += instance.OnPunches;
                Punches.cancelled += instance.OnPunches;
            }
        }
    }
    public Player2Actions @Player2
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new Player2Actions(this);
        }
    }
}
public interface IPlayer1Actions
{
    void OnMovement(InputAction.CallbackContext context);
    void OnPunches(InputAction.CallbackContext context);
}
public interface IPlayer2Actions
{
    void OnMovement(InputAction.CallbackContext context);
    void OnPunches(InputAction.CallbackContext context);
}
