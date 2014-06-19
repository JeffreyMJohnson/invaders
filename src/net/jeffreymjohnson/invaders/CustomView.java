package net.jeffreymjohnson.invaders;
import android.content.Context;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.view.View;

/**
 * 
 */

/**
 * @author Jeff
 *
 */
public class CustomView extends View {
	private Paint paint;
	
	public CustomView(Context context) {
		super(context);
		// TODO Auto-generated constructor stub
		paint = new Paint();
		paint.setColor(Color.RED);
	}
	
	@Override
	protected void onDraw(Canvas canvas) {
		// TODO Auto-generated method stub
		canvas.drawCircle(600, 250, 250, paint);
		super.onDraw(canvas);
	}

}
