package crc64d8d1beb56979ea48;


public class DrawingViewRenderer
	extends crc6477f0d89a9cfd64b1.ViewRenderer_2
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onSizeChanged:(IIII)V:GetOnSizeChanged_IIIIHandler\n" +
			"n_onDraw:(Landroid/graphics/Canvas;)V:GetOnDraw_Landroid_graphics_Canvas_Handler\n" +
			"n_onTouchEvent:(Landroid/view/MotionEvent;)Z:GetOnTouchEvent_Landroid_view_MotionEvent_Handler\n" +
			"n_onInterceptTouchEvent:(Landroid/view/MotionEvent;)Z:GetOnInterceptTouchEvent_Landroid_view_MotionEvent_Handler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.CommunityToolkit.UI.Views.DrawingViewRenderer, Xamarin.CommunityToolkit.MauiCompat", DrawingViewRenderer.class, __md_methods);
	}


	public DrawingViewRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == DrawingViewRenderer.class)
			mono.android.TypeManager.Activate ("Xamarin.CommunityToolkit.UI.Views.DrawingViewRenderer, Xamarin.CommunityToolkit.MauiCompat", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public DrawingViewRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == DrawingViewRenderer.class)
			mono.android.TypeManager.Activate ("Xamarin.CommunityToolkit.UI.Views.DrawingViewRenderer, Xamarin.CommunityToolkit.MauiCompat", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public DrawingViewRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == DrawingViewRenderer.class)
			mono.android.TypeManager.Activate ("Xamarin.CommunityToolkit.UI.Views.DrawingViewRenderer, Xamarin.CommunityToolkit.MauiCompat", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public void onSizeChanged (int p0, int p1, int p2, int p3)
	{
		n_onSizeChanged (p0, p1, p2, p3);
	}

	private native void n_onSizeChanged (int p0, int p1, int p2, int p3);


	public void onDraw (android.graphics.Canvas p0)
	{
		n_onDraw (p0);
	}

	private native void n_onDraw (android.graphics.Canvas p0);


	public boolean onTouchEvent (android.view.MotionEvent p0)
	{
		return n_onTouchEvent (p0);
	}

	private native boolean n_onTouchEvent (android.view.MotionEvent p0);


	public boolean onInterceptTouchEvent (android.view.MotionEvent p0)
	{
		return n_onInterceptTouchEvent (p0);
	}

	private native boolean n_onInterceptTouchEvent (android.view.MotionEvent p0);

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
