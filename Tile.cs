﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static System.Net.Mime.MediaTypeNames;

public class Tile
{
    protected Texture2D texture;
    protected Vector2 position;
    protected float width;

    public Tile(Vector2 position, float width)
    {
        this.position = position;
        this.width = width;
    }

    private float GetScaleFactor()
    {
        return width / Math.Max(texture.Width, texture.Height);
    }

    public bool CollidesWith(Tile other)
    {
        return !(
            position.X + width <= other.position.X ||
            other.position.X + other.width <= position.X ||
            position.Y + width <= other.position.Y ||
            other.position.Y + other.width <= position.Y
        );
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(
            texture,
            position,
            null,
            Color.White,
            0f,
            Vector2.Zero,
            Vector2.One * GetScaleFactor(),
            SpriteEffects.None,
            0f
        );
    }
}