package crc641a62543037d9056a;


public class CollectionViewRenderer_EmptyViewHolder
	extends androidx.recyclerview.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Sharpnado.CollectionView.Droid.Renderers.CollectionViewRenderer+EmptyViewHolder, Sharpnado.CollectionView.Maui", CollectionViewRenderer_EmptyViewHolder.class, __md_methods);
	}


	public CollectionViewRenderer_EmptyViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == CollectionViewRenderer_EmptyViewHolder.class)
			mono.android.TypeManager.Activate ("Sharpnado.CollectionView.Droid.Renderers.CollectionViewRenderer+EmptyViewHolder, Sharpnado.CollectionView.Maui", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

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
