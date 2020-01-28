using BulletMLI.Enums;
using BulletMLI.Nodes;
using System.Diagnostics;

namespace BulletMLI.Tasks
{
    /// <summary>
    /// This task removes a bullet from the game.
    /// </summary>
    public class VanishTask : BulletMLTask
    {
        #region Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="VanishTask"/> class.
        /// </summary>
        /// <param name="node">Node.</param>
        /// <param name="owner">Owner.</param>
        public VanishTask(VanishNode node, BulletMLTask owner) : base(node, owner)
        {
            Debug.Assert(null != Node);
            Debug.Assert(null != Owner);
        }

        /// <summary>
        /// Run this task and all subtasks against a bullet.
        /// This is called once a frame during runtime.
        /// </summary>
        /// <returns>TaskRunStatus: whether this task is done, paused, or still running.</returns>
        /// <param name="bullet">The bullet to update this task against.</param>
        public override TaskRunStatus Run(Bullet bullet)
        {
            // Remove the bullet via the bullet manager interface
            var manager = bullet.BulletManager;
            Debug.Assert(null != manager);
            manager.RemoveBullet(bullet);

            return TaskRunStatus.End;
        }

        #endregion Methods
    }
}