package md5093f3f610c42b9c1e0cabd5fdce82f98;


public class SettingsFragment
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("PL.SettingsFragment, PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", SettingsFragment.class, __md_methods);
	}


	public SettingsFragment ()
	{
		super ();
		if (getClass () == SettingsFragment.class)
			mono.android.TypeManager.Activate ("PL.SettingsFragment, PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
