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
        // Gameplay
        m_Gameplay = asset.GetActionMap("Gameplay");
        m_Gameplay_Movement = m_Gameplay.GetAction("Movement");
        m_Gameplay_Punches = m_Gameplay.GetAction("Punches");
        m_Initialized = true;
    }
    private void Uninitialize()
    {
        if (m_GameplayActionsCallbackInterface != null)
        {
            Gameplay.SetCallbacks(null);
        }
        m_Gameplay = null;
        m_Gameplay_Movement = null;
        m_Gameplay_Punches = null;
        m_Initialized = false;
    }
    public void SetAsset(InputActionAsset newAsset)
    {
        if (newAsset == asset) return;
        var GameplayCallbacks = m_GameplayActionsCallbackInterface;
        if (m_Initialized) Uninitialize();
        asset = newAsset;
        Gameplay.SetCallbacks(GameplayCallbacks);
    }
    public override void MakePrivateCopyOfActions()
    {
        SetAsset(ScriptableObject.Instantiate(asset));
    }
    // Gameplay
    private InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private InputAction m_Gameplay_Movement;
    private InputAction m_Gameplay_Punches;
    public struct GameplayActions
    {
        private PlayerControls m_Wrapper;
        public GameplayActions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement { get { return m_Wrapper.m_Gameplay_Movement; } }
        public InputAction @Punches { get { return m_Wrapper.m_Gameplay_Punches; } }
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                Movement.cancelled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                Punches.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPunches;
                Punches.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPunches;
                Punches.cancelled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPunches;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
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
    public GameplayActions @Gameplay
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new GameplayActions(this);
        }
    }
}
public interface IGameplayActions
{
    void OnMovement(InputAction.CallbackContext context);
    void OnPunches(InputAction.CallbackContext context);
}
