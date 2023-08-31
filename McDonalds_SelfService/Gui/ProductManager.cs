using McDonalds_SelfService.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace McDonalds_SelfService.Gui
{
    internal class ProductManager : Screenmanager
    {
        private int _x;
        private int _y;
        private string _productName;
        private string _productPrice;
        private int _height;
        private int _width;
        private ConsoleColor _boxColor;

        #region Properties
        public int X
        {
            get
            {
                return this._x;
            }
            set
            {
                this._x = value;
            }
        }
        public string ProductName
        {
            get
            {
                return this._productName;
            }
            set
            {
                this._productName = value;
            }
        }
        public string ProductPrice
        {
            get
            {
                return this._productPrice;
            }
            set
            {
                this._productPrice = value;
            }
        }
        public ConsoleColor BoxColor
        {
            get
            {
                return this._boxColor;
            }
            set
            {
                this.BoxColor = value;
            }
        }
        #endregion

        /// <summary>
        /// Sets every single fields to the parameters which are given when creating the object
        /// </summary>
        /// <param name="x">positon of x</param>
        /// <param name="y">position of y</param>
        /// <param name="height">height of the box</param>
        /// <param name="width">width of the box</param>
        /// <param name="boxColor">color of the box</param>
        /// <param name="productName">name of the product</param>
        /// <param name="productPrice">price of the product</param>
        public ProductManager(int x, int y, int height, int width, ConsoleColor boxColor, string productName, string productPrice)
        {
            this._x = x;
            this._y = y;
            this._height = height;
            this._width = width;
            this._boxColor = boxColor;
            this._productName = productName;
            this._productPrice = productPrice;
        }

        /// <summary>
        /// Draws a product box, with text and a outline
        /// </summary>
        public void DrawProduct()
        {
            // Draws the outline of the product box at the correct position
            DrawBox(_x, _y, _height, _width, BoxColor);

            // Draws the text at correct positions inside the outline
            DrawText(_x + 2, _y + 2, "Produkt: " + _productName);
            DrawText(_x + 2, _y + 3, "Pris: " + _productPrice + " kroner");
        }
    }
}
