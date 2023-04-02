using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonogamePlatformer;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Player player;
    private Level level;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        player = new Player();
        level = new Level();
    }

    protected override void Initialize()
    {
        player.Initialize();
        level.Initialize();
        base.Initialize();

        _graphics.PreferredBackBufferWidth = 540;
        _graphics.PreferredBackBufferHeight = 540;
        _graphics.ApplyChanges();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        player.LoadContent(Content);
        level.LoadContent(Content);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        var kstate = Keyboard.GetState();
        float deltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;

        player.Update(kstate, deltaTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        _spriteBatch.Begin();
        level.Draw(_spriteBatch);
        player.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
