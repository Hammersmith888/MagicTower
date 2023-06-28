using System;
using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;


public class Purchaser : MonoSingleton<Purchaser>, IStoreListener
{
    [System.Serializable]
    private class PurchasedProductData
    {
        public string productID;
        public string receipt;
        public string transactionId;
        public SerializedToStringDateTime utsDate;
    }

    const string PURCHASED_PRODUCTS_DB_KEY = "PurchasedProductsData";

    private static IStoreController m_StoreController;          // The Unity Purchasing system.
    private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.

    public static string product_buy10000coins = "buy10000coins";
    public static string product_buy50000coins = "buy50000coins";
    public static string product_buy140000coins = "buy140000coins";
    public static string product_buy400000coins = "buy400000coins";
    public static string product_buy10ressurrect = "buy10ressurrect";
    public static string product_buy30ressurrect = "buy30ressurrect";
    public static string product_buy90ressurrect = "buy90ressurrect";
    public static string product_buy10mana = "buy10mana";
    public static string product_buy30mana = "buy30mana";
    public static string product_buy90mana = "buy90mana";
    public static string product_buy10health = "buy10health";
    public static string product_buy30health = "buy30health";
    public static string product_buy90health = "buy90health";
    public static string product_buy10power = "buy10power";
    public static string product_buy30power = "buy30power";
    public static string product_buy90power = "buy90power";
    public static string product_buyAction199 = "buy_action199";
    public static string product_buyAction499 = "buy_action499";
    public static string product_buyAction1399 = "buy_action1399";
    public static string product_buyVIP = "buydays3";
    public static string product_pyromaniac_robe = "pyromaniac_robe";
    public static string product_pyromaniac_stuff = "pyromaniac_stuff";
    public static string product_freezing_robe = "freezing_robe";
    public static string product_freezing_stuff = "freezing_stuff";
    public static string product_robe_of_geomency = "robe_of_geomency";
    public static string product_stuff_of_geomency = "stuff_of_geomency";
    public static string product_electrophoresis_robe = "electrophoresis_robe";
    public static string product_electrophoresis_stuff = "electrophoresis_stuff";
    public static string product_robe_of_luck = "robe_of_luck";
    public static string product_disable_ads = "remove_ads";
    public static string product_auto_pick = "auto_pick";

    private List<IAPPriceLocalizer> priceLocalizersList = new List<IAPPriceLocalizer>();
    private Dictionary<string, ProductPriceDate> productIDToLocalizedPrice = new Dictionary<string, ProductPriceDate>();

    List<string> idList = new List<string>();
    UIAction uiAction;

    Dictionary<string,ProductMetadata> iapPrice = new Dictionary<string, ProductMetadata>();

