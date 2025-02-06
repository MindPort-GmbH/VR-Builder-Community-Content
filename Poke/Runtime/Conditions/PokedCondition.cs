using System;
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
    /// Condition which is completed when PokeableProperty is poked.
    /// </summary>
    [DataContract(IsReference = true)]
    [HelpLink("https://www.mindport.co/vr-builder/manual/default-conditions/poke-object")] // TODO: Create docu
    public class PokedCondition : Condition<PokedCondition.EntityData>
    {
        [DisplayName("Poke Object")]
        public class EntityData : IConditionData
        {
#if CREATOR_PRO     
            [CheckForCollider] 
#endif
            [DataMember]
            [DisplayName("Object")]
            public SingleScenePropertyReference<IPokeableProperty> PokeableProperty { get; set; }

            public bool IsCompleted { get; set; }

            [DataMember]
            [HideInProcessInspector]
            public string Name { get; set; }

            public Metadata Metadata { get; set; }
        }

        private class ActiveProcess : BaseActiveProcessOverCompletable<EntityData>
        {
            public ActiveProcess(EntityData data) : base(data)
            {
            }

            protected override bool CheckIfCompleted()
            {
                return Data.PokeableProperty.Value.IsBeingPoked;
            }
        }

        private class EntityAutocompleter : Autocompleter<EntityData>
        {
            public EntityAutocompleter(EntityData data) : base(data)
            {
            }

            public override void Complete()
            {
                Data.PokeableProperty.Value.FastForwardTouch();
            }
        }

        [JsonConstructor, Preserve]
        public PokedCondition() : this(Guid.Empty)
        {
        }

        // ReSharper disable once SuggestBaseTypeForParameter
        public PokedCondition(IPokeableProperty target, string name = null) : this(ProcessReferenceUtils.GetUniqueIdFrom(target), name)
        {
        }

        public PokedCondition(Guid target, string name = "Poke Object")
        {
            Data.PokeableProperty = new SingleScenePropertyReference<IPokeableProperty>(target);
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