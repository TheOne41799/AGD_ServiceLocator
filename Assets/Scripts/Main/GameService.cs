using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ServiceLocator.Utilities;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.UI;
using ServiceLocator.Wave;
using ServiceLocator.Map;
using ServiceLocator.Events;

public class GameService : GenericMonoSingleton<GameService>
{
    public PlayerService playerService { get; private set; }
    public SoundService soundService { get; private set; }
    public WaveService waveService { get; private set; }
    public MapService mapService { get; private set; }
    public EventService eventService { get; private set; }

    [SerializeField] private UIService uiService;
    public UIService UIService => uiService;


    [SerializeField] private PlayerScriptableObject playerScriptableObject;

    [SerializeField] private SoundScriptableObject soundScriptableObject;

    [SerializeField] private WaveScriptableObject waveScriptableObject;

    [SerializeField] private MapScriptableObject mapScriptableObject;

    [SerializeField] private AudioSource audioEffects;
    [SerializeField] private AudioSource backgroundMusic;


    private void Start()
    {
        eventService = new EventService();

        UIService.SubscribeToEvents();

        mapService = new MapService(mapScriptableObject);        
        
        waveService = new WaveService(waveScriptableObject);

        soundService = new SoundService(soundScriptableObject, audioEffects, backgroundMusic);

        playerService = new PlayerService(playerScriptableObject);

    }

    private void Update()
    {
        playerService.Update();
    }
}