    #region Currency codes dictionary
    public static Dictionary<string, string> ISOCodeToCurrencyCodeMap = new Dictionary<string, string>()
    {
        {"AED", "د.إ.‏"}, {"AFN", "؋ "}, {"ALL", "Lek"}, {"AMD", "դր."},
        {"ARS", "$"}, {"AUD", "$"}, {"AZN", "man."}, {"BAM", "KM"}, {"BDT", "৳"}, {"BGN", "лв."},
        {"BHD", "د.ب.‏ "}, {"BND", "$"},
        {"BOB", "$b"},
        {"BRL", "R$"},
        {"BYR", "р."},
        {"BZD", "BZ$"},
        {"CAD", "$"},
        {"CHF", "fr."},
        {"CLP", "$"},
        {"CNY", "¥"},
        {"COP", "$"},
        {"CRC", "₡"},
        {"CSD", "Din."},
        {"CZK", "Kč"},
        {"DKK", "kr."},
        {"DOP", "RD$"},
        {"DZD", "DZD"},
        {"EEK", "kr"},
        {"EGP", "ج.م.‏ "},
        {"ETB", "ETB"},
        {"EUR", "€"},
        {"GBP", "£"},
        {"GEL", "Lari"},
        {"GTQ", "Q"},
        {"HKD", "HK$"},
        {"HNL", "L."},
        {"HRK", "kn"},
        {"HUF", "Ft"},
        {"IDR", "Rp"},
        {"ILS", "₪"},
        {"INR", "रु"},
        {"IQD", "د.ع.‏ "},
        {"IRR", "ريال "},
        {"ISK", "kr."},
        {"JMD", "J$"},
        {"JOD", "د.ا.‏ "},
        {"JPY", "¥"},
        {"KES", "S"},
        {"KGS", "сом"},
        {"KHR", "៛"},
        {"KRW", "₩"},
        {"KWD", "د.ك.‏ "},
        {"KZT", "Т"},
        {"LAK", "₭"},
        {"LBP", "ل.ل.‏ "},
        {"LKR", "රු."},
        {"LTL", "Lt"},
        {"LVL", "Ls"},
        {"LYD", "د.ل.‏ "},
        {"MAD", "د.م.‏ "},
        {"MKD", "ден."},
        {"MNT", "₮"},
        {"MOP", "MOP"},
        {"MVR", "ރ."},
        {"MXN", "$"},
        {"MYR", "RM"},
        {"NIO", "N"},
        {"NOK", "kr"},
        {"NPR", "रु"},
        {"NZD", "$"},
        {"OMR", "ر.ع.‏ "},
        {"PAB", "B/."},
        {"PEN", "S/."},
        {"PHP", "PhP"},
        {"PKR", "Rs"},
        {"PLN", "zł"},
        {"PYG", "Gs"},
        {"QAR", "ر.ق.‏ "},
        {"RON", "lei"},
        {"RSD", "Din."},
        {"RUB", "р."},
        {"RWF", "RWF"},
        {"SAR", "ر.س.‏ "},
        {"SEK", "kr"},
        {"SGD", "$"},
        {"SYP", "ل.س.‏ "},
        {"THB", "฿"},
        {"TJS", "т.р."},
        {"TMT", "m."},
        {"TND", "د.ت.‏ "},
        {"TRY", "TL"},
        {"TTD", "TT$"},
        {"TWD", "NT$"},
        {"UAH", "₴"},
        {"USD", "$"},
        {"UYU", "$U"},
        {"UZS", "so'm"},
        {"VEF", "Bs. F."},
        {"VND", "₫"},
        {"XOF", "XOF"},
        {"YER", "ر.ي.‏ "},
        {"ZAR", "R"},
        {"ZWL", "Z$"} };
    #endregion

    private class ProductPriceDate
    {
        public string price;
        public string currencyISOCode;
    }

    override protected void Awake()
    {
        if (s_Instance != null && s_Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        //DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // If we haven't set up the Unity Purchasing reference
        if (m_StoreController == null)
        {
            // Begin to configure our connection to Purchasing
            InitializePurchasing();
        }
    }

    public void InitializePurchasing()
    {
        // If we have already connected to Purchasing ...
        if (IsInitialized())
        {
            // ... we are done here.
            return;
        }

        // Create a builder, first passing in a suite of Unity provided stores.
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(product_buy10000coins, ProductType.Consumable);
        builder.AddProduct(product_buy50000coins, ProductType.Consumable);
        builder.AddProduct(product_buy140000coins, ProductType.Consumable);
        builder.AddProduct(product_buy400000coins, ProductType.Consumable);
        builder.AddProduct(product_buy10ressurrect, ProductType.Consumable);
        builder.AddProduct(product_buy30ressurrect, ProductType.Consumable);
        builder.AddProduct(product_buy90ressurrect, ProductType.Consumable);
        builder.AddProduct(product_buy10mana, ProductType.Consumable);
        builder.AddProduct(product_buy30mana, ProductType.Consumable);
        builder.AddProduct(product_buy90mana, ProductType.Consumable);
        builder.AddProduct(product_buy10health, ProductType.Consumable);
        builder.AddProduct(product_buy30health, ProductType.Consumable);
        builder.AddProduct(product_buy90health, ProductType.Consumable);
        builder.AddProduct(product_buy10power, ProductType.Consumable);
        builder.AddProduct(product_buy30power, ProductType.Consumable);
        builder.AddProduct(product_buy90power, ProductType.Consumable);
        builder.AddProduct(product_buyAction199, ProductType.Consumable);
        builder.AddProduct(product_buyAction499, ProductType.Consumable);
        builder.AddProduct(product_buyAction1399, ProductType.Consumable);
        builder.AddProduct(product_buyVIP, ProductType.Consumable);
        builder.AddProduct(product_pyromaniac_robe, ProductType.Consumable);
        builder.AddProduct(product_pyromaniac_stuff, ProductType.Consumable);
        builder.AddProduct(product_freezing_robe, ProductType.Consumable);
        builder.AddProduct(product_freezing_stuff, ProductType.Consumable);
        builder.AddProduct(product_robe_of_geomency, ProductType.Consumable);
        builder.AddProduct(product_stuff_of_geomency, ProductType.Consumable);
        builder.AddProduct(product_electrophoresis_robe, ProductType.Consumable);
        builder.AddProduct(product_electrophoresis_stuff, ProductType.Consumable);
        builder.AddProduct(product_robe_of_luck, ProductType.Consumable);
        builder.AddProduct(product_disable_ads, ProductType.NonConsumable);
        builder.AddProduct(product_auto_pick, ProductType.NonConsumable);

        foreach (var b in builder.products)
        {
            idList.Add(b.id);
        }

        UnityPurchasing.Initialize(this, builder);
    }

    private bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }

