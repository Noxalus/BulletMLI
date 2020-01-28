﻿using BulletMLI.Nodes;
using System.Diagnostics;

namespace BulletMLI.Tasks
{
    /// <summary>
    /// This task sets the direction of a bullet
    /// </summary>
    public class DirectionTask : BulletMLTask
    {
        #region Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectionTask"/> class.
        /// </summary>
        /// <param name="node">Node.</param>
        /// <param name="owner">Owner.</param>
        public DirectionTask(DirectionNode node, BulletMLTask owner) : base(node, owner)
        {
            Debug.Assert(null != Node);
            Debug.Assert(null != Owner);
        }

        #endregion Methods
    }
}