﻿using BulletML.Enums;
using BulletML.Nodes;
using BulletML;
using System.Diagnostics;

namespace BulletML.Tasks
{
    /// <summary>
    /// This task adds acceleration to a bullet.
    /// </summary>
    public class AccelTask : BulletMLTask
    {
        #region Members

        /// <summary>
        /// How long to run this task... measured in frames
        /// </summary>
        public float Duration { get; private set; }

        /// <summary>
        /// The direction to accelerate in
        /// </summary>
        private Vector2 _acceleration = Vector2.Zero;

        /// <summary>
        /// Gets or sets the acceleration.
        /// </summary>
        /// <value>The acceleration.</value>
        public Vector2 Acceleration
        {
            get
            {
                return _acceleration;
            }
            private set
            {
                _acceleration = value;
            }
        }

        #endregion Members

        #region Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="BulletMLTask"/> class.
        /// </summary>
        /// <param name="node">Node.</param>
        /// <param name="owner">Owner.</param>
        public AccelTask(AccelNode node, BulletMLTask owner) : base(node, owner)
        {
            Debug.Assert(null != Node);
            Debug.Assert(null != Owner);
        }

        /// <summary>
        /// this sets up the task to be run.
        /// </summary>
        /// <param name="bullet">bullet.</param>
        protected override void SetupTask(Bullet bullet)
        {
            //set the accelerataion we are gonna add to the bullet
            Duration = Node.GetChildValue(NodeName.term, this, bullet);

            //check for divide by 0
            if (0.0f == Duration)
            {
                Duration = 1.0f;
            }

            //Get the horizontal node
            HorizontalNode horiz = Node.GetChild(NodeName.horizontal) as HorizontalNode;
            if (null != horiz)
            {
                //Set the x component of the acceleration
                switch (horiz.NodeType)
                {
                    case NodeType.sequence:
                        {
                            //Sequence in an acceleration node means "add this amount every frame"
                            _acceleration.X = horiz.GetValue(this);
                        }
                        break;

                    case NodeType.relative:
                        {
                            //accelerate by a certain amount
                            _acceleration.X = horiz.GetValue(this) / Duration;
                        }
                        break;

                    default:
                        {
                            //accelerate to a specific value
                            _acceleration.X = (horiz.GetValue(this) - bullet.Acceleration.X) / Duration;
                        }
                        break;
                }
            }

            //Get the vertical node
            VerticalNode vert = Node.GetChild(NodeName.vertical) as VerticalNode;
            if (null != vert)
            {
                //set teh y component of the acceleration
                switch (vert.NodeType)
                {
                    case NodeType.sequence:
                        {
                            //Sequence in an acceleration node means "add this amount every frame"
                            _acceleration.Y = vert.GetValue(this);
                        }
                        break;

                    case NodeType.relative:
                        {
                            //accelerate by a certain amount
                            _acceleration.Y = vert.GetValue(this) / Duration;
                        }
                        break;

                    default:
                        {
                            //accelerate to a specific value
                            _acceleration.Y = (vert.GetValue(this) - bullet.Acceleration.Y) / Duration;
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Run this task and all subtasks against a bullet
        /// This is called once a frame during runtime.
        /// </summary>
        /// <returns>TaskRunStatus: whether this task is done, paused, or still running</returns>
        /// <param name="bullet">The bullet to update this task against.</param>
        public override TaskRunStatus Run(Bullet bullet)
        {
            //Add the acceleration to the bullet
            bullet.Acceleration += Acceleration;

            // Decrement the amount if time left to run and return End when this task is finished
            Duration--;
            if (Duration <= 0.0f)
            {
                Finished = true;
                return TaskRunStatus.End;
            }
            else
            {
                // Since this task isn't finished, run it again next time
                return TaskRunStatus.Continue;
            }
        }

        #endregion Methods
    }
}