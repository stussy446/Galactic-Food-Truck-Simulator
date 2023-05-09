using System;

public static class TranslateActions
{
    public static Action OnDialClicked;

    public static Action<TranslatorFunction> OnNewOrder;

    public static Action OnOrderSwitch;

    //Takes 2 int from customer (LanguageID, OrderID)
    public static Action<int, int> OnReceiveOrder;
}
