using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIDailyRewardController : UI.UIWindowBase
{
	#region VARIABLES
	// Item для DailyReword
	[System.Serializable]
	public class DailyItem
	{
		public int lastClaimedItem;
		public SerializedToStringDateTime UnlockNextTime;
		public SerializedToStringDateTime ResetTime;

		override public string ToString( )
		{
			return string.Format( "LastClaimedItem: {0} UnlockNextTime: {1} ResetTime: {2} ", lastClaimedItem, UnlockNextTime, ResetTime );
		}
	}

	protected static UIDailyRewardController _current;
	public static UIDailyRewardController Current
	{
		get {
			if( _current == null )
			{
				_current = FindObjectOfType<UIDailyRewardController>();
			}
			return _current;
		}
	}

	private DateTime currentDate;

	[SerializeField]
	private Text nextTime;
	private string nextTimeString;
	[SerializeField]
	private GameObject claimBtn;

	[SerializeField]
	private GameObject [] smallItems;
	[SerializeField]
	private GameObject [] bigItems;

	private static bool RESET_FOR_TEST = false;
	public static bool SHOW_FOR_TEST = false;

	private DailyItem di;

	[SerializeField]
	private int curentUnlockedItem;

	public bool todayItemClamed;

	private TimeSpan ts;
	private bool startTimer;

	private readonly TimeSpan DAILY_REWARD_INTERVAL = new TimeSpan(TimeSpan.TicksPerDay);
	//private readonly TimeSpan DAILY_REWARD_INTERVAL = new TimeSpan( TimeSpan.TicksPerSecond * 5 );
	#endregion

	protected void Awake( )
	{
		_current = this;
		LoadOrInit();
		startTimer = false;
	}

	void Start( )
	{
		nextTimeString = nextTime.GetComponent<LocalTextLoc>().CurrentText;
	}

	override protected void OnEnable( )
	{
		base.OnEnable();
		currentDate = UnbiasedTime.Instance.Now();
		//переменная чтобы после получения подарка не показывать анимацию бэкграунда
		todayItemClamed = false;
		nextTimeString = nextTime.GetComponent<LocalTextLoc>().CurrentText;

		//Debug.LogFormat( "{0} {1} {2}", currentDate, di.UnlockNextTime, di.ResetTime );

		//Момент когда получена награда и идет таймер до следующей
		if( currentDate < di.UnlockNextTime )
		{
			UIDailyRewardController.ResetVideoLimits();
			SetupTimerLabel();
			todayItemClamed = true;

		}
		// Момент когда открывается награда за следующий день
		else if( currentDate < di.ResetTime )
		{
			curentUnlockedItem++;
			Debug.Log( "before ResetTime " + di.ResetTime );

		}
		// Момент когда еще не получено первой награды, или когда игрок не заходил в игру более 2 дней
		else //if (di.UnlockNextTime != new DateTime(0))
		{
			ResetDailies();
			Debug.Log("ResetDailies");
		}

		if( curentUnlockedItem > 5 )
			curentUnlockedItem = 1;
		claimBtn.SetActive( !todayItemClamed );
		DrawDailyItems();

		//SHOW_FOR_TEST = true;//для тестов

		if( SHOW_FOR_TEST )
			gameObject.SetActive( true );
		else
			gameObject.SetActive( !todayItemClamed );

		SHOW_FOR_TEST = false;
	}

	private void LoadOrInit( )
	{
		di = PPSerialization.Load<DailyItem>( "DailyReward" );
		if( RESET_FOR_TEST )
			di = null;

		if( di == null )
		{
			di = new DailyItem();
			ResetDailies();
		}
		curentUnlockedItem = di.lastClaimedItem;
		//Debug.LogFormat( "LoadOrInit {0}", di.ToString() );
	}

	private void ResetDailies( )
	{
		di.lastClaimedItem = curentUnlockedItem = 1;
		di.UnlockNextTime = new DateTime( 0 );
		di.ResetTime = new DateTime( 0 );
		SaveStatus();
	}

	public static void ResetVideoLimits( )
	{
		PlayerPrefs.SetInt( "VideoViewsLeft0", 3 );
		PlayerPrefs.SetInt( "VideoViewsLeft1", 3 );
		PlayerPrefs.SetInt( "VideoViewsLeft2", 3 );
		PlayerPrefs.Save();
	}

	private void DrawDailyItems( )
	{
		ShowSmallItems();
		ShowBigItems( false );

		for( int i = 0; i < smallItems.Length; i++ )
		{
			if( i != curentUnlockedItem - 1 )
				smallItems[ i ].GetComponentInChildren<Text>().color = new Color( 0.6f, 0.6f, 0.6f );
		}
		for( int i = 1; i < curentUnlockedItem; i++ )
		{
			smallItems[ i - 1 ].transform.Find( "icon" ).gameObject.SetActive( false );
			smallItems[ i - 1 ].transform.Find( "icon_dropped" ).gameObject.SetActive( true );
			DrawClamedItem( smallItems[ i - 1 ] );
		}

		smallItems[ curentUnlockedItem - 1 ].transform.Find( "icon" ).GetComponent<Animation>().enabled = true;

		if( todayItemClamed )
			DrawClamedItem( smallItems[ curentUnlockedItem - 1 ] );
		else
			DrawUnlockedItem( smallItems[ curentUnlockedItem - 1 ] );


		for( int i = curentUnlockedItem + 1; i <= 5; i++ )
		{
			DrawLockedItem( smallItems[ i - 1 ] );
		}
	}

	//изображаем награды которые получил игрок
	private void DrawClamedItem( GameObject item )
	{
		OffShineBackAndSetupAlphaChannel( item, 0.7f );
	}

	//изображаем награду которая доступна сегодня
	private void DrawUnlockedItem( GameObject item )
	{
		foreach( Transform ts in item.transform )
		{
			if( ts.name.EndsWith( "shine_back" ) )
			{
				ts.gameObject.SetActive( true );
			}
		}
	}

	//изображаем награды которые будут доступны в будущем
	private void DrawLockedItem( GameObject item )
	{
		OffShineBackAndSetupAlphaChannel( item, 0.5f );
	}

	private void OffShineBackAndSetupAlphaChannel( GameObject item, float alpha = 0.1f )
	{
		foreach( Transform ts in item.transform )
		{
			if( ts.name.EndsWith( "icon" ) )
			{
				ts.GetComponent<Image>().color = new Color( 1, 1, 1, alpha );
			}
			else if( ts.name.EndsWith( "shine_back" ) )
			{
				ts.gameObject.SetActive( false );
			}
		}
	}


	private void ClaimItem( )
	{
		if( curentUnlockedItem > 5 )
			curentUnlockedItem = 1;
		di.lastClaimedItem = curentUnlockedItem;
		DateTime tempTime = UnbiasedTime.Instance.Now() + DAILY_REWARD_INTERVAL;
		di.UnlockNextTime = tempTime;
		di.ResetTime = tempTime + DAILY_REWARD_INTERVAL;
		//di.UnlockNextTime = DateTime.Today + new TimeSpan( TimeSpan.TicksPerDay );
		//di.UnlockNextTime = UnbiasedTime.Instance.Now() + new TimeSpan (TimeSpan.TicksPerMinute);//for tests
		SaveStatus();

		SetupTimerLabel();

		switch( curentUnlockedItem )
		{
			case 1:
				GiveCoins( 500 );
				break;
			case 2:
				GiveCoins( 1000 );
				break;
			case 3:
				GiveCoins( 1500 );
				//GivePotions (false);
				break;
			case 4:
				GiveCoins( 2000 );
				break;
			case 5:
				GiveCoins( 2500 );
				//GivePotions (true);
				break;
		}
	}

	private void GiveCoins( int coins )
	{
		CoinsManager.AddCoinsST( coins );
		AnalyticsController.Instance.CurrencyAccrual( coins, DevToDev.AccrualType.Earned );
		SoundController.Instanse.PlayBuyCoinsSFX();
	}

	private void GivePotions( bool full )
	{
		Potion_Items potionItems = new Potion_Items( 4 );
		for( int i = 0; i < potionItems.Length; i++ )
			potionItems[ i ] = new PotionItem();

		potionItems = PPSerialization.Load<Potion_Items>( "Potions" );
		potionItems[ 0 ].count++;
		potionItems[ 1 ].count++;
		potionItems[ 2 ].count++;
		if( full )
			potionItems[ 3 ].count++;
		PPSerialization.Save( "Potions", potionItems, true, true);
		SoundController.Instanse.playUseBottle2SFX();
	}

	//не работает в паузе, но поскольку вся логика проверки в OnEnable, ето не столь важно, наверное)
	private void SetupTimerLabel( )
	{
		TimeSpan delta = di.UnlockNextTime - UnbiasedTime.Instance.Now();

		int hours = ( int ) delta.TotalHours;
		int mins = delta.Minutes;
		int seconds = delta.Seconds;
		nextTime.text = nextTimeString.Replace( "#", ( hours.ToString( "D2" ) + ":" + mins.ToString( "D2" ) + ":" + seconds.ToString( "D2" ) ) );
		//nextTime.text = "next in " + hours.ToString("D2") + ":" + mins.ToString("D2") + ":" + seconds.ToString("D2");

		ts = delta;
		startTimer = true;
		StartCoroutine( StartCountdown() );
	}

	private IEnumerator StartCountdown( )
	{
		while( startTimer )
		{
			yield return new WaitForSeconds( 1.0f );
			CountDownTimer();
		}
	}

	private void CountDownTimer( )
	{
		ts = di.UnlockNextTime - UnbiasedTime.Instance.Now();  //ts.Subtract( TimeSpan.FromSeconds( 1 ) );
		int hours = ( int ) ts.TotalHours;
		int mins = ts.Minutes;
		int seconds = ts.Seconds;
		nextTime.text = nextTimeString.Replace( "#", ( hours.ToString( "D2" ) + ":" + mins.ToString( "D2" ) + ":" + seconds.ToString( "D2" ) ) );
		//nextTime.text = "next in " + hours.ToString("D2") + ":" + mins.ToString("D2") + ":" + seconds.ToString("D2");
		if( ts <= new TimeSpan( 0 ) )
		{
			startTimer = false;
		}
	}

	private void SaveStatus( )
	{
		PPSerialization.Save( "DailyReward", di );
		//Debug.LogFormat( "SaveStatus Json: {0} /nToString: {1}", JsonUtility.ToJson( di ), di.ToString() );
	}

	private void ShowSmallItems( bool yes = true )
	{
		for( int i = 0; i < smallItems.Length; i++ )
		{
			smallItems[ i ].SetActive( yes );
		}
	}

	private void ShowBigItems( bool yes = true )
	{
		for( int i = 0; i < bigItems.Length; i++ )
		{
			bigItems[ i ].SetActive( false );
		}

		bigItems[ curentUnlockedItem - 1 ].SetActive( yes );
	}

	public void ClaimBtn( )
	{
		ShowBigItems();
		ShowSmallItems( false );
		todayItemClamed = true;
		claimBtn.SetActive( !todayItemClamed );
		ClaimItem();
	}

	override protected void OnCloseWithBackButton( )
	{
		if( !todayItemClamed )
		{
			ClaimItem();
		}
		if( destroyOnClose )
		{
			Destroy( gameObject );
		}
		else
		{
			gameObject.SetActive( false );
		}
	}
}
