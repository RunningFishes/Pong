using RunningFishes.Pong.Score;
using RunningFishes.Pong.State;
using System;
using UnityEngine;

namespace RunningFishes.Pong.Ball
{
    public class BallController : MonoBehaviour
    {
        /// <summary>
        /// Event raised when ball data is received.
        /// Vector3 is the position of the ball.
        /// Vector2 is the speed of the ball.
        /// </summary>
        public event Action<Vector3, Vector2> OnBallDataReceived;

        [SerializeField]
        private Balls ball;

        [SerializeField]
        private BallMovementController ballMovementController;

        public void Init(StateController stateController, ScoreController scoreController)
        {
            ball.Init(this, stateController, scoreController);
            ballMovementController.Init(stateController);
        }

        public void Dispose()
        {
            ball.Dispose();
            ballMovementController.Dispose();
        }

        public void RaiseBallDataReceive(Vector3 position, Vector2 velocity)
        {
            OnBallDataReceived?.Invoke(position, velocity);
        }
    }
}