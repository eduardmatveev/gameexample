using Data;
using Model;
using Utils;
using View;
using UnityEngine;

public class GameApplication : MonoBehaviour
{
    private GameNetworkBase _network;
    private GameModel _model;
    private GamePresenter _presenter;
    [SerializeField]
    private GameView _view;

    private void Awake()
    {
        DataLibrary.Insert(AssetLibrary.GetTextByPath("Configs/Resources.json").text);
        
        _network = new GameNetworkMock();
        _model = new GameModel(_network);
        _presenter = new GamePresenter(_model);
        _presenter.Attach(_view);
    }

    private void Update()
    {
        _model.Update();
        _presenter.Update();
    }
    
    private void OnDestroy()
    {
        _presenter.Detach();
        _presenter = null;
        _model.Destroy();
        _model = null;
        _network = null;
    }
}