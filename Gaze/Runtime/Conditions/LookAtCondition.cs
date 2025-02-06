using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using UnityEngine.Scripting;
using VRBuilder.Core;
using VRBuilder.Core.Attributes;
using VRBuilder.Core.Conditions;
using VRBuilder.Core.SceneObjects;
using VRBuilder.Core.Utils;

namespace VRBuilder.Community
{
    /// <summary>
    /// Condition which is completed when object(s) are gazed for configured time
    /// </summary>
    [DataContract(IsReference = true)]
    public class LookAtCondition : Condition<LookAtCondition.EntityData>
    {
        [DisplayName("Look At Object")]
        public class EntityData : IConditionData
        {
            
#if CREATOR_PRO     
            [CheckForCollider] 
#endif
            [DataMember]
            [DisplayName("Object")]
            public MultipleScenePropertyReference<IGazeableProperty> GazeableProperty { get; set; }

            [DataMember]
            [DisplayName("Time to trigger")]
            public float TimeToTrigger = 1.0f;
            
            [DataMember]
            [DisplayName("Must gaze all objects")]
            public bool MustGazeAllObjects = false;

            public bool IsCompleted { get; set; }

            [DataMember]
            [HideInProcessInspector]
            public string Name { get; set; }

            public Metadata Metadata { get; set; }
        }

        private class ActiveProcess : BaseActiveProcessOverCompletable<EntityData>
        {
            private HashSet<IGazeableProperty> gazedObjects = new HashSet<IGazeableProperty>();
            public ActiveProcess(EntityData data) : base(data)
            {
                foreach (var value in Data.GazeableProperty.Values)
                {
                    value.TimeToTrigger = Data.TimeToTrigger;
                }
            }

            protected override bool CheckIfCompleted()
            {
                if (Data.MustGazeAllObjects)
                {
                    foreach (IGazeableProperty gazeableProperty in Data.GazeableProperty.Values)
                    {
                        if (gazeableProperty.IsBeingLookedAt)
                        {
                            gazedObjects.Add(gazeableProperty);
                        }
                    }       
                    return gazedObjects.Count == Data.GazeableProperty.Values.Count();
                }
                else
                {
                    return Data.GazeableProperty.Values.Any(property => property.IsBeingLookedAt);
                }
            }
        }

        private class EntityAutocompleter : Autocompleter<EntityData>
        {
            public EntityAutocompleter(EntityData data) : base(data)
            {
            }

            public override void Complete()
            {
                Data.GazeableProperty.Values.FirstOrDefault()?.FastForwardLookAt();
            }
        }

        [JsonConstructor, Preserve]
        public LookAtCondition() : this(Guid.Empty)
        {
        }

        // ReSharper disable once SuggestBaseTypeForParameter
        public LookAtCondition(IGazeableProperty target, string name = null) : this(ProcessReferenceUtils.GetUniqueIdFrom(target), name)
        {
        }

        public LookAtCondition(Guid target, string name = "Look At Object")
        {
            Data.GazeableProperty = new MultipleScenePropertyReference<IGazeableProperty>(target);
            Data.Name = name;
        }

        public override IStageProcess GetActiveProcess()
        {
            return new ActiveProcess(Data);
        }

        protected override IAutocompleter GetAutocompleter()
        {
            return new EntityAutocompleter(Data);
        }
    }
}