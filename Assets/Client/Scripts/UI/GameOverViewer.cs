using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _winnerNameText;
    [SerializeField] private TMP_Text _winnerCoinsText;
    private CanvasGroup _canvasGroup;

    private PhotonView _view;

    private void OnEnable()
    {
        GameManager.OnGameOver += OnGameOver;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= OnGameOver;
    }

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        _view = GetComponent<PhotonView>();
    }

    private void OnGameOver(Photon.Realtime.Player player)
    {
        _view.RPC("ActivateGameOverUI", RpcTarget.All, player);
    }

    public void OnMainMenu()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("Menu");
    }

    public void OnQuit()
    {
        PhotonNetwork.Disconnect();
        Application.Quit();
    }

    [PunRPC]
    private void ActivateGameOverUI(Photon.Realtime.Player player)
    {
        _winnerNameText.text = "Winner name: " + player.NickName;
        _winnerCoinsText.text = "Winner coin count: " + player.CustomProperties["Coins"];
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
    }
}