    public void AddPriceLocalizer(IAPPriceLocalizer priceLocalizer)
    {
        //Debug.Log( "AddPriceLocalizer: "+ priceLocalizer.productId );
        priceLocalizersList.Add(priceLocalizer);
        ProductPriceDate localizedPrice;
        if (productIDToLocalizedPrice.TryGetValue(priceLocalizer.productId, out localizedPrice))
        {
            //priceLocalizer.Localize( localizedPrice.price, localizedPrice.currencyISOCode );
            //priceLocalizer.Localize( localizedPrice.price, localizedPrice.currencyISOCode );
        }
    }

    public void RemovePriceLocalizer(IAPPriceLocalizer priceLocalizer)
    {
        priceLocalizersList.Remove(priceLocalizer);
    }

    public void RestorePurchases()
    {
        if (IsInitialized())
        {
            m_StoreExtensionProvider.GetExtension<IAppleExtensions>().RestoreTransactions(result =>
           {
               if (result)
               {
                   Debug.Log("RestorePurchases successful");
                   // This does not mean anything was restored,
                   // merely that the restoration process succeeded.
               }
               else
               {
                   Debug.Log("RestorePurchases error");
                   // Restoration failed.
               }
           });
        }
    }

    #region BUY_ACTIONS
    public void Buy10k()
    {
        BuyProductID(product_buy10000coins);
    }

    private static bool adsRemove = false;

    public void Buy10kWithRemoveAds()
    {
        adsRemove = true;
        BuyProductID(product_buy10000coins);
    }

    public void Buy50k()
    {
        BuyProductID(product_buy50000coins);
    }

    public void Buy140k()
    {
        BuyProductID(product_buy140000coins);
    }

    public void Buy400k()
    {
        BuyProductID(product_buy400000coins);
    }

    public void Buy10ressurrect()
    {
        BuyProductID(product_buy10ressurrect);
    }

    public void Buy30ressurrect()
    {
        BuyProductID(product_buy30ressurrect);
    }

    public void Buy90ressurrect()
    {
        BuyProductID(product_buy90ressurrect);
    }

    public void Buy10mana()
    {
        BuyProductID(product_buy10mana);
    }

    public void Buy30mana()
    {
        BuyProductID(product_buy30mana);
    }

    public void Buy90mana()
    {
        BuyProductID(product_buy90mana);
    }

    public void Buy10health()
    {
        BuyProductID(product_buy10health);
    }

    public void Buy30health()
    {
        BuyProductID(product_buy30health);
    }

    public void Buy90health()
    {
        BuyProductID(product_buy90health);
    }

    public void Buy10power()
    {
        BuyProductID(product_buy10power);
    }

    public void Buy30power()
    {
        BuyProductID(product_buy30power);
    }

    public void Buy90power()
    {
        BuyProductID(product_buy90power);
    }

    public void BuyAction199(UIAction uIAction)
    {
        BuyProductID(product_buyAction199);
    }

    public void BuyAction499(UIAction uIAction)
    {
        BuyProductID(product_buyAction499);
    }

    public void BuyAction1399(UIAction uIAction)
    {
        BuyProductID(product_buyAction1399);
    }

    public void BuyDays3()
    {
        BuyProductID(product_buyVIP);
    }

    public void BuyPyromaniacRobe()
    {
        BuyProductID(product_pyromaniac_robe);
    }

    public void BuyPyromaniacStuff()
    {
        BuyProductID(product_pyromaniac_stuff);
    }

    public void BuyFreezingRobe()
    {
        BuyProductID(product_freezing_robe);
    }

    public void BuyFreezingStuff()
    {
        BuyProductID(product_freezing_stuff);
    }

