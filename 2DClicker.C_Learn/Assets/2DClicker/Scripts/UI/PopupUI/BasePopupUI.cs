using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePopupUI : BaseUI
{
    public virtual void Init<T>(T option) where T : PopupOption
    {
        Managers.UI.CreatePopup<BasePopupUI>();
    }

    public virtual void Close()
    {
        Managers.UI.ClosePopup();
    }
}
