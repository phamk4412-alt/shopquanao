using System;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp2
{
    public class PanelHoverEffect
    {
        private Panel panel;
        private Size originalSize;
        private Point originalLocation;
        private Timer animationTimer;
        private float targetScale = 1.0f;
        private float currentScale = 1.0f;
        private float scaleRatio = 1.15f;
        private const float ANIMATION_SPEED = 0.08f; // T?c ?? animation (0.0-1.0)

        public PanelHoverEffect(Panel pnl, float scale = 1.15f)
        {
            panel = pnl;
            originalSize = panel.Size;
            originalLocation = panel.Location;
            scaleRatio = scale;

            // Kh?i t?o Timer
            animationTimer = new Timer();
            animationTimer.Interval = 15; // 15ms = smooth animation
            animationTimer.Tick += AnimationTimer_Tick;

            // G?n các event
            panel.MouseEnter += Panel_MouseEnter;
            panel.MouseLeave += Panel_MouseLeave;
            panel.Disposed += (s, e) => animationTimer?.Dispose();
        }

        private void Panel_MouseEnter(object sender, EventArgs e)
        {
            targetScale = scaleRatio;
            animationTimer.Start();
        }

        private void Panel_MouseLeave(object sender, EventArgs e)
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

            panel.Size = new Size(newWidth, newHeight);
            panel.Location = new Point(newX, newY);

            // Smooth border style transition
            if (currentScale > 1.05f) // Ch? thêm border khi phóng to ??
            {
                panel.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                panel.BorderStyle = BorderStyle.None;
            }
        }
    }
}