    public void BuyRobeOfGeomency()
    {
        BuyProductID(product_robe_of_geomency);
    }

    public void BuyStuffOfGeomency()
    {
        BuyProductID(product_stuff_of_geomency);
    }

    public void BuyElectrophoresisRobe()
    {
        BuyProductID(product_electrophoresis_robe);
    }

    public void BuyElectrophoresisStuffy()
    {
        BuyProductID(product_electrophoresis_stuff);
    }

    public void BuyRobeOfLuck()
    {
        BuyProductID(product_robe_of_luck);
    }

    public void BuyDisbaleAds()
    {
        BuyProductID(product_disable_ads);
    }

    public void BuyAutoPick()
    {
        BuyProductID(product_auto_pick);
    }


    #endregion

    void BuyProductID(string productId)
    {
        
        // If Purchasing has been initialized ...
        if (IsInitialized())
        {
            AnalyticsController.Instance.LogMyEvent("press_" + productId);
            // ... look up the Product reference with the general product identifier and the Purchasing 
            // system's products collection.
            Product product = m_StoreController.products.WithID(productId);

            // If the look up found a product for this device's store and that product is ready to be sold ... 
            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                // ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
                // asynchronously.
                m_StoreController.InitiatePurchase(product);
            }
            // Otherwise ...
            else
            {
                // ... report the product look-up failure situation  
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        // Otherwise ...
        else
        {
            // ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
            // retrying initiailization.
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }
    //  
    // --- IStoreListener
    //
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        // Purchasing has succeeded initializing. Collect our Purchasing references.

        // Overall Purchasing system, configured with products for this application.
        m_StoreController = controller;
        Debug.Log("====== PUrchase OnInitialized");
        // Store specific subsystem, for accessing device-specific store features.
        m_StoreExtensionProvider = extensions;
        int count = priceLocalizersList.Count;
        string productId;
        foreach (Product product in m_StoreController.products.all)
        {
            if(!iapPrice.ContainsKey(product.definition.id))
                iapPrice.Add(product.definition.id, product.metadata);
            if(String.IsNullOrEmpty(PlayerPrefs.GetString(product.definition.id)))
                PlayerPrefs.SetString(product.definition.id, product.metadata.localizedPriceString);
            try
            {
                productId = product.definition.id;

                if (!string.IsNullOrEmpty(product.transactionID) || !string.IsNullOrEmpty(product.receipt))
                {
                    Debug.LogFormat("Disabling ADS because IAP receipt or transaction detected for product {0}", product.metadata.localizedTitle);
                    ADs.AdsManager.OnNoAdsBought();
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError(e.Message);
            }
        }

        var keys = new List<string>(iapPrice.Keys);
    }

    public Tuple<decimal,string> GetPriceString(string key)
    {
        //Debug.Log($"----------------- COUNT ---------------: {iapPrice.Count}");
       
        if(iapPrice.ContainsKey(key))
        {
            PlayerPrefs.SetFloat("dec_" + key, (float)iapPrice[key].localizedPrice);
            PlayerPrefs.SetString("iso_" + key, iapPrice[key].isoCurrencyCode);
            return new Tuple<decimal, string>(iapPrice[key].localizedPrice, iapPrice[key].isoCurrencyCode);
        }

        if (!String.IsNullOrEmpty(PlayerPrefs.GetString(key)))
            return new Tuple<decimal, string>((decimal)PlayerPrefs.GetFloat("dec_" + key), PlayerPrefs.GetString("iso_" + key));
        return new Tuple<decimal, string>(0, "error");
    }

    //http://ninja-code.co.uk/how-to-return-currency-symbol-from-currency-code-using-c/
    /// Method used to return a currency symbol.  
    /// It receive as a parameter a currency code (3 digits).  
    /// </summary>  
    /// <param name="code">3 digits code. Samples GBP, BRL, USD, etc.</param>  
    public static string GetCurrencySymbol(string code)
    {
        string currencySymbol;
        if (ISOCodeToCurrencyCodeMap.TryGetValue(code, out currencySymbol))
        {
            return currencySymbol;
        }
        return code;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    private void Bought()
    {
        SaveManager.GameProgress.Current.disableAds = true;
        SaveManager.GameProgress.Current.Save();
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        AnalyticsController.Instance.LogMyEvent("Purchase", new Dictionary<string, string>() {
            { "id", args.purchasedProduct.definition.id },
        });

        Bought();

        SaveManager.Instance.OnPurchaseDone();
        if (String.Equals(args.purchasedProduct.definition.id, product_buy10000coins, StringComparison.Ordinal))
        {
            CoinsManager.AddCoinsST(10000, true);
            if (adsRemove)
                AdsPreview.instance.Bought();
            AnalyticsController.Instance.CurrencyAccrual(10000, DevToDev.AccrualType.Purchased);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, product_buy50000coins, StringComparison.Ordinal))
        {
            CoinsManager.AddCoinsST(50000, true);
            AnalyticsController.Instance.CurrencyAccrual(50000, DevToDev.AccrualType.Purchased);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, product_buy140000coins, StringComparison.Ordinal))
        {
            CoinsManager.AddCoinsST(140000, true);
            AnalyticsController.Instance.CurrencyAccrual(140000, DevToDev.AccrualType.Purchased);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, product_buy400000coins, StringComparison.Ordinal))
        {
            CoinsManager.AddCoinsST(400000, true);
            AnalyticsController.Instance.CurrencyAccrual(400000, DevToDev.AccrualType.Purchased);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, product_buyVIP, StringComparison.Ordinal))
        {
            VIP.BuyDays3();
            PopupWindow.Create(null, TextSheetLoader.GetStringST("t_0700"), TextSheetLoader.GetStringST("t_0701"));
        }
        else if (String.Equals(args.purchasedProduct.definition.id, product_auto_pick, StringComparison.Ordinal))
        {
            if(PPSerialization.Load<UIAutoHelpersWindow.SaveData>("auto_helper") != null)
                UIAutoHelpersWindow.saveData = PPSerialization.Load<UIAutoHelpersWindow.SaveData>("auto_helper");
            UIAutoHelpersWindow.saveData.auto_pick_purchase = "1";
            PPSerialization.Save<UIAutoHelpersWindow.SaveData>("auto_helper", UIAutoHelpersWindow.saveData);
            if (UIAutoHelpersWindow.instance != null)
                UIAutoHelpersWindow.instance.Bought();
        }

