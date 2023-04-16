using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Player : Tile {
    float xVel = 0f;
    float yVel = 0f;
    float xAcc = 95f;
    float gravity = 60f;
    float friction = 0.8f;
    float airResistance = 0.95f;
    float jumpPower = 1500f;

    // Current level
    Level level;

    public Player() : base(Vector2.Zero, 36f)
    {

    }

    public void Initialize(Level level) {
        this.level = level;
        position = new Vector2(200f, 100f);
    }

    public void LoadContent(ContentManager Content) {
        texture = Content.Load<Texture2D>("player");
    }

    private bool CollidesWithGround()
    {
        foreach (Block block in level.blocks)
        {
            if (CollidesWith(block))
            {
                return true;
            }
        }

        return false;
    }

    private void HandleJump(KeyboardState kstate, float deltaTime)
    {
        position.Y += deltaTime;

        if (kstate.IsKeyDown(Keys.Up) && CollidesWithGround())
        {
            yVel = -jumpPower;
        }

        position.Y -= deltaTime;
    }

    public void Update(KeyboardState kstate, float deltaTime) {
        // Update X physics

        if (kstate.IsKeyDown(Keys.Left)) {
            xVel -= xAcc;
        }

        if(kstate.IsKeyDown(Keys.Right)) {
            xVel += xAcc;
        }

        xVel *= friction;
        position.X += xVel * deltaTime;

        // Update Y physics

        // HandleJump(kstate, deltaTime);

        position.Y += deltaTime;

        if (kstate.IsKeyDown(Keys.Up) && CollidesWithGround())
        {
            yVel = -jumpPower;
        }

        position.Y -= deltaTime;

        yVel += gravity;
        yVel *= airResistance;

        position.Y += yVel * deltaTime;

        if (CollidesWithGround())
        {
            // Check whether player hits floor or ceiling

            if (yVel < 0)
            {
                // Player is moving up so player hits ceiling
                // Move player down until player no longer hits ceiling
                while (CollidesWithGround())
                {
                    position.Y += deltaTime;
                }
            }
            else
            {
                // Player is moving down so player hits floor
                // Move player up until player no longer hits floor
                while (CollidesWithGround())
                {
                    position.Y -= deltaTime;
                }
            }

            yVel = 0;
        }
    }
}
