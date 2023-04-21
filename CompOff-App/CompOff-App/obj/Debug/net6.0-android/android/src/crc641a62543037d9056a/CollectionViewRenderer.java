package crc641a62543037d9056a;


public class CollectionViewRenderer
	extends crc64e1fb321c08285b90.ViewRenderer_2
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAttachedToWindow:()V:GetOnAttachedToWindowHandler\n" +
			"n_onLayout:(ZIIII)V:GetOnLayout_ZIIIIHandler\n" +
			"";
		mono.android.Runtime.register ("Sharpnado.CollectionView.Droid.Renderers.CollectionViewRenderer, Sharpnado.CollectionView.Maui", CollectionViewRenderer.class, __md_methods);
	}


	public CollectionViewRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == CollectionViewRenderer.class)
			mono.android.TypeManager.Activate ("Sharpnado.CollectionView.Droid.Renderers.CollectionViewRenderer, Sharpnado.CollectionView.Maui", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public CollectionViewRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == CollectionViewRenderer.class)
			mono.android.TypeManager.Activate ("Sharpnado.CollectionView.Droid.Renderers.CollectionViewRenderer, Sharpnado.CollectionView.Maui", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public CollectionViewRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == CollectionViewRenderer.class)
			mono.android.TypeManager.Activate ("Sharpnado.CollectionView.Droid.Renderers.CollectionViewRenderer, Sharpnado.CollectionView.Maui", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public CollectionViewRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == CollectionViewRenderer.class)
			mono.android.TypeManager.Activate ("Sharpnado.CollectionView.Droid.Renderers.CollectionViewRenderer, Sharpnado.CollectionView.Maui", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public void onAttachedToWindow ()
	{
		n_onAttachedToWindow ();
	}

	private native void n_onAttachedToWindow ();


	public void onLayout (boolean p0, int p1, int p2, int p3, int p4)
	{
		n_onLayout (p0, p1, p2, p3, p4);
	}

	private native void n_onLayout (boolean p0, int p1, int p2, int p3, int p4);

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
