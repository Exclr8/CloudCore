using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;

namespace ProcessViewer.Library.Common
{
    public class Palette
    {

        #region Fields

        private readonly Array _colorArr;
        private Random _random = new Random();
        private int _curInd;

        #endregion

        #region Properties

        public List<PaletteColor> ColorList { get; internal set; }

        #endregion

        #region methods

        public Palette(int randomSeed, int colorX, int colorY)
        {
            _random = new Random(randomSeed);
            ColorList = new List<PaletteColor>();

            Bitmap bmp;
            try
            {
                bmp = Properties.Resources.ColourPalette;
                _colorArr = Array.CreateInstance(typeof(Color), bmp.Height / colorX);

                var y = colorY;
                var ind = 0;
                while (y < bmp.Height)
                {
                    var clr = bmp.GetPixel(colorY, y);
                    y += colorX;

                    _colorArr.SetValue(clr, ind);
                    ind++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public PaletteColor AddColor(int parentId, string description)
        {
            var c = new PaletteColor();

            var cnt = (from u in ColorList where u.Pid == parentId select u.Pid).Count();
            if (cnt != 0)
            {
                c.Color = (from u in ColorList where u.Pid == parentId select u.Color).First();
            }
            else
            {

                c.Color = (Color)_colorArr.GetValue(_curInd);
                _curInd++;

                if (_curInd >= _colorArr.Length)
                {
                    _curInd = 0;
                }

                ColorList.Add(new PaletteColor
                                  {
                    Pid = parentId,
                    Color = c.Color,
                    Label = description

                });
            }

            return c;
        }

        #endregion
    }
}
