using System;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using VRBuilder.Core.Properties;
using VRBuilder.Core.SceneObjects;

namespace VRBuilder.Community
{ 
    /// <summary>
    /// XR implementation of <see cref="IGazeableProperty"/>.
    /// </summary>
    [RequireComponent(typeof(XRSimpleInteractable))]

    public class GazeableProperty : LockableProperty, IGazeableProperty
    {
        public event EventHandler<EventArgs> Gazed;
        public event EventHandler<EventArgs> Ungazed;

        /// <summary>
        /// Returns true if the GameObject is touched.
        /// </summary>
        
        
        public virtual bool IsBeingLookedAt => Interactable != null && Interactable.interactorsSelecting.Any(i => i.transform.root.GetComponentInChildren<UserSceneObject>() != null);

        protected XRSimpleInteractable Interactable
        {
            get
            {
                if (interactable == false)
                {
                    interactable = GetComponent<XRSimpleInteractable>();
                }

                interactable.allowGazeSelect = true;
                interactable.allowGazeInteraction = true;
                interactable.overrideGazeTimeToSelect = true;
                interactable.gazeTimeToSelect = TimeToTrigger;

                return interactable;
            }
        }

        public float TimeToTrigger { get; set ; }

        private XRSimpleInteractable interactable;

        protected override void OnEnable()
        {
            base.OnEnable();
            
            Interactable.selectEntered.AddListener(HandleXRGazed);
            Interactable.selectExited.AddListener(HandleXRUngazed);

            InternalSetLocked(IsLocked);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            
            Interactable.selectEntered.RemoveListener(HandleXRGazed);
            Interactable.selectExited.RemoveListener(HandleXRUngazed);
        }
        
        protected override void Reset()
        {
            // TODO: Anything to do here?
        }

        private void HandleXRGazed(SelectEnterEventArgs arguments)
        {
            if (arguments.interactorObject.transform.root.GetComponentInChildren<UserSceneObject>() != null)
            {
                EmitGaze();
            }
        }

        private void HandleXRUngazed(SelectExitEventArgs arguments)
        {
            if (arguments.interactorObject.transform.root.GetComponentInChildren<UserSceneObject>() != null)
            {
                EmitUngaze();
            }            
        }

        protected void EmitGaze()
        {
            Gazed?.Invoke(this, EventArgs.Empty);
        }

        protected void EmitUngaze()
        {
            Ungazed?.Invoke(this, EventArgs.Empty);
        }

        protected override void InternalSetLocked(bool lockState)
        {
            // TODO: Implement locking
        }

        /// <inheritdoc />
        public void FastForwardLookAt()
        {
            if (IsBeingLookedAt)
            {
                // TODO: Implement force stop interacting
            }
            else
            {
                EmitGaze();
                EmitUngaze();
            }
        }
    }
}