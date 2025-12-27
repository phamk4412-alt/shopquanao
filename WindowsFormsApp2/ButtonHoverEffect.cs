using System;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp2
{
    public class ButtonHoverEffect
    {
        private Button button;
        private Size originalSize;
        private Point originalLocation;
        private Color originalColor;
        private Timer animationTimer;
        private float targetScale = 1.0f;
        private float currentScale = 1.0f;
        private float scaleRatio = 1.1f;
        private const float ANIMATION_SPEED = 0.08f; // T?c ?? animation (0.0-1.0)

        public ButtonHoverEffect(Button btn, float scale = 1.1f)
        {
            button = btn;
            originalSize = button.Size;
            originalLocation = button.Location;
            originalColor = button.BackColor;
            scaleRatio = scale;

            // Kh?i t?o Timer
            animationTimer = new Timer();
            animationTimer.Interval = 15; // 15ms = smooth animation (60fps)
            animationTimer.Tick += AnimationTimer_Tick;

            // G?n các event
            button.MouseEnter += Button_MouseEnter;
            button.MouseLeave += Button_MouseLeave;
            button.Disposed += (s, e) => animationTimer?.Dispose();
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            targetScale = scaleRatio;
            animationTimer.Start();
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            targetScale = 1.0f;
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            // Smooth interpolation (easing)
            currentScale += (targetScale - currentScale) * ANIMATION_SPEED;

            // N?u g?n ?? g?n target, d?ng animation
            if (Math.Abs(targetScale - currentScale) < 0.01f)
            {
                currentScale = targetScale;
                animationTimer.Stop();
            }

            // C?p nh?t kích th??c
            int newWidth = (int)(originalSize.Width * currentScale);
            int newHeight = (int)(originalSize.Height * currentScale);
            
            // Gi? v? trí tâm không thay ??i
            int centerX = originalLocation.X + originalSize.Width / 2;
            int centerY = originalLocation.Y + originalSize.Height / 2;
            
            int newX = centerX - newWidth / 2;
            int newY = centerY - newHeight / 2;

            button.Size = new Size(newWidth, newHeight);
            button.Location = new Point(newX, newY);

            // Thay ??i màu m??t mà (Smooth color transition)
            if (currentScale > 1.0f)
            {
                float colorRatio = (currentScale - 1.0f) / (scaleRatio - 1.0f);
                int rDiff = (int)(Math.Min(30, 30 * colorRatio));
                
                button.BackColor = Color.FromArgb(
                    Math.Min(255, originalColor.R + rDiff),
                    Math.Min(255, originalColor.G + rDiff),
                    Math.Min(255, originalColor.B + rDiff)
                );
            }
            else
            {
                button.BackColor = originalColor;
            }
        }
    }
}
