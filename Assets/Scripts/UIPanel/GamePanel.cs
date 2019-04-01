using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : BasePanel {

    public Text nicknameText;
    public Text baseLevelText;
    public Text coinText;
    public Text diamondText;

    public void SetPlayerInfo(string nickname, byte baselevel, int coin, int diamond)
    {
        nicknameText.text = nickname;
        baseLevelText.text = baselevel.ToString();
        coinText.text = coin.ToString();
        diamondText.text = diamond.ToString();
    }
}
