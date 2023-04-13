using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class Block : Tile {
    public Block(Vector2 position, float width) : base(position, width)
    {

    }

    public void LoadContent(ContentManager Content) {
        texture = Content.Load<Texture2D>("ground");
    }
}
