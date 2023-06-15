using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;

public class TestLobby : MonoBehaviour
{

    private Lobby hostLobby;
    private float heartbeatTimer;
    private async void Start()
    {
        await UnityServices.InitializeAsync();

        // sign in user anonymously
        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed in " + AuthenticationService.Instance.PlayerId);
        };

        await AuthenticationService.Instance.SignInAnonymouslyAsync();

    }

    private void Update()
    {
        HandleLobbyHeartbeat();
    }

    //pings the lobby to ensure it does not go inactive
    private async void HandleLobbyHeartbeat() {
        if (hostLobby != null) {
            heartbeatTimer -= Time.deltaTime;
            if (heartbeatTimer < 0f) {
                float heartbeatTimerMax = 15;
                heartbeatTimer = heartbeatTimerMax;

                await LobbyService.Instance.SendHeartbeatPingAsync(hostLobby.Id);
            }
        }
    }

    // creates a lobby
    public async void CreateLobby() {
        try
        {
            string lobbyName = "MyLobby";
            int maxPlayers = 2;
            CreateLobbyOptions createLobbyOptions = new CreateLobbyOptions
            {
                IsPrivate = true,
            };
            Lobby lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, createLobbyOptions);

            hostLobby = lobby;

            Debug.Log("Created Lobby " + lobby.Name + " " + lobby.MaxPlayers + " " + lobby.Id + " " + lobby.LobbyCode);
        }
        catch(LobbyServiceException e) {
            Debug.Log(e);
        }  
    }

    // lists out current active lobbies
    public async void ListLobbies() {
        try
        {
            QueryLobbiesOptions queryLobbiesOptions = new QueryLobbiesOptions
            {
                Count = 25, // get 25 results
                Filters = new List<QueryFilter> {
                    new QueryFilter(QueryFilter.FieldOptions.AvailableSlots, "0", QueryFilter.OpOptions.GT) // at least 1 available slot
                },
                //order by time created
                Order = new List<QueryOrder> {
                    new QueryOrder(false, QueryOrder.FieldOptions.Created)
                }
            };

            QueryResponse queryResponse = await Lobbies.Instance.QueryLobbiesAsync(queryLobbiesOptions);

            Debug.Log("Lobbies found: " + queryResponse.Results.Count);
            foreach (Lobby lobby in queryResponse.Results)
            {
                Debug.Log(lobby.Name + " " + lobby.MaxPlayers);
            }
        }
        catch (LobbyServiceException e) {
            Debug.Log(e);
        }
    }

    // joins a lobby from user code input
    public async void JoinLobbyByCode(TMP_InputField lobbyCode) {
        try {
            string code = lobbyCode.text.ToString();
            await Lobbies.Instance.JoinLobbyByCodeAsync(code);
            Debug.Log("Joined lobby with code " + code);
        }
        catch (LobbyServiceException e)
        {
            Debug.Log(e);
        }
    }

    // joins a random lobby immediately
    public async void QuickJoinLobby() {
        try
        {
            await LobbyService.Instance.QuickJoinLobbyAsync();
            Debug.Log("Joined a lobby!");
        }
        catch (LobbyServiceException e)
        {
            Debug.Log(e);
        }
    }
}
