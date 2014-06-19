package net.jeffreymjohnson.invaders;

import android.app.Activity;
import android.graphics.Color;
import android.os.Bundle;
import android.view.Menu;
import android.widget.FrameLayout;

public class MainActivity extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		FrameLayout parentLayout = (FrameLayout) findViewById(R.id.FrameLayout1);
		parentLayout.setBackgroundColor(Color.BLUE);
		CustomView myView = new CustomView(getApplicationContext());
		parentLayout.addView(myView);
//		Bitmap b = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
//		Canvas c = new Canvas(b);
		
		
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

}