        if (uiAction == null)
            uiAction = GameObject.FindObjectOfType<UIAction>();

        while (uiAction == null)
            uiAction = GameObject.FindObjectOfType<UIAction>();

        var productID = args.purchasedProduct.definition.id;

        if (String.Equals(productID, product_buy10ressurrect, StringComparison.Ordinal))
        {
            uiAction.BuyFor10Res();
            PopupWindow.Create(null, TextSheetLoader.GetStringST("t_0702"), TextSheetLoader.GetStringST("t_0701"));
        }
        else if (String.Equals(productID, product_buy30ressurrect, StringComparison.Ordinal))
        {
            uiAction.BuyFor30Res();
            PopupWindow.Create(null, TextSheetLoader.GetStringST("t_0702"), TextSheetLoader.GetStringST("t_0701"));
        }
        else if (String.Equals(productID, product_buy90ressurrect, StringComparison.Ordinal))
        {
            uiAction.BuyFor90Res();
            PopupWindow.Create(null, TextSheetLoader.GetStringST("t_0702"), TextSheetLoader.GetStringST("t_0701"));
        }
        else if (String.Equals(productID, product_buy10mana, StringComparison.Ordinal))
        {
            uiAction.BuyFor10Mana();
            PopupWindow.Create(null, TextSheetLoader.GetStringST("t_0702"), TextSheetLoader.GetStringST("t_0701"));
        }
        else if (String.Equals(productID, product_buy30mana, StringComparison.Ordinal))
        {
            uiAction.BuyFor30Mana();
            PopupWindow.Create(null, TextSheetLoader.GetStringST("t_0702"), TextSheetLoader.GetStringST("t_0701"));
        }
        else if (String.Equals(productID, product_buy90mana, StringComparison.Ordinal))
        {
            uiAction.BuyFor90Mana();
            PopupWindow.Create(null, TextSheetLoader.GetStringST("t_0702"), TextSheetLoader.GetStringST("t_0701"));
        }
        else if (String.Equals(productID, product_buy10health, StringComparison.Ordinal))
        {
            uiAction.BuyFor10Health();
            PopupWindow.Create(null, TextSheetLoader.GetStringST("t_0702"), TextSheetLoader.GetStringST("t_0701"));
        }
        else if (String.Equals(productID, product_buy30health, StringComparison.Ordinal))
        {
            uiAction.BuyFor30Health();
            PopupWindow.Create(null, TextSheetLoader.GetStringST("t_0702"), TextSheetLoader.GetStringST("t_0701"));
        }
        else if (String.Equals(productID, product_buy90health, StringComparison.Ordinal))
        {
            uiAction.BuyFor90Health();
            PopupWindow.Create(null, TextSheetLoader.GetStringST("t_0702"), TextSheetLoader.GetStringST("t_0701"));
        }
        else if (String.Equals(productID, product_buy10power, StringComparison.Ordinal))
        {
            uiAction.BuyFor10Power();
            PopupWindow.Create(null, TextSheetLoader.GetStringST("t_0702"), TextSheetLoader.GetStringST("t_0701"));
        }
        else if (String.Equals(productID, product_buy30power, StringComparison.Ordinal))
        {
            uiAction.BuyFor30Power();
            PopupWindow.Create(null, TextSheetLoader.GetStringST("t_0702"), TextSheetLoader.GetStringST("t_0701"));
        }
        else if (String.Equals(productID, product_buy90power, StringComparison.Ordinal))
        {
            uiAction.BuyFor90Power();
            PopupWindow.Create(null, TextSheetLoader.GetStringST("t_0702"), TextSheetLoader.GetStringST("t_0701"));
        }
        else if (String.Equals(productID, product_buyAction199, StringComparison.Ordinal))
        {
            uiAction.BuyHotDeal(0);
            PopupWindow.Create(null, TextSheetLoader.GetStringST("t_0702"), TextSheetLoader.GetStringST("t_0701"));
        }
        else if (String.Equals(productID, product_buyAction499, StringComparison.Ordinal))
        {
            uiAction.BuyHotDeal(1);
            PopupWindow.Create(null, TextSheetLoader.GetStringST("t_0702"), TextSheetLoader.GetStringST("t_0701"));
        }
        else if (String.Equals(productID, product_buyAction1399, StringComparison.Ordinal))
        {
            uiAction.BuyHotDeal(2);
            PopupWindow.Create(null, TextSheetLoader.GetStringST("t_0702"), TextSheetLoader.GetStringST("t_0701"));
        }
        else if (String.Equals(productID, product_pyromaniac_robe, StringComparison.Ordinal))
        {
            uiAction.BuyWear_PyromaniacRobe();
        }
        else if (String.Equals(productID, product_pyromaniac_stuff, StringComparison.Ordinal))
        {
            uiAction.BuyWear_PyromaniacStuff();
        }
        else if (String.Equals(productID, product_freezing_robe, StringComparison.Ordinal))
        {
            uiAction.BuyWear_FreezingRobe();
        }
        else if (String.Equals(productID, product_freezing_stuff, StringComparison.Ordinal))
        {
            uiAction.BuyWear_FreezingStuff();
        }
        else if (String.Equals(productID, product_robe_of_geomency, StringComparison.Ordinal))
        {
            uiAction.BuyWear_RobeOfGeomency();
        }
        else if (String.Equals(productID, product_stuff_of_geomency, StringComparison.Ordinal))
        {
            uiAction.BuyWear_StuffOfGeomency();
        }
        else if (String.Equals(productID, product_electrophoresis_robe, StringComparison.Ordinal))
        {
            uiAction.BuyWear_ElectrophoresisRobe();
        }
        else if (String.Equals(productID, product_electrophoresis_stuff, StringComparison.Ordinal))
        {
            uiAction.BuyWear_ElectrophoresisStuffy();
        }
        else if (String.Equals(productID, product_robe_of_luck, StringComparison.Ordinal))
        {
            uiAction.BuyWear_RobeOfLuck();
        }
        else if (String.Equals(productID, product_disable_ads, StringComparison.Ordinal))
        {
            AdsPreview.instance.Bought();
            PopupWindow.Create(null, TextSheetLoader.GetStringST("t_0702"), TextSheetLoader.GetStringST("t_0701"));
        }

        AnalyticsController.Instance.RealPayment(args);
        // Return a flag indicating whether this product has completely been received, or if the application needs 
        // to be reminded of this purchase at next app launch. Use PurchaseProcessingResult.Pending when still 
        // saving purchased products to the cloud, and when that save is delayed. 
        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        // A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
        // this reason with the user to guide their troubleshooting actions.
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}