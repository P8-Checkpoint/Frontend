package crc64d8d1beb56979ea48;


public class ThumbFrameRenderer
	extends crc64124e178812aeed4c.FrameRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTouchEvent:(Landroid/view/MotionEvent;)Z:GetOnTouchEvent_Landroid_view_MotionEvent_Handler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.CommunityToolkit.UI.Views.ThumbFrameRenderer, Xamarin.CommunityToolkit.MauiCompat", ThumbFrameRenderer.class, __md_methods);
	}


	public ThumbFrameRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == ThumbFrameRenderer.class)
			mono.android.TypeManager.Activate ("Xamarin.CommunityToolkit.UI.Views.ThumbFrameRenderer, Xamarin.CommunityToolkit.MauiCompat", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public ThumbFrameRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == ThumbFrameRenderer.class)
			mono.android.TypeManager.Activate ("Xamarin.CommunityToolkit.UI.Views.ThumbFrameRenderer, Xamarin.CommunityToolkit.MauiCompat", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public ThumbFrameRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == ThumbFrameRenderer.class)
			mono.android.TypeManager.Activate ("Xamarin.CommunityToolkit.UI.Views.ThumbFrameRenderer, Xamarin.CommunityToolkit.MauiCompat", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public boolean onTouchEvent (android.view.MotionEvent p0)
	{
		return n_onTouchEvent (p0);
	}

	private native boolean n_onTouchEvent (android.view.MotionEvent p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
