using Photon.Pun;
using RunningFishes.Pong.Ball;
using RunningFishes.Pong.Constant;
using RunningFishes.Pong.Multiplayer;
using RunningFishes.Pong.Players;
using RunningFishes.Pong.Score;
using RunningFishes.Pong.State;
using RunningFishes.Pong.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RunningFishes.Pong.Gameplay
{
    public class GameController : MonoBehaviourPunCallbacks
    {
        public static GameController instance { get; private set; }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            Init();
        }

        [SerializeField]
        private PlayerController playerController;

        public PlayerController PlayerController => playerController;

        [SerializeField]
        private BallController ballController;

        public BallController BallController => ballController;

        [SerializeField]
        private ScoreController scoreController;

        public ScoreController ScoreController => scoreController;

        [SerializeField]
        private UIController uiController;

        public UIController UIController => uiController;

        private MultiplayerController multiplayerController;
        private StateController stateController;

        public void Init()
        {
            stateController = new StateController();
            scoreController.Init(stateController);
            playerController.Init();
            ballController.Init(stateController, scoreController);
            multiplayerController = new MultiplayerController();
            uiController.Init(scoreController, stateController);
        }

        public void OnDestroy()
        {
            stateController?.Dispose();
            scoreController?.Dispose();
            playerController?.Dispose();
            ballController.Dispose();
            multiplayerController?.Dispose();
            uiController?.Dispose();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PhotonNetwork.LeaveRoom();
            }
        }

        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(SceneName.Lobby);
            base.OnLeftRoom();
        }
    }
}