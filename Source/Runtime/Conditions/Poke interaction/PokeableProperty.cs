using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using VRBuilder.Core.Properties;
using VRBuilder.BasicInteraction.Properties;
using System.Linq;
using UnityEngine.XR.Interaction.Toolkit.Filtering;

namespace VRBuilder.XRInteraction.Properties
{ 
    /// <summary>
    /// XR implementation of <see cref="IPokeableProperty"/>.
    /// </summary>
    [RequireComponent(typeof(XRSimpleInteractable))]
    [RequireComponent(typeof(XRPokeFilter))]
    public class PokeableProperty : LockableProperty, IPokeableProperty
    {
        public event EventHandler<EventArgs> Poked;
        public event EventHandler<EventArgs> Unpoked;

        /// <summary>
        /// Returns true if the GameObject is touched.
        /// </summary>
        public virtual bool IsBeingPoked => Interactable != null && Interactable.interactorsSelecting.Any(i => i.transform.root.GetComponentInChildren<UserSceneObject>() != null);

        protected XRSimpleInteractable Interactable
        {
            get
            {
                if (interactable == false)
                {
                    interactable = GetComponent<XRSimpleInteractable>();
                }

                return interactable;
            }
        }

        private XRSimpleInteractable interactable;

        protected override void OnEnable()
        {
            base.OnEnable();
            
            Interactable.selectEntered.AddListener(HandleXRPoked);
            Interactable.selectExited.AddListener(HandleXRUnpoked);

            InternalSetLocked(IsLocked);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            
            Interactable.selectEntered.RemoveListener(HandleXRPoked);
            Interactable.selectExited.RemoveListener(HandleXRUnpoked);
        }
        
        protected void Reset()
        {
            // TODO: Anything to do here?
        }

        private void HandleXRPoked(SelectEnterEventArgs arguments)
        {
            if (arguments.interactorObject.transform.root.GetComponentInChildren<UserSceneObject>() != null)
            {
                EmitPoked();
            }
        }

        private void HandleXRUnpoked(SelectExitEventArgs arguments)
        {
            if (arguments.interactorObject.transform.root.GetComponentInChildren<UserSceneObject>() != null)
            {
                EmitUnpoked();
            }            
        }

        protected void EmitPoked()
        {
            Poked?.Invoke(this, EventArgs.Empty);
        }

        protected void EmitUnpoked()
        {
            Unpoked?.Invoke(this, EventArgs.Empty);
        }

        protected override void InternalSetLocked(bool lockState)
        {
            // TODO: Implement locking
        }

        /// <inheritdoc />
        public void FastForwardTouch()
        {
            if (IsBeingPoked)
            {
                // TODO: Implement force stop interacting
            }
            else
            {
                EmitPoked();
                EmitUnpoked();
            }
        }
    }
}