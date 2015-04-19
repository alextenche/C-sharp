using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace RubberChicken
{
    /// <summary>
    /// A Rubber Chicken
    /// </summary>
    class RubberChicken
    {
        #region Fields

        bool active = true;
        int damage;

        // drawing and moving support
        Texture2D sprite;
        Rectangle drawRectangle;
        Vector2 velocity;

        #endregion

        #region Properties

        /// <summary>
        /// Gets and sets whether the rubber chicken is active
        /// </summary>
        /// <returns></returns>
        public bool Active
        {
            get { return active; }
            set { active = value;}
        }

        /// <summary>
        /// Gets the collision rectangle for the rubber chicken
        /// </summary>
        public Rectangle CollisionRectangle
        {
            get { return drawRectangle; }
        }

        /// <summary>
        /// Gets the damage the rubber chicken inflicts
        /// </summary>
        public int Damage
        {
            get { return damage; }
        }
        #endregion

        #region Contructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sprite">sprite</param>
        /// <param name="location">location of center</param>
        /// <param name="damage">damage from rubber chicken</param>
        public RubberChicken(Texture2D sprite, Vector2 location, int damage)
        {
            this.sprite = sprite;

            // build draw rectangle
            drawRectangle = new Rectangle((int)(location.X - sprite.Width / 2), (int)(location.Y - sprite.Height / 2), sprite.Width, sprite.Height);
            location = 
        }

        #endregion

    }
}
