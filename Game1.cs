using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGames;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Point GameBounds = new Point(1280, 720); //window resolution

    private Texture2D _pixelTexture;
    private Vector2 _playerPosition;
    private readonly Point _playerSize = new Point(50, 50);
    private float _playerSpeed = 250f;
    // Start do jogo, pirmeiras variaveis
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";

        Window.Title = "My Game";

        _graphics.PreferredBackBufferWidth = GameBounds.X;
        _graphics.PreferredBackBufferHeight = GameBounds.Y;
        IsMouseVisible = true;
        _graphics.ApplyChanges();
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _pixelTexture = new Texture2D(GraphicsDevice, 1, 1);
        _pixelTexture.SetData(new[] { Color.White });
    }

    protected override void Update(GameTime gameTime)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        KeyboardState keyboard = Keyboard.GetState();

        if (keyboard.IsKeyDown(Keys.Escape))
            Exit();

        if (keyboard.IsKeyDown(Keys.Right) || keyboard.IsKeyDown(Keys.D))
            _playerPosition.X += _playerSpeed * deltaTime;

        if (keyboard.IsKeyDown(Keys.Left) || keyboard.IsKeyDown(Keys.A))
            _playerPosition.X -= _playerSpeed * deltaTime;

        if (keyboard.IsKeyDown(Keys.Up) || keyboard.IsKeyDown(Keys.W))
            _playerPosition.Y -= _playerSpeed * deltaTime;

        if (keyboard.IsKeyDown(Keys.Down) || keyboard.IsKeyDown(Keys.S))
            _playerPosition.Y += _playerSpeed * deltaTime;

        _playerPosition.X = MathHelper.Clamp(
            _playerPosition.X,
            0,
            _graphics.PreferredBackBufferWidth - _playerSize.X
        );

        _playerPosition.Y = MathHelper.Clamp(
            _playerPosition.Y,
            0,
            _graphics.PreferredBackBufferHeight - _playerSize.Y
        );
        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.Draw(
            _pixelTexture,
            new Rectangle(
                (int)_playerPosition.X,
                (int)_playerPosition.Y,
                _playerSize.X,
                _playerSize.Y
            ),
            Color.Red
        );
        _spriteBatch.End();
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
