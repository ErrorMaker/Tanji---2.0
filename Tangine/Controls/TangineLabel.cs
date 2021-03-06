﻿using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Tangine.Controls
{
    [DesignerCategory("Code")]
    public class TangineLabel : Control
    {
        private int _borderWidth = 1;
        [DefaultValue(1)]
        public int BorderWidth
        {
            get => _borderWidth;
            set
            {
                _borderWidth = value;
                Invalidate();
            }
        }

        private bool _isBorderVisible = true;
        [DefaultValue(true)]
        public bool IsBorderVisible
        {
            get => _isBorderVisible;
            set
            {
                _isBorderVisible = value;
                Invalidate();
            }
        }

        private Color _skin = Color.SteelBlue;
        [DefaultValue(typeof(Color), "SteelBlue")]
        public Color Skin
        {
            get => _skin;
            set
            {
                _skin = value;
                Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "White")]
        public override Color BackColor
        {
            get => base.BackColor;
            set => base.BackColor = value;
        }

        public override string Text
        {
            get => base.Text;
            set
            {
                base.Text = value;
                Invalidate();
            }
        }

        public TangineLabel()
        {
            SetStyle((ControlStyles)2050, true);
            BackColor = Color.White;
            DoubleBuffered = true;
            Height = 20;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            if (IsBorderVisible)
            {
                using (var brush = new SolidBrush(Skin))
                {
                    e.Graphics.FillRectangle(brush, 0, 0, BorderWidth, Height);
                    e.Graphics.FillRectangle(brush, Width - BorderWidth, 0, BorderWidth, Height);
                }
            }
            TextRenderer.DrawText(e.Graphics, Text, Font, ClientRectangle, ForeColor);
            base.OnPaint(e);
        }
    }
}