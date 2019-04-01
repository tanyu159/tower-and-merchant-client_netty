using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : BaseManager {
   // public User currentLoginedUser;
    public UserSave currentLoginedUserSave;
    public PlayerManager(GameFacade gameFacade) : base(gameFacade)
    {
    }
}
