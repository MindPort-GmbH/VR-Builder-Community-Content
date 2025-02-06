using VRBuilder.Core.SceneObjects;
using VRBuilder.Core.Properties;

namespace VRBuilder.Community
{
    public interface IGazeableProperty : ISceneObjectProperty, ILockable
    {
        /// <summary>
        /// Is object currently touched.
        /// </summary>
        bool IsBeingLookedAt { get; }

        /// <summary>
        /// Time needed for this gazealbe property till the look at is triggered.
        /// </summary>
        float TimeToTrigger { get; set; }
        /// <summary>
        /// Instantaneously simulate that the object was touched.
        /// </summary>
        void FastForwardLookAt();
    }
}