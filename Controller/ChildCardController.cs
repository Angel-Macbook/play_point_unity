using UnityEngine;
using UnityEngine.UI;

public class ChildCardController : MonoBehaviour
{
    [SerializeField] private Image avatar;
    [SerializeField] private Text name;
    [SerializeField] private Text status;
    [SerializeField] private Button ButtonHide;
    [SerializeField] private Button ButtonDelete;

    public void Init(DataUsers data)
    {
        // avatar = data.avatar;
        name.text = data.name;
        switch (data.status)
        {
            case "0":
                status.text = "online";
                break;
            case "1":
                status.text = "offline";
                break;
        }

        ButtonDelete.GetComponentInChildren<Text>().text = data.id;
        ButtonHide.GetComponentInChildren<Text>().text = data.id;
    }
    
}
